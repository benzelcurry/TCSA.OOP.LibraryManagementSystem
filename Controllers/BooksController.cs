using Spectre.Console;
using TCSA.OOP.LibraryManagementSystem.Models;

namespace TCSA.OOP.LibraryManagementSystem.Controllers
{
    internal class BooksController : IBaseController
    {

        public void ViewItems()
        {
            Table table = new();
            table.Border(TableBorder.Rounded);

            table.AddColumn("[yellow]ID[/]");
            table.AddColumn("[yellow]Title[/]");
            table.AddColumn("[yellow]Author[/]");
            table.AddColumn("[yellow]Category[/]");
            table.AddColumn("[yellow]Location[/]");
            table.AddColumn("[yellow]Pages[/]");

            var books = MockDatabase.LibraryItems.OfType<Book>();

            foreach (var book in books)
            {
                table.AddRow(
                    book.Id.ToString(),
                    $"[cyan]{book.Name}[/]",
                    $"[cyan]{book.Author}[/]",
                    $"[green]{book.Category}[/]",
                    $"[blue]{book.Location}[/]",
                    book.Pages.ToString()
                    );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
        }

        public void AddItem()
        {
            string? title = AnsiConsole.Ask<string>("Enter the [green]title[/] of the book to add:");
            string? author = AnsiConsole.Ask<string>("Enter the [green]author[/] of the book:");
            string? category = AnsiConsole.Ask<string>("Enter the [green]category[/] of the book:");
            string? location = AnsiConsole.Ask<string>("Enter the [green]location[/] of the book:");
            int pages = AnsiConsole.Ask<int>("Enter the [green]number of pages[/] in the book:");

            if (MockDatabase.LibraryItems.OfType<Book>().Any(b => b.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                AnsiConsole.MarkupLine("[red]This book already exists.[/]");
            }
            else
            {
                Book newBook = new(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
                MockDatabase.LibraryItems.Add(newBook);
                AnsiConsole.MarkupLine("[green]Book added successfully![/]");
            }

            AnsiConsole.MarkupLine("Press Any Key to Continue.");
            Console.ReadKey();
        }

        public void DeleteItem()
        {
            if (MockDatabase.LibraryItems.OfType<Book>().Count() == 0)
            {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                .Title("Select a [red]book[/] to delete:")
                .UseConverter(book => $"{book.Name}")
                .AddChoices(MockDatabase.LibraryItems.OfType<Book>()));

            if (MockDatabase.LibraryItems.Remove(bookToDelete))
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
