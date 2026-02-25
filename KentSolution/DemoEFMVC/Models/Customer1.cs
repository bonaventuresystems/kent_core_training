using System.ComponentModel.DataAnnotations;

namespace DemoEFMVC.Models
{
    [MetadataType(typeof(PocoValidation))]
    public partial class Customer
    {

    }

    public class PocoValidation
    {
        [Required(ErrorMessage = "Name is requied!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [KentValidation(ErrorMessage = "Address can not be 1234")]
        public string? Address { get; set; }
    }
}
