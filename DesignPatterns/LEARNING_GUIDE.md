# Design Patterns in C#

A comprehensive guide to design patterns categorized by type, with detailed explanations and use cases.

---

## Overview

Design patterns are reusable solutions to common problems in software design. They represent best practices and can speed up the development process by providing tested, proven development paradigms.

### Three Main Categories of Design Patterns:

1. **Creational Patterns** - Deal with object creation mechanisms
2. **Structural Patterns** - Deal with object composition and relationships
3. **Behavioral Patterns** - Deal with object collaboration and responsibility distribution

---

## Creational Patterns

Creational patterns abstract the instantiation process to make systems independent of how their objects are created, composed, and represented.

### 1. Singleton Pattern
- **Purpose**: Ensure a class has only one instance and provide a global point of access to it
- **Problem Solved**: Multiple instances of a class causing issues, need for global state
- **Key Concepts**:
  - Private constructor
  - Static instance
  - Lazy initialization
  - Thread safety
- **Use Cases**:
  - Logger instances
  - Database connection pools
  - Configuration managers
  - Cache instances
- **Variations**:
  - Eager initialization
  - Lazy initialization
  - Thread-safe singleton
  - Double-checked locking
  - Bill Pugh Singleton

### 2. Factory Method Pattern
- **Purpose**: Define an interface for creating objects, but let subclasses decide which class to instantiate
- **Problem Solved**: Object creation without specifying exact classes
- **Key Concepts**:
  - Abstract creator class
  - Concrete creator implementations
  - Product interface
  - Concrete product classes
- **Use Cases**:
  - Document creation (PDF, Word, Excel)
  - Database connection factories
  - UI element creation
  - Transport creation (truck, plane, ship)
- **Advantages**:
  - Eliminates tight coupling
  - Follows Single Responsibility Principle
  - Follows Open/Closed Principle

### 3. Abstract Factory Pattern
- **Purpose**: Provide an interface for creating families of related or dependent objects without specifying their concrete classes
- **Problem Solved**: Creating objects that belong to different families or variants
- **Key Concepts**:
  - Abstract factory interface
  - Concrete factory implementations
  - Abstract product interfaces
  - Concrete product implementations
  - Family of products
- **Use Cases**:
  - UI toolkit creation (Windows, Mac, Linux themes)
  - Database abstraction (SQL Server, MySQL, Oracle)
  - Document families (reports with different formats)
  - Gaming engines (different game object families)
- **Advantages**:
  - Isolates product creation
  - Makes switching product families easy
  - Promotes consistency among products

### 4. Builder Pattern
- **Purpose**: Separate the construction of a complex object from its representation, allowing the same construction process to create different representations
- **Problem Solved**: Complex objects with many optional parameters
- **Key Concepts**:
  - Builder class
  - Director (optional)
  - Complex product
  - Step-by-step construction
- **Use Cases**:
  - Creating objects with many constructor parameters
  - Building immutable objects
  - Creating objects with fluent API
  - Configuration objects
  - HTML/SQL query builders
- **Advantages**:
  - Improves code readability
  - Makes immutable objects easier
  - Reduces constructor overloading
- **Variations**:
  - Director pattern
  - Fluent builder
  - Telescoping constructor alternative

### 5. Prototype Pattern
- **Purpose**: Create new objects by copying a prototype instance rather than creating from scratch
- **Problem Solved**: Expensive object creation, need for object cloning
- **Key Concepts**:
  - Prototype interface (Clone method)
  - Concrete prototype classes
  - Shallow vs deep copy
  - Prototype registry
- **Use Cases**:
  - Cloning complex objects
  - Undo/Redo functionality
  - Game object spawning
  - Creating similar objects with variations
- **Advantages**:
  - Avoids expensive creation process
  - Reduces subclassing
  - Runtime object creation
- **Considerations**:
  - Deep copy complexity
  - Circular references
  - ICloneable interface usage

### 6. Object Pool Pattern
- **Purpose**: Reuse objects that are expensive to create by maintaining a pool of reusable instances
- **Problem Solved**: Performance issues with frequent object creation/destruction
- **Key Concepts**:
  - Object pool
  - Reusable objects
  - Acquire and release operations
  - Pool size management
