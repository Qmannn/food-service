﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Food.EntityFramework.Context
{
    class FoodDbContext : DbContext
    {
        public DbSet<Entities.User> Users { get; set; }
    }
}