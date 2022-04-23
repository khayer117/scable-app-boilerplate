using Sab.Authentication.Features.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sab.Authentication.Features.Services
{
    public class UserAll
    {
        public static IEnumerable<User> GetAll()
        {
            var users = new List<User>()
            {
                new User(){FirstName = "Admin", LastName = "Admin", Username = "admin", Password = "admin", Id = 101},
                new User(){FirstName = "Visitor", LastName = "Visitor", Username = "Visitor", Password = "visitor", Id = 102}
            };

            return users;
        }
    }
}
