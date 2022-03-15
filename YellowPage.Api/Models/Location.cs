using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class Location
{
    public int Id { get; set; }

    public string Country { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string Address { get; set; }

    [JsonIgnore]
    public virtual List<Contact> Contacts { get; set; }

}
