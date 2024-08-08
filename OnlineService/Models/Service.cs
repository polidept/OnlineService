using System;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnlineService.Models
{
	public class Service
	{
        public uint Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public uint CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

		public List<Specialist> Specialists { get; set; } = new List<Specialist>();

		public List<Order> Orders { get; set; } = new List<Order>();

    }
}



