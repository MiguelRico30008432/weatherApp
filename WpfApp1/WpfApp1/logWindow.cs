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
			setUpDataOnUIElements();
        }

		private void setUpDataOnUIElements()
		{
            tb_apiCalls.Text = dataBase.apiCallsNumber.ToString();

            List<dataLogs> dataLogsGrid = db.getDataLogs();
            logsDataDatagrid.ItemsSource = dataLogsGrid;

            List<errorLogs> errorLogsGrid = db.getErrorLogs();
            logsErrorDatagrid.ItemsSource = errorLogsGrid;
        }

        private void bt_refresh_Click(object sender, RoutedEventArgs e)
        {
			setUpDataOnUIElements();
        }

        private void bt_close_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}