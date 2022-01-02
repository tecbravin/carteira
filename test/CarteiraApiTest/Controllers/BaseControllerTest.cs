using AutoFixture;
using AutoMapper;
using CarteiraApi.Profiles;

namespace CarteiraApiTest.Controllers
{
    public class BaseControllerTest
    {
        public readonly Fixture _fixture;
        public readonly IMapper _mapper;

        public BaseControllerTest()
        {
            _fixture = new Fixture();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExchangeRateProfile>();
                cfg.AddProfile<OperationProfile>();
                cfg.AddProfile<StockProfile>();
                cfg.ConstructServicesUsing(x => _mapper);
            });

            _mapper = config.CreateMapper();
        }
    }
}
