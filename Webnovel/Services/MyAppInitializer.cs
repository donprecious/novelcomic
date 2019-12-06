using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.AsyncInitialization;
using Webnovel.Repository;

namespace Webnovel.Services
{
    public class MyAppInitializer : IAsyncInitializer
    {
        private IUser _user;
        private IAppConfig _appConfig;
        public MyAppInitializer(IUser user, IAppConfig appConfig)
        {
            _user = user;
            _appConfig = appConfig;
        }

        public async Task InitializeAsync()
        {
           await _user.CreateDefaultAdminUser();
           await _appConfig.SeedCountry();
           await _appConfig.SeedPages();
           await _appConfig.SeedRateType();
        }
    }
}
