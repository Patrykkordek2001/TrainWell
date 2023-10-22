using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Diet
{
    public class Dinner
    {
        public Dinner(int id, DateTime date)
        {
            Id = id;
            Date = date;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}
