using EmployeeApplicationForm.Domain.Models;
using EmplpyeeApplicationForm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplpyeeApplicationForm.Infrastructure.Repository
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private readonly AppDbContext _appDbContext;

        public PersonalInfoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Add(PersonalInfo personalInfo)
        {
            _appDbContext.Add(personalInfo);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(Guid personalInfoId)
        {
            var personalinfo = await LoadPersonalInfoWithReferences(personalInfoId);

            if (personalinfo == null) return false;

            _appDbContext.PersonalInfos.Remove(personalinfo);

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PersonalInfo?> GetById(Guid personalInfoId)
        {
              var personalInfo = await LoadPersonalInfoWithReferences(personalInfoId);
            return personalInfo;
        }

        private async Task<PersonalInfo?> LoadPersonalInfoWithReferences(Guid PersonalInfoId)
        {
            var personalInfo = await _appDbContext
                .PersonalInfos
                .FindAsync(PersonalInfoId);
            if (personalInfo == null) return null;

            var personalInfoEntry = _appDbContext.PersonalInfos.Entry(personalInfo);

            
            await personalInfoEntry
                .Collection(question => question.Questions)
                .LoadAsync();

            // Include the Suppliers (which come from another container)
            await personalInfoEntry
                .Reference(programInfo => programInfo.Questions)
                .LoadAsync();

            return personalInfo;
        }

       
    }
}
