using System;
using System.Collections.Generic;

namespace CodilityRuntime.Solutions.Extras.CoreDataStructs
{
    class MapWithDoubleList<TKey, TValue>
    {
        private void Initialize(int capacity = 3)
        {
            buckets = new List<KeyValuePair>[capacity];
            maxBucketCapacity = Math.Clamp((int)Math.Ceiling(capacity * 0.3), 2, 5);
        }

        public void Add(TKey key, TValue value)
        {
            AddOrReplace(key, value);
        }

        public TValue Get(TKey key)
        {
            var coords = GetValueCoordinates(key);
            if (coords.IsValid())
            {
                return buckets[coords.bucketIndex][coords.valueIndex].value;
            }

            return default(TValue);
        }

        private MapValueCoordinates GetValueCoordinates(TKey key)
        {
            var hashCode = GetHashCode(key);
            var bucketIndex = GetBucketIndex(hashCode);
            var bucket = GetBucket(GetBucketIndex(hashCode));

            for (int i = 0; i < bucket.Count; i++)
            {
                if (CompareKeys(bucket[i].key, key))
                {
                    return new MapValueCoordinates { bucketIndex = bucketIndex, valueIndex = i };
                }
            }

            return new MapValueCoordinates { bucketIndex = bucketIndex, valueIndex = -1 };
        }

        private void AddOrReplace(TKey key, TValue value)
        {
            if (buckets == null)
            {
                Initialize();
            }

            var coords = GetValueCoordinates(key);
            if (coords.IsValid())
            {
                buckets[coords.bucketIndex][coords.valueIndex] = new KeyValuePair { key = key, value = value };
            }
            else
            {
                if (buckets[coords.bucketIndex].Count >= maxBucketCapacity)
                {
                    IncreaseCapacity();
                    AddOrReplace(key, value);
                }
                else
                {
                    buckets[coords.bucketIndex].Add(new KeyValuePair { key = key, value = value });
                }
            }
        }

        private void IncreaseCapacity(int amount = 3)
        {
            SetCapacity(buckets.Length + amount);
        }

        private void SetCapacity(int newCapacity)
        {
            var newBuckets = new List<KeyValuePair>[newCapacity];
            foreach (var bucket in buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                foreach (var item in bucket)
                {
                    var hashCode = GetHashCode(item.key);
                    var newBucketIndex = GetBucketIndex(newBuckets, hashCode);
                    var newBucket = GetBucket(newBuckets, newBucketIndex);
                    newBucket.Add(item);
                }
            }

            buckets = newBuckets;
        }

        private int GetHashCode(TKey key)
        {
            return key.GetHashCode();
        }

        private int GetBucketIndex(int hashCode)
        {
            return GetBucketIndex(buckets, hashCode);
        }
        private int GetBucketIndex(List<KeyValuePair>[] inBuckets, int hashCode)
        {
            return hashCode % inBuckets.Length;
        }

        private List<KeyValuePair> GetBucket(int bucketIndex)
        {
            return GetBucket(buckets, bucketIndex);
        }

        private List<KeyValuePair> GetBucket(List<KeyValuePair>[] inBuckets, int bucketIndex)
        {
            if (inBuckets[bucketIndex] == null)
            {
                inBuckets[bucketIndex] = new List<KeyValuePair>(maxBucketCapacity);
            }
            return inBuckets[bucketIndex];
        }

        private bool CompareKeys(TKey left, TKey right)
        {
            return left.Equals(right);
        }

        public IEnumerator<KeyValuePair> GetEnumerator()
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

        public override string ToString()
        {
            var str = "[";
            foreach (var keyValue in this)
            {
                str += "{" + keyValue.key.ToString() + ", " + keyValue.value.ToString() + "},";
            }

            return str.Remove(str.Length - 1) + "]";
        }

        private List<KeyValuePair>[] buckets;
        int maxBucketCapacity;
        
        internal struct KeyValuePair
        {
            public TValue value;
            public TKey key;
        }

        internal struct MapValueCoordinates
        {
            public int bucketIndex;
            public int valueIndex;

            public bool IsValid()
            {
                return bucketIndex >= 0 && valueIndex >= 0;
            }
        }
    }
}
