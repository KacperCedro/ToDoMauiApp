using Microsoft.EntityFrameworkCore;
using ToDoDatabaseLibrary.Models;
using ToDoDatabaseLibrary.Models;

namespace ToDoDatabaseLibrary
{
    public class ToDoListDBContext:DbContext
    {
        public DbSet<ToDoModel> ToDoLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=tododb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
            base.OnConfiguring(optionsBuilder);
        }

    }
}
