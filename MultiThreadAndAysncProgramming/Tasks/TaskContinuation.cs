using MultiThreadAndAysncProgramming.Threads;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Tasks
{
    public class TaskContinuation
    {
        public void Execute()
        {
            #region[-- Wait, WaitAll , Result --]
            //WaitExamples();
            #endregion

            #region[-- ContinueWith --]
            ContinueWithExample();
            #endregion

            #region [-- WhenAll -- ]
            WhenAllExample();
            #endregion

            #region [-- WhenAny -- ]
            WhenAnyExample();
            #endregion

            #region [-- Continuation Chain -- ]
            ContinuationChainExample();
            #endregion

            #region [-- UnWarp -- ]
            UnWarpExample();
            #endregion
        }

        private void UnWarpExample()
        {
            throw new NotImplementedException();
        }

        private void ContinuationChainExample()
        {
            throw new NotImplementedException();
        }

        private void WhenAnyExample()
        {
            throw new NotImplementedException();
        }

        private void WhenAllExample()
        {
            
        }

        private void ContinueWithExample()
        {
            var task = Task.Run(() =>
            {
                Console.WriteLine("Task 1 is running");
                Task.Delay(1000).Wait();
                return 42;
            });
            var continuation = task.ContinueWith(antecedent =>
            {
                Console.WriteLine($"Task 1 completed with result: {antecedent.Result}");
                Console.WriteLine("Task 2 is running as continuation");
            });
        }

        private void WaitExamples()
        {
            int sum = 0;
            var task1 = Task.Run(() =>
            {
                int sum1 = 0;
                for (int i = 0; i < 5; i++)
                {
                    Task.Delay(500);
                    sum += i;
                    sum1 += i;
                }
                return sum;
            });

            task1.Wait(); // This is similar to join in threads
            // We can also use Task1.Result instead of Wait
            Console.WriteLine($"Sum is {task1.Result}");

            //Task[] tasks = new Task[2];
            //Task.WaitAll(tasks); // Wait for multiple tasks to complete
        }
    }
}
