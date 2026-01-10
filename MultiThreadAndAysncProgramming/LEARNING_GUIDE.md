# Master Multithreading and Async Programming in C#

## Introduction

### 1. Introduction

#### ?? Overview of Multithreading and Async Programming
- **Multithreading**: Ek application me multiple threads ka use karke parallel kaam karna.
- CPU ke multiple cores ka effective use hota hai.
- **Async Programming**: Non-blocking execution, jisme long-running tasks background me chalte hain.
- C# me async mainly `Task`, `async` aur `await` ke through hota hai.
- Goal: **Performance, responsiveness aur scalability** improve karna.

---

#### ?? Historical Context and Evolution
- **C/C++ Era**: OS-level threads (`pthread`, `CreateThread`), manual memory & synchronization ? complex aur unsafe.
- **Early .NET**: Single-threaded apps, long tasks se UI freeze hoti thi.
- **Thread Class**: Manual thread creation, lifecycle management developer ke haath me.
- **ThreadPool**: Thread reuse, better performance but limited control.
- **APM / EAP**: Old async patterns (Begin-End, Events), code unreadable aur hard to maintain.
- **TPL (Task Parallel Library)**: High-level abstraction, better exception handling.
- **Async/Await**: Modern, readable, non-blocking programming model (industry standard).

---

#### ?? Relevance in Modern Applications
- **Web Apps (ASP.NET Core)**: High concurrency aur scalability.
- **Desktop Apps (WPF/WinForms)**: UI responsiveness maintain karna.
- **Cloud & Microservices**: Efficient I/O handling, better throughput.
- **Real-time & Mobile Apps**: Smooth user experience, fast async operations.

---

#### ?? Summary
- Purane methods complex aur error-prone the.
- C# ne multithreading ko safe aur developer-friendly banaya.
- Modern C# me **async/await + Task-based programming best practice** hai.

---

### 2. CPU, Thread and Thread Scheduler

#### 🔹 Understanding CPU Cores and Logical Processors

```
┌─────────────────────────────────────────────────────────────┐
│                    CPU Architecture                         │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  Physical Cores: 4                                          │
│  Logical Processors: 8 (with Hyper-Threading)               │
│                                                             │
│  ┌──────────────┐  ┌──────────────┐                         │
│  │ Core 1       │  │ Core 2       │                         │
│  │ ┌──────────┐ │  │ ┌──────────┐ │                         │
│  │ │Logic 0   │ │  │ │Logic 2   │ │                         │
│  │ └──────────┘ │  │ └──────────┘ │                         │
│  │ ┌──────────┐ │  │ ┌──────────┐ │                         │
│  │ │Logic 1   │ │  │ │Logic 3   │ │                         │
│  │ └──────────┘ │  │ └──────────┘ │                         │
│  └──────────────┘  └──────────────┘                         │
│                                                             │
│  ┌──────────────┐  ┌──────────────┐                         │
│  │ Core 3       │  │ Core 4       │                         │
│  │ ┌──────────┐ │  │ ┌──────────┐ │                         │
│  │ │Logic 4   │ │  │ │Logic 6   │ │                         │
│  │ └──────────┘ │  │ └──────────┘ │                         │
│  │ ┌──────────┐ │  │ ┌──────────┐ │                         │
│  │ │Logic 5   │ │  │ │Logic 7   │ │                         │
│  │ └──────────┘ │  │ └──────────┘ │                         │
│  └──────────────┘  └──────────────┘                         │
│                                                             │
│  Cache Hierarchy:                                           │
│  ┌──────────────────────────────────────┐                   │
│  │ L1 Cache: 32KB (per core) - Fastest  │                   │
│  ├──────────────────────────────────────┤                   │
│  │ L2 Cache: 256KB (per core)           │                   │
│  ├──────────────────────────────────────┤                   │
│  │ L3 Cache: 8-50MB (shared)            │                   │
│  ├──────────────────────────────────────┤                   │
│  │ RAM: Largest, Slowest                │                   │
│  └──────────────────────────────────────┘                   │
└─────────────────────────────────────────────────────────────┘
```

- **Physical Core**: Alag processor unit, independent computation kar sakta hai
- **Logical Processor**: OS ke liye execution unit (hyper-threading se 2+ per core)
- **Multi-core**: 2, 4, 8, 16, 32+ cores typical
- Check cores: `Environment.ProcessorCount`
- **Hyper-Threading**: 1 physical core → 2 logical (20-30% performance boost)
- **Cache**: L1 (32KB), L2 (256KB), L3 (8MB-50MB) - cache locality matters

---

#### 🔹 What is a Thread in the OS?

```
┌──────────────────────────────────────────────────────┐
│              Process Memory Space                    │
├──────────────────────────────────────────────────────┤
│                                                      │
│  ┌───────────────┐    ┌───────────────┐            │
│  │   Thread 1    │    │   Thread 2    │            │
│  ├───────────────┤    ├───────────────┤            │
│  │ Stack:        │    │ Stack:        │            │
│  │ • Locals      │    │ • Locals      │            │
│  │ • Method Args │    │ • Method Args │            │
│  │ • Return Addr │    │ • Return Addr │            │
│  │               │    │               │            │
│  │ Registers:    │    │ Registers:    │            │
│  │ • PC (IP)     │    │ • PC (IP)     │            │
│  │ • EAX, EBX... │    │ • EAX, EBX... │            │
│  │               │    │               │            │
│  │ TLS (Private) │    │ TLS (Private) │            │
│  └───────────────┘    └───────────────┘            │
│                                                      │
│  ┌──────────────────────────────────────────┐      │
│  │        Shared Heap (Shared Memory)       │      │
│  │  • Objects                               │      │
│  │  • Static fields                         │      │
│  │  • Shared data structures                │      │
│  └──────────────────────────────────────────┘      │
│                                                      │
└──────────────────────────────────────────────────────┘
```

