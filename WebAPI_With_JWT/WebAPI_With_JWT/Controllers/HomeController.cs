using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_With_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return Content(@" All the routes :
             - /users/login | POST
             - /users/register | POST
             - /users/{id}/update | PUT
             - /users/{id}/delete | DELETE
             - /users/all | GET
             - /users/{id} | GET
            ");
        }
    }
}
