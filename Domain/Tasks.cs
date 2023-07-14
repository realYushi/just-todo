using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public string? Title { get; set; }
        public string? Context { get; set; }
        public string? Description { get; set; }
        public bool HelpMe { get; set; }
        public Guid? ParentId { get; set; }
        public bool Completed { get; set; }
        public int Order { get; set; }
        public List<Tasks>? SubTasks { get; set; }

        [NotMapped]
        public int CompletionPercentage
        {
            get
            {
                if (SubTasks == null || SubTasks.Count == 0) return Completed ? 100 : 0;

                int completedSubTasks = SubTasks.Count(st => st.Completed);
                return (completedSubTasks * 100) / SubTasks.Count;
            }
        }

        public Tasks()
        {
            SubTasks = new List<Tasks>();
        }
    }
}
