using System.Text.Json.Serialization;

namespace YellowPage.Api.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    [JsonIgnore]
    public byte[] PasswordHash { get; set; }

    [JsonIgnore]
    public byte[] PasswordSalt { get; set; }

    [JsonIgnore]
    public virtual List<Business> BusinessRecords { get; set; }

    [JsonIgnore]
    public virtual List<Person> PeopleRecords { get; set; }

}
