using BussinessObject;
using Service;
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
using System.Windows.Shapes;

namespace Assign_01_WPF
{
    /// <summary>
    /// Interaction logic for ScheduldeList.xaml
    /// </summary>
    public partial class ScheduldeList : Window
    {

        public IScheduleService scheduleService = null;

        public ScheduldeList()
        {
            
            InitializeComponent();
            scheduleService = new SchedeuleService();
            dgvScheduleIist.ItemsSource = scheduleService.GetSchedules();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            string searchTerm = txtSearch.Text;
            List<InterviewSchedule> searchResults = scheduleService.SearchSchedule(searchTerm);
            dgvScheduleIist.ItemsSource = searchResults;
        }
    }
}
