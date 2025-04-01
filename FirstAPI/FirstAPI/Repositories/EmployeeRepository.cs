using FirstAPI.Contexts;
using FirstAPI.Exceptions;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Repositories
{
	public class EmployeeRepository : Repository<int, Employee>
	{

		public EmployeeRepository(ApplicationDbContext appContext) : base(appContext)
		{
		}

		public async override Task<Employee> Get(int key)
		{
			var employee = await _appContext.Employees.SingleOrDefaultAsync(e => e.Id == key);
			if (employee == null)
				throw new EntityNotFoundException($"Employee with ID {key} not found");
			return employee;
		}

		public async override Task<IEnumerable<Employee>> GetAll()
		{
			var employees = _appContext.Employees;
			if (employees.Count() == 0)
				throw new EntityCollectionEmptyException();
			return employees;
		}

	}
}
