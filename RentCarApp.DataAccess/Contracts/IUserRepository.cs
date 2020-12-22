using Microsoft.AspNetCore.Identity;
using RentCarApp.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentCarApp.DataAccess.Contracts
{

    /// <summary>
    /// Interface of repository for User Domain
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Autenticate user Async
        /// </summary>
        /// <param name="email">Email of User</param>
        /// <param name="password">Password to validate</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation
        /// should be canceled.
        /// <returns></returns>
        Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sign Up user Async
        /// </summary>
        /// <param name="user">User to register</param>
        /// <param name="password">Password value to register</param>
        /// <param name="cancellationToken"></param>
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation
        /// should be canceled.
        /// <returns></returns>
        Task<IdentityResult> SignUpAsync(User user, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get User By Email
        /// </summary>
        /// <param name="requestEmail">Email request</param>
        /// <param name="cancellationToken"></param>
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation
        /// should be canceled.
        /// <returns></returns>
        Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken = default);
    }
}
