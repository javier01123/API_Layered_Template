﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Context
{
    internal class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
    }
}
