using BookMyStay.Domain.Models;

namespace BookMyStay.Api
{
    public class DataSource
    {
        public List<Hotel> hotels { get; set; }

        public DataSource()
        {
            hotels = GetAllHotels();
        }

        #region Private Methods
        private List<Hotel> GetAllHotels()
        {
            return new List<Hotel>
            {
                new Hotel
                {
                    HotelId = 1,
                    Name = "Hotel Taj",
                    Stars = 5,
                    Country = "India",
                    City = "Mumbai",
                    Description = "Taj Hotel Description"
                },
                new Hotel
                {
                    HotelId = 2,
                    Name = "Hotel Mariut",
                    Stars = 4,
                    Country = "India",
                    City = "Pune",
                    Description = "Mariut Hotel Description"
                }
            };
        }

        #endregion Private Methods

    }
}
