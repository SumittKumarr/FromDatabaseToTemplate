using FromDatabaseToTemplate.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FromDatabaseToTemplate.Services
{
    public interface IUserInterface
    {
        Task<string> GetByPolicyNoAndProductCode(string policyNumber, string productCode);
    }
}
