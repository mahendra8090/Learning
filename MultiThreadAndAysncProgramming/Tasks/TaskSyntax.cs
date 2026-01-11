using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Tasks
{
    // What is Task Syntax in C#?
    /*
     C# me Task ek high-level abstraction hai jo asynchronous operation ko represent karta hai.
     Ye usually ThreadPool ke upar execute hota hai aur async-await ke through non-blocking execution provide karta hai.
    Thread ke comparison me Task lightweight, scalable aur better exception handling deta hai.

    Task aur Thread me difference

    Thread ek actual OS-level execution unit hota hai, jise manually create aur manage karna padta hai.
    Task ek logical unit of work hota hai jo usually ThreadPool ke upar run karta hai aur async-await ko support karta hai.
    
    ➡ Thread heavy hota hai, Task lightweight aur scalable hota hai.
    
    🔹 Jab Thread tha to Task kyon laya gaya?
    
    Thread ke saath problems thi:
    
    1️⃣ Thread creation expensive tha (memory + context switching)
    2️⃣ Manual management (start, stop, sync) difficult tha
    3️⃣ No return value aur exception handling tough
    4️⃣ UI freeze & poor scalability in large applications
    
    🔹 Task ne kya solve kiya?
    
    Task ne:
    
    ThreadPool reuse karke performance improve ki
    
    async/await ke through simple non-blocking code diya
    
    Return value (Task<T>) aur easy exception handling di
    
    High concurrency applications (API, UI, microservices) ko scalable banaya
    
    🔹 Interview closing line (best)
    
    Thread low-level execution deta hai, jabki Task modern applications ke liye high-level, efficient aur scalable async programming model provide karta hai.
     
    Task purpse solve karta hi.
    1. Offloading Long Running Task
    2. Parallel Programming (Divide and Conquer)
    3. Asynchronous Programming (Non Blocking UI)
    4. Better Resource Management
    5. Improved Exception Handling
    6. Scalability in High-Concurrency Scenarios
    7. Integration with async/await

    */

    /*
     ⚠️ CRITICAL CONCEPT: Har Task ka matlab "naya thread" nahi hota!
     
     Task ek ABSTRACTION hai kaam ka, Thread ek ABSTRACTION hai execution ka.
     Isliye har Task ke peeche thread hona zaruri nahi hota. Ye interview me VERY strong concept hai! 👇
     
     🔹 Case 1: CPU-Bound Task (Thread use karta hai)
     await Task.Run(() => { for(int i = 0; i < 1_000_000; i++) { } });
     ✔ ThreadPool thread use hoga, CPU busy rahega
     
     🔹 Case 2: I/O-Bound Task (Koi thread use nahi karta)
     await Task.Delay(2000); // 2 sec baad
     ✔ Koi thread 2 seconds block nahi hota, Timer + OS signal use hota hai
     ✔ Thread PURA FREE rehta hai!
     
     🔹 Real-world: API Call
     await httpClient.GetAsync("https://api.example.com");
     ✔ Jab tak response aa raha hai, koi thread wait nahi kar raha
     ✔ OS notify karta hai jab data aa jata hai (TRUE ASYNC!)
     
     🔹 Performance Impact:
     10,000 API calls ke saath:
     ❌ Thread approach → System crash ho jata hai (10K threads!)
     ✅ Task async approach → Smoothly handle hota hai (sirf few threads, reusable)
     
     🔹 Interview Closing Punchline 🔥
     "Task abstraction hai kaam ka, thread abstraction hai execution ka.
      Isliye har Task ke peeche thread hona zaruri nahi hota."
     */

    /*
     Task uses Thread bool by default.
    Thread.CurrentThread.IsThreadPoolThread
     */

    /*
     Return value
     */
    public class TaskSyntax
    {
        internal void Execute()
        {
            var task = new Task(Work);
            task.Start();
            task.Wait();
            

            var t =Task.Run(Work1);
            int result = t.Result;


            Task.Run(() =>
            {
                // Simulate a long-running task
                Console.WriteLine("Task started...");
                Task.Delay(2000).Wait(); // Simulate work
                Console.WriteLine("Task completed.");
            });
        }
        void Work()
        {
            Console.WriteLine("Work method is executing.");
            Console.WriteLine($"Thread is ThreadPool Thread: {Thread.CurrentThread.IsThreadPoolThread}");
        }
        int Work1()
        {
            Console.WriteLine("Work method is executing.");
            Console.WriteLine($"Thread is ThreadPool Thread: {Thread.CurrentThread.IsThreadPoolThread}");
            return 1;
        }
    }
}
