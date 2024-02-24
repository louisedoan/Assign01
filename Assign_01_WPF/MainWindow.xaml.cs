using BussinessObject;
using Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assign_01_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHrAccountService memberService;
        public MainWindow()
        {
            InitializeComponent();
            memberService = new HrAccountService();
        }

    

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount member = memberService.GetManagementMember(txtUsername.Text.Trim());


            if (member != null && txtPassword.Text.Trim().Equals(member.Password))
            {


                switch (member.MemberRole)
                {
                    case 1:
                        /*ManageCandidate managementWindow = new ManageCandidate();
                        managementWindow.Show();
                        this.Hide()*/;


                        ChoosePage choosePage = new ChoosePage();   
                        choosePage.Show();
                        this.Hide();
                        break;
                    case 2:

                        ChoosePage choosePage2 = new ChoosePage();
                        choosePage2.Show();
                        this.Hide();
                        break;
                        
                    case 3:
                        ScheduldeList scheduldeList = new ScheduldeList();
                        scheduldeList.Show();
                        this.Hide();
                        break;
                    default:
                        MessageBox.Show("You are not permission!");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Please check username and password!");
            }

        }
    }
}