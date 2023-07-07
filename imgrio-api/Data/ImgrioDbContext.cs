﻿using imgrio_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imgrio_api.Data
{
    public class ImgrioDbContext : DbContext
    {
        public DbSet<UploadedFile> UploadedFiles { get; set; }

        public ImgrioDbContext(DbContextOptions options) : base(options) { }
    }
}