- **Use Cases**:
  - Database connection pooling
  - Thread pooling
  - Memory management
  - Resource pooling
- **Advantages**:
  - Improves performance
  - Reduces garbage collection pressure
  - Better resource management
- **Trade-offs**:
  - Memory usage
  - Pool management complexity

### 7. Lazy Initialization Pattern
- **Purpose**: Delay object creation until first use
- **Problem Solved**: Unnecessary object creation, slow application startup
- **Key Concepts**:
  - Lazy<T> class
  - Deferred initialization
  - Thread-safe lazy initialization
- **Use Cases**:
  - Loading expensive resources on demand
  - Database connections
  - Large data structures
  - Optional dependencies
- **Advantages**:
  - Faster startup time
  - Better memory usage
  - Resources created only when needed

---

## Structural Patterns

Structural patterns deal with object composition and help form large object structures from individual classes and objects.

### 1. Adapter Pattern (Wrapper)
- **Purpose**: Convert the interface of a class into another interface clients expect, allowing incompatible interfaces to work together
- **Problem Solved**: Integrating incompatible interfaces, legacy code integration
- **Key Concepts**:
  - Target interface
  - Adapter class
  - Adaptee (existing interface)
  - Two approaches: Class adapter, Object adapter
- **Use Cases**:
  - Legacy system integration
  - Third-party library adaptation
  - Converting between different APIs
  - Data format conversion
- **Advantages**:
  - Enables code reuse
  - Single Responsibility Principle
  - Open/Closed Principle
- **Variations**:
  - Class adapter (inheritance)
  - Object adapter (composition)
  - Bidirectional adapter

### 2. Bridge Pattern
- **Purpose**: Decouple an abstraction from its implementation so the two can vary independently
- **Problem Solved**: Preventing class explosion from multiple dimensions of variation
- **Key Concepts**:
  - Abstraction
  - RefinedAbstraction
  - Implementor interface
  - ConcreteImplementor
  - Decoupling through composition
- **Use Cases**:
  - Cross-platform applications
  - Device drivers
  - Database abstraction layers
  - Rendering engines with multiple backends
- **Advantages**:
  - Decouples abstraction from implementation
  - Reduces class hierarchy complexity
  - Runtime implementation selection
- **Related Patterns**:
  - Similar structure to Adapter
  - Different intent: prevent rather than solve mismatch

### 3. Composite Pattern
- **Purpose**: Compose objects into tree structures to represent part-whole hierarchies, allowing clients to treat individual objects and compositions uniformly
- **Problem Solved**: Representing hierarchical structures, treating individual and composite objects the same
- **Key Concepts**:
  - Component interface
  - Leaf objects
  - Composite objects
  - Tree structure
  - Recursive composition
- **Use Cases**:
  - File system (folders and files)
  - UI component hierarchies
  - Organization structures
  - Menu systems
  - Game object hierarchies
- **Advantages**:
  - Simplifies client code
  - Flexible hierarchy structure
  - Easy to add new component types
- **Considerations**:
  - Type safety trade-offs
  - Performance with deep hierarchies

### 4. Decorator Pattern
- **Purpose**: Attach additional responsibilities to an object dynamically, providing a flexible alternative to subclassing
- **Problem Solved**: Avoiding subclass explosion for adding features
- **Key Concepts**:
  - Component interface
  - ConcreteComponent
  - Decorator base class
  - ConcreteDecorator
  - Wrapping and delegation
- **Use Cases**:
  - Adding features to objects dynamically
  - UI widget enhancement
  - Stream wrapping (compression, encryption)
  - Coffee shop beverage add-ons
- **Advantages**:
  - More flexible than inheritance
  - Single Responsibility Principle
  - Open/Closed Principle
  - Runtime behavior modification
- **Compared to Inheritance**:
  - Decorator: composition approach
  - Inheritance: static extension
  - Decorator allows combining decorators

### 5. Facade Pattern
- **Purpose**: Provide a unified, simplified interface to a set of interfaces in a subsystem
- **Problem Solved**: Complex subsystem APIs, reducing dependencies on complex systems
- **Key Concepts**:
  - Facade class
  - Subsystem classes
  - Simplified interface
  - Encapsulation of complexity
