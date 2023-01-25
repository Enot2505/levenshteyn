using System;
using System.IO;
using System.Windows.Forms;

namespace КурсоваяОП
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            string currentDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (!File.Exists($"{currentDirectoryPath}\\dataBase.db"))
            {
                new Database("Data Source=dataBase.db;Version=3;").InitializeDatabase();
            }
            Application.Run(new Main());
        }
    }
}
