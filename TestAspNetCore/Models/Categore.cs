using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAspNetCore.Models
{
    public class Categore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Categore Name")]
        public string Name { get; set; }
        public ICollection<Item>? Items { get; set; }
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
        public byte[]? Image { get; set; }
        [NotMapped]
        public string? ImgSRC
        {
            get
            {
                if (Image != null)
                {
                    string imgBase64Data = Convert.ToBase64String(Image,0,Image.Length);
                   // string imgDataURL = string.Format(",{0}", imgBase64Data);
                    return "data:image/jpg;base64," + imgBase64Data;
                }
                return string.Empty;
            }
        }
    }
}
