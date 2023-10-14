using System.ComponentModel.DataAnnotations;

namespace ToDoSite2.Models
{
    public class Note
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        [Display(Name ="Название")]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        [MinLength(12)]
        [Display(Name ="Описание")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Дата выполнения")]
        public DateTime? ExtremeDate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
