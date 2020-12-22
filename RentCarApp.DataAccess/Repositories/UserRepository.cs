using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentCarApp.DataAccess.Contracts;
using RentCarApp.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentCarApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        #region Private Members

        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        #endregion

        #region Public Constructor

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc/>
        public async Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, false, false);

            return result.Succeeded;
        }

        /// <inheritdoc/>
        public async Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken = default)
        => await userManager.Users.FirstOrDefaultAsync(u => u.Email == requestEmail, cancellationToken);


        /// <inheritdoc/>
        public async Task<IdentityResult> SignUpAsync(User user, string password, CancellationToken cancellationToken = default)
        {
            var result = await userManager.CreateAsync(user, password);
            return result;
        }

        #endregion



    }
}
