using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 这些验证规则将自动应用于编辑 Movie 模型的 Razor 页面

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60,MinimumLength =3)]
        [Required]
        public string Title { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]//用于指定比数据库内部类型更加具体的数据类型，但并不是验证特性
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]//用于限制可输入的字符
        [Required]
        [StringLength(30)]
        public String Genre { get; set; }

        //Price字段映射到数据库中的货币
        [Range(1,100)]
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price {  get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating {  get; set; }
    }
}
