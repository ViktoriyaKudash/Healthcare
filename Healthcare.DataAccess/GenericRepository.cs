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
		private Func<ApplicationContext> createContext;

		public GenericRepository(Func<ApplicationContext> createContext)
		{
			this.createContext = createContext;
		}

		public IEnumerable<TModel> Get()
        {
			using(var context = createContext())
			{
				return context.Set<TModel>().AsNoTracking().ToList();
			}
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
			using(var context = createContext())
			{
				return context.Set<TModel>().AsNoTracking().Where(predicate).ToList();
			}
        }

        public async Task<IEnumerable<TModel>> GetAsync()
        {
			using(var context = createContext())
			{
				return await context.Set<TModel>().AsNoTracking().ToListAsync();
			}
        }

        public TModel FindById(int id)
        {
			using(var context = createContext())
			{
				return context.Set<TModel>().Find(id);
			}
        }

        public void Create(TModel item)
        {
			using(var context = createContext())
			{
				context.Set<TModel>().Add(item);
				context.SaveChanges();
			}
        }

        public void Update(TModel item)
        {
			using(var context = createContext())
			{
				context.Entry(item).State = EntityState.Modified;
				context.SaveChanges();
			}
        }

        public void Remove(TModel item)
        {
			using(var context = createContext())
			{
				context.Set<TModel>().Remove(item);
				context.SaveChanges();
			}
        }
    }
}
