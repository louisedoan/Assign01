using System;
using System.Collections.Generic;

namespace BussinessObject
{
    /* public partial class JobPosting
     {
         public JobPosting()
         {
             CandidateProfiles = new HashSet<CandidateProfile>();
         }

         public string PostingId { get; set; } = null!;
         public string JobPostingTitle { get; set; } = null!;
         public string? Description { get; set; }
         public DateTime? PostedDate { get; set; }

         public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
     }*/

    public partial class JobPosting
    {
        public JobPosting()
        {
        }

        public string PostingId { get; set; } = null!;
        public string JobPostingTitle { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }

        // Kiểm tra và khởi tạo khi cần thiết
        public ICollection<CandidateProfile> GetCandidateProfiles()
        {
            if (CandidateProfiles == null)
            {
                CandidateProfiles = new HashSet<CandidateProfile>();
            }
            return CandidateProfiles;
        }
    }

}