- **Use Cases**:
  - Simplifying library APIs
  - Database access layers
  - Framework initialization
  - Complex system abstraction
- **Advantages**:
  - Simplifies client code
  - Decouples client from subsystem
  - Layering and partitioning
- **Anti-pattern Warning**:
  - Avoid making facade too broad
  - Maintain single responsibility

### 6. Flyweight Pattern
- **Purpose**: Use sharing to support large numbers of fine-grained objects efficiently
- **Problem Solved**: Memory overhead with many similar objects
- **Key Concepts**:
  - Intrinsic state (shared, immutable)
  - Extrinsic state (unique, context-specific)
  - Flyweight factory
  - Object pooling
- **Use Cases**:
  - Text editors (character objects)
  - Game development (particle systems, trees)
  - Graphics rendering
  - Large data collections with many duplicates
- **Advantages**:
  - Significant memory savings
  - Improved performance
  - Object reuse
- **Trade-offs**:
  - Added complexity
  - CPU vs memory trade-off
  - Thread safety considerations

### 7. Proxy Pattern
- **Purpose**: Provide a surrogate or placeholder for another object to control access to it
- **Problem Solved**: Controlling access to objects, deferring expensive operations, adding cross-cutting concerns
- **Key Concepts**:
  - Subject interface
  - RealSubject
  - Proxy
  - Lazy initialization
  - Access control
- **Use Cases**:
  - Lazy initialization
  - Access control (authentication, authorization)
  - Logging and monitoring
  - Caching
  - Remote object access (RPC)
  - Virtual proxies for expensive objects
- **Advantages**:
  - Controls access to another object
  - Adds functionality without modifying subject
  - Works well with lazy initialization
- **Proxy Types**:
  - Virtual proxy (lazy loading)
  - Remote proxy (distributed objects)
  - Protection proxy (access control)
  - Smart reference (reference counting, logging)

### 8. Wrapper Pattern (Alternative to Adapter)
- Similar to Adapter but emphasis on adding functionality
- Can be considered a variation of Decorator

---

## Behavioral Patterns

Behavioral patterns deal with object collaboration and the delegation of responsibility.

### 1. Chain of Responsibility Pattern
- **Purpose**: Avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request
- **Problem Solved**: Passing requests along a chain of handlers, dynamic handler chains
- **Key Concepts**:
  - Handler interface
  - ConcreteHandler
  - Next handler reference
  - Request processing chain
  - Optional request modification
- **Use Cases**:
  - Logging frameworks with multiple levels
  - Event handling systems
  - Approval workflows
  - HTTP middleware pipelines
  - Exception handling chains
- **Advantages**:
  - Decouples sender from receiver
  - Runtime chain composition
  - Single Responsibility Principle
- **Considerations**:
  - Request might not be handled
  - Performance with long chains
  - Debugging complexity

### 2. Command Pattern
- **Purpose**: Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue requests, and log requests
- **Problem Solved**: Decoupling objects that make requests from objects that process them
- **Key Concepts**:
  - Command interface
  - ConcreteCommand
  - Invoker
  - Receiver
  - Request encapsulation
- **Use Cases**:
  - Undo/Redo functionality
  - Macro recording
  - Job scheduling
  - Transaction systems
  - Event handling
  - Request queuing
- **Advantages**:
  - Decouples invoker from receiver
  - Commands as first-class objects
  - Easy to add new commands
  - Enables queuing and persistence
  - Supports undo/redo operations
- **Real-world Applications**:
  - GUI buttons and menu items
  - Callback mechanisms
  - Task scheduling
  - Remote operation execution

### 3. Iterator Pattern
- **Purpose**: Provide a way to access the elements of a collection object sequentially without exposing its underlying representation
- **Problem Solved**: Traversing collections without exposing structure, multiple concurrent traversals
- **Key Concepts**:
  - Iterator interface
  - ConcreteIterator
  - Collection/Aggregate interface
  - ConcreteCollection
  - Sequential access
- **Use Cases**:
  - Collections traversal
  - Different iteration strategies
  - Accessing heterogeneous collections uniformly
  - Lazy evaluation
- **Advantages**:
  - Supports multiple iterations
  - Simplifies collection classes
  - Different iteration strategies
  - Uniform iteration interface
