using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_With_JWT.Utils.Enums
{
    public class ErrorMessages
    {
        //// User
        
        //400
        public static string ERROR_400_BAD_NAME_OR_PASSWORD = "400 : Bad username or password";

        //401
        public static string ERROR_401_Unauthorized = "401 : Unauthorized";

        //500
        public static string ERROR_500_CREATE_USER_ERROR = "500 : An error appear while creating a new user";
        public static string ERROR_500_UPDATE_USER_ERROR = "500 : An error appear while updating a user";
    }
}
