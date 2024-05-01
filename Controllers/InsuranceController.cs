using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : Controller
    {
      
        private readonly InsuranceContext _context;
        public InsuranceController(InsuranceContext context)
        {
            _context = context;
        }



       [HttpPost("login")]
     
        public async Task<IActionResult> Login([FromBody] insurance login)
        {
           
              var user = await _context.Insurances.FirstOrDefaultAsync(u => u.EmailId == login.EmailId && u.LoginPassword == login.LoginPassword);

              if (user != null)
              {


                  return Ok("success");

              }
              else
              {
                  return Unauthorized("failed");
              }
          
      }
   

        [HttpGet]
        public async Task<IEnumerable<insurance>> Getlogins()
        {
            return await _context.Insurances.ToListAsync();
        }
    
    }
}
