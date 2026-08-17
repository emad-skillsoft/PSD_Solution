using System.ComponentModel.DataAnnotations;

namespace PreProjectDemo.ViewModel
{
    public class UserVM
    {
        //public string Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; } = new();
    }
}
