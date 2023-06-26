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
		private forecastAPI apiWeather;
		private WeatherModel t;


		public MainWindow() 
		{
			InitializeComponent();
		}

		private void bt_getResults_Click(object sender, RoutedEventArgs e) 
		{
			if (tb_search.Text == "") 
			{
				MessageBox.Show("Não foi introduzido nenhum valor na procura", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}

			tb_result.Text = "";

			apiWeather = new forecastAPI(tb_search.Text);

			//tb_result.Text = "Região: " + t.daily.data[0].feels_like + "\n " +
			//				"Temperatura: " + t.current.temp_c + "ºC \n " +
			//				"Sensação: " + t.current.feelslike_c + "ºC \n " +
			//				"Estado do Céu: " + t.current.condition.text;
		}
	}
}
