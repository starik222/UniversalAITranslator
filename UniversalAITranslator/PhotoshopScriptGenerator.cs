using System.Text;

namespace UniversalAITranslator.Utils
{
    // Класс для хранения данных о текстовом слое
    public class TextLayer
    {
        public string Text { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int FontSize { get; set; } = 24;
        public string FontName { get; set; } = "ArialMT";
        public string Color { get; set; } = "000000"; // HEX цвет текста

        // Параметры обводки
        public bool StrokeEnabled { get; set; } = false;
        public int StrokeSize { get; set; } = 3; // пиксели
        public string StrokeColor { get; set; } = "FFFFFF"; // HEX цвет обводки
        public int StrokeOpacity { get; set; } = 100; // Видимость
        public string StrokePosition { get; set; } = "outside"; // outside, inside, center

        // Выравнивание текста (left, center, right)
        public string Justification { get; set; } = "center";

        // Интерлиньяж (межстрочное расстояние). Если null — используется авто-интерлиньяж
        public double? Leading { get; set; } = null;
    }

    // НОВОЕ: Класс для прямоугольников (подложек)
    public class RectangleLayer
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Color { get; set; } = "FFFFFF"; // HEX цвет заливки
    }

    public class ScriptGenerator
    {
        // ОБНОВЛЕНО: добавлен параметр List<RectangleLayer> rectangleLayers
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
            jsx.AppendLine("app.preferences.rulerUnits = Units.PIXELS; // Гарантируем работу в пикселях");
            jsx.AppendLine();

            // Функция для создания текстового слоя
            jsx.AppendLine(@"function createTextLayer(doc, text, x, y, fontSize, fontName, hexColor, strokeEnabled, strokeSize, strokeColor, strokeOpacity, strokePosition, justification, leading) {
    var textLayer = doc.artLayers.add();
    textLayer.kind = LayerKind.TEXT;
    
    var textItem = textLayer.textItem;
    textItem.contents = text;
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
                fontFound = true;
                break;
            }
        }
        if (!fontFound) {
            textItem.font = 'ArialMT';
        }
    } catch(e) {
        textItem.font = 'ArialMT';
    }
    
    var color = new SolidColor();
    color.rgb.hexValue = hexColor;
    textItem.color = color;
    
    textLayer.name = text.substring(0, Math.min(text.length, 30));
    
    if (strokeEnabled) {
        applyStroke(textLayer, strokeSize, strokeColor, strokeOpacity, strokePosition);
    }
    
    return textLayer;
}

// НОВОЕ: Функция для создания прямоугольника
function createRectangleLayer(doc, x, y, width, height, hexColor) {
    var rectLayer = doc.artLayers.add();
    rectLayer.kind = LayerKind.NORMAL;
    rectLayer.name = 'Rectangle Background';

    // Создаем прямоугольное выделение
    var shape = [
        [x, y],
        [x + width, y],[x + width, y + height],
        [x, y + height]
    ];
    
    doc.selection.select(shape);

    // Конвертируем HEX цвет заливки
    var fillColor = new SolidColor();
    fillColor.rgb.hexValue = hexColor;

    // Выполняем заливку и снимаем выделение (без обводки по умолчанию)
    doc.selection.fill(fillColor);
    doc.selection.deselect();
    
    return rectLayer;
}

function applyStroke(layer, size, hexColor, opacity, position) {
    app.activeDocument.activeLayer = layer;
    
    var r = parseInt(hexColor.substring(0, 2), 16);
    var g = parseInt(hexColor.substring(2, 4), 16);
    var b = parseInt(hexColor.substring(4, 6), 16);

    var strokeStyle;
    switch(position.toLowerCase()) {
        case 'inside': strokeStyle = 'InsF'; break;
        case 'center': strokeStyle = 'CtrF'; break;
        case 'outside':
        default: strokeStyle = 'OutF'; break;
    }
    
    try {
        var desc = new ActionDescriptor();
        var ref190 = new ActionReference();
        ref190.putProperty( charIDToTypeID( 'Prpr' ), charIDToTypeID( 'Lefx' ) );
        ref190.putEnumerated( charIDToTypeID( 'Lyr ' ), charIDToTypeID( 'Ordn' ), charIDToTypeID( 'Trgt' ) );
        desc.putReference( charIDToTypeID( 'null' ), ref190 );
        var fxDesc = new ActionDescriptor();
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
        fxPropDesc.putBoolean( stringIDToTypeID( 'overprint' ), false );
        fxDesc.putObject( charIDToTypeID( 'FrFX' ), charIDToTypeID( 'FrFX' ), fxPropDesc );
        desc.putObject( charIDToTypeID( 'T   ' ), charIDToTypeID( 'Lefx' ), fxDesc );
        executeAction( charIDToTypeID( 'setd' ), desc, DialogModes.NO );
    } catch(e) {
        try {
            var desc = new ActionDescriptor();
            desc.putInteger(stringIDToTypeID('strokeSize'), size);
            desc.putString(stringIDToTypeID('strokeColor'), hexColor);
            executeAction(stringIDToTypeID('applyStroke'), desc, DialogModes.NO);
        } catch(e2) {}
    }
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
            jsx.AppendLine("        ");

            // НОВОЕ: СНАЧАЛА создаем прямоугольники (чтобы они оказались внизу, под текстом)
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
                        $"\"{rect.Color}\");");
                }
                jsx.AppendLine("        ");
            }

            // ЗАТЕМ создаем текстовые слои
            if (textLayers != null && textLayers.Count > 0)
            {
                jsx.AppendLine("        // Создаем текстовые слои (они будут поверх прямоугольников)");
                for (int i = 0; i < textLayers.Count; i++)
                {
                    var layer = textLayers[i];
                    string leadingValue = layer.Leading.HasValue ? layer.Leading.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) : "null";

                    jsx.AppendLine($"        createTextLayer(doc, \"{EscapeJSString(layer.Text)}\", " +
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
                }
            }

            // Логика сохранения
            if (savePSD)
            {
                string psdPath = Path.ChangeExtension(imagePath, ".psd").Replace("\\", "/");
                jsx.AppendLine("        ");
                jsx.AppendLine("        // Сохранение в формат PSD");
                jsx.AppendLine($"        var psdFile = new File(\"{psdPath}\");");
                jsx.AppendLine("        var psdSaveOptions = new PhotoshopSaveOptions();");
                jsx.AppendLine("        psdSaveOptions.layers = true;");
                jsx.AppendLine("        psdSaveOptions.embedColorProfile = true;");
                jsx.AppendLine("        doc.saveAs(psdFile, psdSaveOptions, true, Extension.LOWERCASE);");
            }

            if (saveBMP)
            {
                string bmpPath = Path.ChangeExtension(imagePath, ".bmp").Replace("\\", "/");
                jsx.AppendLine("        ");
                jsx.AppendLine("        // Сохранение в формат BMP");
                jsx.AppendLine($"        var bmpFile = new File(\"{bmpPath}\");");
                jsx.AppendLine("        var bmpSaveOptions = new BMPSaveOptions();");
                jsx.AppendLine("        bmpSaveOptions.depth = BMPDepthType.THIRTYTWO;");
                jsx.AppendLine("        bmpSaveOptions.alphaChannels = true;");
                jsx.AppendLine("        bmpSaveOptions.osType = OperatingSystem.WINDOWS;");
                jsx.AppendLine("        doc.saveAs(bmpFile, bmpSaveOptions, true, Extension.LOWERCASE);");
            }

            jsx.AppendLine("        ");
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