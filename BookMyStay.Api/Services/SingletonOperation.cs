using BookMyStay.Api.Services.Abstractions;

namespace BookMyStay.Api.Services
{
    public class SingletonOperation : ISingletonOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
