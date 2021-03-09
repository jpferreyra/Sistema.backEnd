using Sistema.BackEnd.Models;
using Sistema.BackEnd.Persistence.Repositories.Contracts;
using Sistema.BackEnd.Persistence.Repositories.Implementations;
using Sistema.BackEnd.Persistence.UnitOfWork.Contracts;
using System;
using System.Threading.Tasks;

namespace Sistema.BackEnd.Persistence.UnitOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaDbContext _context;
        private readonly IGenericRepository<Categoria> _categoriasRepository;

        public UnitOfWork(SistemaDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Categoria> Categorias => _categoriasRepository ?? new GenericRepository<Categoria>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
