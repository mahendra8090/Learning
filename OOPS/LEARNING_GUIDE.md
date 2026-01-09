# Object-Oriented Programming (OOP) in C#

A comprehensive guide to mastering Object-Oriented Programming concepts and principles in C#.

---

## Overview

Object-Oriented Programming (OOP) is a programming paradigm based on the concept of "objects" that contain data (attributes) and code (methods). OOP enables developers to organize code in a more intuitive, modular, and maintainable way.

### Core Philosophy
- **Real-world Modeling**: Objects represent real-world entities
- **Modularity**: Code organized into self-contained objects
- **Reusability**: Code can be reused through inheritance and composition
- **Maintainability**: Clear structure makes code easier to understand and modify
- **Flexibility**: Polymorphism allows flexible code design

---

## Part 1: Fundamentals of OOP

### 1. Classes and Objects

#### What is a Class?
- Blueprint for creating objects
- Defines properties (attributes) and methods (behaviors)
- Template for object creation
- Logical grouping of related data and functionality

#### What is an Object?
- Instance of a class
- Created from class blueprint
- Contains actual data
- Has independent state

#### Creating Classes and Objects

```csharp
// Class Definition
public class Person
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Methods
    public void Introduce()
    {
        Console.WriteLine($"Hello, I'm {Name} and I'm {Age} years old");
    }
}

// Object Creation
Person person1 = new Person();
person1.Name = "John";
person1.Age = 30;
person1.Introduce(); // Output: Hello, I'm John and I'm 30 years old
```

#### Key Concepts
- Object creation with `new` keyword
- Constructor usage
- Object lifetime and garbage collection
- Reference types vs value types
- Object identity vs equality

#### Best Practices
- Use meaningful class names (PascalCase)
- Keep classes focused and cohesive
- Initialize objects properly
- Consider immutability where appropriate
- Use auto-properties for simple properties

### 2. Properties and Fields

#### Fields
- Store actual data
- Usually private
- Direct memory location
- Mutable state container

```csharp
public class BankAccount
{
    private decimal _balance; // Field
    
    public decimal GetBalance()
    {
        return _balance;
    }
}
```

#### Properties
- Public interface to fields
- Encapsulate field access
- Enable validation and logic
- Preferred over public fields

```csharp
public class BankAccount
{
    private decimal _balance;
    
    public decimal Balance
    {
        get { return _balance; }
        set
        {
            if (value >= 0)
                _balance = value;
        }
    }
}
```

#### Auto-Properties
- Simplified property syntax
- Compiler generates backing field
- Clean and readable

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; private set; } // Read-only outside class
}
```

#### Init-only Properties (.NET 5+)
- Set value only during initialization
- Creates immutable objects

```csharp
public class Point
{
    public int X { get; init; }
    public int Y { get; init; }
}

// Usage
Point p = new Point { X = 10, Y = 20 };
// p.X = 30; // Error: init-only property
```

#### Indexed Properties
- Access object like array
- Useful for collection-like objects

```csharp
public class Matrix
{
    private int[,] _data = new int[3, 3];
    
    public int this[int row, int col]
    {
        get { return _data[row, col]; }
        set { _data[row, col] = value; }
    }
}

// Usage
Matrix m = new Matrix();
m[0, 0] = 5;
```

### 3. Methods

#### Method Definition and Invocation
- Methods perform actions
- Accept parameters and return values
- Static vs instance methods
- Method overloading

```csharp
public class Calculator
{
    // Instance method
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    // Static method
    public static int Multiply(int a, int b)
    {
        return a * b;
    }
    
    // Method with out parameter
    public bool TryDivide(int a, int b, out int result)
    {
        if (b != 0)
        {
            result = a / b;
            return true;
        }
        result = 0;
        return false;
    }
    
    // Method with ref parameter
    public void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
```

#### Method Overloading
- Same method name, different parameters
- Parameter type, number, or order must differ
- Resolved at compile time

```csharp
public class Printer
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
    
