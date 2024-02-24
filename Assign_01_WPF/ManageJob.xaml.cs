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
    /// Interaction logic for ManageJob.xaml
    /// </summary>
    public partial class ManageJob : Window
    {

        public IJobPostServicecs jobPostService;
        public ManageJob()
        {
            InitializeComponent();
          
            jobPostService = new JobPostService();
            dgvJob.ItemsSource = jobPostService.GetJobs();
           
        }

        private void dgvCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvJob.SelectedItem != null)
            {
                // Lấy hàng được chọn
                var selectedjob = (JobPosting)dgvJob.SelectedItem;

                // Điền dữ liệu từ hàng đã chọn vào các ô tương ứng trên giao diện người dùng
                txtJobId.Text = selectedjob.PostingId;
                txtJobTittle.Text = selectedjob.JobPostingTitle;
                dtDate.Text = selectedjob.PostedDate?.ToString(); // Kiểm tra null trước khi gán giá trị cho DatePicker
                txtDescription.Text = selectedjob.Description;
               
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobPosting job = new JobPosting();

                job.PostingId = txtJobId.Text.Trim();
                job.JobPostingTitle = txtJobTittle.Text.Trim();
                job.PostedDate = DateTime.Parse(dtDate.Text.Trim());
                job.Description = txtDescription.Text.Trim();


                jobPostService.AddJob(job);
                dgvJob.ItemsSource = jobPostService.GetJobs();


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

                if (txtJobId.Text.Trim().Length > 0)
                {

                    jobPostService.DeleteJob(txtJobId.Text.Trim());
                    dgvJob.ItemsSource = jobPostService.GetJobs();

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
                JobPosting job = jobPostService.GetById(txtJobId.Text);

                if (job != null)
                {


                    job.JobPostingTitle = txtJobTittle.Text.Trim();
                    job.PostedDate = DateTime.Parse(dtDate.Text.Trim());
                    job.Description = txtDescription.Text.Trim();

                    jobPostService.UpdateJob(job);

                    dgvJob.ItemsSource = jobPostService.GetJobs();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            

                string searchTerm = txtSearch.Text;
                List<JobPosting> searchResults = jobPostService.SearchJob(searchTerm);
                dgvJob.ItemsSource = searchResults;

            
        }
    }
}
