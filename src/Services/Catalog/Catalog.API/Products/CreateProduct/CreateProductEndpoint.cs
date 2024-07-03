namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(
        string Name,
        List<string> Category,
        string Description,
        string Image,
        decimal Price
    );

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint
    {
    }
}
