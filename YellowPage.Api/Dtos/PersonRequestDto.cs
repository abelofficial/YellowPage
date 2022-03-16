using System.ComponentModel.DataAnnotations;

namespace YellowPage.Api.Dtos;

public class PersonRequestDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public ContactRequestDto Contact { get; set; }

}
