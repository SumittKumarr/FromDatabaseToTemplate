using FromDatabaseToTemplate.DAL;
using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FromDatabaseToTemplate.Controllers
{


    [ApiController]
    [Route("api/user")]


    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IUserInterface _userInterface;

        public UserController(ApplicationDbContext context, IUserInterface userInterface)
        {
            _userInterface = userInterface;
            this.context = context;
        }

        [HttpGet]
        public async  Task<ActionResult<Template>> Get(string policyNumber, string productNumber)
        {
            string content;
          
            try
            {
               content = await _userInterface.GetByPolicyNoAndProductCode(policyNumber, productNumber);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            };
            
            return Ok(content);
        }



    }
}
