﻿namespace TaskTodoApi.Dtos
{
    public class CreateTaskTodoDto
    {
        public string Department { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
