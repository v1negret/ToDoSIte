using System.ComponentModel.DataAnnotations;

namespace ToDoSite2.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(35, ErrorMessage ="Длинна названия не должна превышать 35 символов")]
        [MinLength(6, ErrorMessage ="Минимальная длина названия 6 символов")]
        [Display(Name ="Название")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage ="Максимальная длина описания 500 символов")]
        [MinLength(12, ErrorMessage ="Минимальная длина описания 12 символов")]
        [Display(Name ="Описание")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Дата выполнения")]
        public DateTime? ExtremeDate { get; set; }

        public string? UserId { get; set; }
    }
}
