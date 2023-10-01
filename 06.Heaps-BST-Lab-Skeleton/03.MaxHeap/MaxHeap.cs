namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }
        public int Size => this.elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
           int parentIndex = this.GetParentIndex(index);

            while(parentIndex >= 0 && IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);

            }
        }

        private int GetParentIndex(int index)
        {
          int parentIndex = (index -1)/ 2;
            return parentIndex;
        }

        private void Swap(int index, int parentIndex)
        {
            T temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return elements[index].CompareTo(elements[parentIndex]) > 0;
        }

        public T ExtractMax()
        {
            if(elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            int firstIndex = 0;
            int lastIndex = this.elements.Count - 1;

            this.Swap(firstIndex, lastIndex);
            T maxElement = this.elements[lastIndex];
            elements.RemoveAt(lastIndex);

            this.HeapifyDown();
            return maxElement;
        }

        private void HeapifyDown()
        {
            
            int index = 0;
            int leftChildIndex = GetLeftChildIndex(index);
            while(leftChildIndex < this.elements.Count && IsLess(index,leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = GetRightChildIndex(index);
                if(rightChildIndex < this.elements.Count && IsLess(toSwapWith,rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }
                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = GetLeftChildIndex(index);
            }
           
            
        }

        private int GetRightChildIndex(int index)
        {
           return 2 * index + 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private bool IsLess(int index, int leftChildIndex)
        {
           return this.elements[index].CompareTo(this.elements[leftChildIndex]) < 0;
        }
 

        public T Peek()
        {
            if(elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return elements[0];
        }
    }
}
