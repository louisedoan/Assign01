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
    /// Interaction logic for ManageCandidate.xaml
    /// </summary>
    public partial class ManageCandidate : Window
    {

        public ICandidateService candidateService ;
        public IJobPostServicecs jobPostServicec;

        public ManageCandidate()
        {
            InitializeComponent();
            candidateService = new CandidateService();
            jobPostServicec = new JobPostService();
            dgvCandidate.ItemsSource = candidateService.GetAllCandidate();
            cbPosting.ItemsSource = jobPostServicec.GetJobs();
            cbPosting.DisplayMemberPath = "JobPostingTitle";
            cbPosting.SelectedValuePath = "PostingId";

        }

       

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandidateProfile profile = new CandidateProfile();

                profile.CandidateId = txtCandidateID.Text.Trim();
                profile.Fullname = txtFullName.Text.Trim();
                profile.Birthday = DateTime.Parse(dtBirthday.Text.Trim());
                profile.ProfileShortDescription = txtProfileShortDescription.Text.Trim();
                profile.ProfileUrl = txtProfileURL.Text.Trim();

                // Lấy mục được chọn từ ComboBox
                var selectedJobPosting = cbPosting.SelectedItem as JobPosting;

                // Kiểm tra xem mục có được chọn không
                if (selectedJobPosting != null)
                {
                    // Gán PostingId từ mục được chọn
                    profile.PostingId = selectedJobPosting.PostingId.ToString();

                    // Thử thêm ứng viên mới
                    candidateService.AddCadidate(profile);
                }
                else
                {
                    // Hiển thị thông báo nếu không có mục nào được chọn
                    MessageBox.Show("Please select a job posting.");
                }
                dgvCandidate.ItemsSource = candidateService.GetAllCandidate();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvCandidate.SelectedItem != null)
            {
                // Lấy hàng được chọn
                var selectedCandidate = (CandidateProfile)dgvCandidate.SelectedItem;

                // Điền dữ liệu từ hàng đã chọn vào các ô tương ứng trên giao diện người dùng
                txtCandidateID.Text = selectedCandidate.CandidateId;
                txtFullName.Text = selectedCandidate.Fullname;
                dtBirthday.Text = selectedCandidate.Birthday.ToString();
                txtProfileShortDescription.Text = selectedCandidate.ProfileShortDescription;
                txtProfileURL.Text = selectedCandidate.ProfileUrl;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CandidateProfile profile = candidateService.GetById(txtCandidateID.Text);

                if (profile != null)
                {


                    profile.Fullname = txtFullName.Text.Trim();
                    profile.Birthday = DateTime.Parse(dtBirthday.Text.Trim());
                    profile.ProfileShortDescription = txtProfileShortDescription.Text.Trim();
                    profile.ProfileUrl = txtProfileURL.Text.Trim();

                    // Lấy mục được chọn từ ComboBox
                    var selectedJobPosting = cbPosting.SelectedItem as JobPosting;

                    // Kiểm tra xem mục có được chọn không
                    if (selectedJobPosting != null)
                    {
                        // Gán PostingId từ mục được chọn
                        profile.PostingId = selectedJobPosting.PostingId.ToString();

                        // Thử thêm ứng viên mới
                        candidateService.UpdateCandidate(profile);
                    }
                    else
                    {
                        // Hiển thị thông báo nếu không có mục nào được chọn
                        MessageBox.Show("Please select a job posting.");
                    }
                    dgvCandidate.ItemsSource = candidateService.GetAllCandidate();
                }
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

                if (txtCandidateID.Text.Trim().Length > 0)
                {

                    candidateService.DeleteCandidate(txtCandidateID.Text.Trim());
                    dgvCandidate.ItemsSource = candidateService.GetAllCandidate();

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

        /*        private void btnSearch_Click(object sender, RoutedEventArgs e)
                {
                    //ICandidateService candidate = new CandidateService();

                    List<CandidateProfile> filterModeLisst = new List<CandidateProfile>();



                    dgvCandidate.ItemsSource = search;




                    foreach (var item in CandidateProfile)
                    {

                    }
                        {

                            if (candidateService.SearchCandidate(txtSearch.Text.Trim()) != null)
                            {
                                filterModeLisst.Add(anim);
                            }
                        }

                }
        */


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

            string searchTerm = txtSearch.Text;
            List<CandidateProfile> searchResults = candidateService.SearchCandidatss(searchTerm);
            dgvCandidate.ItemsSource = searchResults;

        }
    }

}

