using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentService _departmentService;
		public DepartmentController(IDepartmentService departmentService)
		{
			_departmentService = departmentService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateDepartment(Department request)
		{
			var department = await _departmentService.CreateDepartment(request);
			return Ok(department);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDepartmentById(int id)
		{
			var department = await _departmentService.GetById(id);
			return Ok(department);
		}

	}
}
