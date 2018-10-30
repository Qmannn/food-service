using Food.EntityFramework.Entities.Enums;
using System.Collections.Generic;

namespace Food.EntityFramework.Entities
{
    internal class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
