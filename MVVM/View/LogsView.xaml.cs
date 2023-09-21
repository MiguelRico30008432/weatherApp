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

namespace WheaterApp.MVVM.View
{
    public partial class LogsView : UserControl
    {
        private dataBase db = new dataBase();
        public LogsView()
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
    }
}
