using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // НОВОЕ: Выравнивание текста (left, center, right)
        public string Justification { get; set; } = "center";
    }

    public class ScriptGenerator
    {
        public static string GenerateJSX(string imagePath, List<TextLayer> textLayers, string outputJsxPath)
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

            // Функция для создания текстового слоя с обводкой и выравниванием
            jsx.AppendLine(@"// Функция для создания текстового слоя
function createTextLayer(doc, text, x, y, fontSize, fontName, hexColor, strokeEnabled, strokeSize, strokeColor, strokeOpacity, strokePosition, justification) {
    var textLayer = doc.artLayers.add();
    textLayer.kind = LayerKind.TEXT;
    
    var textItem = textLayer.textItem;
    textItem.contents = text;
    textItem.size = fontSize;
    
    // Установка выравнивания текста
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
    
    // Установка позиции (для центрированного текста x будет центральной точкой)
    textItem.position = [x, y];
    
    // Установка шрифта с проверкой
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
    
    // Установка цвета текста
    var color = new SolidColor();
    color.rgb.hexValue = hexColor;
    textItem.color = color;
    
    textLayer.name = text.substring(0, Math.min(text.length, 30));
    
    // Применение обводки если включена
    if (strokeEnabled) {
        applyStroke(textLayer, strokeSize, strokeColor, strokeOpacity, strokePosition);
    }
    
    return textLayer;
}

// Функция для применения обводки к слою
function applyStroke(layer, size, hexColor, opacity, position) {
    // Делаем слой активным
    app.activeDocument.activeLayer = layer;
    
    // Конвертируем HEX в RGB
    var r = parseInt(hexColor.substring(0, 2), 16);
    var g = parseInt(hexColor.substring(2, 4), 16);
    var b = parseInt(hexColor.substring(4, 6), 16);

    var strokeStyle;
    switch(position.toLowerCase()) {
        case 'inside':
            strokeStyle = 'InsF'; // InsetFrame для внутренней обводки
            break;
        case 'center':
            strokeStyle = 'CtrF'; // CenteredFrame для центральной обводки
            break;
        case 'outside':
        default:
            strokeStyle = 'OutF'; // OutsetFrame для внешней обводки
            break;
    }
    
    try {
        // Создаем дескриптор для эффекта обводки
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
        // Альтернативный метод через Layer Style
        try {
            var desc = new ActionDescriptor();
            desc.putInteger(stringIDToTypeID('strokeSize'), size);
            desc.putString(stringIDToTypeID('strokeColor'), hexColor);
            executeAction(stringIDToTypeID('applyStroke'), desc, DialogModes.NO);
        } catch(e2) {
            // Игнорируем ошибку, если не удалось применить обводку
        }
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
            jsx.AppendLine("        // Создаем текстовые слои");

            // Добавляем каждый текстовый слой
            for (int i = 0; i < textLayers.Count; i++)
            {
                var layer = textLayers[i];
                jsx.AppendLine($"        createTextLayer(doc, \"{EscapeJSString(layer.Text)}\", " +
                    $"{layer.X.ToString().Replace(",", ".")}, " +
                    $"{layer.Y.ToString().Replace(",", ".")}, " +
                    $"{layer.FontSize}, " +
                    $"\"{layer.FontName}\", " +
                    $"\"{layer.Color}\", " +
                    $"{layer.StrokeEnabled.ToString().ToLower()}, " +
                    $"{layer.StrokeSize}, " +
                    $"\"{layer.StrokeColor}\", " +
                    $"\"{layer.StrokeOpacity}\", " +
                    $"\"{layer.StrokePosition}\", " +
                    $"\"{layer.Justification}\");");
            }

            jsx.AppendLine("        ");
            jsx.AppendLine("        alert('Скрипт успешно выполнен! Создано слоев: " + textLayers.Count + "');");
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

    //    // Класс для хранения данных о текстовом слое
    //    public class TextLayer
    //    {
    //        public string Text { get; set; }
    //        public double X { get; set; }
    //        public double Y { get; set; }
    //        public int FontSize { get; set; } = 24;
    //        public string FontName { get; set; } = "ArialMT";
    //        public string Color { get; set; } = "000000"; // HEX цвет текста

    //        // НОВОЕ: Параметры обводки
    //        public bool StrokeEnabled { get; set; } = false;
    //        public int StrokeSize { get; set; } = 3; // пиксели
    //        public string StrokeColor { get; set; } = "FFFFFF"; // HEX цвет обводки
    //        public string StrokePosition { get; set; } = "outside"; // outside, inside, center
    //    }

    //    public class ScriptGenerator
    //    {
    //        public static string GenerateJSX(string imagePath, List<TextLayer> textLayers, string outputJsxPath)
    //        {
    //            if (!File.Exists(imagePath))
    //            {
    //                throw new FileNotFoundException($"Изображение не найдено: {imagePath}");
    //            }

    //            string jsxImagePath = imagePath.Replace("\\", "/");
    //            StringBuilder jsx = new StringBuilder();

    //            jsx.AppendLine("// Автоматически сгенерированный скрипт для Adobe Photoshop");
    //            jsx.AppendLine("// Дата создания: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    //            jsx.AppendLine();

    //            // Функция для создания текстового слоя с обводкой
    //            jsx.AppendLine(@"// Функция для создания текстового слоя
    //function createTextLayer(doc, text, x, y, fontSize, fontName, hexColor, strokeEnabled, strokeSize, strokeColor, strokePosition) {
    //    var textLayer = doc.artLayers.add();
    //    textLayer.kind = LayerKind.TEXT;

    //    var textItem = textLayer.textItem;
    //    textItem.contents = text;
    //    textItem.position = [x, y];
    //    textItem.size = fontSize;

    //    // Установка шрифта с проверкой
    //    try {
    //        var fontFound = false;
    //        for (var i = 0; i < app.fonts.length; i++) {
    //            if (app.fonts[i].postScriptName == fontName || app.fonts[i].name == fontName) {
    //                textItem.font = app.fonts[i].postScriptName;
    //                fontFound = true;
    //                break;
    //            }
    //        }
    //        if (!fontFound) {
    //            textItem.font = 'ArialMT';
    //        }
    //    } catch(e) {
    //        textItem.font = 'ArialMT';
    //    }

    //    // Установка цвета текста
    //    var color = new SolidColor();
    //    color.rgb.hexValue = hexColor;
    //    textItem.color = color;

    //    textLayer.name = text.substring(0, Math.min(text.length, 30));

    //    // НОВОЕ: Применение обводки если включена
    //    if (strokeEnabled) {
    //        applyStroke(textLayer, strokeSize, strokeColor, strokePosition);
    //    }

    //    return textLayer;
    //}

    //// НОВАЯ функция для применения обводки к слою
    //function applyStroke(layer, size, hexColor, position) {
    //    // Делаем слой активным
    //    app.activeDocument.activeLayer = layer;

    //    // Конвертируем HEX в RGB
    //    var r = parseInt(hexColor.substring(0, 2), 16);
    //    var g = parseInt(hexColor.substring(2, 4), 16);
    //    var b = parseInt(hexColor.substring(4, 6), 16);

    //    // Определяем позицию обводки
    //    var strokeStyle;
    //    switch(position.toLowerCase()) {
    //        case 'inside':
    //            strokeStyle = 'InsF'; // insetFrame
    //            break;
    //        case 'center':
    //            strokeStyle = 'CtrF'; // centeredFrame
    //            break;
    //        case 'outside':
    //        default:
    //            strokeStyle = 'OutF'; // outsetFrame
    //            break;
    //    }

    //    try {
    //        // Создаем дескриптор для эффекта обводки
    //        var desc = new ActionDescriptor();
    //        var desc2 = new ActionDescriptor();
    //        var desc3 = new ActionDescriptor();
    //        var desc4 = new ActionDescriptor();
    //        var ref = new ActionReference();

    //        ref.putProperty(charIDToTypeID('Prpr'), charIDToTypeID('Lefx'));
    //        ref.putEnumerated(charIDToTypeID('Lyr '), charIDToTypeID('Ordn'), charIDToTypeID('Trgt'));
    //        desc.putReference(charIDToTypeID('null'), ref);

    //        // Настройки обводки
    //        desc3.putUnitDouble(charIDToTypeID('Sz  '), charIDToTypeID('#Pxl'), size);
    //        desc3.putEnumerated(charIDToTypeID('PntT'), charIDToTypeID('FrFl'), charIDToTypeID(strokeStyle));
    //        desc3.putEnumerated(charIDToTypeID('Md  '), charIDToTypeID('BlnM'), charIDToTypeID('Nrml'));
    //        desc3.putUnitDouble(charIDToTypeID('Opct'), charIDToTypeID('#Prc'), 100);

    //        // Цвет обводки
    //        desc4.putDouble(charIDToTypeID('Rd  '), r);
    //        desc4.putDouble(charIDToTypeID('Grn '), g);
    //        desc4.putDouble(charIDToTypeID('Bl  '), b);
    //        desc3.putObject(charIDToTypeID('Clr '), charIDToTypeID('RGBC'), desc4);

    //        desc3.putBoolean(charIDToTypeID('enab'), true);
    //        desc2.putObject(charIDToTypeID('FrFX'), charIDToTypeID('FrFX'), desc3);
    //        desc.putObject(charIDToTypeID('T   '), charIDToTypeID('Lefx'), desc2);

    //        executeAction(charIDToTypeID('setd'), desc, DialogModes.NO);
    //    } catch(e) {
    //        // Альтернативный метод через Layer Style
    //        try {
    //            var desc = new ActionDescriptor();
    //            desc.putInteger(stringIDToTypeID('strokeSize'), size);
    //            desc.putString(stringIDToTypeID('strokeColor'), hexColor);
    //            executeAction(stringIDToTypeID('applyStroke'), desc, DialogModes.NO);
    //        } catch(e2) {
    //            // Игнорируем ошибку, если не удалось применить обводку
    //        }
    //    }
    //}
    //");

    //            jsx.AppendLine("// Основной код");
    //            jsx.AppendLine("try {");
    //            jsx.AppendLine($"    var imageFile = new File(\"{jsxImagePath}\");");
    //            jsx.AppendLine("    ");
    //            jsx.AppendLine("    if (!imageFile.exists) {");
    //            jsx.AppendLine("        alert('Файл изображения не найден: ' + imageFile.fsName);");
    //            jsx.AppendLine("    } else {");
    //            jsx.AppendLine("        var doc = app.open(imageFile);");
    //            jsx.AppendLine("        ");
    //            jsx.AppendLine("        // Создаем текстовые слои");

    //            // Добавляем каждый текстовый слой
    //            for (int i = 0; i < textLayers.Count; i++)
    //            {
    //                var layer = textLayers[i];
    //                jsx.AppendLine($"        createTextLayer(doc, \"{EscapeJSString(layer.Text)}\", " +
    //                    $"{layer.X.ToString().Replace(",", ".")}, " +
    //                    $"{layer.Y.ToString().Replace(",", ".")}, " +
    //                    $"{layer.FontSize}, " +
    //                    $"\"{layer.FontName}\", " +
    //                    $"\"{layer.Color}\", " +
    //                    $"{layer.StrokeEnabled.ToString().ToLower()}, " +
    //                    $"{layer.StrokeSize}, " +
    //                    $"\"{layer.StrokeColor}\", " +
    //                    $"\"{layer.StrokePosition}\");");
    //            }

    //            jsx.AppendLine("        ");
    //            jsx.AppendLine("        alert('Скрипт успешно выполнен! Создано слоев: " + textLayers.Count + "');");
    //            jsx.AppendLine("    }");
    //            jsx.AppendLine("} catch (e) {");
    //            jsx.AppendLine("    alert('Ошибка: ' + e.message + '\\nСтрока: ' + e.line);");
    //            jsx.AppendLine("}");

    //            string jsxContent = jsx.ToString();
    //            File.WriteAllText(outputJsxPath, jsxContent, Encoding.UTF8);

    //            return jsxContent;
    //        }

    //        private static string EscapeJSString(string input)
    //        {
    //            return input
    //                .Replace("\\", "\\\\")
    //                .Replace("\"", "\\\"")
    //                .Replace("\n", "\\n")
    //                .Replace("\r", "\\r")
    //                .Replace("\t", "\\t");
    //        }
    //    }

}
