using System.ComponentModel.DataAnnotations.Schema;

namespace YellowPage.Api.Models;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public virtual Contact Contact { get; set; }

    [NotMapped]
    public string FullName { get => FirstName + " " + LastName; }

}
