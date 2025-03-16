namespace BookMyStay.Domain.Models
{
    public class Hotel
    {
        public Hotel(string name, int stars, string address)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name should not contain whitespace or null");
        }
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Room> Rooms { get; set; }
        public string Description { get; set; }
    }
}
