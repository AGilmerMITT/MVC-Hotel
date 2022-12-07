namespace MVC_Hotel.Models
{
    public class Reservation
    {
        public DateTime Date { get; set; }
        public int Occupants { get; set; }
        public bool IsCurrent { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }

        public Reservation() { }

        public Reservation(int occupants, Client client, Room room)
        {
            Date = DateTime.Now;
            Occupants = occupants;
            IsCurrent = true;
            Client = client;
            Room = room;
        }
    }
}
