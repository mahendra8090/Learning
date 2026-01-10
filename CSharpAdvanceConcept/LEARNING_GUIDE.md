# Comprehensive Guide to C# Concepts

A complete and organized reference guide to all C# features, concepts, and best practices across multiple categories.

---

## Overview

C# is a modern, versatile programming language that combines the power of C++ with the simplicity of Visual Basic. It's designed for building robust, scalable applications across multiple platforms.

### Language Evolution
- **C# 1.0** (2002): Basic OOP features
- **C# 2.0** (2005): Generics
- **C# 3.0** (2007): LINQ, Anonymous types, Lambda expressions
- **C# 4.0** (2010): Dynamic types, Named/Optional parameters
- **C# 5.0** (2012): Async/Await
- **C# 6.0** (2015): Null-conditional operators, String interpolation
- **C# 7.0** (2017): Pattern matching, Tuples, Local functions
- **C# 8.0** (2019): Nullable reference types, Default interface members
- **C# 9.0** (2020): Records, Init-only properties, Top-level statements
- **C# 10.0** (2021): File-scoped types, Record structs, Global using directives
- **C# 11.0** (2022): Generic attributes, Raw string literals, Required members
- **C# 12.0** (2023): Primary constructors, Collection expressions
- **C# 13.0** (2024): Params collections, Implicit index access
- **C# 14.0** (2024): Overload resolution improvements

---

## Part 1: Syntax and Basic Concepts

### 1. Variables and Data Types

#### Primitive Data Types
- `byte` (0-255)
- `sbyte` (-128 to 127)
- `short` (-32,768 to 32,767)
- `ushort` (0 to 65,535)
- `int` (-2.1B to 2.1B)
- `uint` (0 to 4.2B)
- `long` (-9.2E18 to 9.2E18)
- `ulong` (0 to 1.8E19)
- `float` (±1.5E-45 to ±3.4E38)
- `double` (±5E-324 to ±1.7E308)
- `decimal` (±1E-28 to ±7.9E28)
- `bool` (true/false)
- `char` (single Unicode character)
- `string` (sequence of characters)

#### Variable Declaration and Initialization

```csharp
// Explicit typing
int age = 25;
string name = "John";
double salary = 50000.50;

// Implicit typing with var
var count = 10;              // int
var message = "Hello";       // string
var price = 19.99m;          // decimal

// Constants
const int MaxAttempts = 3;
const string AppName = "MyApp";

// Nullable types
int? nullableInt = null;
string? nullableString = null;

// Default values
int defaultInt = default;    // 0
string defaultString = default; // null

// Literal suffixes
int hexValue = 0xFF;         // 255
long largeNumber = 1000L;
float singleValue = 3.14f;
decimal preciseValue = 10.50m;
```

#### Variable Scope
- Local variables (method scope)
- Class-level variables (field scope)
- Namespace-level variables (namespace scope)
- Block scope

### 2. Control Flow Statements

#### If-Else Statements

```csharp
int age = 20;

if (age >= 18)
{
    Console.WriteLine("Adult");
}
else if (age >= 13)
{
    Console.WriteLine("Teenager");
}
else
{
    Console.WriteLine("Child");
}
```

#### Switch Statements

```csharp
// Traditional switch
string day = "Monday";
switch (day)
{
    case "Monday":
        Console.WriteLine("Start of week");
        break;
    case "Friday":
        Console.WriteLine("Almost weekend");
        break;
    default:
        Console.WriteLine("Regular day");
        break;
}

// Switch expressions (C# 8.0+)
string message = day switch
{
    "Monday" => "Start of week",
    "Friday" => "Almost weekend",
    "Saturday" or "Sunday" => "Weekend",
    _ => "Regular day"
};
```

#### Ternary Operator

```csharp
int age = 20;
string status = age >= 18 ? "Adult" : "Minor";
```

#### Loops

```csharp
// For loop
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

// While loop
int count = 0;
while (count < 10)
{
    Console.WriteLine(count);
    count++;
}

// Do-While loop
do
{
    Console.WriteLine("At least once");
} while (false);

// Foreach loop
int[] numbers = { 1, 2, 3, 4, 5 };
foreach (int num in numbers)
{
    Console.WriteLine(num);
}

// Break and Continue
for (int i = 0; i < 10; i++)
{
    if (i == 5) break;        // Exit loop
    if (i == 2) continue;     // Skip to next iteration
    Console.WriteLine(i);
}
```

### 3. Operators

#### Arithmetic Operators
```csharp
int a = 10, b = 3;
int add = a + b;        // 13
int subtract = a - b;   // 7
int multiply = a * b;   // 30
int divide = a / b;     // 3
int modulo = a % b;     // 1
```

