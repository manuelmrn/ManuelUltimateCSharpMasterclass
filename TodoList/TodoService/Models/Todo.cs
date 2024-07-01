using System;
using TodoList.TodoService.Enums;

namespace TodoList.TodoService.Models
{
	public class Todo
	{
		private readonly int _id;
		private readonly DateTime _createdAt;

		private string _title;
		private string _description;
		private TodoStatus _status;
		private DateTime _dueDate;
		private DateTime _updatedAt;

		public int Id => _id;
		public string Title => _title;
		public string Description => _description;
		public TodoStatus Status => _status;
		public DateTime DueDate => _dueDate;
		public DateTime CreatedAt => _createdAt;
		public DateTime UpdatedAt => _updatedAt;

		public Todo(string title, string description, DateTime dueDate, int id = 0, TodoStatus todoStatus = TodoStatus.NotStarted)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"The '{nameof(title)}' cannot be null or whitespace.", nameof(title));
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException($"The '{nameof(description)}' cannot be null or whitespace.", nameof(description));
			if (dueDate.Ticks < DateTime.Now.Ticks)
				throw new ArgumentOutOfRangeException(nameof(dueDate), $"The '{nameof(dueDate)}' cannot be in the past.");

			_id = id;
			_title = title;
			_status = todoStatus;
			_description = description;
			_dueDate = dueDate;
			_createdAt = DateTime.Now;
			_updatedAt = DateTime.MinValue;
		}

		public void UpdateTitle(string title)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"The '{nameof(title)}' cannot be null or whitespace.", nameof(title));

			_title = title;
			_updatedAt = DateTime.Now;
		}

		public void UpdateDescription(string description)
		{
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException($"The '{nameof(description)}' cannot be null or whitespace.", nameof(description));

			_description = description;
			_updatedAt = DateTime.Now;
		}

		public void UpdateStatus(TodoStatus status)
		{
			_status = status;
			_updatedAt = DateTime.Now;
		}

		public void UpdateDueDate(DateTime dueDate)
		{
			if (dueDate.Ticks < DateTime.Now.Ticks)
				throw new ArgumentOutOfRangeException(nameof(dueDate), $"The '{nameof(dueDate)}' cannot be in the past.");

			_dueDate = dueDate;
			_updatedAt = DateTime.Now;
		}

		public override string ToString()
		{
			return $"Id: {Id}, Title: {Title}, Description: {Description}, Status: {Status}, DueDate: {DueDate}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
		}

		public override bool Equals(object? obj)
		{
			if (obj is Todo todo)
			{
				return todo.Id == Id &&
					   todo.Title == Title &&
					   todo.Description == Description &&
					   todo.Status == Status &&
					   todo.DueDate == DueDate &&
					   todo.CreatedAt == CreatedAt &&
					   todo.UpdatedAt == UpdatedAt;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Title, Description, Status, DueDate, CreatedAt, UpdatedAt);
		}
	}
}