- **C# Implementation**:
  - IEnumerable and IEnumerator
  - Yield keyword
  - LINQ extension methods

### 4. Mediator Pattern
- **Purpose**: Define an object that encapsulates how a set of objects interact
- **Problem Solved**: Complex communication between multiple objects, tight coupling in multi-object scenarios
- **Key Concepts**:
  - Mediator interface
  - ConcreteMediator
  - Colleague classes
  - Centralized communication
  - Decoupled object interaction
- **Use Cases**:
  - Dialog box with multiple controls
  - Air traffic control systems
  - Chat room applications
  - Game turn management
  - Event coordination systems
- **Advantages**:
  - Decouples colleagues
  - Centralizes communication logic
  - Simplifies object relationships
  - Single Responsibility Principle
- **Considerations**:
  - Mediator can become complex (God object)
  - Not always better than direct communication
  - Debugging complexity

### 5. Memento Pattern
- **Purpose**: Without violating encapsulation, capture and externalize an object's internal state so the object can be restored to this state later
- **Problem Solved**: Undo/Redo functionality, state snapshots, transaction-like behavior
- **Key Concepts**:
  - Originator (state holder)
  - Memento (snapshot)
  - Caretaker (manages mementos)
  - State preservation without exposure
- **Use Cases**:
  - Undo/Redo implementations
  - Transaction rollback
  - Game save/load systems
  - Checkpoint systems
  - Text editor state management
- **Advantages**:
  - Preserves encapsulation
  - Supports undo/redo
  - Simple state management
  - No violation of object integrity
- **Considerations**:
  - Memory usage with many mementos
  - Serialization complexity
  - Deep copy requirements

### 6. Observer Pattern (Publish-Subscribe)
- **Purpose**: Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified automatically
- **Problem Solved**: Loose coupling between event sources and listeners, one-to-many communication
- **Key Concepts**:
  - Subject/Observable
  - Observer/Subscriber
  - Event notification
  - Loose coupling
  - Subscription mechanism
- **Use Cases**:
  - Event handling systems
  - Model-View-Controller (MVC) pattern
  - Real-time data updates
  - Reactive programming
  - Stock market ticker
  - Social media notifications
- **Advantages**:
  - Loose coupling
  - Dynamic subscription
  - Support for broadcast communication
  - Open/Closed Principle
- **C# Implementation**:
  - Event and delegate pattern
  - IObservable and IObserver (Rx.NET)
  - Event-based asynchronous pattern
- **Variations**:
  - Push model (subject sends data)
  - Pull model (observer requests data)

### 7. State Pattern
- **Purpose**: Allow an object to alter its behavior when its internal state changes, appearing to change its class
- **Problem Solved**: Objects with behavior that varies based on state, reducing conditional statements
- **Key Concepts**:
  - Context class
  - State interface
  - ConcreteState classes
  - State transitions
  - Encapsulated state behavior
- **Use Cases**:
  - TCP connection states (Established, Listen, Closed)
  - Document states (Draft, Moderation, Published)
  - Media player states (Playing, Paused, Stopped)
  - Order states (Pending, Confirmed, Shipped, Delivered)
  - User account states (Active, Suspended, Closed)
- **Advantages**:
  - Eliminates large conditional statements
  - State-specific behavior encapsulation
  - Easy to add new states
  - Single Responsibility Principle
  - Open/Closed Principle
- **State Diagram Benefits**:
  - Visual representation of transitions
  - Clear state boundaries
  - Completeness verification
- **Compared to Strategy**:
  - State: object behavior changes based on state
  - Strategy: algorithm selection

### 8. Strategy Pattern
- **Purpose**: Define a family of algorithms, encapsulate each one, and make them interchangeable
- **Problem Solved**: Multiple algorithm implementations, runtime algorithm selection
- **Key Concepts**:
  - Strategy interface
  - ConcreteStrategy classes
  - Context class
  - Algorithm encapsulation
  - Interchangeable strategies
- **Use Cases**:
  - Payment processing (credit card, PayPal, etc.)
  - Sorting algorithms (quicksort, mergesort, bubblesort)
  - Compression algorithms (ZIP, RAR, 7Z)
  - Route planning algorithms
  - Data validation strategies
  - Caching strategies
