using FirstAPI.Models;

namespace FirstAPI.Interfaces
{
	public interface IDepartmentService
	{
		Task<Department> GetById(int id);
		Task<Department> CreateDepartment(Department request);

	}
}