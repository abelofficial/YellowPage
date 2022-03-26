namespace YellowPage.Api.Models;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public virtual List<Business> BusinessRecords { get; set; }

    public virtual List<Person> PeopleRecords { get; set; }

}