- **Advantages**:
  - Eliminates conditional statements
  - Easy to switch algorithms
  - Easy to add new algorithms
  - Runtime algorithm selection
  - Follows Single Responsibility Principle
- **Compared to State**:
  - Strategy: algorithm encapsulation
  - State: behavior based on internal state
  - Strategy: client chooses algorithm
  - State: object chooses behavior

### 9. Template Method Pattern
- **Purpose**: Define the skeleton of an algorithm in a method, deferring some steps to subclasses
- **Problem Solved**: Avoiding code duplication in similar algorithms, enforcing algorithm structure
- **Key Concepts**:
  - AbstractClass with template method
  - Abstract step methods
  - ConcreteClass implementations
  - Algorithm skeleton
  - Overridable steps
- **Use Cases**:
  - Data processing pipelines
  - Document generation
  - Game turn sequences
  - Framework hook methods
  - Build processes
  - Configuration file parsing
- **Advantages**:
  - Reduces code duplication
  - Enforces algorithm structure
  - Inversion of control
  - Promotes code reuse
- **Considerations**:
  - Can be replaced by Strategy in some cases
  - Inheritance-based approach
  - Difficult subclass navigation

### 10. Visitor Pattern
- **Purpose**: Represent an operation to be performed on elements of an object structure, allowing you to define a new operation without changing the classes of the elements
- **Problem Solved**: Adding operations to object hierarchies without modifying them, separating algorithms from object structures
- **Key Concepts**:
  - Visitor interface
  - ConcreteVisitor classes
  - Element interface
  - ConcreteElement classes
  - Accept method
  - Double dispatch
- **Use Cases**:
  - Compiler abstract syntax tree (AST) processing
  - Report generation from object structures
  - Game entity behavior (damage calculation)
  - File system operations
  - Object serialization
- **Advantages**:
  - Easy to add new operations
  - Encapsulates operations
  - Open/Closed Principle
  - Separates algorithms from structures
- **Disadvantages**:
  - Complex to implement
  - Difficult to add new element types
  - Double dispatch complexity
  - Can violate encapsulation
- **Double Dispatch Mechanism**:
  - First dispatch: visitor type
  - Second dispatch: element type

### 11. Interpreter Pattern
- **Purpose**: Define a representation for a grammar and an interpreter to interpret sentences in that language
- **Problem Solved**: Implementing domain-specific languages (DSLs), expression evaluation
- **Key Concepts**:
  - AbstractExpression
  - TerminalExpression
  - NonTerminalExpression
  - Context
  - Parse tree
  - Expression interpretation
- **Use Cases**:
  - Query language interpreters (SQL)
  - Configuration languages
  - Mathematical expression evaluation
  - Regular expression engines
  - Domain-specific languages
  - Report query languages
- **Advantages**:
  - Easy to add new interpretations
  - Grammar encapsulation
  - Flexible language implementation
- **Disadvantages**:
  - Complex implementation
  - Performance overhead
  - Grammar changes require code changes
  - Class hierarchy explosion for complex grammars
- **Alternatives**:
  - Parser generators (Antlr, Lex, Yacc)
  - Language-specific implementations

### 12. Responsibility Pattern (sometimes classified separately)
- Related to Chain of Responsibility
- Focuses on assigning responsibilities to objects

---

## Design Pattern Classification Summary

### By Purpose

#### Creational (7 patterns)
- Singleton
- Factory Method
- Abstract Factory
- Builder
- Prototype
- Object Pool
- Lazy Initialization

#### Structural (8 patterns)
- Adapter
- Bridge
- Composite
- Decorator
- Facade
- Flyweight
- Proxy
- Wrapper

#### Behavioral (12 patterns)
- Chain of Responsibility
- Command
- Iterator
- Mediator
- Memento
- Observer
- State
- Strategy
- Template Method
- Visitor
- Interpreter
- (Responsibility)

### By Complexity

#### Simple (Beginner-friendly)
- Singleton
- Adapter
- Decorator
- Factory Method
- Observer
- Strategy

#### Moderate
- Builder
- Composite
- Facade
- Iterator
- Proxy
- State
- Template Method

#### Complex (Advanced)
- Abstract Factory
- Bridge
- Chain of Responsibility
- Command
- Flyweight
- Mediator
- Memento
- Visitor
- Interpreter

