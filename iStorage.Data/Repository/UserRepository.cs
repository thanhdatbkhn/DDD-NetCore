using System;
using iStorage.Data.DataContext;
using iStorage.Domain.AggregatesModels.Users;
using iStorage.DomainCore.Repository;
namespace iStorage.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {

    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(iStorageContext context) : base(context)
        {
        }
    }
}