#### Comparison Operators
```csharp
int x = 10, y = 20;
bool isEqual = x == y;          // false
bool isNotEqual = x != y;       // true
bool isLess = x < y;            // true
bool isLessEqual = x <= y;      // true
bool isGreater = x > y;         // false
bool isGreaterEqual = x >= y;   // false
```

#### Logical Operators
```csharp
bool a = true, b = false;
bool and = a && b;              // false
bool or = a || b;               // true
bool not = !a;                  // false
```

#### Bitwise Operators
```csharp
int a = 5;      // 0101
int b = 3;      // 0011
int and = a & b;    // 0001 = 1
int or = a | b;     // 0111 = 7
int xor = a ^ b;    // 0110 = 6
int not = ~a;       // 1010 (inverted)
int leftShift = a << 1;     // 1010 = 10
int rightShift = a >> 1;    // 0010 = 2
```

#### Assignment Operators
```csharp
int x = 10;
x += 5;     // x = 15
x -= 3;     // x = 12
x *= 2;     // x = 24
x /= 4;     // x = 6
x %= 5;     // x = 1
```

#### Null-Coalescing Operators
```csharp
string? name = null;
string result = name ?? "Unknown";  // "Unknown"

// Null-coalescing assignment (C# 8.0+)
name ??= "John";

// Null-conditional operator
string? text = name?.ToUpper();     // null if name is null
int? length = name?.Length;        // null if name is null
```

#### Range and Index (C# 8.0+)
```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

// Index from end
int lastElement = numbers[^1];      // 5
int secondLast = numbers[^2];       // 4

// Range
int[] slice = numbers[1..4];        // { 2, 3, 4 }
int[] firstThree = numbers[..3];    // { 1, 2, 3 }
int[] lastTwo = numbers[^2..];      // { 4, 5 }
```

### 4. String Operations

#### String Creation and Manipulation

```csharp
// String literals
string text = "Hello, World!";
string escaped = "Line 1\nLine 2";

// String interpolation (C# 6.0+)
string name = "Alice";
string greeting = $"Hello, {name}!";
int age = 25;
string ageText = $"Age: {age}";

// Verbatim strings (@)
string path = @"C:\Users\Documents\file.txt";
string multiline = @"Line 1
Line 2
Line 3";

// Raw strings (C# 11.0+)
string json = """
{
    "name": "John",
    "age": 30
}
""";

// String concatenation
string result = "Hello" + " " + "World";
string combined = string.Concat("Part1", "Part2", "Part3");

// String methods
string upper = text.ToUpper();
string lower = text.ToLower();
bool contains = text.Contains("World");
int index = text.IndexOf("World");
string substring = text.Substring(0, 5);
string[] parts = text.Split(',');
string trimmed = text.Trim();
bool startsWith = text.StartsWith("Hello");
bool endsWith = text.EndsWith("!");

// String formatting
string formatted = string.Format("Value: {0}, Name: {1}", 100, "Test");
string currency = (1000).ToString("C");      // $1,000.00
string percentage = (0.5).ToString("P");     // 50.00%
```

---

## Part 2: Object-Oriented Programming

### 1. Classes and Objects
- Class definitions
- Properties and fields
- Methods and constructors
- Access modifiers
- Static members

*(Detailed coverage in OOPS/LEARNING_GUIDE.md)*

### 2. Inheritance

```csharp
public class Animal
{
    public string Name { get; set; }
    public virtual void Speak() => Console.WriteLine("Generic sound");
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Woof!");
}
```

### 3. Interfaces

```csharp
public interface IMovable
{
    void Move();
    int Speed { get; set; }
}

public class Car : IMovable
{
    public int Speed { get; set; }
    public void Move() => Console.WriteLine("Car moving");
}

// Default interface members (C# 8.0+)
public interface ILogger
{
    void Log(string message);
    
    void LogError(string message)
    {
        Console.WriteLine($"ERROR: {message}");
    }
}
```

### 4. Abstract Classes

```csharp
public abstract class Shape
{
    public abstract double GetArea();
    
    public virtual void Display()
    {
        Console.WriteLine($"Area: {GetArea()}");
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public override double GetArea() => Math.PI * Radius * Radius;
}
```

### 5. Enums

```csharp
// Simple enum
public enum Color
{
    Red,
    Green,
    Blue
}

// Enum with values
public enum Status
{
    Pending = 1,
    Active = 2,
    Inactive = 3
}

// Enum with flags (C#)
[Flags]
public enum Permissions
{
    Read = 1,
    Write = 2,
    Execute = 4
}

// Usage
Color myColor = Color.Red;
Permissions userPerms = Permissions.Read | Permissions.Write;
bool canRead = (userPerms & Permissions.Read) != 0;
```

