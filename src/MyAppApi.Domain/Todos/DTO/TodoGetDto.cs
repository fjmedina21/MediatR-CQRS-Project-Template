namespace MyAppApi.Domain.Todos.DTO
{
	public class TodoGetDto
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Title { get; set; } = string.Empty;
		public bool IsCompleted { get; set; } = false;
		public DateTime? CompletedAtUtc { get; set; } = null;

	}
}
