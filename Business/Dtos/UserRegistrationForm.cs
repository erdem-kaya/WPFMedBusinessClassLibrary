using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class UserRegistrationForm
{
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must be at least 2 characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must be at least 2 characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format. Exempel username@domain.com")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone Number is required")]
    //[RegularExpression(@"^(\+46[\s-]?\d{2,3}[\s-]?\d{2,3}[\s-]?\d{2,3})$", ErrorMessage = "Invalid phone number format. Exempel: +46 70 123 45 67")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [MinLength(2, ErrorMessage = "Address must be at least 2 characters")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [MinLength(2, ErrorMessage = "City must be at least 2 characters")]
    [RegularExpression(@"^[A-Za-zÅÄÖåäö\s]+$", ErrorMessage = "Invalid city name")]
    public string City { get; set; } = null!;


    [Required(ErrorMessage = "Postal code is required")]
    [RegularExpression(@"^\d{3}\s?\d{2}$", ErrorMessage = "Invalid postal code format. Exempel: 12345 eller 123 45")]

    public string PostalCode { get; set; } = null!;
}
