using System.ComponentModel.DataAnnotations;

namespace YellowPage.Api.Dtos;

public class RegisterUserDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

}
