using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadAndAysncProgramming.Threads
{
    /*
     ReaderLock - A ReaderLock allows multiple threads to read a shared resource concurrently,
    as long as no thread is writing to it. This is useful when read operations are more frequent than write operations,
    as it improves performance by allowing concurrent reads.
     */
    public class ReaderAndWriterLock
    {
        public void Execute()
        {
           
        }
    }


    public class GlobalConfigurationCache
    {
        private ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private Dictionary<int,string> _cache = new Dictionary<int, string>();

        public void Add(int key,string value)       
        {
            bool lockAccured = false;
            try
            {
                _lock.EnterWriteLock();
                lockAccured = true;
                _cache[key] = value;
            }
            finally
            {
                if(lockAccured)
                _lock.ExitWriteLock();
            }
            
        }

        public string? Get(int key)
        {
            bool lockAccured = false;
            try
            {
                _lock.EnterReadLock();
                lockAccured = true; 
                if (_cache.TryGetValue(key, out var value))
                {
                    return value;
                }
                return null;
            }
            finally 
            { 
                if(lockAccured)
                _lock.ExitReadLock();
            }
            
        }
    }
}