- **Thread**: Smallest execution unit within process
- Har thread ka apna: Stack, Registers, Program Counter, TLS
- **vs Process**: Threads share memory, cheaper context switch, no isolation
- **Foreground**: Process can't exit while running
- **Background**: App close kar sakta hai even if running
- **UI Thread**: Only one, GUI operations handle karta hai
- **Worker Threads**: Background tasks ke liye

---

#### 🔹 Thread Scheduler and Context Switching

```
┌────────────────────────────────────────────────────────────┐
│                   Thread States Flow                       │
├────────────────────────────────────────────────────────────┤
│                                                            │
│   ┌──────────────┐                                        │
│   │  Unstarted   │  (thread.Start() not called)           │
│   └──────┬───────┘                                        │
│          │ .Start()                                       │
│          ▼                                                │
│   ┌──────────────┐                                        │
│   │    Ready     │◄─────────────────────┐               │
│   └──────┬───────┘                       │               │
│          │ Scheduler picks (runs)        │ Context       │
│          ▼                               │ Switch back   │
│   ┌──────────────┐      Timer Interrupt │               │
│   │   Running    │ ─────(10-15ms)──────►│               │
│   └──────┬───────┘                       │               │
│          │ WaitOne(), Sleep()            │               │
│          │ Lock acquired                 │               │
│          ▼                               │               │
│   ┌──────────────┐◄──────────────────────┘               │
│   │   Waiting    │  (signal/timeout)                     │
│   └──────┬───────┘                                       │
│          │ Signal received / Timeout                     │
│          ▼                                                │
│   ┌──────────────┐                                        │
│   │   Stopped    │  (thread completed)                   │
│   └──────────────┘                                        │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

```
┌────────────────────────────────────────────────────────────┐
│              Context Switch Timeline                       │
├────────────────────────────────────────────────────────────┤
│                                                            │
│ Thread A (Running)                                         │
│ ├─ EAX = 100, EBX = 200                                   │
│ ├─ Stack: [method1, method2]                              │
│ └─ PC pointing to instruction #42                         │
│                                                            │
│           [Timer Interrupt - 15ms passed]                 │
│                    │                                       │
│                    ▼                                       │
│        [Save Context to TCB - A]                          │
│        [Load Context from TCB - B]                        │
│                    │                                       │
│                    ▼                                       │
│ Thread B (Now Running)                                     │
│ ├─ EAX = 50, EBX = 75                                     │
│ ├─ Stack: [methodX]                                       │
│ └─ PC pointing to instruction #18                         │
│                                                            │
│ Cost: 1-10 microseconds + Cache flush                      │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

- **Scheduler**: OS component jo decide karta hai kaunsa thread kab CPU time le
- **Preemptive**: OS force karke switch karta hai (modern Windows/Linux)
- **Context Switch**: Save registers → Restore next thread → Resume
- **Overhead**: 1-10 microseconds + cache flush
- **Thread States**: Unstarted → Ready → Running → Waiting → Stopped
- **Impact**: Too many threads = more switches = less actual work

---

#### 🔹 Time Slicing and Quantum

```
┌────────────────────────────────────────────────────────────┐
│            Time Quantum Distribution                       │
├────────────────────────────────────────────────────────────┤
│                                                            │
│ Quantum = 15ms (Windows default)                           │
│                                                            │
│ Timeline (ms):  0    15   30   45   60   75   90  105     │
│                 │     │    │    │    │    │    │   │      │
│ Thread A:      [███]      [███]      [███]      [██]      │
│                                                            │
│ Thread B:           [███]      [███]      [███]           │
│                                                            │
│ Thread C:                 [███]      [███]      [███]      │
│                                                            │
│ Legend: [███] = Running, [   ] = Waiting                  │
│                                                            │
│ Total Time for 3 threads to complete equal work: 105ms    │
│ If sequential: 45ms (but blocking!)                       │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

```
┌────────────────────────────────────────────────────────────┐
│           Thread Priority Impact                           │
├────────────────────────────────────────────────────────────┤
│                                                            │
│ Priority Levels in C#:                                     │
│                                                            │
│  Highest    ▲  Gets more quantum slices                    │
│             │  ┌──────────────────────┐                    │
│  AboveNorm  │  │ Scheduled more often  │                   │
│             │  ├──────────────────────┤                    │
│  Normal     │  │ Default priority      │◄── Most threads   │
│             │  ├──────────────────────┤                    │
│  BelowNorm  │  │ Less quantum          │                   │
│             │  ├──────────────────────┤                    │
│  Lowest     │  │ Highest wait time     │                   │
│             ▼  └──────────────────────┘                    │
│                                                            │
│ ⚠️ Risk: Priority Inversion                               │
│    Low-priority thread holds lock                          │
│    High-priority thread waiting (starvation)               │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

