using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.BusinessLogic.Dto.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class SignInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Dto for Request SignUp
    /// </summary>
    public class SignUpRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        
    }
}
