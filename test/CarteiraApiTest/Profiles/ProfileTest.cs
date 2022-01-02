using AutoMapper;
using CarteiraApi.Profiles;
using Xunit;

namespace CarteiraApiTest.Profiles
{
    public class ProfileTest
    {
        protected readonly IConfigurationProvider _mapperConfig;

        public ProfileTest()
        {
            _mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExchangeRateProfile>();
                cfg.AddProfile<OperationProfile>();
                cfg.AddProfile<StockProfile>();
            });
        }

        [Fact]
        public void TestConfigMapper()
        {
            _mapperConfig.AssertConfigurationIsValid();
        }
    }
}
