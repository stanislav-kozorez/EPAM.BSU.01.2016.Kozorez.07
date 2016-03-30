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
            return new CustomEnumerator<T>(container, head, size);
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
    }
}
