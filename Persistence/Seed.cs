using Task = System.Threading.Tasks.Task;

namespace Persistence
{
    public class DataSeeder
    {
        public static async Task SeedData(DataContext dbContext)
        {
            // Check if data already exists
            if (dbContext.Tasks.Any())
            {
                return; // Data has already been seeded
            }

            // Seed your data
            var tasks = new List<Domain.Tasks>
            {
                new Domain.Tasks
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.UtcNow,
                    Title = "Task 1",
                    Description = "Description of Task 1",
                    HelpMe = true,
                    ParentId = null,
                    Completed = false,
                    Order = 1,
                    SubTasks = new List<Domain.Tasks>
                    {
                        new Domain.Tasks
                        {
                            Id = Guid.NewGuid(),
                            CreatedTime = DateTime.UtcNow,
                            Title = "Subtask 1 of Task 1",
                            Description = "Description of Subtask 1",
                            HelpMe = false,
                            ParentId = null,
                            Completed = true,
                            Order = 1
                        },
                        new Domain.Tasks
                        {
                            Id = Guid.NewGuid(),
                            CreatedTime = DateTime.UtcNow,
                            Title = "Subtask 2 of Task 1",
                            Description = "Description of Subtask 2",
                            HelpMe = false,
                            ParentId = null,
                            Completed = false,
                            Order = 2
                        }
                    }
                },
                new Domain.Tasks
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.UtcNow,
                    Title = "Task 2",
                    Description = "Description of Task 2",
                    HelpMe = false,
                    ParentId = null,
                    Completed = false,
                    Order = 2,
                    SubTasks = null
                },
                new Domain.Tasks
                {
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.UtcNow,
                    Title = "Task 3",
                    Description = "Description of Task 3",
                    HelpMe = false,
                    ParentId = null,
                    Completed = true,
                    Order = 3,
                    SubTasks = null,
                }
            };
            // Set the ParentId of subtasks to their parent's Id
            foreach (var task in tasks)
            {
                if (task.SubTasks != null)
                {
                    foreach (var subtask in task.SubTasks)
                    {
                        subtask.ParentId = task.Id;
                    }
                }
            }



            dbContext.Tasks.AddRange(tasks);
            dbContext.SaveChanges();
        }
    }
}
