using Microsoft.Extensions.Options;
using RentCarApp.BusinessLogic.Contracts;
using RentCarApp.BusinessLogic.Dto.Request;
using RentCarApp.BusinessLogic.Dto.Responses;
using RentCarApp.Common.ErrorHandling;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Configurations;
using RentCarApp.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentCarApp.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        #region Private Members

        private readonly AuthenticationSettings authenticationSettings;
        private readonly IUserRepository userRepository;
        private readonly IValidationError validationError;
        


        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository userRepository,IValidationError validationError,
            IOptions<AuthenticationSettings> authenticationSettings)
        {
            this.userRepository = userRepository;
            this.authenticationSettings = authenticationSettings.Value;
            this.validationError = validationError;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TokenResponse> SignInAsync(Guid tenantId, SignInRequest request, CancellationToken cancellationToken = default)
            => await SignIn(request, cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default)
            => await this.SignIn(request, cancellationToken);

        private async Task<TokenResponse> SignIn(SignInRequest request, CancellationToken cancellationToken)
        {
            bool response = await userRepository.AuthenticateAsync(request.Email, request.Password, cancellationToken);

            if (!response)
                return null;

            var user = await userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                validationError.Add("IncorrectLogin", "User or password is incorrect");

            if (validationError.Any())
                return null;

            return new TokenResponse { Token = "Login Correcto" };
        }

        public async Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default)
        {
            var user = new User { Email = request.Email, UserName = request.Email, Name = request.Name };
            var result = await userRepository.SignUpAsync(user, request.Password, cancellationToken);

            if (result.Errors.Any())
                validationError.Add(result.Errors.Select(x => (x.Code, x.Description)).ToList());

            return !result.Succeeded ? null : new UserResponse { Name = request.Name, Email = request.Email, Id = user.Id };
        }

        

        
    }
}
