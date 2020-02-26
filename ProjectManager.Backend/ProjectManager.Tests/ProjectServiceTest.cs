using System;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Services;
using ProjectManager.Entities.Context;
using ProjectManager.Entities.Models;
using ProjectManager.Repositories;
using ProjectManager.Tests.ContextInMemory;
using Xunit;

namespace ProjectManager.Tests
{
    public class ProjectServiceTest
    {
        [Fact]
        public void SaveNormal()
        {
           var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;

            using (var context = new ProjectManagerContext(options, null))
            {
                var repoP = new ProjectRepository(context);

                var service = new ProjectService(repoP);

                var newP = service.Save(new Project
                {
                    Name = "teste1",
                    InitialDate = DateTime.Now,
                    FinalDate = DateTime.Now.AddDays(1),
                    PercentComplete = 0,
                    Late = false,
                    Removed = false
                }).Result;

                Assert.NotNull(newP);
            }
        }

        [Fact]
        public void SaveWithoutField()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;

            using (var context = new ProjectManagerContext(options, null))
            {

                var repoP = new ProjectRepository(context);

                var service = new ProjectService(repoP);

                Assert.ThrowsAsync<AggregateException>(() => service.Save(
                    new Project
                    {
                        Name = "teste1",
                        InitialDate = DateTime.Now,
                        FinalDate = DateTime.Now.AddDays(1),
                        PercentComplete = 0,
                    })
                );
            }
        }

        [Fact]
        public void UpdateNormal()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;

            using (var context = new ProjectManagerContext(options, null))
            {
                context.Projects.Add(new Project
                {
                    Name = "teste1",
                    InitialDate = DateTime.Now,
                    FinalDate = DateTime.Now.AddMonths(1),
                    PercentComplete = 0,
                    Late = false,
                    Removed = false
                });
                context.Projects.Add(new Project
                {
                    Name = "teste2",
                    InitialDate = DateTime.Now,
                    FinalDate = DateTime.Now.AddMonths(1),
                    PercentComplete = 0,
                    Late = false,
                    Removed = false
                });
                context.SaveChanges();
            }

            using (var context = new ProjectManagerContext(options, null))
            {
                var repoP = new ProjectRepository(context);

                var service = new ProjectService(repoP);

                var project = service.Get(2).Result;

                project.Name = "testeUpdate";

                service.Update(project).Wait();

                var newProject = service.Get(2).Result;

                Assert.Equal("testeUpdate" , newProject.Name);
            }
        }

        [Fact]
        public void DeleteNormal()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;

            using (var context = new ProjectManagerContext(options, null))
            {
                context.Projects.Add(new Project
                {
                    Name = "teste1",
                    InitialDate = DateTime.Now,
                    FinalDate = DateTime.Now.AddMonths(1),
                    PercentComplete = 0,
                    Late = false,
                    Removed = false
                });
                context.SaveChanges();
            }

            using (var context = new ProjectManagerContext(options, null))
            {
                var repoP = new ProjectRepository(context);

                var service = new ProjectService(repoP);

                service.Delete(1).Wait();

                var project = service.Get(1).Result;

                Assert.Null(null);
            }
        }

        [Fact]
        public void GetAll()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerContext>()
                .UseInMemoryDatabase(databaseName: "save")
                .Options;

            using (var context = new ProjectManagerContext(options, null))
            {
                context.Projects.Add(new Project
                {
                    Name = "teste1",
                    InitialDate = DateTime.Now,
                    FinalDate = DateTime.Now.AddMonths(1),
                    PercentComplete = 0,
                    Late = false,
                    Removed = false
                });
                context.SaveChanges();
            }

            using (var context = new ProjectManagerContext(options, null))
            {
                var repoP = new ProjectRepository(context);

                var service = new ProjectService(repoP);

                var projects = service.GetAll().Result;

                Assert.Equal(3, projects.Count);
            }
        }
    }
}