- **Time Quantum**: Fixed interval har thread ko (~15ms Windows)
- **Fair Distribution**: Prevent starvation, equal CPU time
- **Priority**: `ThreadPriority.Lowest` to `Highest` affects quantum allocation
- **Priority Inversion Risk**: Low-priority thread lock kare high-priority ke liye
- **Thread.Priority**: CPU scheduling priority control

---

#### 🔹 CPU-Bound vs I/O-Bound Threading

```
┌────────────────────────────────────────────────────────────┐
│        CPU-Bound: Thread Count = CPU Cores                 │
├────────────────────────────────────────────────────────────┤
│                                                            │
│ 4 CPU Cores, 4 Threads (Optimal)                          │
│                                                            │
│ Core 0: [Thread A ─────────────────────────]              │
│ Core 1: [Thread B ─────────────────────────]              │
│ Core 2: [Thread C ─────────────────────────]              │
│ Core 3: [Thread D ─────────────────────────]              │
│                                                            │
│ ✓ 0 context switches, 100% CPU utilization               │
│ ✓ Cache locality maintained                               │
│ ✓ Maximum throughput                                      │
│                                                            │
│ 4 CPU Cores, 8 Threads (Not Optimal)                      │
│                                                            │
│ Core 0: [Thread A ][Thread E ][Thread A ][Thread E ]     │
│ Core 1: [Thread B ][Thread F ][Thread B ][Thread F ]     │
│ Core 2: [Thread C ][Thread G ][Thread C ][Thread G ]     │
│ Core 3: [Thread D ][Thread H ][Thread D ][Thread H ]     │
│                                                            │
│ ✗ Context switch overhead                                 │
│ ✗ Cache thrashing                                         │
│ ✗ ~20% performance degradation                            │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

```
┌────────────────────────────────────────────────────────────┐
│     I/O-Bound: More Threads OK (Wait != CPU Time)          │
├────────────────────────────────────────────────────────────┤
│                                                            │
│ 4 CPU Cores, 20 Threads (I/O Operations)                  │
│                                                            │
│ Core 0: [T1────][T5────][T9────][T13───]                 │
│ Core 1: [T2────][T6────][T10───][T14───]                 │
│ Core 2: [T3────][T7────][T11───][T15───]                 │
│ Core 3: [T4────][T8────][T12───][T16───]                 │
│                                                            │
│ T17-T20: Waiting for I/O (file read, network, DB)        │
│                                                            │
│ ✓ While T1-T4 wait, T5-T8 run on same cores               │
│ ✓ While T5-T8 wait, T9-T12 run                            │
│ ✓ Maximize CPU usage during I/O operations                │
│ ✓ Better throughput for I/O-heavy workloads               │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

#### 🎯 Key Points
- **Optimal threads ≈ CPU cores** for CPU-bound work
- **More threads OK** for I/O-bound (waiting time nahi count hota)
- **Context switching** has significant overhead
- **Cache locality** matters for performance

---

