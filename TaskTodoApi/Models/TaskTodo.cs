namespace TaskTodoApi.Models
{
    public class TaskTodo
    {
        public int Id { get; set; }
        public string Department {  get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set;}
    }
}
