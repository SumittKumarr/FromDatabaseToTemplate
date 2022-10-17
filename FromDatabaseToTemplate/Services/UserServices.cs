using FromDatabaseToTemplate.DAL;
using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Extention.cs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FromDatabaseToTemplate.Services
{
    public class UserServices : IUserInterface
    {
        private readonly ApplicationDbContext context;
        public UserServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> GetByPolicyNoAndProductCode(string policyNumber, string productCode)
        {
            var userDetails = await context.Users
                .FirstOrDefaultAsync(t=>t.PolicyNumber == policyNumber && t.ProductCode == productCode);
            if (userDetails == null)
                throw new Exception("Enter valid policy number or product code");


            string code = "User Template";
            var userTemplate = await GetTemplate(code);
            var content = userTemplate.Content;


            var htmlContent = ExtentionMethods.MapUserTemplateWithUser(this, content, userDetails);


            return htmlContent;
        }


        private async Task<Template> GetTemplate(string code)
        {
            var userTemplate = await context.Templates.Where(t => t.Code == code).FirstAsync();
            return userTemplate;

        }
    }
}
