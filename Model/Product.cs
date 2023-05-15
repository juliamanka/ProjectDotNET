using System.ComponentModel.DataAnnotations;

namespace Praktyki_projectDotNET.Model
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0.5,500)]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }


    }
}
