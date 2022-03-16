using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class Contact
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string WebSite { get; set; }

    [JsonIgnore]
    public virtual List<Person> People { get; set; }

    [JsonIgnore]
    public virtual List<Business> Businesses { get; set; }

    public virtual Location Location { get; set; }

}
