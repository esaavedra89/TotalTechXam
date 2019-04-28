
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using TestTotalXam.Data;
using TestTotalXam.Models;
using Xamarin.Forms;

namespace TestTotalXam.ViewModels
{
    public class LoginViewModel
    {

        DataContext datacontext;

        public LoginViewModel()
        {
            datacontext = new DataContext();

            CargarDatos();
        }

        public async void CargarDatos()
        {
            try
            {
                var Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                HttpResponseMessage response2 = await Client.GetAsync(
                    "https://randomuser.me/api/?results=5");
                if (!response2.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response2.RequestMessage.ToString(),
                    "Aceptar");

                    return;
                }

                var resultado = response2.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(resultado))
                {
                    var resulta = JsonConvert.DeserializeObject<PersonasModel>(resultado);
                    foreach (var item in resulta.results)
                    {
                        DetallePersonaModel detalle = new DetallePersonaModel
                        {

                        };
                    }
                }
                //Link del video
                //https://www.loom.com/share/5b84eaa3722a414fac4624e4b36b41f1 
                //2:30 Min enviaré hasta aquí para enviarlo como se acordo. Detengo video
                //Igual terminaré esto en otra rama, en caso de interesarse por el contenido final
            }
            catch (Exception error)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ha ocurrido un error: " +error.Message.ToString(),
                    "Aceptar");

                return;
            }
        }
    }
}
