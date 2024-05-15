using EmployeeApplicationForm.Domain.Models;


namespace EmplpyeeApplicationForm.Infrastructure.Interfaces
{
    public interface IPersonalInfoRepository
    {
        Task Add(PersonalInfo personalInfo);
        Task<PersonalInfo?> GetById(Guid PersonalInfoId);
        Task<bool> Delete(Guid PersonalInfoId);
    }
}
