using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.DataAccess
{
    public class GenericRepository<TModel>
        where TModel : BaseModel
    {
        private DbContext context;
        private DbSet<TModel> dbSet;

        public GenericRepository(DbContext context)
        {
            this.context = context;

            dbSet = context.Set<TModel>();
        }

        public IEnumerable<TModel> Get()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public TModel FindById(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(TModel item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public void CreateWithTransaction(TModel item)
        {
            var transaction = context.Database.BeginTransaction();
    
            try
            {
                dbSet.Add(item);
                context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();

                throw;
            }
        }

        public void Update(TModel item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Remove(TModel item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }
    }
}