    public void Print(int number)
    {
        Console.WriteLine(number);
    }
    
    public void Print(string text, int count)
    {
        for (int i = 0; i < count; i++)
            Console.WriteLine(text);
    }
}
```

#### Named and Optional Parameters
- Improve code readability
- Default values for optional parameters

```csharp
public class Report
{
    public void Generate(string title, string author = "Unknown", int year = 2024)
    {
        Console.WriteLine($"{title} by {author} ({year})");
    }
}

// Usage
Report r = new Report();
r.Generate("C# Guide");
r.Generate("C# Guide", author: "Microsoft");
r.Generate("C# Guide", year: 2023);
```

#### Params Keyword
- Accept variable number of parameters
- Must be last parameter

```csharp
public class Sum
{
    public int Calculate(params int[] numbers)
    {
        int total = 0;
        foreach (int num in numbers)
            total += num;
        return total;
    }
}

// Usage
int result = sum.Calculate(1, 2, 3, 4, 5); // Result: 15
```

### 4. Constructors

#### Purpose and Usage
- Initialize objects
- Set up initial state
- Called when object is created
- Only one constructor executes per instantiation

```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    // Default constructor (parameterless)
    public Person()
    {
        Name = "Unknown";
        Age = 0;
    }
    
    // Parameterized constructor
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
```

#### Constructor Chaining
- Constructors calling other constructors
- Reduces code duplication
- Uses `this` keyword

```csharp
public class Student
{
    public string Name { get; set; }
    public int StudentId { get; set; }
    public string Grade { get; set; }
    
    public Student() : this("Unknown", 0, "N/A")
    {
    }
    
    public Student(string name, int id) : this(name, id, "N/A")
    {
    }
    
    public Student(string name, int id, string grade)
    {
        Name = name;
        StudentId = id;
        Grade = grade;
    }
}
```

#### Static Constructor
- Initialize static members
- Called before first use of class
- No access modifier
- Called only once

```csharp
public class Configuration
{
    public static string AppName { get; private set; }
    public static string Version { get; private set; }
    
    static Configuration()
    {
        AppName = "MyApp";
        Version = "1.0.0";
    }
}
```

#### Object Initializer Syntax
- Initialize properties during creation
- Clean and readable

```csharp
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}

// Usage
Product p = new Product 
{ 
    Name = "Laptop", 
    Price = 1000, 
    Category = "Electronics" 
};
```

---

## Part 2: Four Pillars of OOP

### 1. Encapsulation

#### Definition
- Bundling data and methods together
- Hiding internal implementation details
- Controlling access through public interface
- Protection of object state

#### Access Modifiers

| Modifier | Visibility | Use Case |
|----------|-----------|----------|
| `public` | Everywhere | Public interface |
| `private` | Class only | Internal implementation |
| `protected` | Class and derived classes | Inheritance-based access |
| `internal` | Assembly only | Internal framework code |
| `protected internal` | Assembly and derived classes | Framework extension points |
| `private protected` | Class and derived classes in same assembly | Internal derived classes |

#### Benefits of Encapsulation
- Data protection and integrity
- Flexibility to change internal implementation
- Validation of data
- Reduced coupling
- Better maintainability

#### Example: Bank Account

```csharp
public class BankAccount
{
    private decimal _balance;
    private List<string> _transactions;
    
    public BankAccount(decimal initialBalance)
    {
        if (initialBalance < 0)
            throw new ArgumentException("Initial balance cannot be negative");
        
        _balance = initialBalance;
        _transactions = new List<string>();
        _transactions.Add($"Account opened with ${initialBalance}");
    }
    
    public decimal Balance
    {
        get { return _balance; }
    }
    
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive");
        
