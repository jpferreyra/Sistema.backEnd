using Sistema.BackEnd.Models;
using Sistema.BackEnd.Persistence.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace Sistema.BackEnd.Persistence.UnitOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Categoria> Categorias { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