### By Frequency of Use

#### Frequently Used
- Singleton
- Factory Method
- Observer
- Strategy
- Adapter
- Decorator
- Facade
- Template Method

#### Moderately Used
- Builder
- Iterator
- Composite
- State
- Command
- Proxy

#### Less Frequently Used
- Abstract Factory
- Bridge
- Chain of Responsibility
- Flyweight
- Memento
- Visitor
- Interpreter
- Object Pool
- Lazy Initialization

---

## Pattern Selection Guide

### Choose Singleton When:
- You need exactly one instance of a class
- Access must be global
- Creating instance is expensive

### Choose Factory Method When:
- Classes need to instantiate objects without knowing exact types
- Subclasses decide which class to instantiate
- Object creation logic is complex

### Choose Abstract Factory When:
- Multiple families of objects need to be created
- Objects from same family need to work together
- System should be independent of how objects are created

### Choose Builder When:
- Object has many constructor parameters
- Creating complex immutable objects
- Building step-by-step is beneficial
- Want fluent API

### Choose Prototype When:
- Object creation is expensive
- Need to clone similar objects
- Object types determined at runtime

### Choose Adapter When:
- Integrating incompatible interfaces
- Legacy code integration
- Creating wrapper around existing code

### Choose Bridge When:
- Multiple dimensions of variation exist
- Avoiding class hierarchy explosion
- Runtime implementation selection needed

### Choose Composite When:
- Tree structures with part-whole hierarchies
- Treating individual and composite objects uniformly
- Building menu systems, file systems

### Choose Decorator When:
- Adding responsibilities dynamically
- Avoiding subclass explosion
- Combining multiple decorators

### Choose Facade When:
- Simplifying complex subsystems
- Decoupling client from subsystem
- Layering subsystems

### Choose Proxy When:
- Controlling access to another object
- Lazy initialization needed
- Adding cross-cutting concerns (logging, caching)

### Choose Chain of Responsibility When:
- Handling requests dynamically
- Handler chain composition at runtime
- Request might be handled by multiple handlers

### Choose Command When:
- Parameterizing objects with requests
- Queuing, logging, undoing requests
- Deferred execution needed

### Choose Iterator When:
- Sequential access to collection elements
- Multiple traversal modes needed
- Hiding collection structure

### Choose Mediator When:
- Objects communicate in complex ways
- Reducing coupling between communicating objects
- Centralizing communication logic

### Choose Memento When:
- Capturing and externalizing state
- Implementing undo/redo
- Transaction rollback needed

### Choose Observer When:
- Many objects need notification of state changes
- Loose coupling between notifier and observers
- Event-driven architecture

### Choose State When:
- Object behavior varies based on state
- Many conditional statements based on state
- State transitions are clear

### Choose Strategy When:
- Multiple algorithm implementations
- Runtime algorithm selection
- Avoiding conditional algorithm selection

### Choose Template Method When:
- Algorithm skeleton is common
- Steps vary in subclasses
- Avoiding code duplication

### Choose Visitor When:
- Operations on complex object structures
- Many unrelated operations needed
- Adding new operations without changing classes

### Choose Interpreter When:
- Defining language grammar
- Interpreting domain-specific languages
- Building query interpreters

---

## Best Practices

### When Using Design Patterns

1. **Don't Overuse Patterns**
   - Use patterns only when they solve real problems
   - Premature pattern application complicates code
   - Keep it simple when not needed

2. **Pattern Combinations**
   - Patterns often work together
   - Example: Decorator with Strategy
   - Example: Builder with Factory Method

3. **Anti-patterns to Avoid**
   - God Object (too many responsibilities)
   - Feature Envy (accessing too many object members)
   - Inappropriate Intimacy (tight coupling)

4. **Pattern Naming**
   - Use recognizable pattern names in code
   - Helps team understanding
   - Facilitates communication

5. **Documentation**
   - Document which patterns are used
   - Explain why specific pattern was chosen
   - Help future developers understand design decisions

### C# Specific Considerations

1. **Leverage Language Features**
   - Properties, indexers, events
   - Generics for type safety
   - Extension methods for decorator-like behavior
   - Async/await for command queuing

