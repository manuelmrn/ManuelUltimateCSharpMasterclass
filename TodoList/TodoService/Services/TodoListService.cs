using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.TodoService.Enums;
using TodoList.TodoService.Models;

namespace TodoList.TodoService.Services
{
	public class TodoListService
	{
		private readonly IList<Todo> _todoList;

		public TodoListService()
		{
			_todoList = [];
		}

		public void AddTodo(string title, string description, DateTime dueDate)
		{
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title));
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException($"'{nameof(description)}' cannot be null or whitespace.", nameof(description));
			if (dueDate.Ticks < DateTime.Now.Ticks)
				throw new ArgumentOutOfRangeException(nameof(dueDate), $"The '{nameof(dueDate)}' cannot be in the past.");

			var id = GetNextId();

			var todo = new Todo(title, description, dueDate, id, TodoStatus.NotStarted);

			_todoList.Add(todo);
		}

		private int GetNextId()
		{
			var id = 0;

			if (_todoList.Any())
			{
				id = _todoList.Max(todo => todo.Id);
			}

			return id;
		}

		public void DeleteTodoById(int id)
		{
			if (id < 0 || id > _todoList.Max(todo => todo.Id))
				throw new ArgumentOutOfRangeException(nameof(id), $"The '{nameof(id)}' parameter is out of range.");

			var targetTodo = _todoList.FirstOrDefault(todo => todo.Id == id);

			targetTodo?.UpdateStatus(TodoStatus.Deleted);
		}

		public void UpdateTodoTitle(int id, string title)
		{
			if (id < 0 || id > _todoList.Max(todo => todo.Id))
				throw new ArgumentOutOfRangeException(nameof(id), $"The '{nameof(id)}' parameter is out of range.");
			if (string.IsNullOrWhiteSpace(title))
				throw new ArgumentException($"The '{nameof(title)}' cannot be null or whitespace.", nameof(title));

			var targetTodo = _todoList.FirstOrDefault(todo => todo.Id == id);

			targetTodo?.UpdateTitle(title);
		}

		public void UpdateTodoDescription(int id, string description)
		{
			if (id < 0 || id > _todoList.Max(todo => todo.Id))
				throw new ArgumentOutOfRangeException(nameof(id), $"The '{nameof(id)}' parameter is out of range.");
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentException($"The '{nameof(description)}' cannot be null or whitespace.", nameof(description));

			var targetTodo = _todoList.FirstOrDefault(todo => todo.Id == id);

			targetTodo?.UpdateDescription(description);
		}

		public void UpdateTodoDueDate(int id, DateTime dueDate)
		{
			if (id < 0 || id > _todoList.Max(todo => todo.Id))
				throw new ArgumentOutOfRangeException(nameof(id), $"The '{nameof(id)}' parameter is out of range.");
			if (dueDate.Ticks < DateTime.Now.Ticks)
				throw new ArgumentOutOfRangeException(nameof(dueDate), $"The '{nameof(dueDate)}' cannot be in the past.");

			var targetTodo = _todoList.FirstOrDefault(todo => todo.Id == id);

			targetTodo?.UpdateDueDate(dueDate);
		}

		public void UpdateTodoStatus(int id, TodoStatus status)
		{
			if (id < 0 || id > _todoList.Max(todo => todo.Id))
				throw new ArgumentOutOfRangeException(nameof(id), $"The '{nameof(id)}' parameter is out of range.");

			var targetTodo = _todoList.FirstOrDefault(todo => todo.Id == id);

			targetTodo?.UpdateStatus(status);
		}

		public IEnumerable<Todo> GetTodos()
		{
			return _todoList;
		}

		public IEnumerable<Todo> GetTodosByStatus(TodoStatus status)
		{
			return _todoList.Where(todo => todo.Status == status);
		}

		public IEnumerable<Todo> GetTodosByDueDate(DateTime dueDate)
		{
			return _todoList.Where(todos => todos.DueDate.Date == dueDate.Date);
		}
	}
}
