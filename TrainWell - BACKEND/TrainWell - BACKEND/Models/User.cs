using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models
{
    public class User
    {
        public User(int id, string username, string password, string email, string? phone)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Phone = phone;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }



    }
}
