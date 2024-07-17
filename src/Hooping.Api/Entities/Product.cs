namespace Hooping.Api.Entities;

public class Product(
    string description,
    decimal price) : Entity
{
    public string Description { get; private set; } = description;
    public decimal Price { get; private set; } = price;
    public long SupplierId { get; private set; }
    public Supplier Supplier { get; private set; } = null!;
}
