namespace Diplom_Maksim
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
            Zasttavka zasttavka = new Zasttavka();
            DateTime dateTime = DateTime.Now + TimeSpan.FromSeconds(5);
            zasttavka.Show();
            while (dateTime >  DateTime.Now) 
                Application.DoEvents();
            zasttavka.Close();
            zasttavka.Dispose();
            Application.Run(new FormMainMtnu());
        }
    }
}