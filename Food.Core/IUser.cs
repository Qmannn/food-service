using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Core
{
    public interface IUser
    {
        public int UserId { get; }
        public string UserName { get; }
    }
}