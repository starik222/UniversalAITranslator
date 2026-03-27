using Translator;

namespace TranslatorApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Tools = new TextTool(Application.StartupPath);
            Application.Run(new Form1());
        }

        public static TextTool Tools { get; set; }
    }
}