### 6. Records (C# 9.0+)

#### Reference Records
```csharp
public record Person(string Name, int Age);

// Usage
Person p1 = new Person("John", 30);
Person p2 = new Person("John", 30);
bool equal = p1 == p2;  // true (value equality)

// With properties
public record Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
}
```

#### Record Structs (C# 10.0+)
```csharp
public record struct Point(int X, int Y);
```

### 7. Delegates and Events

#### Delegates
```csharp
// Delegate definition
public delegate void NotifyDelegate(string message);

// Using delegate
public class Notifier
{
    public void SendNotification(string msg)
    {
        Console.WriteLine($"Notification: {msg}");
    }
}

NotifyDelegate notify = new Notifier().SendNotification;
notify("Hello!");

// Or with lambda
NotifyDelegate notify2 = (msg) => Console.WriteLine($"Alert: {msg}");
notify2("Alert!");
```

#### Events
```csharp
public class Button
{
    // Define event
    public event EventHandler Clicked;
    
    public void Click()
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}

// Subscribe to event
Button btn = new Button();
btn.Clicked += (sender, e) => Console.WriteLine("Button clicked!");
btn.Click();
```

#### Func and Action (Built-in Delegates)
```csharp
// Action - void return
Action<string> print = (msg) => Console.WriteLine(msg);
print("Hello");

// Func - returns value
Func<int, int, int> add = (a, b) => a + b;
int result = add(5, 3);

// Predicate - bool return
Predicate<int> isEven = (num) => num % 2 == 0;
bool even = isEven(4);
```

---

## Part 3: Advanced Features

### 1. Generics

```csharp
// Generic class
public class Container<T>
{
    private T _value;
    
    public void Add(T item) => _value = item;
    public T Get() => _value;
}

// Generic method
public static T Max<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) > 0 ? a : b;
}

// Generic constraints
public class Repository<T> where T : class, new()
{
    public T Create() => new T();
}

// Covariance and Contravariance
public interface IEnumerable<out T> { }
public interface IComparer<in T> { }
```

### 2. LINQ (Language Integrated Query)

#### Query Syntax
```csharp
List<Person> people = new List<Person>
{
    new Person { Name = "John", Age = 30 },
    new Person { Name = "Jane", Age = 25 },
    new Person { Name = "Bob", Age = 35 }
};

// Query syntax
var adults = from p in people
             where p.Age >= 30
             orderby p.Name
             select p.Name;
```

#### Method Syntax
```csharp
var adults = people
    .Where(p => p.Age >= 30)
    .OrderBy(p => p.Name)
    .Select(p => p.Name);

// Common operations
.First(), .FirstOrDefault()
.Last(), .LastOrDefault()
.Single(), .SingleOrDefault()
.Where()
.Select()
.SelectMany()
.OrderBy(), .OrderByDescending()
.GroupBy()
.Join()
.Distinct()
.Union(), .Intersect(), .Except()
.Any(), .All()
.Count(), .Sum(), .Average()
.Skip(), .Take()
```

### 3. Lambda Expressions

```csharp
// Single parameter
Func<int, int> square = x => x * x;

// Multiple parameters
Func<int, int, int> add = (x, y) => x + y;

// Multiple statements
Func<int, string> describe = x =>
{
    if (x > 0) return "Positive";
    if (x < 0) return "Negative";
    return "Zero";
};

// Type inference
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
var evenNumbers = numbers.Where(n => n % 2 == 0);
```

### 4. Anonymous Types

```csharp
// Implicit typed
var person = new { Name = "John", Age = 30 };
Console.WriteLine(person.Name);

// With LINQ
var result = people.Select(p => new { p.Name, p.Age });

// Nested anonymous types
var complex = new
{
    Person = new { Name = "John", Age = 30 },
    Address = new { City = "NY", Country = "USA" }
};
```

### 5. Tuple Types

```csharp
// Tuple creation
var point = (1, 2);
var person = ("John", 30, "New York");

// Named tuple elements
(int X, int Y) coords = (10, 20);
var named = (Name: "John", Age: 30);

// Deconstruction
(string name, int age) = ("Alice", 25);

// With methods
(int quotient, int remainder) Divide(int a, int b)
{
    return (a / b, a % b);
}

// Tuple operations
var (q, r) = Divide(10, 3);
```

### 6. Pattern Matching

