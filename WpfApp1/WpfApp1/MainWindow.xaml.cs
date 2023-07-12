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
		private List <LocationModel> l;
		private WeatherModel t;


		public MainWindow() 
		{
			InitializeComponent();
			clearElements();
        }

		private void clearElements()
		{
			comboBox.Items.Clear();
			comboBox.Visibility = System.Windows.Visibility.Hidden;
			l = null;
			t = null;
			lbl_t_temp_v.Content = "";
			lbl_t_temp_max_v.Content = "";
			lbl_t_temp_min_v.Content = "";
			lbl_t_temp_sen_v.Content = "";
		}

		private void bt_getResults_Click(object sender, RoutedEventArgs e) 
		{
			clearElements();

			if (tb_search.Text == "") 
			{
				MessageBox.Show("Não foi introduzido nenhum valor na procura", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
			
			l = apiWeather.getLocationID(tb_search.Text);

			if( l.Count > 1 ) 
			{
				startProcessFromComboBox();
			}
			else if (l.Count == 1) 
			{
				getForecast(l[0].place_id);
			}
			else 
			{
				MessageBox.Show("Não foi possível obter nenhuma região com o valor introduzido", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
		}

		private void startProcessFromComboBox() 
		{
			comboBox.Visibility = System.Windows.Visibility.Visible;
			populateComboBox(l);
		}

	

		private void populateComboBox(List<LocationModel> location) 
		{
			foreach (LocationModel i in location) 
			{
				//foreach (Object i in comboBox.Items) { if (i == model.adm_area1) { break; } }
				comboBox.Items.Add(i.adm_area1);
			}
		}


		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
		{
			LocationModel selectedLocation = l.Where(f => f.adm_area1 == comboBox.SelectedValue).FirstOrDefault();
			getForecast(selectedLocation.place_id);
		}


		private void getForecast(string placeID) 
		{
			t = apiWeather.getForecast(placeID);
			populateLabels();
		}


		private void populateLabels() 
		{
			lbl_t_temp_v.Content = t.daily.data[0].temperature + "ºC";
			lbl_t_temp_max_v.Content = t.daily.data[0].temperature_max + "ºC";
			lbl_t_temp_min_v.Content = t.daily.data[0].temperature_min + "ºC";
			lbl_t_temp_sen_v.Content = t.daily.data[0].feels_like + "ºC";
		}
	}
}
