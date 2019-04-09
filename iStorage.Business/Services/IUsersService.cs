using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStorage.Business.DataTransferObjects;

namespace iStorage.Business.Services
{
    public interface IUsersService
    {
        UserDTO Register(string userName, string password, string email);
        long Authenticate(string userName, string password);
    }
}
