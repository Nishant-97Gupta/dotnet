using Microsoft.EntityFrameworkCore;
using BOL;

namespace DAL;
    public class CollectionContext:DbContext{
        public DbSet<Product> Products {get;set;}
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     
     {
        string conString=@"server=localhost;port=3306;user=root; password=Nishant@123;database=mydb";       
        optionsBuilder.UseMySQL(conString);
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity => 
            {
            entity.HasKey(e => e.pid);
            entity.Property(e => e.pname);
             
            entity.Property(e => e.price);
             entity.Property(e => e.stock);

            });
            modelBuilder.Entity<Product>().ToTable("product1");

        }
    }

