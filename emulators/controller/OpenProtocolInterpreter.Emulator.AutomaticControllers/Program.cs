using LiteDB;

namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
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
            var database = new LiteDatabase("configuration.db");
            ApplicationConfiguration.Initialize();
            Application.Run(new ConfigurationForm(database));
        }
    }
}