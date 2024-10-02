using Microsoft.EntityFrameworkCore;
using NotissimusTest.Models;

namespace NotissimusTest.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<MouseMovement> MouseMovement { get; set; }
    }
}
