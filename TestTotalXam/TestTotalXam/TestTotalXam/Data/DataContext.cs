using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTotalXam.Interfaces;
using TestTotalXam.Models;
using Xamarin.Forms;

namespace TestTotalXam.Data
{
    public class DataContext : IDisposable
    {
        public SQLiteConnection cnn;

        public DataContext()
        {
            cnn = DependencyService.Get<IConfiguration>().GetConnection();

            cnn.CreateTable<DetallePersonaModel>();
        }

        public void Dispose()
        {
            cnn.Dispose();
        }

        #region MetodosGenericosZulu
        public void Insert<T>(T model)
        {
            try
            {
                cnn.Insert(model);
                cnn.Dispose();
            }
            catch (Exception error)
            {
                Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Un error a ocurrido con la DB: " + error.Message.ToString(),
                    "Ok");
            }
        }

        public void Update<T>(T model)
        {
            try
            {
                cnn.Update(model);
                cnn.Dispose();
            }
            catch (Exception error)
            {
                Application.Current.MainPage.DisplayAlert(
                                    "Error",
                                    "Un error a ocurrido con la DB: " + error.Message.ToString(),
                                    "Ok");
            }
        }

        public void Delete<T>(T model)
        {
            try
            {
                cnn.Delete(model);
                cnn.Dispose();
            }
            catch (Exception error)
            {
                Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Un error a ocurrido con la DB: " + error.Message.ToString(),
                    "Ok");
            }
        }

        public List<T> GetList<T>() where T : new()
        {
            try
            {
                List<T> lista = cnn.Table<T>().ToList();
                cnn.Dispose();
                return lista;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
       
        public void DropAndCreate<T>()//Borra y crea una tabla
        {
            cnn.DropTable<T>();
            cnn.CreateTable<T>();
            cnn.Dispose();
        }

        public T UltimoAgregado<T>() where T : new()
        {
            return cnn.Table<T>().LastOrDefault();
        }
        #endregion
    }
}
