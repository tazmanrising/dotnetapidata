using dotnetapi.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace dotnetapi.Data
{
    public class DOCContext : DbContext
    {
        public DbSet<tblTips> tblTips { get; set; }

        public DbSet<tblComments> tblComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //    //modelBuilder.Entity<Course>()
            //    //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    //    .Map(t => t.MapLeftKey("CourseID")
            //    //        .MapRightKey("InstructorID")
            //    //        .ToTable("CourseInstructor"));

            //    //modelBuilder.Entity<Department>().MapToStoredProcedures();


            Database.SetInitializer<DOCContext>(null);


            modelBuilder.Entity<tblTips>().ToTable("tblTips", schemaName: "ESO");
            modelBuilder.Entity<tblComments>().ToTable("tblComments", schemaName: "ESO");

            // created in tblcomments does have a default of self entry with  (getdate())   


        }


    }
}
