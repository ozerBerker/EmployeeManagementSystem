using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-IGJ7D1I\\SQLEXPRESS;Database=CompanyInfo-db;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personnel>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Personnels)
                .HasForeignKey(p => p.DepId);
        }
        /*
         Context Entity Framework den DBContext sınıfını miras alaran her class için table oluşturmamıza olanak sağlıyor.
         Aşağıya table oluşturmak istediğim sınıflarımı ekliyorum
         */
        public DbSet<Department> Departments { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
    }
}