        _balance += amount;
        _transactions.Add($"Deposit: ${amount}");
    }
    
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive");
        
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds");
        
        _balance -= amount;
        _transactions.Add($"Withdrawal: ${amount}");
    }
    
    public void PrintStatement()
    {
        Console.WriteLine($"Current Balance: ${_balance}");
        Console.WriteLine("Transactions:");
        foreach (var transaction in _transactions)
            Console.WriteLine($"  - {transaction}");
    }
}
```

### 2. Inheritance

#### Definition
- Creating new classes based on existing classes
- Parent class (base class) and child class (derived class)
- Code reuse and hierarchical relationships
- Single inheritance in C#

#### Basic Inheritance

```csharp
// Base class
public class Animal
{
    public string Name { get; set; }
    
    public virtual void MakeSound()
    {
        Console.WriteLine("Generic animal sound");
    }
    
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping");
    }
}

// Derived class
public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
    
    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball");
    }
}

// Usage
Dog dog = new Dog { Name = "Buddy" };
dog.MakeSound();  // Output: Buddy says: Woof!
dog.Sleep();      // Output: Buddy is sleeping
dog.Fetch();      // Output: Buddy is fetching the ball
```

#### Access in Inheritance

| Scenario | Base Class | Derived Class | Outside |
|----------|-----------|---------------|---------|
| public | ? | ? | ? |
| protected | ? | ? | ? |
| private | ? | ? | ? |

#### Method Overriding
- Derived class provides new implementation
- Method must be marked `virtual` in base class
- Use `override` in derived class
- Runtime polymorphism

```csharp
public class Shape
{
    public virtual double CalculateArea()
    {
        return 0;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public override double CalculateArea()
    {
        return Width * Height;
    }
}
```

#### Base Class Access
- Use `base` keyword to access parent class members
- Call parent constructor
- Access parent methods

```csharp
public class Vehicle
{
    public string Brand { get; set; }
    
    public virtual void Start()
    {
        Console.WriteLine("Vehicle starting");
    }
}

public class Car : Vehicle
{
    public Car(string brand)
    {
        Brand = brand;
    }
    
    public override void Start()
    {
        base.Start(); // Call parent implementation
        Console.WriteLine($"{Brand} car engine running");
    }
}
```

#### Sealed Classes and Methods
- Prevent inheritance or overriding
- Performance optimization
- Design decision

```csharp
// Cannot be inherited
public sealed class FinalClass
{
}

public class BaseClass
{
    // Cannot be overridden
    public sealed virtual void Method()
    {
    }
}
```

### 3. Polymorphism

#### Definition
- "Many forms" - ability to take multiple forms
- Objects behave differently based on context
- Two types: Compile-time (static) and Runtime (dynamic)

#### Compile-Time Polymorphism (Method Overloading)

```csharp
public class MathOperations
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    
    public double Add(double a, double b)
    {
        return a + b;
    }
    
    public string Add(string a, string b)
    {
        return a + b;
    }
}

// Usage - resolved at compile time
MathOperations math = new MathOperations();
Console.WriteLine(math.Add(5, 10));           // Calls int version
Console.WriteLine(math.Add(5.5, 10.5));       // Calls double version
Console.WriteLine(math.Add("Hello", "World")); // Calls string version
```

#### Runtime Polymorphism (Method Overriding)

```csharp
public class Animal
{
    public virtual void Eat()
    {
        Console.WriteLine("Animal is eating");
    }
}

public class Herbivore : Animal
{
    public override void Eat()
    {
        Console.WriteLine("Herbivore eating plants");
    }
}

public class Carnivore : Animal
{
    public override void Eat()
    {
        Console.WriteLine("Carnivore eating meat");
    }
}

// Usage - resolved at runtime
List<Animal> animals = new List<Animal>
{
    new Herbivore(),
    new Carnivore(),
    new Animal()
};

foreach (Animal animal in animals)
{
    animal.Eat(); // Calls appropriate overridden method
}
```

#### Interface-Based Polymorphism

```csharp
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class CreditCardProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} with credit card");
    }
}

public class PayPalProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing ${amount} with PayPal");
    }
}

