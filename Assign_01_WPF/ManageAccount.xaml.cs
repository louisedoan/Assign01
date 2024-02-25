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
    /// Interaction logic for ManageAccount.xaml
    /// </summary>
    public partial class ManageAccount : Window
    {
        public IHrAccountService accountService = null;
        public ManageAccount()
        {
            InitializeComponent();
            accountService = new HrAccountService();
            dgvAccount.ItemsSource = accountService.GetAccounts();
        }

        private void txtProfileShortDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }





       

           
            

            private void dgvCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (dgvAccount.SelectedItem != null)
                {
                   
                    var selectedjob = (Hraccount)dgvAccount.SelectedItem;
                                  
                    txtFullname.Text = selectedjob.FullName;
                    txtEmail.Text = selectedjob.Email;
                    txtPassword.Text = selectedjob.Password;
               // txtMemberRole= selectedjob.MemberRole;
                    txtMemberRole.Text = selectedjob.MemberRole.HasValue ? selectedjob.MemberRole.ToString() : string.Empty;

            }
        }

            private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Hraccount hraccount = new Hraccount();

                hraccount.Email = txtEmail.Text.Trim();
                hraccount.Password = txtPassword.Text.Trim();
                hraccount.FullName = txtFullname.Text.Trim();
                hraccount.MemberRole = int.Parse(txtMemberRole.Text.Trim());


                    accountService.AddAccount(hraccount);
                    dgvAccount.ItemsSource = accountService.GetAccounts();


                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {

                try
                {

                    if (txtEmail.Text.Trim().Length > 0)
                    {

                        accountService.DeleteAccount(txtEmail.Text.Trim());
                        dgvAccount.ItemsSource = accountService.GetAccounts();

                    }
                    else
                    {
                        // Hiển thị thông báo nếu không có mục nào được chọn
                        MessageBox.Show("error.");
                    }

                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Error: " + ex.Message);
                }




            }

            private void btnEdit_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Hraccount acc = accountService.GetById(txtEmail.Text);

                    if (acc != null)
                    {


                       acc.Email  = txtEmail.Text.Trim();
                    acc.FullName = txtFullname.Text.Trim();
                        acc.Password = txtPassword.Text.Trim();
                    acc.MemberRole = int.Parse(txtMemberRole.Text.Trim());

                    accountService.UpdateAccount(acc);

                        dgvAccount.ItemsSource = accountService.GetAccounts();
                    }
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            ChoosePage choosePage = new ChoosePage();
            choosePage.Show();
            this.Hide();
           
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            string searchTerm = txtSearch.Text;
            List<Hraccount> searchResults = accountService.SearchAccount(searchTerm);
            dgvAccount.ItemsSource = searchResults;
        }
    }

}


