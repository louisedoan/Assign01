using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICandidateRepo
    {
         List<CandidateProfile> GetAllCandidate();
        void AddCadidate(CandidateProfile candidate);

        CandidateProfile GetById(string id);
      //  void DeleteCandidate(CandidateProfile id);
        void DeleteCandidate(string id);
        void UpdateCandidate(CandidateProfile profile);

        public List<CandidateProfile> SearchCandidatss(string value);
     



    }
}
