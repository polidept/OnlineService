using System;

namespace OnlineService.Models
{
    public class User
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime DateOfBirth { get; set; }

		public List<Order> Orders { get; set; } = new();
	}
}

