using PreProjectDemo.Models;
using System.ComponentModel.DataAnnotations;
namespace PreProjectDemo.ViewModel
{

    public class CustomerVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Age is required")]
        [Range(1,70, ErrorMessage = "Age must be between 1 and 70")]
        public int Age { get; set; } = 0;


        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [Display(Name = "Is Married")]
        public bool IsMarried { get; set; } = false;
        
        
        public Gender Gender { get; set; } = Gender.Male;
    }
}
