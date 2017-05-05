using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Cnp { get; set; }
    }
}
