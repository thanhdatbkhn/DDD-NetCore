using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.DataLayer.Models.Data;
using System.Configuration;
using iStorage.Data.UnitOfWork;
using iStorage.Business.DataTransferObjects;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using iStorage.DomainCore.Configurations;

namespace iStorage.Business.Services
{
    public class TokensService : ITokensService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppConfigs _configs;
        public TokensService(IUnitOfWork uow, IOptions<AppConfigs> options)
        {
            _unitOfWork = uow;
            _configs = options.Value;
        }
        public TokenDTO GenerateToken(long userId)
        {
            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.UtcNow;
            DateTime expiresOn = DateTime.UtcNow.AddSeconds(_configs.AuthTokenExpire);
            var tokenDomain = new TokenDTO
            {
                //UserId = userId,
                //AuthToken = token,
                //IssuedOn = issuedOn,
                //ExpiresOn = expiresOn
            };
            //_unitOfWork.TokenRepository.Insert(tokenDomain);
            //_unitOfWork.Save();
            return tokenDomain;
        }
        public bool ValidateToken(string tokenKey)
        {
            //var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenKey
            //&& t.ExpiresOn > DateTime.UtcNow);
            //if( token != null )
            //{
            //    token.ExpiresOn = token.ExpiresOn.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings.GetValues(Constants.AuthTokenExpiryKey)));
            //    _unitOfWork.TokenRepository.Update(token);
            //    _unitOfWork.Save();
            //    return true;
            //}
            return false;
        }
        public bool Kill(string tokenKey)
        {
            //_unitOfWork.TokenRepository.Delete(t => t.AuthToken == tokenKey);
            //_unitOfWork.Save();
            return true;
        }
        public bool DeleteByUserId(long userId)
        {
            //_unitOfWork.TokenRepository.Delete(t => t.UserId == userId);
            //_unitOfWork.Save();
            return true;
        }
    }
}
