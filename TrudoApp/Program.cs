using Microsoft.EntityFrameworkCore;
using TrucoData;
using System;

namespace TrudoApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string databasePath = System.IO.Path.Combine(appDataPath, "TrudoApp", "truco.db");

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(databasePath));

            var options = new DbContextOptionsBuilder<TrucoContext>()
                .UseSqlite($"Data Source={databasePath}")
                .Options;

            TrucoContext context = new TrucoContext(options);
            try
            {
                context.Database.Migrate();
                ApplicationConfiguration.Initialize();
                Application.Run(new TrucoForm(context));
            }
            finally
            {
                context.Dispose();
            }
        }

        
    }
}
