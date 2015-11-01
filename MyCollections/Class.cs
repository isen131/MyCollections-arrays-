using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class MyStack<T>
    {
        private T[] array;
        private const int startSize = 10;
        private int size;

        public MyStack()
        {
            size = 0;
            array = new T[startSize];
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int Count()
        {
            return size;
        }

        public void Push(T newElement)
        {
            if (size == array.Length)
            {
                T[] newArray = new T[2 * array.Length];
                Array.Copy(array, 0, newArray, 0, size);
                array = newArray;
            }
            array[size++] = newElement;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new Exception("Стек пуст.");
            }
            return array[size--];
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new Exception("Стек пуст.");
            }
            return array[size - 1];
        }
    }

    public class MyList<T>
    {
        private T[] array;
        private const int startSize = 10;
        private int size;

        public MyList()
        {
            size = 0;
            array = new T[startSize];
        }

        private T GetItem(int index)
        {
            return array[index];
        }

        private void SetItem(int index, T value)
        {
            array[index] = value;
        }

        public T this[int index]
        {
            get
            {
                return GetItem(index);
            }
            set
            {
                SetItem(index, value);
            }
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int Count()
        {
            return size;
        }

        public void Add(T newElement)
        {
            if (size == array.Length)
            {
                T[] newArray = new T[2 * array.Length];
                Array.Copy(array, 0, newArray, 0, size);
                array = newArray;
            }
            array[size++] = newElement;
        }

        public void Remove(T removingElement)
        {
            if (size == 0)
            {
                throw new Exception("Список пуст.");
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(removingElement))
                {
                    for (int j = i; j < array.Length - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    size--;
                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (size == 0)
            {
                throw new Exception("Список пуст.");
            }
            if (index < size)
            {
                for (int j = index; j < size - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                size--;
            }
            else
                throw new Exception("Элемента с таким индексом не существует.");
        }
    }

    public class MyQueue<T>
    {
        private T[] array;
        private int size;
        private const int startSize = 10;
        private int maxSize;
        private int first;
        private int last;

        public MyQueue()
        {
            maxSize = startSize;
            array = new T[startSize];
            size = 0;
            first = -1;
            last = 0;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Enqueue(T newElement)
        {
            if (size == maxSize)
            {
                T[] newQueue = new T[2 * maxSize];
                Array.Copy(array, 0, newQueue, 0, array.Length);
                array = newQueue;
                maxSize *= 2;
            }
            size++;
            array[last++ % maxSize] = newElement;
        }

        public T Dequeue()
        {
            if (size == 0)
            {
                throw new Exception("Очередь пуста.");
            }
            size--;
            return array[first++ % maxSize];
        }

        public int Count()
        {
            return size;
        }
    }
}
