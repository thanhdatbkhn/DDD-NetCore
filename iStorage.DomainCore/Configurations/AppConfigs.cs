using System;
namespace iStorage.DomainCore.Configurations
{
    public class AppConfigs
    {
        public string ConnectionString { get; set; }
        public long AuthTokenExpire { get; set; }
    }
}
