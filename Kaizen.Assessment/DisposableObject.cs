using System;
using System.Linq;

namespace Kaizen.Assessment
{
    public delegate void MyEventHandler(string foo);

    public class DisposableObject : IDisposable
    {
        public event MyEventHandler SomethingHappened;

        public int Counter { get; private set; }

        public void PerformSomeLongRunningOperation()
        {

            for (int i = 0; i < 10; i++)//for loop is faster
            {
                this.SomethingHappened += HandleSomethingHappened;
            }
            //foreach (var i in Enumerable.Range(1, 10))
            //{
            //    this.SomethingHappened += HandleSomethingHappened;
            //}
        }

        public void RaiseEvent(string data)
        {
            this.SomethingHappened?.Invoke(data);// changed the structure of the code
        }

        private void HandleSomethingHappened(string foo)
        {
            Counter = Counter++;// removed the "this" keyword
            Console.WriteLine("HIT {0} => HandleSomethingHappened. Data: {1}", Counter, foo);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
                Dispose();//disposed of managed resources
            }

            // Free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }
    }
}