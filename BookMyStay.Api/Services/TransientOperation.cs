using BookMyStay.Api.Services.Abstractions;

namespace BookMyStay.Api.Services
{
    public class TransientOperation : ITransientOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
