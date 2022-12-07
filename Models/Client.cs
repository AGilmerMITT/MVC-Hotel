namespace MVC_Hotel.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string CreditCard { get; set; }
        public List<Reservation> Reservations { get; set; }

        public Client()
        {
            Name = "";
            CreditCard = "";
            Reservations = new();
        }

        public Client(string name, string creditCard)
        {
            Name = name;
            CreditCard = creditCard;
            Reservations = new();
        }
    }
}
