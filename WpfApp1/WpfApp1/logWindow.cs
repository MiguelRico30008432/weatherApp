using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WeatherApp.Model;

namespace WpfApp1
{
	public partial class logWindow : Window
	{
		private dataBase db = new dataBase();
	
		public logWindow() 
		{
			InitializeComponent();

			List<dataLogs> dataGrid = db.getDataLogs();
            logsDataDatagrid.ItemsSource = dataGrid;

			tb_apiCalls.Text = dataBase.apiCallsNumber.ToString();
        }

	       
    }
}