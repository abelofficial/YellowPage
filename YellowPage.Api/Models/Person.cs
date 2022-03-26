namespace YellowPage.Api.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual Contact Contact { get; set; }

    public virtual User AddedBy { get; set; }
}
