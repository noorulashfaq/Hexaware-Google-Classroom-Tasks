using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FirstAPI.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;
		[JsonIgnore]
		public IEnumerable<Employee>? Employees { get; set; }
	}
}
