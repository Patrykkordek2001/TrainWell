namespace TrainWell___BACKEND.Models
{
    public class User
    {
        public User(string username, string password, string email, string? phone)
        {
            Id = Guid.NewGuid(); ;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }



    }
}
