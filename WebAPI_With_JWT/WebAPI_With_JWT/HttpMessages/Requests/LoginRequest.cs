using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_With_JWT.HttpMessages.Requests
{
    public class LoginRequest
    {
        [Required]
        public string UsernameOrEmail { get; set; }


        [Required]
        public string Password { get; set; }

    }
}
