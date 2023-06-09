namespace AdventuresOf___
{
    internal static class Program
    {
        //Storing playerName into Program.CS so it can be refered to anywhere across the application
        public static string playerName = null;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Start());
        }
    }
}