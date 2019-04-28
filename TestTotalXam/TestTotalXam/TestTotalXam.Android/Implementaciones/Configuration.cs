using SQLite;
using System.IO;
using TestTotalXam.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(TestTotalXam.Droid.Implementaciones.Configuracion))]
namespace TestTotalXam.Droid.Implementaciones
{
    public class Configuracion : IConfiguration
    {
        public Configuracion() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "FloraNueva_Desarrollo.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            return conn;
        }
    }
}