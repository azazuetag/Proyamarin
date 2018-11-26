using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Json
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DesatteNoticia : ContentPage
	{

        public DesatteNoticia (string titulo, string descrip, string img, string URLNoti, string conte)
		{
			InitializeComponent ();
            var data = new List<Noticia>();
            Noticia tmp = new Noticia
                {
                    Titulo = titulo,
                    Descripcion = descrip,
                    ImagenURL = img,
                    URLNoticia = URLNoti,
                    contenido = conte
            };
                data.Add(tmp);
            list.ItemsSource = data;
        }
	}
}
