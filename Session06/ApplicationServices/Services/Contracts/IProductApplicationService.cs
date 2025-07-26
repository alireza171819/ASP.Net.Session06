using Session06.ApplicationServices.Dtos.ProductDtos;

namespace Session06.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {
        Task<List<GetAllProductDto>> GetAll();
        Task<GetByIdProductDto> GetById(Guid id);
        void Add(AddProductDto product);
        void Update(UpdateProductDto product);
        void Delete(DeleteProductDto id);
    }
}
