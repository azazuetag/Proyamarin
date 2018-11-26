using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace Json
{
    public partial class MainPage : ContentPage
    {
        JArray arrData;
        string sURL;
        public MainPage()
        {
            InitializeComponent();
            loadJSONAsync();
        }

        private async void loadJSONAsync()
        {
            var client = new  HttpClient()
            {
                //BaseAddress = new Uri("Http://area51.pe/sol/")
                BaseAddress = new Uri("https://newsapi.org/v2/")
            };
            
            string url = string.Format("top-headlines?language=es&apiKey=4da205d6f216424b86d00b317f89a991");
            var resp = await client.GetAsync(url);
            var result = resp.Content.ReadAsStringAsync().Result;
            JObject values = JObject.Parse(result);
            arrData = (JArray)values["articles"];
            fillData(arrData);
        }

        private void fillData(JArray arrData)
        {
          
            var data = new List<Noticia>();
            for (int i = 0; i < arrData.Count; i++)
            {
                Noticia tmp = new Noticia
                {
                    Titulo = arrData[i]["title"].ToString(),
                    Descripcion = arrData[i]["description"].ToString(),
                    URLNoticia = arrData[i]["url"].ToString(),
                    ImagenURL = arrData[i]["urlToImage"].ToString(),
                    contenido = arrData[i]["content"].ToString()
                };
                data.Add(tmp);
            }
            list.ItemsSource = data;
            list.ItemSelected += List_ItemSelected;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (e.SelectedItem == null) return;
            Noticia noticia = new Noticia();
            noticia.Titulo = (list.SelectedItem as Noticia).Titulo;
            noticia.Descripcion = (list.SelectedItem as Noticia).Descripcion;
            noticia.URLNoticia = (list.SelectedItem as Noticia).URLNoticia;
            noticia.ImagenURL = (list.SelectedItem as Noticia).ImagenURL;
            noticia.contenido = (list.SelectedItem as Noticia).contenido;

            Device.OpenUri(new Uri(noticia.URLNoticia));
            DesatteNoticia detalle = new DesatteNoticia(noticia.Titulo,noticia.Descripcion,noticia.ImagenURL, noticia.URLNoticia, noticia.contenido);
            
            Navigation.PushAsync(detalle);
        }

        private void Boton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
