using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсова_работа
{
    internal class PriorityQueue<T>
    {
        private List<T> heap;
        private List<int> priorities;

        public int Count => heap.Count;

        public PriorityQueue()
        {
            heap = new List<T>();
            priorities = new List<int>();
        }

        public void Enqueue(T item, int priority)
        {
            heap.Add(item);
            priorities.Add(priority);

            int i = heap.Count - 1;
            int parent = (i - 1) / 2;

            // Поддержка свойства пирамиды (кучи)
            while (i > 0 && priorities[parent] > priorities[i])
            {
                // Обмен значениями с родительским элементом
                int tempPriority = priorities[i];
                priorities[i] = priorities[parent];
                priorities[parent] = tempPriority;

                T tempItem = heap[i];
                heap[i] = heap[parent];
                heap[parent] = tempItem;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        public T Dequeue()
        {
            if (heap.Count == 0)
            {
                throw new InvalidOperationException("Priority queue is empty.");
            }

            T item = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            priorities[0] = priorities[priorities.Count - 1];
            priorities.RemoveAt(priorities.Count - 1);

            Heapify(0);

            return item;
        }

        private void Heapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;

            if (left < heap.Count && priorities[left] < priorities[smallest])
            {
                smallest = left;
            }

            if (right < heap.Count && priorities[right] < priorities[smallest])
            {
                smallest = right;
            }

            if (smallest != i)
            {
                int tempPriority = priorities[i];
                priorities[i] = priorities[smallest];
                priorities[smallest] = tempPriority;

                T tempItem = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = tempItem;

                Heapify(smallest);
            }
        }
    }
}
