using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UniversalAITranslator.Utils
{
    public class TextLayer
    {
        public string Text { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int FontSize { get; set; } = 24;
        public string FontName { get; set; } = "ArialMT";
        public string Color { get; set; } = "000000";

        public bool StrokeEnabled { get; set; } = false;
        public int StrokeSize { get; set; } = 3;
        public string StrokeColor { get; set; } = "FFFFFF";
        public int StrokeOpacity { get; set; } = 100;
        public string StrokePosition { get; set; } = "outside";

        public string Justification { get; set; } = "center";
        public double? Leading { get; set; } = null;

        // НОВОЕ СВОЙСТВО
        public bool DrawOnAlpha { get; set; } = false;
    }

    public class RectangleLayer
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public string Color { get; set; } = "FFFFFF";

        public bool UseGradient { get; set; } = false;
        public string GradientStartColor { get; set; } = "FFFFFF";
        public string GradientEndColor { get; set; } = "000000";
        public double GradientAngle { get; set; } = -90.0;

        // НОВОЕ СВОЙСТВО
        public bool DrawOnAlpha { get; set; } = false;
    }

    public class ScriptGenerator
    {
        public static string GenerateJSX(string imagePath, List<TextLayer> textLayers, List<RectangleLayer> rectangleLayers, string outputJsxPath, bool saveBMP, bool savePSD)
        {
            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"Изображение не найдено: {imagePath}");
            }

            string jsxImagePath = imagePath.Replace("\\", "/");
            StringBuilder jsx = new StringBuilder();

            jsx.AppendLine("// Автоматически сгенерированный скрипт для Adobe Photoshop");
            jsx.AppendLine("// Дата создания: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            jsx.AppendLine();
            jsx.AppendLine("app.preferences.rulerUnits = Units.PIXELS;");
            jsx.AppendLine();

            jsx.AppendLine(@"function createTextLayer(doc, text, x, y, fontSize, fontName, hexColor, strokeEnabled, strokeSize, strokeColor, strokeOpacity, strokePosition, justification, leading) {
    var textLayer = doc.artLayers.add();
    textLayer.kind = LayerKind.TEXT;
    
    var textItem = textLayer.textItem;
    textItem.contents = text.replace(""\\n"",""\r"");
    textItem.size = fontSize;

    if (leading !== null && leading !== undefined) {
        textItem.useAutoLeading = false;
        textItem.leading = leading;
    } else {
        textItem.useAutoLeading = true;
    }
    
    switch(justification.toLowerCase()) {
        case 'left':
            textItem.justification = Justification.LEFT;
            break;
        case 'right':
            textItem.justification = Justification.RIGHT;
            break;
        case 'center':
        default:
            textItem.justification = Justification.CENTER;
            break;
    }
    
    textItem.position = [x, y];
    
    try {
        var fontFound = false;
        for (var i = 0; i < app.fonts.length; i++) {
            if (app.fonts[i].postScriptName == fontName || app.fonts[i].name == fontName) {
                textItem.font = app.fonts[i].postScriptName;
                fontFound = true; break;
            }
        }
        if (!fontFound) textItem.font = 'ArialMT';
    } catch(e) { textItem.font = 'ArialMT'; }
    
    hexColor = hexColor.replace('#', '');
    var color = new SolidColor();
    color.rgb.hexValue = hexColor;
    textItem.color = color;
    
    textLayer.name = text.substring(0, Math.min(text.length, 30));

    if (text !== '') {
        try {
            var bounds = textLayer.bounds; 
            var top = bounds[1].value;
            var bottom = bounds[3].value;
            var textCenterY = (top + bottom) / 2;
            var offsetY = y - textCenterY;
            if (offsetY !== 0) textLayer.translate(0, offsetY);
        } catch(e) {}
    }
    
    if (strokeEnabled) applyStroke(textLayer, strokeSize, strokeColor, strokeOpacity, strokePosition);
    
    return textLayer;
}

function createRectangleLayer(doc, x, y, width, height, hexColor, useGradient, gradStart, gradEnd, gradAngle, drawOnAlpha) {
    var rectLayer = doc.artLayers.add();
    rectLayer.kind = LayerKind.NORMAL;
    rectLayer.name = 'Rectangle Background';

    var shape = [ [x, y], [x + width, y], [x + width, y + height], [x, y + height] ];
    doc.selection.select(shape);

    hexColor = hexColor.replace('#', '');
    var fillColor = new SolidColor();
    fillColor.rgb.hexValue = hexColor;

    doc.selection.fill(fillColor);
    doc.selection.deselect();
    
    if (useGradient) {
        applyGradientOverlay(rectLayer, gradStart, gradEnd, gradAngle);
    }
    
    // ОПТИМИЗИРОВАННАЯ ЛОГИКА: Отрисовка черного прямоугольника на альфа канале
    if (drawOnAlpha && doc.channels.length > 3) {
        try {
            var alphaChannel = doc.channels[3];
            var origChannels = doc.activeChannels;
            doc.activeChannels = [alphaChannel];
            
            doc.selection.select(shape);
            var blackColor = new SolidColor();
            blackColor.rgb.hexValue = '000000';
            doc.selection.fill(blackColor);
            doc.selection.deselect();
            
            doc.activeChannels = origChannels;
        } catch(e) {}
    }
    
    return rectLayer;
}

// НОВАЯ ФУНКЦИЯ: Отрисовка текста на альфе (Смарт-объект -> Выделение -> Заливка на Альфе)
function processTextAlpha(doc, layer) {
    if (doc.channels.length <= 3) return;
    var alphaChannel = doc.channels[3]; // Динамически берем первый альфа-канал
    
    try {
        doc.activeLayer = layer;
        
        // 1. Превращаем в смарт-объект
        var idnewPlacedLayer = stringIDToTypeID('newPlacedLayer');
        executeAction(idnewPlacedLayer, undefined, DialogModes.NO);
        
        // 2. Выделяем пиксели слоя (аналог Ctrl + Click по иконке слоя)
        var desc = new ActionDescriptor();
        var ref = new ActionReference();
        ref.putProperty(charIDToTypeID('Chnl'), charIDToTypeID('fsel'));
        desc.putReference(charIDToTypeID('null'), ref);
        var ref2 = new ActionReference();
        ref2.putEnumerated(charIDToTypeID('Chnl'), charIDToTypeID('Chnl'), charIDToTypeID('Trsp'));
        desc.putReference(charIDToTypeID('T   '), ref2);
        executeAction(charIDToTypeID('setd'), desc, DialogModes.NO);
        
        // 3. Переходим на альфа-канал и заливаем черным цветом
        var origChannels = doc.activeChannels;
        doc.activeChannels = [alphaChannel];
        
        var whiteColor = new SolidColor();
        whiteColor.rgb.hexValue = 'FFFFFF';
        doc.selection.fill(whiteColor);
        doc.selection.deselect();
        
        doc.activeChannels = origChannels; // Возвращаем обратно RGB
    } catch(e) {}
}

function applyGradientOverlay(layer, hex1, hex2, angle) {
    app.activeDocument.activeLayer = layer;
    
    hex1 = hex1.replace('#', '');
    hex2 = hex2.replace('#', '');
    
    var r1 = parseInt(hex1.substring(0, 2), 16) || 0;
    var g1 = parseInt(hex1.substring(2, 4), 16) || 0;
    var b1 = parseInt(hex1.substring(4, 6), 16) || 0;
    
    var r2 = parseInt(hex2.substring(0, 2), 16) || 0;
    var g2 = parseInt(hex2.substring(2, 4), 16) || 0;
    var b2 = parseInt(hex2.substring(4, 6), 16) || 0;

    var idsetd = charIDToTypeID( 'setd' );
    var desc1 = new ActionDescriptor();
    var idnull = charIDToTypeID( 'null' );
    var ref1 = new ActionReference();
    var idPrpr = charIDToTypeID( 'Prpr' );
    var idLefx = charIDToTypeID( 'Lefx' );
    ref1.putProperty( idPrpr, idLefx );
    var idLyr = charIDToTypeID( 'Lyr ' );
    var idOrdn = charIDToTypeID( 'Ordn' );
    var idTrgt = charIDToTypeID( 'Trgt' );
    ref1.putEnumerated( idLyr, idOrdn, idTrgt );
    desc1.putReference( idnull, ref1 );
    
    var idT = charIDToTypeID( 'T   ' );
    var desc2 = new ActionDescriptor();
    var idScl = charIDToTypeID( 'Scl ' );
    var idPrc = charIDToTypeID( '#Prc' );
    desc2.putUnitDouble( idScl, idPrc, 100.0 );
    
    var idGrFl = charIDToTypeID( 'GrFl' );
    var desc3 = new ActionDescriptor();
    var idenab = charIDToTypeID( 'enab' );
    desc3.putBoolean( idenab, true );
    var idMd = charIDToTypeID( 'Md  ' );
    var idBlnM = charIDToTypeID( 'BlnM' );
    var idNrml = charIDToTypeID( 'Nrml' );
    desc3.putEnumerated( idMd, idBlnM, idNrml );
    var idOpct = charIDToTypeID( 'Opct' );
    desc3.putUnitDouble( idOpct, idPrc, 100.0 );
    
    var idGrad = charIDToTypeID( 'Grad' );
    var desc4 = new ActionDescriptor();
    var idNm = charIDToTypeID( 'Nm  ' );
    desc4.putString( idNm, 'Custom Gradient' );
    var idGrdF = charIDToTypeID( 'GrdF' );
    var idCstS = charIDToTypeID( 'CstS' );
    desc4.putEnumerated( idGrdF, idGrdF, idCstS );
    var idIntr = charIDToTypeID( 'Intr' );
    desc4.putDouble( idIntr, 4096.0 );
    
    var idClrs = charIDToTypeID( 'Clrs' );
    var list1 = new ActionList();
    
    var desc5 = new ActionDescriptor();
    var idType = charIDToTypeID( 'Type' );
    var idClry = charIDToTypeID( 'Clry' );
    var idUsrS = charIDToTypeID( 'UsrS' );
    desc5.putEnumerated( idType, idClry, idUsrS ); 
    var idLctn = charIDToTypeID( 'Lctn' );
    desc5.putInteger( idLctn, 0 );
    var idMdpn = charIDToTypeID( 'Mdpn' );
    desc5.putInteger( idMdpn, 50 );
    var idClr = charIDToTypeID( 'Clr ' );
    var desc6 = new ActionDescriptor();
    var idRd = charIDToTypeID( 'Rd  ' );
    desc6.putDouble( idRd, r1 );
    var idGrn = charIDToTypeID( 'Grn ' );
    desc6.putDouble( idGrn, g1 );
    var idBl = charIDToTypeID( 'Bl  ' );
    desc6.putDouble( idBl, b1 );
    var idRGBC = charIDToTypeID( 'RGBC' );
    desc5.putObject( idClr, idRGBC, desc6 );
    var idClrt = charIDToTypeID( 'Clrt' );
    list1.putObject( idClrt, desc5 );
    
    var desc7 = new ActionDescriptor();
    desc7.putEnumerated( idType, idClry, idUsrS ); 
    desc7.putInteger( idLctn, 4096 );
    desc7.putInteger( idMdpn, 50 );
    var desc8 = new ActionDescriptor();
    desc8.putDouble( idRd, r2 );
    desc8.putDouble( idGrn, g2 );
    desc8.putDouble( idBl, b2 );
    desc7.putObject( idClr, idRGBC, desc8 );
    list1.putObject( idClrt, desc7 );
    
    desc4.putList( idClrs, list1 );
    
    var idTrns = charIDToTypeID( 'Trns' );
    var list2 = new ActionList();
    
    var desc9 = new ActionDescriptor();
    desc9.putUnitDouble( idOpct, idPrc, 100.0 );
    desc9.putInteger( idLctn, 0 );
    desc9.putInteger( idMdpn, 50 );
    var idTrnS = charIDToTypeID( 'TrnS' );
    list2.putObject( idTrnS, desc9 );
    
    var desc10 = new ActionDescriptor();
    desc10.putUnitDouble( idOpct, idPrc, 100.0 );
    desc10.putInteger( idLctn, 4096 );
    desc10.putInteger( idMdpn, 50 );
    list2.putObject( idTrnS, desc10 );
    
    desc4.putList( idTrns, list2 );
    
    var idGrdn = charIDToTypeID( 'Grdn' );
    desc3.putObject( idGrad, idGrdn, desc4 );
    
    var idAngl = charIDToTypeID( 'Angl' );
    var idAng = charIDToTypeID( '#Ang' );
    desc3.putUnitDouble( idAngl, idAng, angle );
    
    var idGrdT = charIDToTypeID( 'GrdT' );
    var idLnr = charIDToTypeID( 'Lnr ' );
    desc3.putEnumerated( idType, idGrdT, idLnr );
    
    desc2.putObject( idGrFl, idGrFl, desc3 );
    desc1.putObject( idT, idLefx, desc2 );
    
    executeAction( idsetd, desc1, DialogModes.NO );
}

function applyStroke(layer, size, hexColor, opacity, position) {
    app.activeDocument.activeLayer = layer;
    
    hexColor = hexColor.replace('#', '');
    var r = parseInt(hexColor.substring(0, 2), 16) || 0;
    var g = parseInt(hexColor.substring(2, 4), 16) || 0;
    var b = parseInt(hexColor.substring(4, 6), 16) || 0;

    var strokeStyle;
    switch(position.toLowerCase()) {
        case 'inside': strokeStyle = 'InsF'; break;
        case 'center': strokeStyle = 'CtrF'; break;
        case 'outside': default: strokeStyle = 'OutF'; break;
    }
    
    try {
        var desc = new ActionDescriptor();
        var ref190 = new ActionReference();
        ref190.putProperty( charIDToTypeID( 'Prpr' ), charIDToTypeID( 'Lefx' ) );
        ref190.putEnumerated( charIDToTypeID( 'Lyr ' ), charIDToTypeID( 'Ordn' ), charIDToTypeID( 'Trgt' ) );
        desc.putReference( charIDToTypeID( 'null' ), ref190 );
        
        var fxDesc = new ActionDescriptor();
        fxDesc.putUnitDouble(charIDToTypeID('Scl '), charIDToTypeID('#Prc'), 100.0);
        
        var fxPropDesc = new ActionDescriptor();
        fxPropDesc.putBoolean( charIDToTypeID( 'enab' ), true );
        fxPropDesc.putBoolean( stringIDToTypeID( 'present' ), true );
        fxPropDesc.putBoolean( stringIDToTypeID( 'showInDialog' ), true );
        fxPropDesc.putEnumerated( charIDToTypeID( 'Styl' ), charIDToTypeID( 'FStl' ), charIDToTypeID( strokeStyle ) );
        fxPropDesc.putEnumerated(  charIDToTypeID( 'PntT' ),  charIDToTypeID( 'FrFl' ), charIDToTypeID( 'SClr' ) );
        fxPropDesc.putEnumerated( charIDToTypeID( 'Md  ' ), charIDToTypeID( 'BlnM' ), charIDToTypeID( 'Nrml' ) );
        fxPropDesc.putUnitDouble( charIDToTypeID( 'Opct' ), charIDToTypeID( '#Prc' ), opacity );
        fxPropDesc.putUnitDouble( charIDToTypeID( 'Sz  ' ), charIDToTypeID( '#Pxl') , size );
        
        var colorDesc = new ActionDescriptor();
        colorDesc.putDouble( charIDToTypeID( 'Rd  ' ), r);
        colorDesc.putDouble( charIDToTypeID( 'Grn ' ), g );
        colorDesc.putDouble( charIDToTypeID( 'Bl  ' ), b );
        
        fxPropDesc.putObject( charIDToTypeID( 'Clr ' ), charIDToTypeID( 'RGBC' ), colorDesc );
        fxDesc.putObject( charIDToTypeID( 'FrFX' ), charIDToTypeID( 'FrFX' ), fxPropDesc );
        desc.putObject( charIDToTypeID( 'T   ' ), charIDToTypeID( 'Lefx' ), fxDesc );
        
        executeAction( charIDToTypeID( 'setd' ), desc, DialogModes.NO );
    } catch(e) { }
}
");

            jsx.AppendLine("// Основной код");
            jsx.AppendLine("#target photoshop");
            jsx.AppendLine("try {");
            jsx.AppendLine($"    var imageFile = new File(\"{jsxImagePath}\");");
            jsx.AppendLine("    ");
            jsx.AppendLine("    if (!imageFile.exists) {");
            jsx.AppendLine("        alert('Файл изображения не найден: ' + imageFile.fsName);");
            jsx.AppendLine("    } else {");
            jsx.AppendLine("        var doc = app.open(imageFile);");
            jsx.AppendLine("        var textLayersForAlpha = []; // Массив для отложенной обработки текста на альфе");
            jsx.AppendLine("        ");

            if (rectangleLayers != null && rectangleLayers.Count > 0)
            {
                jsx.AppendLine("        // Создаем слои с прямоугольниками (подложки)");
                for (int i = 0; i < rectangleLayers.Count; i++)
                {
                    var rect = rectangleLayers[i];
                    jsx.AppendLine($"        createRectangleLayer(doc, " +
                        $"{rect.X.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{rect.Y.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{rect.Width.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{rect.Height.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"\"{rect.Color}\", " +
                        $"{rect.UseGradient.ToString().ToLower()}, " +
                        $"\"{rect.GradientStartColor}\", " +
                        $"\"{rect.GradientEndColor}\", " +
                        $"{rect.GradientAngle.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{rect.DrawOnAlpha.ToString().ToLower()});"); // Передача флага DrawOnAlpha
                }
                jsx.AppendLine("        ");
            }

            if (textLayers != null && textLayers.Count > 0)
            {
                jsx.AppendLine("        // Создаем текстовые слои (они будут поверх прямоугольников)");
                for (int i = 0; i < textLayers.Count; i++)
                {
                    var layer = textLayers[i];
                    string leadingValue = layer.Leading.HasValue ? layer.Leading.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) : "null";

                    jsx.AppendLine($"        var tLayer{i} = createTextLayer(doc, \"{EscapeJSString(layer.Text)}\", " +
                        $"{layer.X.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{layer.Y.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                        $"{layer.FontSize}, " +
                        $"\"{layer.FontName}\", " +
                        $"\"{layer.Color}\", " +
                        $"{layer.StrokeEnabled.ToString().ToLower()}, " +
                        $"{layer.StrokeSize}, " +
                        $"\"{layer.StrokeColor}\", " +
                        $"\"{layer.StrokeOpacity}\", " +
                        $"\"{layer.StrokePosition}\", " +
                        $"\"{layer.Justification}\", " +
                        $"{leadingValue});");

                    // Если текст нужно отрисовать в альфе, добавляем ссылку на слой в JS-массив
                    if (layer.DrawOnAlpha)
                    {
                        jsx.AppendLine($"        textLayersForAlpha.push(tLayer{i});");
                    }
                }
            }

            // ШАГ 1: Сохраняем исходный PSD
            if (savePSD)
            {
                string psdPath = Path.ChangeExtension(imagePath, ".psd").Replace("\\", "/");
                jsx.AppendLine("        ");
                jsx.AppendLine("        // Сохранение в формат PSD (до растеризации текста)");
                jsx.AppendLine($"        var psdFile = new File(\"{psdPath}\");");
                jsx.AppendLine("        var psdSaveOptions = new PhotoshopSaveOptions();");
                jsx.AppendLine("        psdSaveOptions.layers = true;");
                jsx.AppendLine("        psdSaveOptions.embedColorProfile = true;");
                jsx.AppendLine("        doc.saveAs(psdFile, psdSaveOptions, true, Extension.LOWERCASE);");
            }

            // ШАГ 2: Обработка альфа-канала для текста СТРОГО МЕЖДУ сохранениями PSD и BMP
            jsx.AppendLine("        ");
            jsx.AppendLine("        // Выполнение обработки текста для Альфа-канала (Превращение в смарт-объекты)");
            jsx.AppendLine("        if (textLayersForAlpha.length > 0) {");
            jsx.AppendLine("            for(var k = 0; k < textLayersForAlpha.length; k++) {");
            jsx.AppendLine("                processTextAlpha(doc, textLayersForAlpha[k]);");
            jsx.AppendLine("            }");
            jsx.AppendLine("        }");

            // ШАГ 3: Сохраняем BMP
            if (saveBMP)
            {
                string bmpPath = Path.ChangeExtension(imagePath, ".bmp").Replace("\\", "/");
                jsx.AppendLine("        ");
                jsx.AppendLine("        // Сохранение в формат BMP (с изменениями на альфа-канале)");
                jsx.AppendLine($"        var bmpFile = new File(\"{bmpPath}\");");
                jsx.AppendLine("        var bmpSaveOptions = new BMPSaveOptions();");
                jsx.AppendLine("        bmpSaveOptions.depth = BMPDepthType.THIRTYTWO;");
                jsx.AppendLine("        bmpSaveOptions.alphaChannels = true;");
                jsx.AppendLine("        bmpSaveOptions.osType = OperatingSystem.WINDOWS;");
                jsx.AppendLine("        doc.saveAs(bmpFile, bmpSaveOptions, true, Extension.LOWERCASE);");
            }

            jsx.AppendLine("        ");
            jsx.AppendLine("        // Закрываем документ без сохранения исходника (чтобы в оригинале слои остались текстом)");
            jsx.AppendLine("        doc.close(SaveOptions.DONOTSAVECHANGES);");
            jsx.AppendLine("    }");
            jsx.AppendLine("} catch (e) {");
            jsx.AppendLine("    alert('Ошибка: ' + e.message + '\\nСтрока: ' + e.line);");
            jsx.AppendLine("}");

            string jsxContent = jsx.ToString();
            File.WriteAllText(outputJsxPath, jsxContent, Encoding.UTF8);

            return jsxContent;
        }

        private static string EscapeJSString(string input)
        {
            return input
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }
    }
}