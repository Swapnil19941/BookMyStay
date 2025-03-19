using BookMyStay.Api.Services.Abstractions;

namespace BookMyStay.Api.Services
{
    public class ScopedOperation : IScopedOperation
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
