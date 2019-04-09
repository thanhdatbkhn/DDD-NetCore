using System;
using iStorage.DomainCore.Entities;
namespace iStorage.Domain.AggregatesModels.Users
{
    public class User : Entity<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
