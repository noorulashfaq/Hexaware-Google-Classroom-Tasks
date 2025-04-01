using FirstAPI.Contexts;
using FirstAPI.Exceptions;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
	public class DepartmentRepository: Repository<int, Department>
	{
		public DepartmentRepository(ApplicationDbContext _appContext) : base(_appContext)
		{

		}
		public async override Task<Department> Get(int key)
		{
			var dept = _appContext.Departments.Include(d => d.Employees).FirstOrDefault(d => d.Id == key);
			//var dept = await _appContext.Departments.SingleOrDefaultAsync(p => p.Id == key);
			if (dept == null)
				throw new EntityNotFoundException($"Department with the {key} not present");
			return dept;
		}

		public async override Task<IEnumerable<Department>> GetAll()
		{
			var depts = _appContext.Departments.Include(d => d.Employees);
			//var depts = _appContext.Departments;
			if (depts.Count() == 0)
				throw new EntityCollectionEmptyException();
			return depts;
		}		
	}
}
