namespace Hooping.Api.Entities;

public class Supplier(
    string name, 
    string contact) : Entity
{
    private readonly List<Product> _products = [];

    public string Name { get; private set; } = name;
    public string Contact { get; private set; } = contact;
    public IReadOnlyCollection<Product> Products => _products;
}
