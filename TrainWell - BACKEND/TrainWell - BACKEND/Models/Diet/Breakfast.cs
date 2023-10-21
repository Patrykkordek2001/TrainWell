using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Breakfast
    {
        public Breakfast(int id, DateTime date)
        {
            Id = id;
            Date = date;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        ICollection<Product> Products { get; set; }
    }
}
