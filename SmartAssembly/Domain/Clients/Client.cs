namespace Domain.Clients
{
    public class Client
    {
        public Client(string name, string number, string email, string adress)
        {
            Name = name;
            Number = number;
            Email = email;
            Adress = adress;
        }

        public string Name { get; }
        public string Number { get; }
        public string Email { get; }
        public string Adress { get; }
    }
}
