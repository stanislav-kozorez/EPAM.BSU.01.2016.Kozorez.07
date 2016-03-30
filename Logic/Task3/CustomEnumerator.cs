using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task3
{
    class CustomEnumerator<T> : IEnumerator<T>
    {
        private T[] container;
        private int head;
        private int size;
        private int initialHead;
        private int initialSize;
        private bool isDisposed = false;

        public CustomEnumerator(T[] container, int head, int size)
        {
            this.container = container;
            this.head = head - 1;
            this.size = size;
            this.initialHead = head - 1;
            this.initialSize = size;
        }

        public T Current
        {
            get
            {
                if (!isDisposed)
                    return container[head];
                else
                    throw new ObjectDisposedException("Disposed");
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            isDisposed = true;
        }

        public bool MoveNext()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Disposed");
            if (size == 0)
                return false;
            else
            {
                head = (head + 1 == container.Length) ? 0 : head + 1;
                size--;
                return true;
            }
        }

        public void Reset()
        {
            if (isDisposed)
                throw new ObjectDisposedException("Disposed");
            head = initialHead;
            size = initialSize;
        }
    }
}
