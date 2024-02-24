using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SchedeuleService : IScheduleService
    {
        private IScheduleRepo scheduleRepo = null;

        public SchedeuleService()
        {
            scheduleRepo = new ScheduleRepo();
        }

        public void AddInterview(InterviewSchedule interview)
        {
            scheduleRepo.AddInterview(interview);
        }

        public void DeleteInterview(string id)
        {
            scheduleRepo.DeleteInterview(id);
        }

        public InterviewSchedule GetById(string id)
        {
           return scheduleRepo.GetById(id);
        }

        public List<InterviewSchedule> GetSchedules()
        {
            return scheduleRepo.GetSchedules();
        }

        public List<InterviewSchedule> SearchSchedule(string value)
        {
            return scheduleRepo.SearchSchedule(value);
        }
        

        public void UpdateInterview(InterviewSchedule interview)
        {
            scheduleRepo.UpdateInterview(interview);
        }
    }
}