#### 🔹 How Scheduler, Threads, and CPU Cores Work Together

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                   Complete Thread Execution Model                           │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│ ┌──────────────────────────────┐                                            │
│ │    Operating System Kernel   │                                            │
│ │                              │                                            │
│ │  ┌──────────────────────┐    │                                            │
│ │  │  Thread Scheduler    │    │  Decides which thread runs when            │
│ │  │  (Dispatcher)        │    │                                            │
│ │  │                      │    │  • Maintains Ready Queue                   │
│ │  │  • Preemption        │    │  • Tracks thread states                    │
│ │  │  • Priority Based    │    │  • Timer interrupts (10-15ms)              │
│ │  │  • Load Balancing    │    │  • I/O event handling                      │
│ │  └──────────────────────┘    │                                            │
│ │                              │                                            │
│ └──────────────────────────────┘                                            │
│            │                                                                │
│            │ Assigns threads to cores                                       │
│            ▼                                                                │
│ ┌──────────────────────────────────────────────────────────────┐            │
│ │              Ready Queue (Waiting Threads)                   │            │
│ │                                                              │            │
│ │  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐      │              │
│ │  │ Thread 1     │  │ Thread 2     │  │ Thread 3     │ ...  │              │
│ │  │ (Normal)     │  │ (Normal)     │  │ (High)       │      │              │
│ │  └──────────────┘  └──────────────┘  └──────────────┘      │              │
│ │                                                              │            │
│ └──────────────────────────────────────────────────────────────┘            │
│            │                                                                │
│            │ Dispatch to cores                                              │
│            ▼                                                                │
│                                                                             │
│  ╔═══════════════════════════════════════════════════════════════════╗      │
│  ║                    Physical CPU Package                           ║      │
│  ╠═══════════════════════════════════════════════════════════════════╣      │
│  ║                                                                   ║      │
│  ║  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐ ║      │
│  ║  │  Physical Core 0 │  │  Physical Core 1 │  │  Physical Core 2 │ │      │
│  ║  │                  │  │                  │  │                  │ │      │
│  ║  │ ┌──────────────┐ │  │ ┌──────────────┐ │  │ ┌──────────────┐ │ │      │
│  ║  │ │ Logical 0    │ │  │ │ Logical 2    │ │  │ │ Logical 4    │ │ │      │
│  ║  │ │              │ │  │ │              │ │  │ │              │ │ │      │
│  ║  │ │ Thread A     │ │  │ │ Thread B     │ │  │ │ Thread C     │ │ │      │
│  ║  │ │ (Running)    │ │  │ │ (Running)    │ │  │ │ (Running)    │ │ │      │
│  ║  │ │              │ │  │ │              │ │  │ │              │ │ │      │
│  ║  │ │ ┌──────────┐ │ │  │ │ ┌──────────┐ │ │  │ │ ┌──────────┐ │ │ │      │
│  ║  │ │ │ALU       │ │ │  │ │ │ALU       │ │ │  │ │ │ALU       │ │ │ │      │
│  ║  │ │ │FPU       │ │ │  │ │ │FPU       │ │ │  │ │ │FPU       │ │ │ │      │
│  ║  │ │ │Registers │ │ │  │ │ │Registers │ │ │  │ │ │Registers │ │ │ │      │
│  ║  │ │ │PC = 1000 │ │ │  │ │ │PC = 2500 │ │ │  │ │ │PC = 3800 │ │ │ │      │
│  ║  │ │ └──────────┘ │ │  │ │ └──────────┘ │ │  │ │ └──────────┘ │ │ │      │
│  ║  │ │              │ │  │ │              │ │  │ │              │ │ │      │
│  ║  │ └──────────────┘ │  │ └──────────────┘ │  │ └──────────────┘ │ │      │
│  ║  │                  │  │                  │  │                  │ │      │
│  ║  │ ┌──────────────┐ │  │ ┌──────────────┐ │  │ ┌──────────────┐ │ │      │
│  ║  │ │ Logical 1    │ │  │ │ Logical 3    │ │  │ │ Logical 5    │ │ │      │
│  ║  │ │              │ │  │ │              │ │  │ │              │ │ │      │
│  ║  │ │ (Idle/HT)    │ │  │ │ (Idle/HT)    │ │  │ │ (Idle/HT)    │ │ │      │
│  ║  │ └──────────────┘ │  │ └──────────────┘ │  │ └──────────────┘ │ │      │
│  ║  │                  │  │                  │  │                  │ │      │
│  ║  │ L1 Cache: 32KB   │  │ L1 Cache: 32KB   │  │ L1 Cache: 32KB   │ │      │
│  ║  │ L2 Cache: 256KB  │  │ L2 Cache: 256KB  │  │ L2 Cache: 256KB  │ │      │
│  ║  └──────────────────┘  └──────────────────┘  └──────────────────┘ ║      │

```

- **Scheduler Decision**
   - Threads A, B, C are in Ready Queue
   - Scheduler picks 3 threads (one per core) for 15ms quantum
   - Thread 1 waits in Ready Queue

2. **Core Assignment**
   - Thread A → Core 0, Logical 0 (actual execution)
   - Thread B → Core 1, Logical 2
   - Thread C → Core 2, Logical 4
   - Logical 1, 3, 5 (Hyper-Threading) idle (no work)

3. **Execution Context**
   - Each thread has own PC (Program Counter), Registers, Stack
   - Executing different instructions simultaneously
   - Each core working on different data

4. **Cache Usage**
   - Thread A uses Core 0's L1/L2 cache
   - If data different → L3 cache miss → RAM access (slow!)
   - If data same core → L1 cache hit (fast!)

---

#### 🔹 Thread Execution Timeline: From Queue to Core

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                     Detailed Execution Timeline                             │
├─────────────────────────────────────────────────────────────────────────────┤
│                                                                             │
│  Time (ms):  0         5         10        15        20        25        30 │
│  ────────────┼─────────┼─────────┼─────────┼─────────┼─────────┼─────────┼  │
│                                                                             │
│  Ready Queue                                                                │
│  ┌──────────────────────────────────────────────────────────────┐           │
│  │ [T1:High] → │ [T4] → │ [T4] → │ [T4] → │ [T7] → │ [T7]       │           │
│  │ [T2:Norm] → │ [T5] → │ [T5] → │ [T5] → │ [T8] → │ [T8]       │           │
│  │ [T3:Norm] → │ [T6] → │ [T6] → │ [T1] → │ [T1] → │ [T1]       │           │
│  └──────────────────────────────────────────────────────────────┘           │
│                    (Queue evolves as threads complete)                      │
│                                                                             │
│  Core 0 (Logical 0)                                                         │
│  ┌──────────────────────────────────────────────────────────────┐           │
│  │ [T1 RUN ]  │ [T1 RUN ]  │ [T4 RUN ]  │ [T4 RUN ]  │ [T7 RUN] │           │
│  │ Inst: 100→200→300→400→500→506→507...│                        │           │
│  │ PC moves forward, executing instructions                     │           │
│  └──────────────────────────────────────────────────────────────┘           │
│                                                                             │
│  Core 1 (Logical 2)                                                         │
│  ┌──────────────────────────────────────────────────────────────┐           │
│  │ [T2 RUN ]  │ [T2 RUN ]  │ [T5 RUN ]  │ [T5 RUN ]  │ [T8 RUN] │           │
│  │ Inst: 50→100→150→200→250→256→257... │                        │           │
│  │ Different thread, different PC, different data               │           │
│  └──────────────────────────────────────────────────────────────┘           │
│                                                                             │
│  Core 2 (Logical 4)                                                         │
│  ┌──────────────────────────────────────────────────────────────┐           │
│  │ [T3 RUN ]  │ [T3 RUN ]  │ [T6 RUN ]  │ [T6 RUN ]  │ [T1 RUN] │           │
│  │ Inst: 1→10→20→30→40→45→46...         │                       │           │
│  │ Parallel execution, improving throughput                     │           │
│  └──────────────────────────────────────────────────────────────┘           │
│                                                                             │
│  Timeline Events:                                                           │
│  ├─ @0ms: Scheduler dispatches T1, T2, T3 to cores                          │
│  ├─ @0-15ms: T1, T2, T3 execute in parallel                                 │
│  ├─ @15ms: Timer interrupt! Scheduler saves context of T1,T2,T3             │
│  ├─ @15ms: Scheduler picks T4, T5, T6 (from Ready Queue)                    │
│  ├─ @15ms: Cores 0,1,2 load context of T4,T5,T6 and resume                  │
│  ├─ @15-30ms: T4, T5, T6 execute in parallel                                │
│  ├─ @30ms: Timer interrupt again! Context switch to T7, T8, T1              │
│  └─ Pattern repeats...                                                      │
│                                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

**Key Observations:**
```
┌──────────────────────────────────────────────────────────────────┐
│              Why This Model is Efficient                         │
├──────────────────────────────────────────────────────────────────┤
│                                                                  │
│ Parallelism:                                                     │
│  • 3 cores running 3 different threads simultaneously            │
│  • Work that takes 45ms sequentially takes 15ms with 3 cores     │
│  • Speedup ≈ Number of cores (ideal case)                        │
│                                                                  │
│ Fairness:                                                        │
│  • Each thread gets equal CPU time (15ms quantum)                │
│  • No starvation (all threads make progress)                     │
│  • Ready queue ensures next thread is always available           │
│                                                                  │
│ Responsiveness:                                                  │
│  • Context switch happens every 15ms (quantum)                   │
│  • Even low-priority threads get CPU time                        │
│  • I/O-waiting threads don't block others                        │
│                                                                  │
│ Cache Efficiency:                                                │
│  • If T1 stays on Core 0 → L1 cache hits (fast)                  │
│  • If T1 moves to Core 1 → Cache miss → Slower                   │
│  • Thread affinity: Keep thread on same core                     │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

