using TCSA.OOP.LibraryManagementSystem;

UserInterface userInterface = new();
userInterface.MainMenu();

internal abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    protected Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Abstract method that must be implemented by derived classes
    public abstract void MakeSound();
}

internal class Dog : Animal
{
    public Dog(string name, int age) : base(name, age)
    {

    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}
