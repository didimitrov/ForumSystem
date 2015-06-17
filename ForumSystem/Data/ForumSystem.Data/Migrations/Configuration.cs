using System.Collections.Generic;
using ForumSystem.Models;

namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //TODO: Remove in production :)
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ForumSystem.Data.ApplicationDbContext context)
        {
            //new List<Category>
            //{
            //    new Category() { Id = 1, Title = "IT",IsDeleted = false},
            //    new Category() { Id = 2, Title = "Games",IsDeleted = false},
               
            //}.ForEach(i => context.Categories.AddOrUpdate(i));

            //new List<Tag>
            //{
            //    new Tag { Id = 1, Name = ".NET", CategoryId =1, IsDeleted = false},
            //    new Tag { Id = 2, Name = "QuakeLive", CategoryId =2, IsDeleted = false },
               
            //}.ForEach(t => context.Tags.AddOrUpdate(t));

        }
    }
}
