using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAspNetCore.Models
{
    public class Item
    {
        [Key]//primary key
        public int Id { get; set; }
        [Required]//not null
        public string Name { get; set; }
        [Required]
        [DisplayName("The Price")]
        [Range(0.01, 300, ErrorMessage = "Value for {0} must be betwen {1} and {2}")]//min value and max
        public decimal Price { get; set; }
        public DateTime creatDateTime { get; set; }= DateTime.Now;
        [Required]
        [DisplayName("CatogoreId")]
        [ForeignKey("Categorecs")]
        public int CatogoreId { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
        public Categore? Categorecs { get; set; }
    }
}
