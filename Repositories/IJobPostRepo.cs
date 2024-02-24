using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IJobPostRepo
    {
        List<JobPosting> GetJobs();
        public JobPosting GetById(string id);
        public void AddJob(JobPosting jobPosting);
        public void DeleteJob(string id);

        public void UpdateJob(JobPosting job);

        public List<JobPosting> SearchJob(string value);

    }
}
