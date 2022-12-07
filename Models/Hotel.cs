namespace MVC_Hotel.Models
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Client> Clients { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Hotel(string name, string address)
        {
            Name = name;
            Address = address;
            Clients = new();
            Rooms = new();
            Reservations = new();
        }
    }
}
