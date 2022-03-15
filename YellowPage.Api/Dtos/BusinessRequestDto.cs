using System.ComponentModel.DataAnnotations;

namespace YellowPage.Api.Dtos;

public class BusinessRequestDto
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public virtual ContactRequestDto Contact { get; set; }

}
