using Microsoft.EntityFrameworkCore;
using MyAppApi.Domain.Todos.Entities;

namespace MyAppApi.Infrastructure.Data;

public class MyAppContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}