---

#### 🔹 Context Switch Deep Dive: What Actually Happens

```
┌──────────────────────────────────────────────────────────────────┐
│              Context Switch Operation (@15ms)                    │
├──────────────────────────────────────────────────────────────────┤
│                                                                  │
│ STEP 1: Timer Interrupt (Hardware)                               │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ CPU receives interrupt signal (every 15ms)                  │
│  │ Current instruction completes (or halts)                    │
│  │ Control passes to OS Kernel (Interrupt Handler)             │
│  └─────────────────────────────────────────────────────────────┘
│                           │
│                           ▼
│ STEP 2: Save Current Thread Context (T1)                         │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ CPU Registers → TCB (Thread Control Block)                  │
│  │ ├─ EAX: 0x12345678                                          │
│  │ ├─ EBX: 0x87654321                                          │
│  │ ├─ ECX: 0xABCDEF00                                          │
│  │ ├─ ESP (Stack Pointer): 0x7FFF0000                          │
│  │ ├─ EBP (Base Pointer): 0x7FFF0050                           │
│  │ ├─ EIP (Program Counter): 0x00401234  ← Next instruction    │
│  │ ├─ EFLAGS (Status): 0x00000202                              │
│  │ └─ Segment Registers, Debug Regs...                         │
│  │                                                             │
│  │ Also save:                                                  │
│  │ ├─ Stack contents (local variables)                         │
│  │ ├─ Cache state info (for some CPUs)                         │
│  │ └─ MMU state (memory translation)                           │
│  │                                                             │
│  │ Cost: ~1-10 microseconds                                    │
│  └─────────────────────────────────────────────────────────────┘
│                           │
│                           ▼
│ STEP 3: Select Next Thread (T2 or T4)                           │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ Scheduler looks at Ready Queue                              │
│  │ Algorithm:                                                  │
│  │  • Check priority of waiting threads                        │
│  │  • Check how long thread waited (aging)                     │
│  │  • Apply load balancing (other cores busy?)                 │
│  │  • Pick thread with best score                              │
│  │                                                             │
│  │ Decision: "T4 will run next" (higher priority)              │
│  │ Cost: ~100 nanoseconds                                      │
│  └─────────────────────────────────────────────────────────────┘
│                           │
│                           ▼
│ STEP 4: Flush CPU Caches (Expensive!)                           │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ T1's data in L1/L2 is stale for T4                          │
│  │ Options:                                                    │
│  │  A) Flush all (slower but safe)                             │
│  │  B) Invalidate selectively (faster, depends on isolation)   │
│  │  C) Mark as "other thread" (Intel support)                  │
│  │                                                             │
│  │ For T1 → T4 switch:                                         │
│  │ ├─ T1's working set evicted from L1                         │
│  │ ├─ T4's previous data in L2/L3 maybe available              │
│  │ └─ T4 may get L2 cache hit if ran on same core recently     │
│  │                                                             │
│  │ Cost: 5-50 microseconds (major cost!)                       │
│  └─────────────────────────────────────────────────────────────┘
│                           │
│                           ▼
│ STEP 5: Load New Thread Context (T4)                            │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ TCB of T4 → CPU Registers                                   │
│  │ ├─ EAX: 0x11111111  (T4's value)                            │
│  │ ├─ EBX: 0x22222222  (T4's value)                            │
│  │ ├─ ECX: 0x33333333  (T4's value)                            │
│  │ ├─ ESP: 0x7FFF4000  (T4's stack pointer)                    │
│  │ ├─ EBP: 0x7FFF4050  (T4's base pointer)                     │
│  │ ├─ EIP: 0x00401500  ← T4's next instruction                 │
│  │ └─ ...other registers...                                    │
│  │                                                             │
│  │ Also restore:                                               │
│  │ ├─ TLB entries (Virtual → Physical address mappings)        │
│  │ ├─ MMU state                                                │
│  │ └─ Special registers                                        │
│  │                                                             │
│  │ Cost: ~1-10 microseconds                                    │
│  └─────────────────────────────────────────────────────────────┘
│                           │
│                           ▼
│ STEP 6: Resume Execution (T4)                                   │
│  ┌─────────────────────────────────────────────────────────────┐
│  │ CPU executes instruction at EIP (0x00401500)                │
│  │ T4 continues as if it was never interrupted                 │
│  │ T4 is unaware of context switch (from T4's perspective)     │
│  │                                                             │
│  │ Cost: Negligible (execution starts immediately)             │
│  └─────────────────────────────────────────────────────────────┘
│                                                                  │
│ TOTAL COST OF CONTEXT SWITCH: ~10-60 microseconds                │
│ But Cache flush can add: 10-100+ microseconds more!              │
│                                                                  │
│ Example:                                                         │
│  • 100 context switches/second = minimal impact                  │
│  • 10,000 switches/second = ~1% overhead                         │
│  • 100,000 switches/second = ~10% CPU lost to switching!         │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

---

#### 🎯 Final Summary: Scheduler ↔ Threads ↔ Cores

```
┌──────────────────────────────────────────────────────────────────┐
│           The Complete Picture                                  │
├──────────────────────────────────────────────────────────────────┤
│                                                                  │
│ Many Threads (100+)                                              │
│         ↓                                                        │
│ Scheduler (OS Kernel)                                            │
│ - Manages all threads                                            │
│ - Time quantum allocation                                       │
│ - Context switching                                             │
│ - Priority scheduling                                           │
│         ↓                                                        │
│ Few Cores (4-16 typically)                                       │
│         ↓                                                        │
│ Actual Parallel Execution                                        │
│                                                                  │
│ Formula: N Threads → Scheduler → K Cores (N >> K)              │
│                                                                  │
│ Benefit: 100 threads can run on 4 cores through:                │
│  • Time sharing (quantum)                                       │
│  • I/O waiting (doesn't block others)                           │
│  • Preemption (fair distribution)                               │
│  • Load balancing (across cores)                                │
│                                                                 │
│ Cost: Context switch overhead                                   │
│  • CPU → Registers: Fast                                        │
│  • TLB flush: Slow                                              │
│  • Cache flush: Very slow                                       │
│  • Typical: 1-100 microseconds per switch                       │
│                                                                  │
│ Optimization:                                                    │
│  • Thread affinity (same thread → same core)                    │
│  • Minimize context switches                                    │
│  • Match threads ≈ cores for CPU-bound work                     │
│  • Allow more threads for I/O-bound work                        │
│                                                                  │
└──────────────────────────────────────────────────────────────────┘
```

---

### 3. Basic Syntax to Start a Thread
- `Thread` class fundamentals
- Creating and starting threads
- ThreadStart and ParameterizedThreadStart delegates
- Thread lifecycle methods

### 4. Why Threading - Divide and Conquer
- Breaking down complex tasks
- Parallel execution benefits
- Scalability and performance improvements
- Real-world use cases

### 5. Why Threading - Offload Long Running Tasks
- Keeping UI responsive
- Background processing
- Preventing application freezing
- Non-blocking operations

### 6. Reason of Using Multithreading
- Concurrency vs Parallelism
- Performance benefits
- Resource utilization
- Responsiveness and throughput
- Drawbacks and challenges

---

## Thread Synchronization

### 1. Thread Synchronization Overview
- Why synchronization is needed
- Race conditions and data corruption
- Synchronization primitives overview
- Best practices

### 2. Critical Section and Atomic Operation
- Identifying critical sections
- Atomic operations in C#
- Interlocked class methods
- When atomic operations suffice

### 3. Exclusive Lock
- `lock` statement in C#
- How locking works
- Monitor class basics
- Lock contention and performance

### 4. Airplane Seat Booking System
- Practical example: booking system implementation
- Handling concurrent reservations
- Preventing double-booking
- Testing with multiple threads

### 5. Use Monitor to Add Timeout of Lock
- `Monitor.TryEnter()` method
- Timeout handling
- Preventing deadlocks with timeouts
- Real-world timeout scenarios

### 6. Use Mutex to Synchronize Across Processes
- Mutex vs Lock (thread vs process synchronization)
- Creating and using Mutex
- Named mutexes for inter-process communication
- Cross-application synchronization

### 7. Reader and Writer Lock
- `ReaderWriterLockSlim` class
- Multiple readers, single writer pattern
- Read and write lock acquisition
- Performance benefits for read-heavy workloads

### 8. Use Semaphore to Limit Number of Threads
- `Semaphore` and `SemaphoreSlim` classes
- Controlling thread count to limited resources
- Pool management scenarios
- Throughput optimization

### 9. Use AutoResetEvent for Signaling
- `AutoResetEvent` signaling mechanism
- One thread waiting for signal from another
- Automatic reset behavior
- Simple notification patterns

### 10. Use ManualResetEvent to Release Multiple Threads
- `ManualResetEvent` for multiple thread notification
- Set and Reset behavior
- Broadcasting signals
- Complex coordination scenarios

### 11. Two Way Signaling in Producer and Consumer Scenario
- Producer-consumer pattern
- Mutual signaling between threads
- Work queue implementation
- Blocking queue behavior

### 12. Thread Affinity
- Setting thread affinity
- CPU core assignment
- Performance implications
- Cache locality benefits

### 13. Thread Safety
- Thread-safe data structures
- Immutable objects
- Volatile keyword
- Safe publication patterns

### 14. Nested Lock and Deadlock
- Reentrant locks
- Deadlock conditions (Circular wait, Hold and wait, Mutual exclusion, No preemption)
- Detecting and preventing deadlocks
- Lock ordering best practices
- Timeout-based deadlock recovery

---

## Multithreading Misc

### 1. Debug Program with Multithreading
- Visual Studio debugging tools for multithreading
- Breakpoints in multithreaded programs
- Thread window and stack traces
- Parallel stacks debugging
- Race condition detection tools

### 2. State of a Thread
- ThreadState enum values
- Unstarted, Running, WaitSleepJoin, Stopped states
- Checking thread status
- Thread lifecycle transitions

### 3. Make Thread Wait for Some Time
- `Thread.Sleep()` method
- Precision and accuracy considerations
- Spin waiting vs blocking
- Cancellation with sleep

### 4. Returning Result from a Thread
- Using out parameters (limitations)
- Shared fields and thread safety
- Task-based approach
- Callback methods

### 5. Cancelling a Thread
- `CancellationToken` pattern
- Cooperative cancellation
- Abort vs cooperative (deprecated methods)
- Graceful shutdown

### 6. Thread Pool
- ThreadPool overview
- `ThreadPool.QueueUserWorkItem()`
- Thread pool sizing and queue
- Benefits and limitations
- Global thread pool tuning

### 7. Exception Handling in Thread
- Unhandled exceptions in threads
- AppDomain.CurrentDomain.UnhandledException
- ThreadExceptionEventHandler (WinForms)
- Try-catch in thread methods
- Logging and recovery patterns

---

## Task Based Asynchronous Programming

### 1. Multithreading vs Asynchronous Programming
- Concurrency models comparison
- Thread-per-request vs async/await
- Resource efficiency
- When to use each approach

### 2. Basic Syntax of Using Tasks
- `Task` class introduction
- `Task.Run()` method
- Creating tasks manually
- Task vs Thread overhead

### 3. Task vs Thread
- Abstraction level differences
- Task advantages (scheduling, composition)
- Thread control and low-level access
- Performance comparison

### 4. Task Uses Thread Pool by Default
- Thread pool internals
- Work-stealing queue
- Thread injection algorithm
- Benefits of thread pool usage

### 5. Returning Result from Tasks
- `Task<T>` generic type
- Retrieving task results
- Result property blocking behavior
- Exception propagation

### 6. Task Continuation - Wait, WaitAll, Result
- Waiting for single task completion
- `Task.WaitAll()` for multiple tasks
- Blocking on Result property
- Timeout handling

### 7. Task Continuation - ContinueWith
- `ContinueWith()` method usage
- Chaining operations
- TaskScheduler and continuation options
- Parent-child task relationships

### 8. Task Continuation - WhenAll, WhenAny
- `Task.WhenAll()` for all completions
- `Task.WhenAny()` for first completion
- Non-blocking await pattern
- Composite task operations

### 9. Task Continuation - Continuation Chain and Unwrap
- Chaining multiple continuations
- Task composition patterns
- `Unwrap()` for Task<Task<T>>
- Flattening task hierarchies

### 10. Exception Handling in Task
- AggregateException in tasks
- Unwrapping task exceptions
- Inner exception propagation
- Task exception observation

### 11. Task Synchronization
- Task-based synchronization primitives
- Coordinating multiple tasks
- Waiting patterns
- Lock-free synchronization

### 12. Task Cancellation
- `CancellationToken` and `CancellationTokenSource`
- Cancelling running tasks
- Handling OperationCanceledException
- Cleanup on cancellation

---

## Async and Await

### 1. Overview of Async and Await
- Language-level abstraction for asynchronous code
- State machine compilation
- SynchronizationContext role
- Error handling improvements

### 2. Basic Syntax of Async/Await
- `async` keyword on methods
- `await` keyword usage
- Method naming conventions (Async suffix)
- Return types (void, Task, Task<T>)

### 3. Which Thread is Used
- Context switching with await
- SynchronizationContext capture
- ThreadPool threads for continuation
- UI context preservation

### 4. Continuation After Returning Values
- Resuming execution after await
- Returning values from async methods
- Multiple awaits in sequence
- Control flow tracking

### 5. Exception Handling with Async and Await
- Try-catch with await
- Exception unwrapping
- Async void exception handling (dangers)
- Proper error propagation

### 6. Wait and Synchronization Context
- SynchronizationContext importance
- UI thread context preservation
- ConfigureAwait(false) for library code
- Deadlock scenarios

### 7. What Does Await Do
- Await mechanics and state machine
- Creating awaitable types
- INotifyCompletion interface
- Custom awaiter implementation

---

## Parallel Loop

### 1. Parallel Loop Overview and Basic Syntax
- `Parallel.For()` and `Parallel.ForEach()`
- Partitioning strategies
- Degree of parallelism
- Simple parallelization benefits

### 2. What Happened Behind Scene
- Loop partitioning and work distribution
- Overpartitioning vs underpartitioning
- Custom partitioners
- Performance analysis

### 3. Exception Handling in Parallel Loops
- AggregateException in parallel loops
- Inner exception enumeration
- Per-iteration exception handling
- Cancellation behavior

### 4. Stop
- `ParallelLoopState.Stop()` method
- Immediate loop termination
- Comparison with break
- Use cases

### 5. Break
- `ParallelLoopState.Break()` method
- Partial iteration completion
- Ordered iteration guarantees
- Break vs Stop differences

### 6. ParallelLoopResult
- Returned result structure
- IsCompleted property
- LowestBreakIteration property
- Loop state analysis

### 7. Cancellation in Parallel Loops
- `CancellationToken` integration
- Cooperative cancellation
- Cancellation exception handling
- Graceful partial completion

### 8. Thread Local Storage
- Local state initialization and finalization
- `localInit` and `localFinally` delegates
- Thread-local variable aggregation
- Performance considerations

### 9. Performance Considerations
- Overhead of parallelization
- Grain size and task granularity
- Work-stealing behavior
- Profiling and benchmarking
- When parallelization helps vs hurts

---

## Parallel LINQ (PLINQ)

### 1. Basics of PLINQ
- `AsParallel()` extension method
- PLINQ vs sequential LINQ
- Automatic parallelization
- Query composition

### 2. Producer, Consumer and Buffer
- Data source partitioning
- Intermediate buffering
- Producer-consumer balance
- Buffering size tuning

### 3. ForEach vs ForAll
- `ForEach()` method returning IEnumerable
- `ForAll()` terminal operation
- Deferred vs eager execution
- Use case differences

### 4. Exception Handling in PLINQ
- AggregateException propagation
- InnerExceptions collection
- Exception observation
- Partial result handling

### 5. Cancellation in PLINQ
- `WithCancellation()` method
- `CancellationToken` integration
- OperationCanceledException
- Partial result retrieval

---

## Concurrent Collections

### 1. ConcurrentQueue
- Thread-safe queue operations
- Enqueue and TryDequeue methods
- Performance characteristics
- Use cases (producer-consumer queues)
- Queue semantics (FIFO)

### 2. ConcurrentStack
- Thread-safe stack operations
- Push and TryPop methods
- LIFO semantics
- Compare to ConcurrentQueue
- Use cases (undo/redo, task scheduling)

### 3. BlockingCollection and Producer-Consumer Scenario
- Blocking collection wrapper
- Take and Add blocking methods
- Bounded collections
- Producer-consumer pattern implementation
- Multiple producers and consumers
- Backpressure handling
- CompleteAdding for graceful shutdown

---

## Hands-On Projects and Examples

This learning guide covers practical implementation of each topic. For each section:

1. **Understand the theory** - Read the concepts
2. **Implement the example** - Create hands-on code
3. **Test the scenario** - Write unit tests
4. **Measure performance** - Use profiling tools
5. **Handle edge cases** - Test concurrent scenarios

---

## Best Practices Summary

### General Principles
- Use async/await for I/O-bound operations
- Use Task Parallel Library for CPU-bound operations
- Prefer high-level abstractions (async/await, PLINQ) over low-level threading
- Always handle exceptions in multithreaded code
- Use CancellationToken for cancellation support

### Synchronization
- Minimize lock scope and duration
- Use lock-free alternatives when possible (Interlocked, concurrent collections)
- Avoid nested locks to prevent deadlocks
- Use timeouts for potentially blocking operations

### Performance
- Profile before and after parallelization
- Consider overhead of thread creation and context switching
- Use appropriate grain sizes for parallel operations
- Monitor thread pool health and congestion

### Debugging and Testing
- Use thread-safe testing patterns
- Test with various thread counts
- Use debugging tools effectively
- Stress test concurrent scenarios
- Consider using tools like ThreadSanitizer for race detection

---

## Resources for Further Learning

- Microsoft Docs: Task-based Asynchronous Pattern (TAP)
- Concurrency in C# Cookbook (Stephen Cleary)
- Microsoft Parallel Computing Platform and Tools
- Threading in C# (Joseph Albahari)
- Async/Await best practices
