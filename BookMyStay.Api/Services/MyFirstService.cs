using BookMyStay.Domain.Models;

namespace BookMyStay.Api.Services
{
    public class MyFirstService
    {
        private readonly DataSource _dataSource;

        public MyFirstService(DataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public List<Hotel> GetAllHotels()
        {
            return _dataSource.GetAllHotels();
        }
    }
}
