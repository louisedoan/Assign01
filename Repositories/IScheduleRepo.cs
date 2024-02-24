using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IScheduleRepo
    {
        public List<InterviewSchedule> GetSchedules();
        public void UpdateInterview(InterviewSchedule interview);
        public void DeleteInterview(string id);

        public void AddInterview(InterviewSchedule interview);
        public InterviewSchedule GetById(string id);


        public List<InterviewSchedule> SearchSchedule(string value);

    }
}
