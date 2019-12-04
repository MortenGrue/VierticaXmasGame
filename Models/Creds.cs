namespace VierticaXmasGame.Models.Credentials
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RootObject
    {
        public string Id { get; set; }
        public Credentials Credentials { get; set; }
    }
}
