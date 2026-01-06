using Server.Application.Catalog.Products;

namespace Server.Application.Catalog.Brands;
public class DeleteBrandRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteBrandRequest(Guid id) => Id = id;
}

public class DeleteBrandRequestHandler : IRequestHandler<DeleteBrandRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Brand> _brandRepo;
    private readonly IReadRepository<Product> _productRepo;

    public DeleteBrandRequestHandler(IRepositoryWithEvents<Brand> brandRepo, IReadRepository<Product> productRepo) =>
        (_brandRepo, _productRepo) = (brandRepo, productRepo);

    public async Task<Guid> Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
    { 
        var product = await _productRepo.AnyAsync(new ProductsByBrandSpec(request.Id), cancellationToken);
        if (product)
        {
            var array = new List<string>();
            array.Add("Brand.BrandCannotBeDeletedAsItsBeingUsed");
            throw new ConflictException("Brand.BrandCannotBeDeletedAsItsBeingUsed", array);
        }

        var brand = await _brandRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = brand ?? throw new NotFoundException("Brand {0} Not Found.");

        await _brandRepo.DeleteAsync(brand, cancellationToken);

        return request.Id;
    }
}