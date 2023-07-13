using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace WpfApp1
{
	public partial class MainWindow : Window
	{
		private forecastAPI apiWeather = new forecastAPI();
		private List <LocationModel> l;
		private WeatherModel t;
		private Dictionary<string, string> backgroungPic = new Dictionary<string, string>() 
		{
			{"mostly_sunny", "cloudy.jpeg" },
			{"sunny", "cloudy.jpeg" },
			{"partly_sunny", "cloudy.jpeg" },
		};


		public MainWindow() 
		{
			InitializeComponent();
			resetUIElements();	
        }

		private void resetUIElements()
		{
	        myGrid.Background = null;
            comboBox.Items.Clear();
			comboBox.Visibility = System.Windows.Visibility.Hidden;
			lbl_selectRegion.Visibility = System.Windows.Visibility.Hidden;
			NextWeekDatagrid.Visibility = System.Windows.Visibility.Hidden;
            l = null;
			t = null;
			lbl_t_temp_v.Content = "";
			lbl_t_temp_max_v.Content = "";
			lbl_t_temp_min_v.Content = "";
			lbl_t_temp_sen_v.Content = "";
		}

		private void bt_getResults_Click(object sender, RoutedEventArgs e) 
		{
			resetUIElements();

			if (tb_search.Text == "") 
			{
				MessageBox.Show("Não foi introduzido nenhum valor na procura", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
			
			l = apiWeather.getLocationID(tb_search.Text);
			int countDistinct = (from x in l select x.name).Distinct().Count();

			if(countDistinct > 1 ) 
			{
				startProcessFromComboBox();
			}
			else if (countDistinct == 1) 
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
            lbl_selectRegion.Visibility = System.Windows.Visibility.Visible;
            comboBox.Visibility = System.Windows.Visibility.Visible;
			populateComboBox(l);
		}

	
		private void populateComboBox(List<LocationModel> location) 
		{
			var insert = true;
			foreach (LocationModel i in location) 
			{
				foreach (Object j in comboBox.Items) 
				{ 
					if (j.ToString() == i.name) 
					{
						insert = false;
						break;
					} 
				}
				if(insert == true) {comboBox.Items.Add(i.name);}
				insert = true;
			}
		}


		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) 
		{
			LocationModel selectedLocation = l.Where(f => f.name == comboBox.SelectedValue).FirstOrDefault();
			if (selectedLocation != null) { getForecast(selectedLocation.place_id); };
		}


		private void getForecast(string placeID) 
		{
			t = apiWeather.getForecast(placeID);
			changeBackground();
			populateLabels();
		}


		private void populateLabels() 
		{
			lbl_t_temp_v.Content = t.daily.data[0].temperature + "ºC";
			lbl_t_temp_max_v.Content = t.daily.data[0].temperature_max + "ºC";
			lbl_t_temp_min_v.Content = t.daily.data[0].temperature_min + "ºC";
			lbl_t_temp_sen_v.Content = t.daily.data[0].feels_like + "ºC";

			NextWeekDatagrid.Visibility = System.Windows.Visibility.Visible;

            List <dataGridModel> gridData = new List<dataGridModel>();
			for (int i = 1; i < t.daily.data.Count; i++)
			{
				gridData.Add(new dataGridModel{
					date = t.daily.data[i].day,
                    temp = t.daily.data[i].temperature,
                    tempMin = t.daily.data[i].temperature_min,
                    tempMax = t.daily.data[i].temperature_max,
                    feelsLike = t.daily.data[i].feels_like
                });
			}

            NextWeekDatagrid.ItemsSource = gridData;
		}

		private void changeBackground() 
		{		
			skyStatusPicture.ImageSource = new BitmapImage(new Uri(@"C:\Users\miguelrico\Desktop\weatherApp\WpfApp1\WpfApp1\Images\" + backgroungPic[t.daily.data[0].weather], UriKind.Relative));
			myGrid.Background = skyStatusPicture;
		}
	}
}