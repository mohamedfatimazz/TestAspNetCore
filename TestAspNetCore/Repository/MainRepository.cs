using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestAspNetCore.Data;
using TestAspNetCore.Repository.Base;

namespace TestAspNetCore.Repository
{
    public class MainRepository<T> :IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context) 
        { 
            this.context = context;
        }
        protected AppDbContext context;
        public T GetById(int Id)
        {
          return context.Set<T>().Find(Id);
        }
        public T SelectOne(Expression<Func<T, bool>> math)
        {
           return context.Set<T>().FirstOrDefault(math);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public async Task <T> GetByIdAsync(int Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }
        public async Task< IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
            if (agers != null && agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();
            if (agers != null && agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return await query.ToListAsync();
        }

        public void Add(T Item)
        {
            context.Set<T>().Add(Item);
             Save();
        }

        public void Update(T Ietm)
        {
          context.Set<T>().Update(Ietm);
            Save();
        }

        public void Delete(T Item)
        {
           context.Set<T>().Remove(Item);
            Save();
        }

        public void Add(IEnumerable<T> Items)
        {
           context.Set<T>().AddRange(Items);
            Save();
        }

        public void Update(IEnumerable<T> Ietms)
        {
            context.Set<T>().UpdateRange(Ietms);
            Save();
        }

        public void Delete(IEnumerable<T> Items)
        {
            context.Set<T>().RemoveRange(Items);
            Save();
        }

        public void Save()
        {
           context.SaveChanges();
        }
    }
}
