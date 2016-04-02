using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic.Task3
{
    public class CustomQueue<T>: IEnumerable<T>
    {
        private T[] container;
        private int head;
        private int tail;
        private int size;
        private int version;

        private const int DEFAULT_CAPACITY = 4;

        public CustomQueue()
        {
            container = new T[DEFAULT_CAPACITY];
        }

        public CustomQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException(nameof(capacity));

            container = new T[capacity];
            head = 0;
            tail = 0;
            size = 0;
            version = 0;
        }

        public int Count { get { return size; } }

        public void Enqueue(T item)
        {
            if (size == container.Length)
            {
                int newCapacity = (int)((long)container.Length * 2);
                if (newCapacity == 0)
                    newCapacity = DEFAULT_CAPACITY;
                SetNewCapacity(newCapacity);
            }

            container[tail] = item;
            tail = (tail + 1 == container.Length) ? 0 : tail + 1;
            size++;
            version++;
        }

        public T Dequeue()
        {
            T result;
            if (size == 0)
                throw new QueueIsEmptyException("Queue is empty");
            result = container[head];
            container[head] = default(T);
            head = (head + 1) == container.Length ? 0 : head + 1;
            size--;
            version++;
            return result;
        }

        public T Peek()
        {
            if (size == 0)
                throw new QueueIsEmptyException("Queue is empty");
            return container[head];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void SetNewCapacity(int newCapacity)
        {
            T[] newContainer = new T[newCapacity];

            if (head < tail)
            {
                Array.Copy(container, head, newContainer, 0, size);
            }
            else
            {
                Array.Copy(container, head, newContainer, 0, container.Length - head);
                Array.Copy(container, 0, newContainer, container.Length - head, tail);
            }

            container = newContainer;
            head = 0;
            tail = size;
        }

        struct CustomEnumerator<T> : IEnumerator<T>
        {
            private int size;
            private int head;
            private int initialHead;
            private int initialSize;
            private bool isDisposed;
            private CustomQueue<T> queue;
            private T current;
            private int version;

            public CustomEnumerator(CustomQueue<T> queue)
            {
                this.queue = queue;
                this.size = queue.size;
                this.head = queue.head - 1;
                this.initialHead = this.head - 1;
                this.initialSize = queue.size;
                this.isDisposed = false;
                this.version = queue.version;
                this.current = default(T);
            }

            public T Current
            {
                get
                {
                    if (!isDisposed)
                    {
                        if(head  != initialHead)
                            current = queue.container[head];
                        return current;
                    }
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
                if (version != queue.version)
                    throw new InvalidOperationException("Version");
                if (size == 0)
                    return false;
                else
                {
                    head = (head + 1 == queue.container.Length) ? 0 : head + 1;
                    size--;
                    return true;
                }
            }

            public void Reset()
            {
                if (isDisposed)
                    throw new ObjectDisposedException("Disposed");
                if (version != queue.version)
                    throw new InvalidOperationException("Version");
                head = initialHead;
                size = initialSize;
                current = default(T);
            }
        }
    }
}
