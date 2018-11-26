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
	public partial class ListarItems : ContentPage
	{
		public ListarItems (JArray arrData)
		{
			InitializeComponent ();
            var data = new List<Product>();
            for (int i = 0; i < arrData.Count; i++)
            {
                Product tmp = new Product
                {
                    nombre = arrData[i]["nombre"].ToString(),
                    precioMillar = arrData[i]["precioMillar"].ToString(),
                    imagen = "Http://area51.pe/sol/" + arrData[i]["imagen"]
                };
                data.Add(tmp);

            }
            list.ItemsSource = data;
        }
	}
}