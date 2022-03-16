namespace YellowPage.Api.Dtos;

public class ContactRequestDto
{
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string WebSite { get; set; }

    public LocationRequestDto Location { get; set; }

}
