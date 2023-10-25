using System;

// lớp (Class) Person
public class Person
{
    // Thuộc tính (Property) Name
    public string Name { get; set; }

    // Phương thức (Method) SayHello
    public void Hello()
    {
        Console.WriteLine("Hello, my name is " + Name);
    }
}



// lớp Kế thừa
// Lớp cơ sở (lớp cha)
class Animal
{
    public string Name { get; set; }

    public void Eat()
    {
        Console.WriteLine(Name + " is eating.");
    }
}

// Lớp dẫn xuất (lớp con) kế thừa từ lớp cơ sở
class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine(Name + " is barking.");
    }
}
class Program
{
    static void Main()
    {
        
        Dog dog = new Dog();
        dog.Name = "Buddy";
        dog.Eat();
        dog.Bark();

        Person person = new Person();

        // Gán giá trị cho thuộc tính Name của đối tượng
        person.Name = "Khang";

        // Gọi phương thức SayHello của đối tượng
        person.Hello();
        //Đa hình
        Vehicle vehicle1 = new Car("Toyota");
        vehicle1.Start();
    }
}

// Lớp cơ sở (lớp cha)
class Vehicle
{
    public string Name { get; set; }

    public Vehicle(string name)
    {
        Name = name;
    }

    public virtual void Start()
    {
        Console.WriteLine(Name + " is starting.");
    }
}

// Lớp dẫn xuất (lớp con) ô tô "Đa hình (Polymorphism)"
class Car : Vehicle
{
    public Car(string name) : base(name)
    {
    }

    public override void Start()
    {
        Console.WriteLine(Name + " is starting with a key!");
    }
}
