using System;
using System.Collections.Generic;
using System.Text;

namespace CodilityRuntime.Solutions.Extras.CoreDataStructs
{
    public class HashSetWithBuckets<T>
    {
        public HashSetWithBuckets(int capacity)
        {
            Initialize(capacity);
        }

        public HashSetWithBuckets(IEnumerable<T> collection)
        {
            Initialize(3);
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public void Add(T value)
        {
            AddIfNotPresent(value);
        }

        public int Count()
        {
            return lastIndex + 1;
        }
        private void AddIfNotPresent(T value)
        {
            if (buckets == null)
            {
                Initialize(3);
            }

            int hashCode = GetHashCode(value);
            int bucketIndex = GetBucketIndex(hashCode);

            int i = GetBucket(bucketIndex);
            while (i >= 0)
            {
                if (slots[i].hashCode == hashCode && CompareValues(slots[i].value, value))
                {
                    return;
                }

                if (slots[i].next < 0)
                {
                    break;
                }
                else
                {
                    i = slots[i].next;
                }
            }

            if (lastIndex >= slots.Length - 1)
            {
                IncreaseCapacity();
            }

            ++lastIndex;
            slots[lastIndex] = new Slot { value = value, hashCode = hashCode, next = i };
            buckets[bucketIndex] = lastIndex + 1;
        }

        public bool Contains(T value)
        {
            if (buckets == null)
            {
                return false;
            }

            int hashCode = GetHashCode(value);
            int bucketIndex = GetBucketIndex(hashCode);
            for (int i = GetBucket(bucketIndex); i >= 0; i = slots[i].next)
            {
                if (slots[i].hashCode == hashCode && CompareValues(slots[i].value, value))
                {
                    return true;
                }
            }

            return false;
        }

        private void Initialize(int capacity)
        {
            slots = new Slot[capacity];
            buckets = new int[capacity];
            lastIndex = -1;
        }

        private void IncreaseCapacity(int amount = 5)
        {
            SetCapacity(slots.Length + amount);
        }

        private void SetCapacity(int newCapacity)
        {
            var newSlots = new Slot[newCapacity];
            for (int i = 0; i <= lastIndex; i++)
            {
                newSlots[i] = slots[i];
            }

            var newBuckets = new int[newCapacity];
            for (int i = 0; i <= lastIndex; i++)
            {
                int bucketIndex = GetBucketIndex(newSlots[i].hashCode, newCapacity);
                newSlots[i].next = GetBucket(newBuckets, bucketIndex);
                newBuckets[bucketIndex] = i + 1;
            }

            slots = newSlots;
            buckets = newBuckets;
        }

        private int GetHashCode(T value)
        {
            return value.GetHashCode();
        }

        private int GetBucketIndex(int hashCode)
        {
            return GetBucketIndex(hashCode, slots.Length);
        }

        private int GetBucketIndex(int hashCode, int capacity)
        {
            return hashCode % capacity;
        }

        private int GetBucketIndex(T value)
        {
            return GetBucketIndex(GetHashCode(value));
        }

        private int GetBucket(int bucketIndex)
        {
            return GetBucket(buckets, bucketIndex);
        }

        private int GetBucket(int[] inBuckets, int bucketIndex)
        {
            return inBuckets[bucketIndex] - 1;
        }

        private bool CompareValues(T left, T right)
        {
            //TODO change for equality comparer
            return left.Equals(right);
        }

        public override string ToString()
        {
            var str = "[";
            for (var i = 0; i <= lastIndex; ++i)
            {
                str += slots[i].value.ToString() + ",";
            }

            return str.Remove(str.Length - 1) + "]";
        }

        private int[] buckets;
        private Slot[] slots;
        private int lastIndex;

        /*
         * Slot for a hash value.
         * Contains it HashCode and an index for the next value with the same hashCode
         */
        internal struct Slot
        {
            public T value;
            public int hashCode;
            public int next;
        }
    }
}
