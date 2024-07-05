

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


    // To setup post endpoint
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // Map incoming request to CreateProductCommand object 
                var command = request.Adapt<CreateProductCommand>();

                // Send it using the mediator
                var result = await sender.Send(command);

                //Get back and return this response to CreateProductResponse
                var response = result.Adapt<CreateProductResponse>();

                //return 201 and redirect and return response
                return Results.Created($"/products/{response.Id}", response);
            })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }
}