// Usage
IPaymentProcessor processor = new CreditCardProcessor();
processor.ProcessPayment(100);
processor = new PayPalProcessor();
processor.ProcessPayment(100);
```

#### Duck Typing and Dynamic
- Runtime type checking
- `dynamic` keyword
- Flexibility with runtime cost

```csharp
public class DataProcessor
{
    public void ProcessData(dynamic data)
    {
        data.Display(); // Method resolved at runtime
    }
}

public class TextData
{
    public void Display()
    {
        Console.WriteLine("Displaying text data");
    }
}

public class NumericData
{
    public void Display()
    {
        Console.WriteLine("Displaying numeric data");
    }
}
```

### 4. Abstraction

#### Definition
- Hiding complexity and showing only essential features
- Creating abstract classes and interfaces
- Defining contracts without implementation
- Focusing on what object does, not how

#### Abstract Classes
- Cannot be instantiated directly
- Can have abstract and concrete methods
- Provide common functionality to derived classes

```csharp
public abstract class DataReader
{
    // Abstract method - must be implemented by derived classes
    public abstract string Read();
    
    // Concrete method
    public void Display()
    {
        string data = Read();
        Console.WriteLine($"Data: {data}");
    }
}

public class FileReader : DataReader
{
    private string _filePath;
    
    public FileReader(string filePath)
    {
        _filePath = filePath;
    }
    
    public override string Read()
    {
        return System.IO.File.ReadAllText(_filePath);
    }
}

public class DatabaseReader : DataReader
{
    private string _connectionString;
    
    public DatabaseReader(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public override string Read()
    {
        return "Data from database";
    }
}

// Usage
DataReader reader = new FileReader("data.txt");
reader.Display();

reader = new DatabaseReader("connection_string");
reader.Display();
```

#### Interfaces
- Define contracts
- Multiple interface implementation
- Focuses on what, not how
- Method signatures only

```csharp
public interface ILogable
{
    void Log(string message);
}

public interface ISearchable
{
    List<T> Search<T>(string query);
}

public class Document : ILogable, ISearchable
{
    public void Log(string message)
    {
        Console.WriteLine($"[Log] {message}");
    }
    
    public List<T> Search<T>(string query)
    {
        // Implementation
        return new List<T>();
    }
}
```

#### Abstract Classes vs Interfaces

| Aspect | Abstract Class | Interface |
|--------|----------------|-----------|
| Instantiation | Cannot | Cannot |
| Inheritance | Single | Multiple |
| State | Can have state | No state |
| Methods | Can be abstract or concrete | Signatures only (C# 8.0+: default implementations) |
| Access Modifiers | Can have various modifiers | Usually public |
| Constructors | Can have constructors | No constructors |
| Use Case | Shared implementation | Contracts |

---

## Part 3: Advanced OOP Concepts

### 1. Static Members

#### Static Fields
- Belong to class, not instance
- Shared among all instances
- Initialized once

```csharp
public class Counter
{
    public static int TotalCount { get; private set; } = 0;
    
    public Counter()
    {
        TotalCount++;
    }
}

Counter c1 = new Counter();
Counter c2 = new Counter();
Console.WriteLine(Counter.TotalCount); // Output: 2
```

#### Static Methods
- Called on class, not instance
- Cannot access instance members
- Useful for utility functions

```csharp
public class MathHelper
{
    public static double SquareRoot(double number)
    {
        return Math.Sqrt(number);
    }
    
    public static int Max(int a, int b)
    {
        return a > b ? a : b;
    }
}

// Usage
double result = MathHelper.SquareRoot(16); // 4
int max = MathHelper.Max(10, 20);          // 20
```

#### Static Classes
- Cannot be inherited
- Only static members
- Utility or helper classes

```csharp
public static class StringHelper
{
    public static string Reverse(string text)
    {
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    
    public static bool IsPalindrome(string text)
    {
        return text == Reverse(text);
    }
}
```

### 2. Nested Classes

#### Definition
- Classes defined inside other classes
- Access to outer class members
- Organizing related classes

```csharp
public class OuterClass
{
    private int _outerValue = 10;
    
