using System;
namespace OnlineService.Models
{
	public class Specialist
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public uint Age { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Specialization { get; set; }
		public string Description { get; set; }
		public decimal HourlyRate { get; set; }

		public List<Service> Services { get; set; }

		public List<Order> Orders { get; set; }
	}
}
