namespace Hooping.Api.Entities;

public class Supplier(
    string name, 
    string contact,
    long userId) : Entity
{
    private readonly List<Product> _products = [];

    public string Name { get; private set; } = name;
    public string Contact { get; private set; } = contact;
    public IReadOnlyCollection<Product> Products => _products;
    public long UserId { get; private set; } = userId;
    public User User { get; private set; } = null!;
}
