using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	public partial class MainWindow : Window
	{
		private forecastAPI apiWeather = new forecastAPI();
		private WeatherModel t;


		public MainWindow() 
		{
			InitializeComponent();
			clearLabels();

        }

		private void clearLabels()
		{
			lbl_t_temp_v.Content = "";
			lbl_t_temp_max_v.Content = "";
			lbl_t_temp_min_v.Content = "";
			lbl_t_temp_sen_v.Content = "";
		}


		private void bt_getResults_Click(object sender, RoutedEventArgs e) 
		{
			if (tb_search.Text == "") 
			{
				MessageBox.Show("Não foi introduzido nenhum valor na procura", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			t = apiWeather.processRequestChain(tb_search.Text);

			lbl_t_temp_v.Content = t.daily.data[0].temperature + "ºC";
            lbl_t_temp_max_v.Content = t.daily.data[0].temperature_max + "ºC";
            lbl_t_temp_min_v.Content = t.daily.data[0].temperature_min + "ºC";
            lbl_t_temp_sen_v.Content = t.daily.data[0].feels_like + "ºC";


        }
	}
}
