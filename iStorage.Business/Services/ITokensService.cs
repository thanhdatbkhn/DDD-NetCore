using iStorage.Business.DataTransferObjects;
using ProductApp.DataLayer.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStorage.Business.Services
{
    public interface ITokensService
    {
        TokenDTO GenerateToken(long userId);
        bool ValidateToken(string tokenKey);
        bool Kill(string tokenKey);
        bool DeleteByUserId(long userId);
    }
}
