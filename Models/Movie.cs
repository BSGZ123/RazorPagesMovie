using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }

        //Price字段映射到数据库中的货币
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price {  get; set; }
    }
}
