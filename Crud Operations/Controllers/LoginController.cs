using Crud_Operations.Data;
using Crud_Operations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Crud_Operations.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }



        [HttpPost]

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                string email = loginModel.email;
                string password = loginModel.password;
                JobSeekerSignupModel olduser = _context.SeekerSignup.Where(user1 => user1.JobSeekerEmailId == email).FirstOrDefault()!;

                if (olduser.JobSeekerEmailId == email && olduser != null)
                {
                    if (olduser.JobSeekerPassword == password)
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":true}");
                    }
                    else
                    {
                        return Ok("{\"emailstatus\":true,\"passwordstatus\":false}");
                    }
                }
            }
            catch (Exception ex)
            {
                return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");

            }
            return Ok("{\"emailstatus\":false,\"passwordstatus\":false}");


        }



        [HttpPost]
        public ActionResult FindEmail([FromBody] Finduser email)
        {
            var Email = _context.SeekerSignup.Where(s => s.JobSeekerEmailId == email.Email).FirstOrDefault();
            if (Email == null)
            {
                return Ok("Not the data");
            }
            else
            {
                return Ok(Email);
            }
        }


    }
}

