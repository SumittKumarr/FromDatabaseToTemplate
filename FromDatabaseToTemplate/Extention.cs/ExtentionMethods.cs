using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Services;
using System.Runtime.CompilerServices;

namespace FromDatabaseToTemplate.Extention.cs
{
    public static class ExtentionMethods
    {
        public static string MapUserTemplateWithUser(this UserServices user, string content, User userDetails )
        {
            string userString = userDetails.ToString();
            //for( int i = 0; i < userString.Length; i++ )
            {
               
            }
            content = content.Replace("{{Name}}", userDetails.Name);
            content = content.Replace("{{PolicyNumber}}", userDetails.PolicyNumber);
            content = content.Replace("{{PersonAge}}", userDetails.Age.ToString());
            content = content.Replace("{{PersonSalary}}", userDetails.Salary.ToString());
            content = content.Replace("{{PersonOccupation}}", userDetails.Occupation);
            content = content.Replace("{{PersonProductCode}}", userDetails.ProductCode);
            content = content.Replace("{{PersonTenure}}", userDetails.Tenure);
            content = content.Replace("{{PersonAPolicyExpiryDate}}", userDetails.PolicyExpiryDate.ToString());
            return content;
        }
    }
}
