using System.ComponentModel.DataAnnotations;

namespace PSDWebApp.ViewModel
{



    public class UserViewModel
    {
        //public string Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; } = new();
    }

}
