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
    /// Interaction logic for ChoosePage.xaml
    /// </summary>
    public partial class ChoosePage : Window
    {
        public ChoosePage()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManageSchedule scheduldes = new ManageSchedule();
            scheduldes.Show();
            this.Hide();
        }

        private void btnManageCandidate_Click(object sender, RoutedEventArgs e)
        {
            ManageCandidate managementWindow = new ManageCandidate();
            managementWindow.Show();
            this.Hide();
        }

        private void btnManageJob_Click(object sender, RoutedEventArgs e)
        {
            ManageJob managementWindow = new ManageJob();
            managementWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManageAccount managementWindow = new ManageAccount();
            managementWindow.Show();
            this.Hide();

        }
    }
}
