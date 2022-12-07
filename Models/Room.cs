namespace MVC_Hotel.Models
{
    public class Room
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public bool Occupied { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Room()
        {
            Number = "";
            Capacity = 0;
            Occupied = false;
            Reservations = new();
        }

        public Room(string number, int capacity)
        {
            Number = number;
            Capacity = capacity;
            Occupied = false;
            Reservations = new();
        }
    }
}
