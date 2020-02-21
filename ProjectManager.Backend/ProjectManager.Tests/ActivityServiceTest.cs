using System;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Services;
using ProjectManager.Entities.Context;
using ProjectManager.Repositories;
using ProjectManager.Tests.ContextInMemory;
using Xunit;

namespace ProjectManager.Tests
{
    public class ActivityServiceTest
    {
        [Fact]
        public void Save()
        {
            var options =  StartDb.Start();
            using var context = options;
            
            var repoA = new ActivityRepository(context);
            var repoR = new ProjectRepository(context);
            var service = new ActivityService(repoA, repoR);
        }
    }
}
