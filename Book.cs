namespace TCSA.OOP.LibraryManagementSystem
{
    internal class Book
    {
        string Name;
        int Pages;

        internal Book()
        {
            Name = "Unknown";
            Pages = 0;
        }

        internal Book(int pages)
        {
            Name = "Unknown";
            Pages = pages;
            Console.WriteLine($"Name: {Name}, Pages = {Pages}");
        }

        internal Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
            Console.WriteLine($"Name: {Name}, Pages = {Pages}");
        }
    }
}
