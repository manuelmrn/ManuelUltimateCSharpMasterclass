using System;
using System.Globalization;
using TodoList.Application.Enums;

namespace TodoList.Application.Classes
{
	internal static class ConsoleUi
	{
		public static void DisplayApplicationHeader()
		{
			Console.WriteLine("Todo List Manager App");
			Console.WriteLine("=====================\n");
		}

		public static void DisplayMenu()
		{
			Console.WriteLine("Select an Option from the List:");
			Console.WriteLine("[L]ist Todos.");
			Console.WriteLine("[A]dd Todo.");
			Console.WriteLine("[E]dit Todo.");
			Console.WriteLine("[D]elete Todo.");
			Console.WriteLine("[C]lear the screen.");
			Console.WriteLine("[Q]uit.");
		}

		public static MenuOption ReadMenuOption()
		{
			var input = Console.ReadLine();

			var option = GetMenuOptionFromInput(input);

			return option;
		}

		private static MenuOption GetMenuOptionFromInput(string? input)
		{
			if (string.IsNullOrWhiteSpace(input))
				return MenuOption.None;
			if (input.Length > 1)
				return MenuOption.Invalid;

			var key = input[..1].ToUpper();

			var option = key switch
			{
				"L" => MenuOption.ListTodos,
				"A" => MenuOption.AddTodo,
				"E" => MenuOption.EditTodo,
				"D" => MenuOption.DeleteTodo,
				"C" => MenuOption.ClearScreen,
				"Q" => MenuOption.Quit,
				_ => MenuOption.Invalid
			};

			return option;
		}

		public static void DisplayMessage(string message)
		{
			if (string.IsNullOrWhiteSpace(message))
				throw new ArgumentException($"'{nameof(message)}' cannot be null or whitespace.", nameof(message));

			Console.WriteLine(message);
		}

		public static void DisplayInvalidOptionMessage()
		{
			Console.WriteLine("Invalid option. Please try again.");

			DisplayPressAnyKeyToContinueMessage();
		}

		public static void DisplayPressAnyKeyToContinueMessage()
		{
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}

		public static void DisplayNoTodosFoundMessage()
		{
			Console.WriteLine("No todos found.");

			DisplayPressAnyKeyToContinueMessage();
		}

		public static void DisplayTodoAddedMessage()
		{
			Console.WriteLine("Todo added successfully.");

			DisplayPressAnyKeyToContinueMessage();
		}

		public static void DisplayErrorMessage(string message)
		{
			Console.WriteLine(message);

			DisplayPressAnyKeyToContinueMessage();
		}

		public static void DisplayGoodbyeMessage()
		{
			Console.WriteLine("Goodbye!");

			DisplayPressAnyKeyToContinueMessage();
		}

		public static void ClearScreen()
		{
			Console.Clear();
		}

		public static string? ReadTitle()
		{
			Console.Write("Enter the title: ");

			var title = Console.ReadLine();

			return title;
		}

		public static string? ReadDescription()
		{
			Console.Write("Enter the description: ");

			var description = Console.ReadLine();

			return description;
		}

		public static DateTime ReadDueDate()
		{
			Console.Write("Enter the due date: ");

			var input = Console.ReadLine();
			var dueDate = DateTime.MinValue;

			_ = input is not null && DateTime.TryParse(input, CultureInfo.InvariantCulture, out dueDate);

			return dueDate;
		}
	}
}
