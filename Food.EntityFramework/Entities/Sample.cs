using System;

namespace Food.EntityFramework.Entities
{
    public class Sample: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}