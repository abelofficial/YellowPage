using System.ComponentModel.DataAnnotations;

namespace YellowPage.Api.Dtos;

public class LoginUserRequestDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
