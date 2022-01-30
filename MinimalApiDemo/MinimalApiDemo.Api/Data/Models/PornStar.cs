namespace MinimalApiDemo.Api.Data.Models;

public class PornStar
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public DateTime Birthdate { get; set; }

    public string Address { get; set; }

    public byte Age { get; set; }

    public byte Height { get; set; }

    public Category Category { get; set; }
}
