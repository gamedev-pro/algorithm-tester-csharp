using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgTester.Solutions.Extras.CoreDataStructs
{
    class HashSetWithDoubleList<T> : IEnumerable<T>
    {
        public HashSetWithDoubleList(int capacity = 3)
        {
            Initialize(capacity);
        }

        public HashSetWithDoubleList(IEnumerable<T> collection)
        {
            Initialize(2);
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
            return Length;
        }

        public bool Contains(T value)
        {
            var hashCode = GetHashCode(value);
            var bucket = GetBucket(GetBucketIndex(hashCode));

            return bucket.Contains(value);
        }

        private void AddIfNotPresent(T value)
        {
            var hashCode = GetHashCode(value);
            var bucket = GetBucket(GetBucketIndex(hashCode));

            if (bucket.Contains(value))
            {
                return;
            }

            if (bucket.Count >= maxBucketCapacity)
            {
                IncreaseCapacity();
                AddIfNotPresent(value);
            }
            else
            {
                bucket.Add(value);
                ++Length;
            }
        }

        private void Initialize(int capacity = 3)
        {
            buckets = new List<T>[capacity];
            Length = 0;
            maxBucketCapacity = Math.Clamp((int) Math.Ceiling(capacity * 0.3), 2, 5);
        }

        private void IncreaseCapacity(int amount = 5)
        {
            SetCapacity(buckets.Length + amount);
        }

        private void SetCapacity(int newCapacity)
        {
            var newBuckets = new List<T>[newCapacity];
            foreach (var item in this)
            {
                var bucketIndex = GetBucketIndex(newBuckets, GetHashCode(item));
                var bucket =  GetBucket(newBuckets, bucketIndex);
                bucket.Add(item);
            }
            buckets = newBuckets;
        }

        private int GetHashCode(T value)
        {
            return value.GetHashCode();
        }

        private int GetBucketIndex(int hashCode)
        {
            return GetBucketIndex(buckets, hashCode);
        }

        private int GetBucketIndex(List<T>[] inBuckets, int hashCode)
        {
            return hashCode % inBuckets.Length;
        }

        private List<T> GetBucket(int bucketIndex)
        {
            return GetBucket(buckets, bucketIndex);
        }

        private List<T> GetBucket(List<T>[] inBuckets, int bucketIndex)
        {
            if (inBuckets[bucketIndex] == null)
            {
                inBuckets[bucketIndex] = new List<T>(maxBucketCapacity);
            }
            return inBuckets[bucketIndex];
        }

        public override string ToString()
        {
            var str = "[";
            foreach (var item in this)
            {
                str += item.ToString() + ",";
            }

            return str.Remove(str.Length - 1) + "]";
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (var item in bucket)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private List<T>[] buckets;
        int Length;
        private int maxBucketCapacity;
    }
}