```csharp
// Type pattern
if (obj is string str)
{
    Console.WriteLine(str.Length);
}

// Property pattern
if (person is { Age: >= 18, Name: not null })
{
    Console.WriteLine("Adult");
}

// List pattern (C# 11.0+)
int[] numbers = { 1, 2, 3 };
if (numbers is [1, 2, ..])
{
    Console.WriteLine("Starts with 1, 2");
}

// Switch pattern
string GetDescription(object obj) => obj switch
{
    string s => $"String: {s}",
    int i => $"Integer: {i}",
    Person p => $"Person: {p.Name}",
    null => "Nothing",
    _ => "Unknown"
};

// Relational patterns
int x = 5;
string category = x switch
{
    < 0 => "Negative",
    = 0 => "Zero",
    > 0 and < 10 => "Single digit",
    _ => "Large"
};
```

### 7. Async/Await

```csharp
// Async method
public async Task FetchDataAsync()
{
    using (HttpClient client = new HttpClient())
    {
        string data = await client.GetStringAsync("https://api.example.com/data");
        Console.WriteLine(data);
    }
}

// Async method returning value
public async Task<int> GetCountAsync()
{
    await Task.Delay(1000);
    return 42;
}

// Multiple async operations
public async Task ProcessMultiple()
{
    var task1 = GetCountAsync();
    var task2 = GetCountAsync();
    
    int[] results = await Task.WhenAll(task1, task2);
}

// ConfigureAwait
public async Task SafeAsync()
{
    string data = await FetchAsync().ConfigureAwait(false);
}
```

### 8. Nullable Reference Types (C# 8.0+)

```csharp
#nullable enable

public class Example
{
    public string Name { get; set; }           // Cannot be null
    public string? OptionalName { get; set; }  // Can be null
    
    public void ProcessName(string? name)
    {
        if (name != null)
        {
            Console.WriteLine(name.Length);
        }
    }
}

#nullable disable
```

### 9. Using Declarations (C# 8.0+)

```csharp
// Old way
using (var file = new StreamWriter("file.txt"))
{
    file.WriteLine("Content");
}

// New way - automatically disposed at end of scope
using var file = new StreamWriter("file.txt");
file.WriteLine("Content");
```

### 10. Local Functions

```csharp
public int Calculate(int x, int y)
{
    int Add(int a, int b) => a + b;
    int Multiply(int a, int b) => a * b;
    
    return Add(x, y) * Multiply(x, y);
}
```

### 11. Top-Level Statements (C# 9.0+)

```csharp
// No need for Program class or Main method
Console.WriteLine("Hello, World!");

string GetMessage() => "Greetings!";
Console.WriteLine(GetMessage());
```

### 12. Init-Only Properties (C# 9.0+)

```csharp
public class Person
{
    public string Name { get; init; }
    public int Age { get; init; }
}

var person = new Person { Name = "John", Age = 30 };
// person.Name = "Jane";  // Error: can't set init property
```

### 13. Global Using Directives (C# 10.0+)

```csharp
// GlobalUsings.cs
global using System;
global using System.Linq;
global using System.Collections.Generic;
```

### 14. File-Scoped Types (C# 11.0+)

```csharp
// Only visible within this file
file class InternalClass
{
}

file record InternalRecord;
```

### 15. Required Members (C# 11.0+)

```csharp
public class Configuration
{
    public required string ApiKey { get; init; }
    public required string Endpoint { get; init; }
    public string? Description { get; init; }
}

// Must provide required members
var config = new Configuration 
{ 
    ApiKey = "key123", 
    Endpoint = "https://api.example.com"
};
```

### 16. Primary Constructors (C# 12.0+)

```csharp
public class Person(string name, int age)
{
    public string Name { get; } = name;
    public int Age { get; } = age;
}

var person = new Person("John", 30);
```

### 17. Collection Expressions (C# 12.0+)

```csharp
// Initialize collections with [..]
int[] numbers = [1, 2, 3, 4, 5];
List<string> names = ["Alice", "Bob", "Charlie"];
Dictionary<string, int> ages = new() { ["Alice"] = 30, ["Bob"] = 25 };

// Collection initializers
var nested = [
    [1, 2, 3],
    [4, 5, 6],
    [7, 8, 9]
];
```

### 18. Params Collections (C# 13.0+)

```csharp
public void Process(params ReadOnlySpan<int> numbers)
{
    foreach (int num in numbers)
    {
        Console.WriteLine(num);
    }
}

Process(1, 2, 3, 4, 5);
```

---

## Part 4: Collections and Data Structures

### 1. Arrays

```csharp
// Single dimension
int[] numbers = new int[5];
int[] initialized = { 1, 2, 3, 4, 5 };
int[] withSize = new int[3] { 1, 2, 3 };

// Multi-dimensional
int[,] matrix = new int[3, 3];
int[,] initialized = { { 1, 2 }, { 3, 4 } };

// Jagged arrays
int[][] jagged = new int[3][];
jagged[0] = new int[3];
jagged[1] = new int[5];

// Array methods
Array.Sort(numbers);
Array.Reverse(numbers);
Array.IndexOf(numbers, 3);
Array.Copy(source, destination, count);
```

