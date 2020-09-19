using System;
using System.Collections.Generic;

namespace EatOrDie.Common
{
    public class Pool<T> : IDisposable
    {
        private readonly Queue<T> poolQue;
        
        public Pool (int capacity) => poolQue = new Queue<T>(capacity);

        public void Enqueue(T item) => poolQue.Enqueue(item);

        public T Dequeue() => poolQue.Dequeue();
        
        public void Dispose() => poolQue.Clear();
    }
}