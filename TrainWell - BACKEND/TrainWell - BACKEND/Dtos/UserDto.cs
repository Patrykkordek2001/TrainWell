namespace TrainWell___BACKEND.Dtos
{
    public class UserDto
    {
        public UserDto(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
