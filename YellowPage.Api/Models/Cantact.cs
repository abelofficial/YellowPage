namespace YellowPage.Api.Models;

public class Contact
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string WebSite { get; set; }

    public virtual List<Person> People { get; set; }

    public virtual List<Business> Businesses { get; set; }

    public virtual Location Location { get; set; }

}
