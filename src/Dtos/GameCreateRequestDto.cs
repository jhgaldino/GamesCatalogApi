using System.ComponentModel.DataAnnotations;

namespace GamesCatalogApi.src.Dtos
{
    public class GameCreateRequestDto
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Title { get; set; }
        public string Genre { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The field {0} must be between {2} and {1} characters")]
        public string Developer { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        public string Publisher { get; set; }
    }
}