    public class InnerClass
    {
        public void DisplayOuterValue(OuterClass outer)
        {
            Console.WriteLine($"Outer value: {outer._outerValue}");
        }
    }
}

// Usage
OuterClass outer = new OuterClass();
OuterClass.InnerClass inner = new OuterClass.InnerClass();
inner.DisplayOuterValue(outer);
```

### 3. Operator Overloading

#### Definition
- Define custom behavior for operators
- Works with classes and structs
- Makes code more intuitive

```csharp
public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // Overload + operator
    public static Vector operator +(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y);
    }
    
    // Overload - operator
    public static Vector operator -(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y);
    }
    
    // Overload == operator
    public static bool operator ==(Vector a, Vector b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    
    // Overload != operator
    public static bool operator !=(Vector a, Vector b)
    {
        return !(a == b);
    }
    
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

// Usage
Vector v1 = new Vector(1, 2);
Vector v2 = new Vector(3, 4);
Vector v3 = v1 + v2; // Vector(4, 6)
Vector v4 = v1 - v2; // Vector(-2, -2)
bool equal = v1 == v2; // false
```

### 4. Type Casting and Conversion

#### Implicit Casting
- Automatic conversion
- No data loss
- Child to parent, smaller to larger

```csharp
int intValue = 10;
double doubleValue = intValue; // Implicit conversion

Animal animal = new Dog(); // Implicit conversion to base class
```

#### Explicit Casting
- Manual conversion required
- Possible data loss
- Use cast operator

```csharp
double doubleValue = 10.5;
int intValue = (int)doubleValue; // Explicit conversion: 10

Animal animal = new Dog();
Dog dog = (Dog)animal; // Explicit cast to derived class
```

#### Safe Casting with `is` and `as`

```csharp
public class AnimalProcessor
{
    public void ProcessAnimal(Animal animal)
    {
        // Using 'is' pattern (C# 7.0+)
        if (animal is Dog dog)
        {
            dog.Bark();
        }
        else if (animal is Cat cat)
        {
            cat.Meow();
        }
        
        // Using 'as' operator
        Dog dog2 = animal as Dog;
        if (dog2 != null)
        {
            dog2.Bark();
        }
    }
}
```

### 5. Generics

#### Generic Classes
- Type-safe containers
- Reusable for different types
- Avoid boxing/unboxing

```csharp
public class Container<T>
{
    private T _value;
    
    public void Add(T item)
    {
        _value = item;
    }
    
    public T Get()
    {
        return _value;
    }
}

// Usage
Container<int> intContainer = new Container<int>();
intContainer.Add(42);
int value = intContainer.Get(); // 42

Container<string> stringContainer = new Container<string>();
stringContainer.Add("Hello");
string text = stringContainer.Get(); // "Hello"
```

#### Generic Methods
- Methods with generic type parameters
- Type inference

```csharp
public class ArrayHelper
{
    public static void PrintArray<T>(T[] array)
    {
        foreach (T item in array)
            Console.WriteLine(item);
    }
    
    public static T GetMax<T>(T[] array) where T : IComparable<T>
    {
        T max = array[0];
        foreach (T item in array)
        {
            if (item.CompareTo(max) > 0)
                max = item;
        }
        return max;
    }
}

// Usage
int[] numbers = { 1, 2, 3, 4, 5 };
ArrayHelper.PrintArray(numbers);

string[] words = { "apple", "banana", "cherry" };
string max = ArrayHelper.GetMax(words); // "cherry"
```

#### Generic Constraints
- Limit type parameters
- Ensure type safety
- Enable compile-time checking

```csharp
// where T : BaseClass - T must derive from BaseClass
public class Repository<T> where T : Entity
{
    public void Save(T item)
    {
        // item has all Entity members
        Console.WriteLine($"Saving {item.Id}");
    }
}

// where T : IComparable - T must implement IComparable
public class SortedCollection<T> where T : IComparable<T>
{
    // Can use T.CompareTo()
}

// where T : new() - T must have parameterless constructor
public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();
    }
}