### 2. List<T>

```csharp
List<int> numbers = new List<int>();
numbers.Add(1);
numbers.AddRange(new[] { 2, 3, 4 });
numbers.Remove(2);
numbers.RemoveAt(0);
numbers.Insert(0, 0);
numbers.Contains(3);
numbers.Count;
numbers.Clear();

// Collection initializer
List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
```

### 3. Dictionary<K, V>

```csharp
Dictionary<string, int> ages = new Dictionary<string, int>();
ages["John"] = 30;
ages.Add("Jane", 25);
ages.Remove("John");
ages.ContainsKey("John");
ages.TryGetValue("Jane", out int age);

// Iteration
foreach (var kvp in ages)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// Collection initializer
var dict = new Dictionary<string, int>
{
    { "Alice", 30 },
    { "Bob", 25 }
};
```

### 4. HashSet<T>

```csharp
HashSet<int> numbers = new HashSet<int> { 1, 2, 3 };
numbers.Add(4);
numbers.Remove(2);
numbers.Contains(3);

// Set operations
HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

set1.IntersectWith(set2);  // {3}
set1.UnionWith(set2);      // {1, 2, 3, 4, 5}
set1.ExceptWith(set2);     // {1, 2}
```

### 5. Queue<T> and Stack<T>

```csharp
// Queue - FIFO
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
int first = queue.Dequeue();    // 1
queue.Peek();

// Stack - LIFO
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
int top = stack.Pop();          // 2
stack.Peek();
```

### 6. LinkedList<T>

```csharp
LinkedList<int> list = new LinkedList<int>();
list.AddLast(1);
list.AddFirst(0);
list.AddAfter(list.First, 0.5);

var node = list.First;
while (node != null)
{
    Console.WriteLine(node.Value);
    node = node.Next;
}
```

### 7. IEnumerable and IEnumerator

```csharp
public class CustomCollection : IEnumerable<int>
{
    private int[] _items = { 1, 2, 3 };
    
    public IEnumerator<int> GetEnumerator()
    {
        foreach (int item in _items)
            yield return item;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
```

---

## Part 5: Exception Handling

### 1. Try-Catch-Finally

```csharp
try
{
    int result = Divide(10, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"General error: {ex.Message}");
}
finally
{
    Console.WriteLine("Cleanup");
}

private int Divide(int a, int b)
{
    return a / b;
}
```

### 2. Custom Exceptions

```csharp
public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message) { }
    
    public InvalidAgeException(string message, Exception inner) 
        : base(message, inner) { }
}

throw new InvalidAgeException("Age must be positive");
```

### 3. Exception Filters (C# 6.0+)

```csharp
try
{
    // code
}
catch (HttpRequestException ex) when (ex.InnerException is TimeoutException)
{
    Console.WriteLine("Request timeout");
}
```

### 4. Throwing Exceptions

```csharp
public void ValidateAge(int age)
{
    if (age < 0)
        throw new ArgumentException("Age cannot be negative", nameof(age));
    
    if (age > 150)
        throw new ArgumentOutOfRangeException(nameof(age), "Age seems unrealistic");
}
```

---

## Part 6: Reflection and Metadata

### 1. Type Information

```csharp
Type type = typeof(Person);
Type type2 = person.GetType();

// Get properties
PropertyInfo[] properties = type.GetProperties();
foreach (PropertyInfo prop in properties)
{
    Console.WriteLine($"{prop.Name}: {prop.PropertyType}");
}

// Get methods
MethodInfo[] methods = type.GetMethods();

// Get fields
FieldInfo[] fields = type.GetFields();
```

### 2. Creating Instances Dynamically

```csharp
Type type = Type.GetType("Namespace.ClassName");
object instance = Activator.CreateInstance(type);

// With parameters
object instanceWithParams = Activator.CreateInstance(
    type, 
    new object[] { "parameter1", 42 }
);
```

### 3. Invoking Methods Dynamically

```csharp
MethodInfo method = typeof(Person).GetMethod("Introduce");
method.Invoke(person, null);

MethodInfo add = typeof(Calculator).GetMethod("Add");
object result = add.Invoke(null, new object[] { 5, 3 });
```

### 4. Custom Attributes

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class DocumentedAttribute : Attribute
{
    public string Description { get; set; }
    public string Author { get; set; }
}

[Documented(Description = "Test class", Author = "John")]
public class TestClass
{
    [Documented(Description = "Test method")]
    public void TestMethod() { }
}

