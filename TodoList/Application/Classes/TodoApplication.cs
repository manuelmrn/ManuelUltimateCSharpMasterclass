using System;
using System.Linq;
using TodoList.Application.Enums;
using TodoList.TodoService.Services;

namespace TodoList.Application.Classes
{
	public class TodoApplication
	{
		private MenuOption _option;
		private readonly TodoListService _todoListService;

		public TodoApplication()
		{
			_option = MenuOption.None;
			_todoListService = new TodoListService();
		}

		public void Run()
		{
			while (_option != MenuOption.Quit)
			{
				ConsoleUi.DisplayApplicationHeader();

				ConsoleUi.DisplayMenu();

				_option = ConsoleUi.ReadMenuOption();

				HandleMenuOption(_option);

				ConsoleUi.ClearScreen();
			}
		}

		private void HandleMenuOption(MenuOption option)
		{
			switch (option)
			{
				case MenuOption.ListTodos:
					ListTodos();
					break;
				case MenuOption.AddTodo:
					AddTodo();
					break;
				case MenuOption.EditTodo:
					// EditTodo();
					break;
				case MenuOption.DeleteTodo:
					// DeleteTodo();
					break;
				case MenuOption.ClearScreen:
					ConsoleUi.ClearScreen();
					break;
				case MenuOption.Quit:
					ConsoleUi.DisplayGoodbyeMessage();
					break;
				case MenuOption.Invalid:
					ConsoleUi.DisplayInvalidOptionMessage();
					break;
				default:
					ConsoleUi.DisplayInvalidOptionMessage();
					break;
			}
		}

		public void ListTodos()
		{
			var todoCollection = _todoListService.GetTodos();

			if (todoCollection.Any())
			{
				var titleMaxLength = Math.Max("Title".Length, todoCollection.Max(todo => todo.Title.Length));
				var descriptionMaxLength = Math.Max("Description".Length, todoCollection.Max(todo => todo.Description.Length));
				var dueDateMaxLength = Math.Max("Due Date".Length, todoCollection.Max(todo => todo.DueDate.ToShortDateString().Length));
				var statusMaxLength = Math.Max("Status".Length, todoCollection.Max(todo => todo.Status.ToString().Length));

				ConsoleUi.DisplayMessage($"\n| {"Title".PadRight(titleMaxLength)} | {"Description".PadRight(descriptionMaxLength)} | {"Due Date".PadRight(dueDateMaxLength)} | {"Status".PadRight(statusMaxLength)} |");
				ConsoleUi.DisplayMessage(new string('-', titleMaxLength + descriptionMaxLength + dueDateMaxLength + statusMaxLength + 10));

				foreach (var todo in todoCollection)
				{
					ConsoleUi.DisplayMessage($"" +
						$"| {todo.Title.PadRight(titleMaxLength)} " +
						$"| {todo.Description.PadRight(descriptionMaxLength)} " +
						$"| {todo.DueDate.ToShortDateString().PadRight(dueDateMaxLength)} " +
						$"| {todo.Status.ToString().PadRight(statusMaxLength)} |");
				}

				ConsoleUi.DisplayMessage("\n");

				ConsoleUi.DisplayPressAnyKeyToContinueMessage();
			}
			else
			{
				ConsoleUi.DisplayNoTodosFoundMessage();
			}
		}

		private void AddTodo()
		{
			var title = ConsoleUi.ReadTitle();
			var description = ConsoleUi.ReadDescription();
			var dueDate = ConsoleUi.ReadDueDate();

			try
			{
				_todoListService.AddTodo(title, description, dueDate);

				ConsoleUi.DisplayTodoAddedMessage();
			}
			catch (Exception e)
			{
				ConsoleUi.DisplayErrorMessage(e.Message);
			}
		}
	}
}
