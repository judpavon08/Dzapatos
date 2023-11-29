using System;

namespace Domain.Endpoint.Entities
{
    public enum ToDoStatus
    {
        InProgress,
        Completed,
        NotStarted
    }

    public class ToDo : BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public ToDoStatus Status { get; set; }
        public Nullable<DateTime> StartedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
