using Sistema.BackEnd.Models;
using Sistema.BackEnd.Persistence.UnitOfWork.Contracts;
using Sistema.BackEnd.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sistema.BackEnd.Services.Implementations
{
    public class CategoryService : ICategoriaService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _unitOfWork.Categorias.GetAllAsync();
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _unitOfWork.Categorias.GetByIdAsync(id);
        }

        public async Task InsertAsync(Categoria categoria)
        {
            await _unitOfWork.Categorias.InsertAsync(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Categoria categoria)
        {
            _unitOfWork.Categorias.Update(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            await _unitOfWork.Categorias.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
