using System;
using System.Collections.Generic;
using System.Text;

namespace Food.EntityFramework.Entity
{
    class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}