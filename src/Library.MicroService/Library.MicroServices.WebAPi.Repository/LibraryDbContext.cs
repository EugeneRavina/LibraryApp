﻿using Library.MicroServices.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.MicroServices.WebApi.Repositories
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
       : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}