using System;
using System.Collections.Generic;

namespace OnlineService.Models
{
	public class Order
	{
		public uint Id { get; set; }
        public DateTime OrderDate { get; private set; }
		public decimal Price { get; set; }

        public uint UserId { get; set; }
		public User User { get; set; }

		public uint ServiceId { get; set; }
		public Service Service { get; set; }

		public uint SpecialistId { get; set; }
		public Specialist Specialist { get; set; }

		public Order()
		{
			OrderDate = DateTime.Now;
		}
			
	}
}

