using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    // To create new product
    public record CreateProductCommand(string Name,
     List<string> Category,
     string Description,
     string Image,
     decimal Price
        ) : ICommand<CreateProductResult>;

    // to return productId
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //create Product entity using command object

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                Image = command.Image,
                Price = command.Price,
            };

            // save to database


            //return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
