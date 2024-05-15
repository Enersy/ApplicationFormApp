using EmployeeApplicationForm.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplpyeeApplicationForm.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Choice> Choices{ get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);


           // modelBuilder.Entity<PersonalInfo>()
           //.ToContainer(nameof(PersonalInfo))
           //.HasPartitionKey(q => q.Id)
           //.HasNoDiscriminator();

            modelBuilder.Entity<Question>()
              .ToContainer(nameof(Question))
              .HasPartitionKey(q => q.Id)
              .HasNoDiscriminator();


                modelBuilder.Entity<Choice>()
               .ToContainer(nameof(Choice))
               .HasPartitionKey(o => o.QuestionId)
               .HasNoDiscriminator();

        }

    }
}
