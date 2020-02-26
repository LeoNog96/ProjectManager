using System;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.Models;

namespace ProjectManager.Tests.ContextInMemory
{
    public static class StartDb
    {
        public static ProjectManagerContext Start()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;
             // Run the test against one instance of the context

            var context = new ProjectManagerContext(options, null);

            context.Projects.Add(new Project
            {
                Name = "teste1",
                InitialDate = DateTime.Now,
                FinalDate = DateTime.Now.AddMonths(1),
                PercentComplete = 0,
                Late = false,
            });

            context.SaveChanges();

            context.Activities.Add(new Activity
            {
                Name = "teste1",
                InitialDate = DateTime.Now,
                FinalDate = DateTime.Now.AddDays(1),
                ProjectId = 1,
                Finished = false
            });

            context.SaveChanges();

            return context;
        }
    }
}