using System.Collections.Generic;

namespace OnlineService.Models
{
    public class Categoria
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public List<Service> Services { get; set; } = new List<Service>();
    }
}