// Multiple constraints
public class Container<T> where T : class, ISerializable, new()
{
    // T must be reference type, implement ISerializable, and have parameterless constructor
}
```

### 6. Nullable Types

#### Reference Types
- Can be null by default
- Nullable reference types feature (C# 8.0+)

```csharp
#nullable enable

public class Person
{
    public string? Name { get; set; } // Can be null
    public string Email { get; set; }  // Cannot be null (compiler warning if assigned null)
    
    public void Introduce()
    {
        if (Name != null)
            Console.WriteLine($"I'm {Name}");
    }
}
```

#### Value Types
- Use `Nullable<T>` or `T?` syntax
- Can be null

```csharp
int? age = null;
if (age.HasValue)
{
    Console.WriteLine($"Age: {age.Value}");
}
else
{
    Console.WriteLine("Age not set");
}

// Null-coalescing operator
int actualAge = age ?? 0; // 0 if age is null

// Null-conditional operator
string? description = age?.ToString(); // null if age is null
```

### 7. Extension Methods

#### Definition
- Add methods to existing classes
- Static methods in static classes
- Appear as instance methods

```csharp
public static class StringExtensions
{
    public static string Reverse(this string text)
    {
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
    
    public static bool IsPalindrome(this string text)
    {
        return text == text.Reverse();
    }
}

// Usage
string text = "racecar";
string reversed = text.Reverse(); // "racecar"
bool isPalin = text.IsPalindrome(); // true
```

### 8. LINQ (Language Integrated Query)

#### Query Syntax
- SQL-like syntax for collections
- Declarative approach

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

var evenNumbers = from n in numbers
                  where n % 2 == 0
                  select n;

foreach (int num in evenNumbers)
    Console.WriteLine(num); // 2, 4, 6
```

#### Method Syntax
- Fluent API approach
- More flexible

```csharp
List<Person> people = new List<Person>
{
    new Person { Name = "John", Age = 30 },
    new Person { Name = "Jane", Age = 25 },
    new Person { Name = "Bob", Age = 35 }
};

var adults = people
    .Where(p => p.Age >= 30)
    .OrderBy(p => p.Name)
    .Select(p => p.Name);

foreach (string name in adults)
    Console.WriteLine(name); // Bob, John
```

---

## Part 4: Object-Oriented Design Principles

### 1. SOLID Principles

#### Single Responsibility Principle (SRP)
- Class should have one reason to change
- One responsibility per class

```csharp
// Bad - Multiple responsibilities
public class User
{
    public string Name { get; set; }
    
    public void SaveToDatabase() { }
    public void SendEmail() { }
    public void GenerateReport() { }
}

// Good - Single responsibility
public class User
{
    public string Name { get; set; }
}

public class UserRepository
{
    public void Save(User user) { }
}

public class EmailService
{
    public void SendEmail(string recipient, string message) { }
}

public class ReportGenerator
{
    public void Generate(User user) { }
}
```

#### Open/Closed Principle (OCP)
- Open for extension, closed for modification
- Use inheritance and polymorphism

```csharp
// Bad - Needs modification for new shapes
public class AreaCalculator
{
    public double CalculateArea(object[] shapes)
    {
        double area = 0;
        foreach (object shape in shapes)
        {
            if (shape is Circle)
                area += Math.PI * ((Circle)shape).Radius * ((Circle)shape).Radius;
            else if (shape is Rectangle)
                area += ((Rectangle)shape).Width * ((Rectangle)shape).Height;
        }
        return area;
    }
}

// Good - Closed for modification, open for extension
public interface IShape
{
    double CalculateArea();
}

public class AreaCalculator
{
    public double CalculateArea(IShape[] shapes)
    {
        double area = 0;
        foreach (IShape shape in shapes)
            area += shape.CalculateArea();
        return area;
    }
}

public class Circle : IShape
{
    public double Radius { get; set; }
    
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public double CalculateArea()
    {
        return Width * Height;
    }
}
```

#### Liskov Substitution Principle (LSP)
- Derived classes should be substitutable for base classes
- Maintain contract consistency

```csharp
// Bad - Square breaks Rectangle contract
public class Rectangle
{
    public virtual void SetWidth(double width) { }
    public virtual void SetHeight(double height) { }
}

public class Square : Rectangle
{
    public override void SetWidth(double width)
    {
        Width = Height = width; // Violates LSP
    }
    
    public override void SetHeight(double height)
    {
        Width = Height = height; // Violates LSP
    }
}

// Good - Use composition or proper inheritance
public interface IShape
{
    double CalculateArea();
}

public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public double CalculateArea() => Width * Height;
}

public class Square : IShape
{
    public double Side { get; set; }
    
    public double CalculateArea() => Side * Side;
}
```

#### Interface Segregation Principle (ISP)
- Clients should depend on small, specific interfaces
- Avoid fat interfaces

```csharp
// Bad - Fat interface
public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
    void Pay();
}

// Good - Segregated interfaces
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public interface IPayable
{
    void Pay();
}

public class Employee : IWorkable, IEatable, ISleepable, IPayable
{
    public void Work() { }
    public void Eat() { }
    public void Sleep() { }
    public void Pay() { }
}

public class Robot : IWorkable
{
    public void Work() { }
}
```

#### Dependency Inversion Principle (DIP)
- Depend on abstractions, not concrete implementations
- High-level modules independent of low-level modules

```csharp
// Bad - Direct dependency
public class EmailNotification
{
    public void SendEmail(string message) { }
}

public class OrderService
{
    private EmailNotification _notification = new EmailNotification();
    
    public void PlaceOrder(Order order)
    {
        _notification.SendEmail("Order placed");
    }
}

// Good - Depend on abstraction
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) { }
}

public class OrderService
{
    private readonly INotification _notification;
    
    public OrderService(INotification notification)
    {
        _notification = notification;
    }
    
    public void PlaceOrder(Order order)
    {
        _notification.Send("Order placed");
    }
}
```

### 2. DRY Principle (Don't Repeat Yourself)
- Avoid code duplication
- Extract common code into methods
- Create reusable components

### 3. KISS Principle (Keep It Simple, Stupid)
- Keep code simple and understandable
- Avoid over-engineering
- Choose clarity over cleverness

### 4. YAGNI Principle (You Aren't Gonna Need It)
- Don't build features you don't need
- Focus on current requirements
- Refactor when needed

---

## Part 5: Advanced Patterns and Practices

### 1. Composition over Inheritance
- Favor composition when appropriate
- More flexible than inheritance
- Avoids tight coupling

```csharp
// Inheritance approach
public class Animal { }
public class Flyer : Animal { }
public class Swimmer : Animal { }
public class FlyingSwimmer : Animal { } // Problem: multiple inheritance

// Composition approach
public interface IFlyer
{
    void Fly();
}

public interface ISwimmer
{
    void Swim();
}

public class Bird : IFlyer
{
    public void Fly() { }
}

public class Fish : ISwimmer
{
    public void Swim() { }
}

public class Duck : IFlyer, ISwimmer
{
    public void Fly() { }
    public void Swim() { }
}
```

### 2. Immutability
- Objects that cannot be changed after creation
- Thread-safe by nature
- Predictable behavior

```csharp
public class ImmutablePoint
{
    public int X { get; }
    public int Y { get; }
    
    public ImmutablePoint(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public ImmutablePoint Move(int dx, int dy)
    {
        return new ImmutablePoint(X + dx, Y + dy);
    }
}

// C# 9.0+ record syntax
public record Point(int X, int Y);

// Immutable collection
ImmutableList<int> numbers = ImmutableList.Create(1, 2, 3);
numbers = numbers.Add(4); // Creates new list
```

### 3. Sealed Classes and Methods
- Prevent inheritance or overriding
- Performance optimization
- Design safety

### 4. Object Equality and Hashing

#### Overriding Equals and GetHashCode

```csharp
public class Person : IEquatable<Person>
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public override bool Equals(object obj)
    {
        return Equals(obj as Person);
    }
    
    public bool Equals(Person other)
    {
        return other != null && 
               Name == other.Name && 
               Age == other.Age;
    }
    
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = Name?.GetHashCode() ?? 0;
            hashCode = (hashCode * 397) ^ Age;
            return hashCode;
        }
    }
    
    public static bool operator ==(Person left, Person right)
    {
        return Equals(left, right);
    }
    
    public static bool operator !=(Person left, Person right)
    {
        return !Equals(left, right);
    }
}
```

### 5. Disposable Pattern
- Managing unmanaged resources
- Implementing IDisposable
- Proper cleanup

```csharp
public class FileProcessor : IDisposable
{
    private FileStream _fileStream;
    
    public FileProcessor(string filePath)
    {
        _fileStream = File.Open(filePath, FileMode.Open);
    }
    
    public void Process()
    {
        // Process file
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _fileStream?.Dispose();
        }
    }
    
    ~FileProcessor()
    {
        Dispose(false);
    }
}

// Usage with using statement
using (var processor = new FileProcessor("file.txt"))
{
    processor.Process();
} // Automatically calls Dispose
```

---

## Part 6: Best Practices

### 1. Naming Conventions
- PascalCase for classes, methods, properties
- camelCase for parameters, local variables
- _camelCase for private fields
- Descriptive and meaningful names

### 2. Code Organization
- One class per file (generally)
- Logical grouping of related methods
- Separate concerns
- Clear directory structure

### 3. Comments and Documentation
- XML documentation comments
- Explain why, not what
- Keep comments updated
- Use meaningful method/class names instead of comments

### 4. Error Handling
- Specific exception types
- Meaningful exception messages
- Use try-catch appropriately
- Avoid swallowing exceptions

### 5. Performance Considerations
- Profile before optimizing
- Avoid premature optimization
- String concatenation vs StringBuilder
- Collection type selection
- LINQ performance implications

### 6. Testing
- Unit test design
- Mock external dependencies
- Test behavior, not implementation
- Arrange-Act-Assert pattern

---

## Common Mistakes to Avoid

1. **Violating Encapsulation**
   - Making everything public
   - Direct field access instead of properties

2. **Deep Inheritance Hierarchies**
   - Hard to maintain and understand
   - Use composition instead

3. **God Objects**
   - Classes with too many responsibilities
   - Apply SRP

4. **Not Using Polymorphism**
   - Long if-else chains
   - Type checking and casting

5. **Ignoring Null References**
   - NullReferenceException crashes
   - Use nullable types and checks

6. **Tight Coupling**
   - Hard-coded dependencies
   - Use dependency injection

7. **Ignoring SOLID Principles**
   - Code becomes unmaintainable
   - Design patterns help

---

## Resources for Further Learning

### Books
- "Clean Code" by Robert C. Martin
- "Object-Oriented Design Patterns" by Gang of Four
- "C# Player's Guide" by RB Whitaker
- "Pro C#" by Andrew Troelsen

### Online Resources
- Microsoft C# Documentation
- Refactoring.Guru OOP Guide
- GeeksforGeeks OOP Concepts
- C# Corner Tutorials

### Practice
- Code daily
- Refactor existing code
- Build projects using OOP principles
- Code review and learn from others
- Contribute to open source

---

## Conclusion

Object-Oriented Programming is a powerful paradigm for building robust, maintainable, and scalable applications. Master the fundamentals, understand the four pillars, follow SOLID principles, and continuously practice. The journey to becoming an OOP expert is ongoing, but with dedication and consistent learning, you'll build exceptional software.

**Key Takeaway**: OOP is about modeling real-world problems with objects that encapsulate data and behavior, interact through well-defined interfaces, and follow proven design principles.
