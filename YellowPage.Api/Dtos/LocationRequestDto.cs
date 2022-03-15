using System.ComponentModel.DataAnnotations;

namespace YellowPage.Api.Dtos;

public class LocationRequestDto
{
    [Required]
    public string Country { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string ZipCode { get; set; }

    [Required]
    public string Address { get; set; }

}
