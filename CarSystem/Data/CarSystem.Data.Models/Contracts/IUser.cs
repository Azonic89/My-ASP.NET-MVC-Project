using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

namespace CarSystem.Data.Models.Contracts
{
    public interface IUser
    {
        ICollection<Advert> Adverts { get; set; }

        string FirstName { get; set; }

        bool IsDeleted { get; set; }

        string LastName { get; set; }

        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager);
    }
}