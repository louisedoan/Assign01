using System;
using System.Collections.Generic;

namespace BussinessObject
{
    /* public partial class CandidateProfile
     {
         public CandidateProfile()
         {
             InterviewSchedules = new HashSet<InterviewSchedule>();
         }


         public string CandidateId { get; set; } = null!;
         public string Fullname { get; set; } = null!;
         public DateTime? Birthday { get; set; }
         public string? ProfileShortDescription { get; set; }
         public string? ProfileUrl { get; set; }
         public string? PostingId { get; set; }

         public virtual JobPosting? Posting { get; set; }
         public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; }
     }*/
    public partial class CandidateProfile
    {
        // Không cần khởi tạo ngay lập tức trong constructor
        public CandidateProfile()
        {
        }

        public string CandidateId { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public string? ProfileShortDescription { get; set; }
        public string? ProfileUrl { get; set; }
        public string? PostingId { get; set; }

        public virtual JobPosting? Posting { get; set; }
        public virtual ICollection<InterviewSchedule> InterviewSchedules { get; set; }

        // Kiểm tra và khởi tạo khi cần thiết
        public ICollection<InterviewSchedule> GetInterviewSchedules()
        {
            if (InterviewSchedules == null)
            {
                InterviewSchedules = new HashSet<InterviewSchedule>();
            }
            return InterviewSchedules;
        }
    }

}
