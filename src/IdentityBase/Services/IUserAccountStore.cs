﻿using IdentityBase.Models;
using ServiceBase.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityBase.Services
{
    public interface IUserAccountStore
    {
        /// <summary>
        /// Writes a user account to database including all accounts and claims
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        Task<UserAccount> WriteAsync(UserAccount userAccount);

        /// <summary>
        /// Looks for the user by local email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserAccount> LoadByEmailAsync(string email);

        /// <summary>
        /// Looks for the user by email including all external accounts
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserAccount> LoadByEmailWithExternalAsync(string email);

        // Task<User> LoadByExternalEmailAsync(string email);

        /// <summary>
        /// Looks for the user by provider name and provider user id
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task<UserAccount> LoadByExternalProviderAsync(string provider, string subject);

        /// <summary>
        /// Load by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserAccount> LoadByIdAsync(Guid id);

        /// <summary>
        /// Loads user account by verification key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<UserAccount> LoadByVerificationKeyAsync(string key);

        Task DeleteByIdAsync(Guid id);

        Task<ExternalAccount> WriteExternalAccountAsync(ExternalAccount externalAccount);

        Task DeleteExternalAccountAsync(Guid id);

        Task<PagedList<UserAccount>> LoadInvitedUserAccounts(int take, int skip = 0, Guid? invitedBy = null); 
    }
}