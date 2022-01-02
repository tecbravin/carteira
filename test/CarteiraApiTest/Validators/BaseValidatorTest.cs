using AutoFixture;
using FluentValidation;

namespace CarteiraApiTest.Validators
{
    public class BaseValidatorTest<T> where T : IValidator, new()
    {
        protected readonly Fixture _fixture;
        public T _validator;

        public BaseValidatorTest()
        {
            _fixture = new Fixture();
            _validator = new T();
        }
    }
}
