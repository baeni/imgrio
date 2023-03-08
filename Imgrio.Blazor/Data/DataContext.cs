﻿using Imgrio.Blazor.Backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imgrio.Blazor.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<UserFile> UserFiles { get; set; }
    }
}
