using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentCarApp.BusinessLogic.Contracts;
using RentCarApp.BusinessLogic.Dto.Request;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        #region Private Members

        private readonly IUserService userService;
        private readonly IValidationError _validationError;
        private readonly IUnitOfWork _uow;
        

        #endregion

        #region Public Constructor

        public AuthController(IUserService userService,
            IValidationError validationErrors,
            IUnitOfWork uow
            )
        {
            this.userService = userService;
            _validationError = validationErrors;
            _uow = uow;
            
        }

        #endregion

        #region Public Methods



        //[AllowAnonymous]
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var token = await userService.SignInAsync(request);
            if (token == null)
                return BadRequest(_validationError.GetErrors());

            return Ok(new { token.Token });
        }

        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {

            var user = await userService.SignUpAsync(request);
            if (user == null)
                return BadRequest();


            if (_validationError.Any())
                return BadRequest(_validationError.GetErrors());



            return Ok("Usuario creado correctamente");
        }

       
        #endregion
    }
}
