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
    public class ActivityServiceTest
    {
        [Fact]
        public void SaveNormal()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            var newAct = service.Save(new Activity
            {
                Name = "teste1",
                InitialDate = DateTime.Now,
                FinalDate = DateTime.Now.AddDays(1),
                ProjectId = 1,
                Finished = false
            }).Result;

            Assert.NotNull(newAct);
        }

        [Fact]
        public void SaveWithoutField()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            Assert.Throws<AggregateException>(
                () =>  service.Save(new Activity
                    {
                        Name = "teste1",
                        InitialDate = DateTime.Now,
                        FinalDate = DateTime.Now.AddDays(1),
                        Finished = false
                    }
                ).Result
            );
        }

        [Fact]
        public void UpdateWithoutField()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            var activity = service.Get(1).Result;

            activity.ProjectId = 0;

            Assert.Throws<AggregateException>(
                () =>  service.Update(activity).Wait()
            );
        }

        [Fact]
        public void UpdateNormal()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            var activity = service.Get(1).Result;

            activity.Name = "testeUpdate";

            service.Update(activity).Wait();

            var newActivity = service.Get(1).Result;

            Assert.Equal("testeUpdate" , newActivity.Name);
        }

        [Fact]
        public void DeleteNormal()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            service.Delete(1, 1).Wait();

            var activity = service.Get(1).Result;

            Assert.Null(activity);
        }

        [Fact]
        public void ValidDatesWithException()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            Exception ex = Assert.Throws<Exception>(
                () => service.ValidDates(DateTime.Now.AddDays(-1), DateTime.Now));

            Assert.Equal("Data inicial da Atividade não pode ser menor que data inicial do projeto", ex.Message);
        }

        [Fact]
        public void ValidDatesWithoutException()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);
            try
            {
                service.ValidDates(DateTime.Now, DateTime.Now.AddDays(-1));
                Assert.True(true);
            }
            catch {
                Assert.True(false);
            }
        }

        [Fact]
        public void ValidDatesEquals()
        {
            using var context = StartDb.Start();

            var repoA = new ActivityRepository(context);

            var service = new ActivityService(repoA);

            try
            {
                var date = DateTime.Now;

                service.ValidDates(date, date);

                Assert.True(true);
            }
            catch {
                Assert.True(false);
            }
        }
    }
}
