using RentCarApp.BusinessLogic.Dto.Request;
using RentCarApp.BusinessLogic.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentCarApp.BusinessLogic.Contracts
{
    public interface IUserService
    {
        
        Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellationToken = default);
        Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken = default);
    }
}
