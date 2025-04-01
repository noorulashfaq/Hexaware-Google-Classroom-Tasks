using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FirstAPI.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public int Age { get; set; }

		public string Phone { get; set; } = string.Empty;

		public int DepartmentId { get; set; }

		[ForeignKey("DepartmentId")]
		[JsonIgnore]
		public Department? Department { get; set; }
	}
}