// Reading attributes
var attributes = typeof(TestClass).GetCustomAttributes(typeof(DocumentedAttribute));
foreach (DocumentedAttribute attr in attributes)
{
    Console.WriteLine($"{attr.Description} by {attr.Author}");
}
```

---

## Part 7: File I/O and Streams

### 1. File Operations

```csharp
// Reading
string content = File.ReadAllText("file.txt");
string[] lines = File.ReadAllLines("file.txt");
byte[] data = File.ReadAllBytes("file.bin");

// Writing
File.WriteAllText("file.txt", "content");
File.WriteAllLines("file.txt", new[] { "line1", "line2" });
File.WriteAllBytes("file.bin", data);

// Appending
File.AppendAllText("file.txt", "\nmore content");

// File information
FileInfo fileInfo = new FileInfo("file.txt");
Console.WriteLine(fileInfo.Length);
Console.WriteLine(fileInfo.CreationTime);
```

### 2. Directory Operations

```csharp
// Directory info
DirectoryInfo dir = new DirectoryInfo("folder");
FileInfo[] files = dir.GetFiles();
DirectoryInfo[] subdirs = dir.GetDirectories();

// Directory methods
Directory.CreateDirectory("newfolder");
Directory.Delete("folder", recursive: true);
string[] files = Directory.GetFiles("folder");
string[] dirs = Directory.GetDirectories("folder");
```

### 3. Streams

```csharp
// FileStream
using (FileStream stream = new FileStream("file.txt", FileMode.Open))
{
    byte[] buffer = new byte[1024];
    int bytesRead = stream.Read(buffer, 0, buffer.Length);
}

