using FirstAPI.Contexts;
using FirstAPI.Interfaces;
using FirstAPI.Exceptions;

namespace FirstAPI.Repositories
{
	public abstract class Repository<K, T> : IRepository<K, T> where T : class
	{
		protected readonly ApplicationDbContext _appContext;
		public Repository(ApplicationDbContext appContext)
		{
			_appContext = appContext;
		}
		public abstract Task<IEnumerable<T>> GetAll();

		public abstract Task<T> Get(K key);


		public async Task<T> Add(T entity)
		{
			_appContext.Add(entity);
			await _appContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T> Update(K key, T entity)
		{
			var data = await Get(key);
			if (data == null)
				throw new EntityNotFoundException($"Entity with the {key} not present");
			_appContext.Entry(data).CurrentValues.SetValues(entity);
			await _appContext.SaveChangesAsync();
			return data;
		}

		public async Task<T> Delete(K key)
		{
			var data = await Get(key);
			if (data == null)
				throw new EntityNotFoundException($"Entity with the {key} not present");
			_appContext.Remove(data);
			await _appContext.SaveChangesAsync();
			return data;
		}


	}
}
