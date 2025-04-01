using FirstAPI.Interfaces;
using FirstAPI.Models;
using FirstAPI.Models.DTOs;

namespace FirstAPI.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IRepository<int, Employee> _employeeRepository;
		private readonly IRepository<int, Department> _departmentRepository;

		public DepartmentService(IRepository<int, Employee> employeeRepository,
								IRepository<int, Department> departmentRepository)
		{
			_employeeRepository = employeeRepository;
			_departmentRepository = departmentRepository;
		}

		public async Task<Department> CreateDepartment(Department request)
		{
			var newDepartment = new Department
			{
				Name = request.Name
			};
			return await _departmentRepository.Add(newDepartment);
		}

		public async Task<Department> GetById(int id)
		{
			var department = await _departmentRepository.Get(id);
			if (department == null)
				throw new Exception("Department not found");

			return department;
		}
	}
}