2. **Interface Segregation**
   - Use small, focused interfaces
   - Avoid interface pollution
   - Enable better pattern implementation

3. **SOLID Principles**
   - Single Responsibility
   - Open/Closed
   - Liskov Substitution
   - Interface Segregation
   - Dependency Inversion

### When to Consider Alternatives

1. **Instead of Singleton**: Dependency injection, static classes
2. **Instead of Abstract Factory**: Dependency injection containers
3. **Instead of Template Method**: Strategy pattern, composition
4. **Instead of Visitor**: Method on each element (if possible)
5. **Instead of Observer**: Events, Rx.NET, message bus

---

## Related Patterns and Combinations

### Commonly Combined Patterns

| Pattern 1 | Pattern 2 | Why |
|-----------|-----------|-----|
| Factory Method | Singleton | Factory returns singleton instance |
| Abstract Factory | Builder | Factory creates complex objects |
| Composite | Iterator | Iterating tree structures |
| Observer | Mediator | Mediator notifies observers |
| Strategy | State | Similar structures, different purposes |
| Decorator | Factory | Factory creates decorated objects |
| Template Method | Strategy | Algorithm skeleton + algorithm selection |
| Proxy | Decorator | Both wrap objects, different intents |
| Chain of Responsibility | Command | Commands passed through chain |
| Builder | Abstract Factory | Building families of objects |

---

## Refactoring to Patterns

### Common Refactoring Scenarios

1. **Multiple If-Else Chains** ? Strategy or State
2. **Subclass Explosion** ? Decorator, Strategy, or Bridge
3. **Complex Object Creation** ? Builder or Abstract Factory
4. **Many Unrelated Methods** ? Visitor or separate handlers
5. **Tight Coupling** ? Observer, Mediator, or Facade

---

## Resources for Further Learning

### Books
- "Design Patterns: Elements of Reusable Object-Oriented Software" (Gang of Four)
- "Head First Design Patterns"
- "Refactoring to Patterns" by Joshua Kerievsky
- "Design Patterns in C#" by Steven John Metsker

### Online Resources
- Refactoring.Guru Design Patterns
- Microsoft Design Patterns documentation
- SOLID Principles guides
- Pattern implementation examples

### Practice
- Implement each pattern with simple examples
- Identify patterns in existing codebases
- Refactor code to use patterns
- Study open-source implementations

---

## Summary Table: All Design Patterns

| Pattern | Type | Purpose | Complexity |
|---------|------|---------|-----------|
| Singleton | Creational | Single instance | Low |
| Factory Method | Creational | Object creation | Low |
| Abstract Factory | Creational | Family creation | Medium |
| Builder | Creational | Complex objects | Medium |
| Prototype | Creational | Object cloning | Medium |
| Object Pool | Creational | Resource reuse | Medium |
| Lazy Initialization | Creational | Deferred creation | Low |
| Adapter | Structural | Interface compatibility | Low |
| Bridge | Structural | Abstraction decoupling | High |
| Composite | Structural | Tree structures | Medium |
| Decorator | Structural | Dynamic behavior | Medium |
| Facade | Structural | Subsystem simplification | Low |
| Flyweight | Structural | Memory optimization | High |
| Proxy | Structural | Access control | Medium |
| Chain of Responsibility | Behavioral | Request handling | Medium |
| Command | Behavioral | Request encapsulation | Medium |
| Iterator | Behavioral | Sequential access | Low |
| Mediator | Behavioral | Object communication | High |
| Memento | Behavioral | State capture | Medium |
| Observer | Behavioral | Change notification | Low |
| State | Behavioral | Behavior variation | Medium |
| Strategy | Behavioral | Algorithm selection | Low |
| Template Method | Behavioral | Algorithm skeleton | Low |
| Visitor | Behavioral | Operation definition | High |
| Interpreter | Behavioral | Language interpretation | High |

---

## Conclusion

Design patterns are powerful tools for solving recurring design problems. Understanding when and how to apply each pattern is essential for writing maintainable, scalable, and robust C# applications. Start with the most common patterns (Singleton, Factory, Observer, Strategy) and gradually explore more complex ones as your needs grow.

Remember: **The best design pattern is no pattern at all if it complicates the code unnecessarily.**
