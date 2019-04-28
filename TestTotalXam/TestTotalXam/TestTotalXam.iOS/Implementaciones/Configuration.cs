using SQLite;
using System;
using System.IO;
using TestTotalXam.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestTotalXam.iOS.Implementaciones.Configuracion))]
namespace TestTotalXam.iOS.Implementaciones
{
    public class Configuracion : IConfiguration
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            var path = Path.Combine(libFolder);
            var conn = new SQLite.SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            return conn;
        }
    }
}