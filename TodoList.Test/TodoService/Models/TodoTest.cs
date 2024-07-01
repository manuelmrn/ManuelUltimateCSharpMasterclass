using TodoList.TodoService.Enums;
using TodoList.TodoService.Models;

namespace TodoList.Test.TodoService.Models
{
	[TestFixture]
	internal class TodoTest
	{
		[Test]
		public void Todo_WhenTitleIsNull_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo(null, "description", DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenTitleIsEmpty_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo(string.Empty, "description", DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenTitleIsWhiteSpace_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo(" ", "description", DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenDescriptionIsNull_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo("title", null, DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenDescriptionIsEmpty_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo("title", string.Empty, DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenDescriptionIsWhiteSpace_ThrowsArgumentException()
		{
			Assert.Throws<ArgumentException>(() => new Todo("title", " ", DateTime.Now.AddDays(1)));
		}

		[Test]
		public void Todo_WhenDueDateIsInThePast_ThrowsArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new Todo("title", "description", DateTime.Now.AddDays(-1)));
		}

		[Test]
		public void Todo_WhenTitleDescriptionAndDueDateAreValid_CreatesTodo()
		{
			var title = "title";
			var description = "description";
			var dueDate = DateTime.Now.AddDays(1);

			var todo = new Todo(title, description, dueDate);

			Assert.Multiple(() =>
			{
				Assert.That(todo.Title, Is.EqualTo(title));
				Assert.That(todo.Description, Is.EqualTo(description));
				Assert.That(todo.DueDate, Is.EqualTo(dueDate));
				Assert.That(todo.Status, Is.EqualTo(TodoStatus.NotStarted));
				Assert.That(todo.CreatedAt, Is.EqualTo(DateTime.Now).Within(1).Seconds);
				Assert.That(todo.UpdatedAt, Is.EqualTo(DateTime.MinValue));
			});
		}
	}
}