// StreamReader/StreamWriter
using (StreamReader reader = new StreamReader("file.txt"))
{
    string line;
    while ((line = reader.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
}

using (StreamWriter writer = new StreamWriter("file.txt"))
{
    writer.WriteLine("New content");
}
```

---

## Part 8: LINQ to Objects

```csharp
// Filtering
var adults = people.Where(p => p.Age >= 18);

// Projection
var names = people.Select(p => p.Name);

// Sorting
var sorted = people.OrderBy(p => p.Name);
var reverse = people.OrderByDescending(p => p.Age);

// Grouping
var grouped = people.GroupBy(p => p.City);
foreach (var group in grouped)
{
    Console.WriteLine($"{group.Key}: {group.Count()}");
}

// Joining
var joined = people.Join(
    orders,
    p => p.Id,
    o => o.PersonId,
    (p, o) => new { p.Name, o.OrderDate }
);

// Aggregation
int count = people.Count();
int sum = numbers.Sum();
double average = numbers.Average();
int max = numbers.Max();

// Set operations
var unique = people.Distinct();
var union = list1.Union(list2);
var intersect = list1.Intersect(list2);
var except = list1.Except(list2);

// Pagination
var page = people.Skip(10).Take(5);

// Lookup
bool any = people.Any(p => p.Age > 30);
bool all = people.All(p => p.Age > 0);
```

---

## Part 9: Parallel Processing

### 1. Task Parallel Library (TPL)

```csharp
// Single task
Task task = Task.Run(() =>
{
    Console.WriteLine("Running on thread pool");
});
task.Wait();

// Multiple tasks
Task task1 = Task.Run(() => DoWork1());
Task task2 = Task.Run(() => DoWork2());
Task.WaitAll(task1, task2);

// Parallel for
Parallel.For(0, 10, i =>
{
    Console.WriteLine($"Index: {i}");
});

// Parallel foreach
Parallel.ForEach(collection, item =>
{
    ProcessItem(item);
});
```

### 2. Async/Await

*(Covered in Advanced Features section)*

---

## Part 10: Attributes and Reflection

### 1. Built-in Attributes

```csharp
[Obsolete("Use NewMethod instead")]
public void OldMethod() { }

[Serializable]
public class Data { }

[Flags]
public enum Options { Option1 = 1, Option2 = 2 }

[AttributeUsage(AttributeTargets.Method)]
public class CustomAttribute : Attribute { }

[CLSCompliant(true)]
public class PublicClass { }
```

### 2. Reflection Examples

```csharp
// Get type information
Type type = typeof(Person);

// Get constructors
ConstructorInfo[] constructors = type.GetConstructors();

// Get constructor and invoke
ConstructorInfo ctor = type.GetConstructor(
    System.Type.EmptyTypes
);
object instance = ctor.Invoke(null);

// Get and set property
PropertyInfo nameProp = type.GetProperty("Name");
nameProp.SetValue(instance, "John");
string name = (string)nameProp.GetValue(instance);
```

---

## Part 11: Best Practices and Conventions

### 1. Naming Conventions

```csharp
// Classes, Interfaces, Methods, Properties - PascalCase
public class MyClass { }
public interface IMyInterface { }
public void MyMethod() { }
public string MyProperty { get; set; }

// Constants - UPPER_CASE or PascalCase
const string CONNECTION_STRING = "";
const int MAX_SIZE = 100;

// Private fields - _camelCase
private int _count;
private string _name;

// Parameters, local variables - camelCase
public void Calculate(int firstNumber, int secondNumber)
{
    int result = firstNumber + secondNumber;
}
```

### 2. Code Organization

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Services
{
    /// <summary>
    /// Description of the class
    /// </summary>
    public class MyService
    {
        // Constants
        private const int DefaultTimeout = 5000;
        
        // Static fields
        private static int _instanceCount = 0;
        
        // Instance fields
        private string _name;
        private int _age;
        
        // Properties
        public string Name { get; set; }
        public int Age { get; set; }
        
        // Constructors
        public MyService() { }
        public MyService(string name) { _name = name; }
        
        // Public methods
        public void DoSomething() { }
        
        // Private methods
        private void InternalOperation() { }
    }
}
```

### 3. Documentation Comments

```csharp
/// <summary>
/// Calculates the sum of two numbers.
/// </summary>
/// <param name="a">The first number</param>
/// <param name="b">The second number</param>
/// <returns>The sum of a and b</returns>
/// <exception cref="ArgumentException">Thrown when inputs are invalid</exception>
public int Add(int a, int b)
{
    return a + b;
}
```

### 4. Async Method Naming

```csharp
public async Task FetchDataAsync() { }
public async Task<Data> GetDataAsync() { }

// Don't use this pattern:
// public Task FetchDataTask() { }
// public Task<Data> GetDataTask() { }
```

### 5. Error Handling Best Practices

```csharp
// Specific exceptions
try
{
    ValidateInput(value);
}
catch (ArgumentNullException ex)
{
    // Handle null argument
}
catch (ArgumentException ex)
{
    // Handle general argument error
}
catch (Exception ex)
{
    // Log and rethrow
    Logger.LogError(ex);
    throw;
}

// Throwing with context
if (value == null)
    throw new ArgumentNullException(nameof(value), "Value cannot be null");
```

### 6. Null Checking

```csharp
#nullable enable

// Guard clause
public void Process(string? input)
{
    if (input == null)
        throw new ArgumentNullException(nameof(input));
    
    // Process input
}

// Null-coalescing
string text = input ?? "default";

// Null-conditional
int? length = input?.Length;

// Pattern matching
if (input is not null and { Length: > 0 })
{
    // Process non-empty input
}
```

---

## Part 12: Performance Optimization

### 1. String Optimization

```csharp
// Bad - creates multiple string objects
string result = "";
for (int i = 0; i < 1000; i++)
{
    result += i.ToString();  // Creates new string each time
}

// Good - use StringBuilder
StringBuilder sb = new StringBuilder();
for (int i = 0; i < 1000; i++)
{
    sb.Append(i);
}
string result = sb.ToString();

// Or use string.Concat/Join
string result = string.Concat(items);
string result = string.Join(",", items);
```

### 2. Collection Selection

```csharp
// For indexed access - List<T> or Array
List<int> list = new List<int> { 1, 2, 3 };
int item = list[0];

// For unique items - HashSet<T>
HashSet<string> uniqueNames = new HashSet<string>();

// For key-value pairs - Dictionary<K,V>
Dictionary<string, int> ages = new Dictionary<string, int>();

// For frequent removals - LinkedList<T>
LinkedList<int> list = new LinkedList<int>();

// For FIFO - Queue<T>
Queue<int> queue = new Queue<int>();

// For LIFO - Stack<T>
Stack<int> stack = new Stack<int>();
```

### 3. LINQ Performance

```csharp
// Avoid multiple enumeration
var items = GetItems();  // IEnumerable
var count = items.Count();  // Enumerates
var first = items.First(); // Enumerates again

// Better - materialize once
var list = GetItems().ToList();
var count = list.Count;
var first = list.First();

// Avoid unnecessary filtering
var results = items
    .Where(x => x.Active)
    .Where(x => x.Age > 18)
    .ToList();

// Better
var results = items
    .Where(x => x.Active && x.Age > 18)
    .ToList();
```

---

## Part 13: Design Patterns in C#

*(Comprehensive coverage in DesignPatterns/LEARNING_GUIDE.md)*

---

## Part 14: Testing

### 1. Unit Testing with xUnit/NUnit

```csharp
[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_WithPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        var calculator = new Calculator();
        
        // Act
        int result = calculator.Add(5, 3);
        
        // Assert
        Assert.AreEqual(8, result);
    }
}
```

### 2. Mocking with Moq

```csharp
[TestClass]
public class OrderServiceTests
{
    [TestMethod]
    public void PlaceOrder_CallsRepository()
    {
        // Arrange
        var mockRepository = new Mock<IOrderRepository>();
        var service = new OrderService(mockRepository.Object);
        var order = new Order { Id = 1, Total = 100 };
        
        // Act
        service.PlaceOrder(order);
        
        // Assert
        mockRepository.Verify(r => r.Save(order), Times.Once);
    }
}
```

---

## Part 15: Common Libraries and Frameworks

### 1. Entity Framework Core

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("connection_string");
    }
}

