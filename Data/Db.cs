using System.Data.Entity;
using Omu.ProDinner.Core.Model;

namespace Omu.ProDinner.Data
{
    //dbcontext作为与数据库交互的桥梁，从这里可以获取需要的数据源
    public class Db : DbContext
    {
        public Db()
        {
            Database.SetInitializer<Db>(null);
        }

        //Entity Framework
        public DbSet<Country> Countries { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dinner>().HasMany(r => r.Meals).WithMany(o => o.Dinners).Map(f =>
            {
                f.MapLeftKey("DinnerId");
                f.MapRightKey("MealId");
            });

            modelBuilder.Entity<User>().HasMany(r => r.Roles).WithMany(o => o.Users).Map(f =>
            {
                f.MapLeftKey("UserId");
                f.MapRightKey("RoleId");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}