using PSDWebApp.Models;

namespace PSDWebApp.ViewModel
{
    public class CustomerDetailVM
    {    
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public bool IsMarried { get; set; } = false;
        public Gender Gender { get; set; } = Gender.Male;
    }
}