// CRUD operations
using (var context = new AppDbContext())
{
    // Create
    var person = new Person { Name = "John" };
    context.People.Add(person);
    context.SaveChanges();
    
    // Read
    var people = context.People.Where(p => p.Age > 18).ToList();
    
    // Update
    person.Name = "Jane";
    context.SaveChanges();
    
    // Delete
    context.People.Remove(person);
    context.SaveChanges();
}
```

### 2. Dependency Injection

```csharp
// Configure services
services.AddScoped<IRepository, Repository>();
services.AddTransient<IService, Service>();
services.AddSingleton<ICache, Cache>();

// Inject into constructor
public class MyService
{
    private readonly IRepository _repository;
    
    public MyService(IRepository repository)
    {
        _repository = repository;
    }
}
```

### 3. Logging

```csharp
// Configure logging
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});

// Use logging
public class MyService
{
    private readonly ILogger<MyService> _logger;
    
    public MyService(ILogger<MyService> logger)
    {
        _logger = logger;
    }
    
    public void DoWork()
    {
        _logger.LogInformation("Starting work");
        _logger.LogWarning("Be careful");
        _logger.LogError("An error occurred");
    }
}
```

---

## Part 16: Modern C# Features Summary

| Feature | Version | Description |
|---------|---------|-------------|
| Nullable Reference Types | C# 8.0 | Static null-safety analysis |
| Pattern Matching | C# 7.0+ | Advanced matching capabilities |
| Records | C# 9.0 | Reference types with value semantics |
| Init-only Properties | C# 9.0 | Set only during initialization |
| Top-level Statements | C# 9.0 | Simplified entry point |
| Global Usings | C# 10.0 | File-scoped usings |
| File-scoped Types | C# 11.0 | Types visible only within file |
| Primary Constructors | C# 12.0 | Simplified constructor syntax |
| Collection Expressions | C# 12.0 | New syntax for initializing collections |
| Params Collections | C# 13.0 | Better support for spans |

---

## Quick Reference Cheat Sheet

### Type Conversions
```csharp
// Implicit
int x = 5;
double y = x;

// Explicit
double d = 5.5;
int i = (int)d;

// Safe casting
if (obj is string str) { }
string str = obj as string;
```

### Common Patterns
```csharp
// Singleton
private static readonly Lazy<MyClass> _instance = new(() => new MyClass());
public static MyClass Instance => _instance.Value;

// Factory
public static Person CreatePerson(string name) => new Person { Name = name };

// Builder
var person = new PersonBuilder()
    .WithName("John")
    .WithAge(30)
    .Build();
```

### Common Exceptions
```csharp
ArgumentNullException      // Parameter is null
ArgumentException          // Parameter invalid
ArgumentOutOfRangeException // Parameter out of valid range
InvalidOperationException   // Operation invalid for current state
NotSupportedException       // Operation not supported
IOException                 // I/O error
```

---

## Resources for Continued Learning

### Official Documentation
- Microsoft C# Documentation
- Microsoft .NET Documentation
- GitHub - dotnet/docs

### Books
- "C# Player's Guide" by RB Whitaker
- "Pro C#" by Andrew Troelsen
- "Effective C#" by Bill Wagner
- "C# In Depth" by Jon Skeet

### Online Resources
- Pluralsight C# Courses
- Microsoft Learn Modules
- C# Corner Tutorials
- FreeCodeCamp

### Practice Platforms
- LeetCode
- HackerRank
- Codewars
- Project Euler

---

## Conclusion

C# is a rich, expressive language with powerful features for building modern applications. Whether you're developing desktop, web, mobile, or cloud applications, understanding these concepts will make you a more effective developer.

**Key Takeaways:**
- Master the fundamentals before moving to advanced topics
- Understand the purpose behind each feature
- Practice regularly with real projects
- Keep up with language updates and best practices
- Write clean, maintainable code
- Performance matters, but clarity comes first

**Remember**: The best code is code that is easy to understand, maintain, and extend!
