using TestAspNetCore.Models;
using TestAspNetCore.Repository.Base;

namespace TestAspNetCore.UnitOFWork.Base
{
    public interface IUnitOFWork : IDisposable 
    {
        IRepository<Categore> Categoreis { get; }
        IRepository<Item> Items { get; }
        IEmpRepo Employees { get; }
        int CommitChanges();

    }
}
