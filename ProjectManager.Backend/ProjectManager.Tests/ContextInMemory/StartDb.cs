using Microsoft.EntityFrameworkCore;
using ProjectManager.Entities.Context;

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

            return context;
        }
    }
}