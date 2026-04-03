using Microsoft.EntityFrameworkCore.Diagnostics;
using TestAspNetCore.Data;
using TestAspNetCore.Models;
using TestAspNetCore.Repository;
using TestAspNetCore.Repository.Base;
using TestAspNetCore.UnitOFWork.Base;

namespace TestAspNetCore.UnitOFWork
{
    public class MianUnitOfWork:IUnitOFWork
    {
        public MianUnitOfWork(AppDbContext context)
        {
            _context = context;
            Categoreis = new MainRepository<Categore>(_context);
            Items = new MainRepository<Item>(_context);
            Employees = new EmpRepo(_context);

        }
        private readonly AppDbContext _context;

        public IRepository<Categore> Categoreis { get; private set; }

        public IRepository<Item> Items { get; private set; }

        public IEmpRepo Employees { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
