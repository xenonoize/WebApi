using Core.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace WebApi.DAL.Entities
{
    public class User : IdentityUser, IUserEntity
    {
        public static readonly string[] Roles = { "SuperAdministrator", "Administrator", "Helpdesk", "User" };
        public DateTimeOffset CreationDateTime { get; set; } = DateTimeOffset.UtcNow;
        public string RegistrationToken { get; set; }
    }
}
