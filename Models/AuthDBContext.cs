using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginRegistration.Models
{
    public class AuthDBContext : IdentityDbContext
    {
        public AuthDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
