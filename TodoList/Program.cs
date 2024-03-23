using TodoList.Application.Classes;

namespace TodoList
{
	class Program
	{
		static void Main(string[] args)
		{
			var app = new TodoApplication();

			app.Run();
		}
	}
}
