using System;

namespace Food.EntityFramework.Entities
{
    public class Command: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
       
    }
}