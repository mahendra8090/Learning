using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Tasks
{

    // Use CancellationToken and CancellationTokenSource to cancel tasks cooperatively.
    public class TaskCancellation
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        
        public void Execute()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
