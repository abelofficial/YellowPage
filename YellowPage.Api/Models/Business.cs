namespace YellowPage.Api.Models;

public class Business
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual Contact Contact { get; set; }

    public virtual User AddedBy { get; set; }
}
