using System.Linq.Expressions;

namespace TestAspNetCore.Repository.Base
{
    public interface IRepository<T>where T: class
    {
        T GetById(int Id);
        T SelectOne(Expression<Func<T,bool>>math);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params string[] agers);
        Task<T> GetByIdAsync(int Id);
        Task <IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params string[] agers);
        void Add(T Item);
        void Update(T Ietm);
        void Delete(T Item);
        void Add(IEnumerable<T> Items);
        void Update(IEnumerable<T> Ietms);
        void Delete(IEnumerable<T> Items);
        void Save();
    }
}
