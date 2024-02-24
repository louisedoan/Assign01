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
    /// Interaction logic for ManageSchedule.xaml
    /// </summary>
    public partial class ManageSchedule : Window
    {
        public IScheduleService scheduleService = null;
        public ManageSchedule()
        {
            InitializeComponent();
            scheduleService = new SchedeuleService();
            dgvSchedule.ItemsSource = scheduleService.GetSchedules();
        }

        private void dgvCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvSchedule.SelectedItem != null)
            {
                // Lấy hàng được chọn
                var selectedjob = (InterviewSchedule)dgvSchedule.SelectedItem;

                // Điền dữ liệu từ hàng đã chọn vào các ô tương ứng trên giao diện người dùng
                txtInterviewId.Text = selectedjob.InterviewId;
                txtCandidateId.Text = selectedjob.CandidateId;
                dtInterviewDate.Text = selectedjob.InterviewDate.ToString(); // Kiểm tra null trước khi gán giá trị cho DatePicker
                txtLocation.Text = selectedjob.InterviewLocation;
                txtInterviewer.Text = selectedjob.Interviewer;

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InterviewSchedule interview = new InterviewSchedule();

                interview.InterviewId = txtInterviewId.Text.Trim();
                interview.CandidateId = txtCandidateId.Text.Trim();
                interview.InterviewDate = DateTime.Parse(dtInterviewDate.Text.Trim());
                interview.InterviewLocation = txtLocation.Text.Trim();
                interview.Interviewer = txtInterviewer.Text.Trim();


               scheduleService.AddInterview(interview);
                dgvSchedule.ItemsSource = scheduleService.GetSchedules();


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

                if (txtInterviewId.Text.Trim().Length > 0)
                {

                    scheduleService.DeleteInterview(txtInterviewId.Text.Trim());
                    dgvSchedule.ItemsSource = scheduleService.GetSchedules();

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
                InterviewSchedule interview = scheduleService.GetById(txtInterviewId.Text);

                if (interview != null)
                {


                    interview.CandidateId = txtCandidateId.Text.Trim();
                    interview.InterviewDate = DateTime.Parse(dtInterviewDate.Text.Trim());
                    interview.InterviewLocation = txtLocation.Text.Trim();
                    interview.Interviewer = txtInterviewer.Text.Trim();

                    scheduleService.UpdateInterview(interview);

                    dgvSchedule.ItemsSource = scheduleService.GetSchedules();
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
                List<InterviewSchedule> searchResults = scheduleService.SearchSchedule(searchTerm);
                dgvSchedule.ItemsSource = searchResults;

        }
    }
}
