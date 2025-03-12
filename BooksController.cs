using Spectre.Console;

namespace TCSA.OOP.LibraryManagementSystem
{
    internal class BooksController
    {

        internal void ViewBooks()
        {
            AnsiConsole.MarkupLine("[yellow]List of Books:[/]");

            foreach (Book book in MockDatabase.Books)
            {
                AnsiConsole.MarkupLine($"- [cyan]{book.Name}[/]");
            }

            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
        }

        internal void AddBook()
        {
            string? title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book you'd like to add:");
            int pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] the book contains:");

            if (MockDatabase.Books.Exists(book => book.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                AnsiConsole.MarkupLine("[red]This book already exists.[/]");
            }
            else
            {
                Book newBook = new(title, pages);
                MockDatabase.Books.Add(newBook);
                AnsiConsole.MarkupLine("[green]Book added successfully![/]");
            }

            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
        }

        internal void DeleteBook()
        {
            if (MockDatabase.Books.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                .Title("Select a [red]book[/] to delete:")
                .UseConverter(book => $"{book.Name}")
                .AddChoices(MockDatabase.Books));

            if (MockDatabase.Books.Remove(bookToDelete))
            {
                AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Book not found.[/]");
            }

            AnsiConsole.MarkupLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}
