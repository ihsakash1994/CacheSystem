using System;
using System.Collections.Generic;

namespace FlipkartCache
{
    /// <summary>
    /// The cache class
    /// </summary>
    public class Cache
    {
        /// <summary>
        /// Maximum size of cache.
        /// </summary>
        private int cacheSize;

        /// <summary>
        /// Dictinary of key and value.
        /// </summary>
        private Dictionary<string, string> KeyValue;

        /// <summary>
        /// Dictinary of key and score.
        /// </summary>
        private Dictionary<string, DateTime> KeyScore;

        /// <summary>
        /// Policy object.
        /// </summary>
        private IPolicy Policy;

        /// <summary>
        /// Datastore object.
        /// </summary>
        private IDataStore DataStore;

        /// <summary>
        /// Intialize the cache.
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="dataStore"></param>
        /// <param name="cacheSize"></param>
        public Cache(IPolicy policy, IDataStore dataStore, int cacheSize)
        {
            if (cacheSize <= 0)
            {
                throw new InvalidOperationException("Cahche size must be positive number.");
            }

            this.Policy = policy;
            this.cacheSize = cacheSize;
            this.KeyValue = new Dictionary<string, string>();
            this.KeyScore = new Dictionary<string, DateTime>();
            this.DataStore = dataStore;
        }

        /// <summary>
        /// Get the value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            if (!KeyValue.ContainsKey(key))
            {
                throw new InvalidOperationException("Key not found");
            }

            Policy.UpdateScore(KeyScore, key, OperationType.Get);
            return KeyValue[key];
        }

        /// <summary>
        /// set the key and value.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, string value)
        {
            if (KeyValue.Count == this.cacheSize)
            {
                Policy.RemoveKey(KeyValue, KeyScore, cacheSize);
            }

            KeyValue[key] = value;
            Policy.UpdateScore(KeyScore, key, OperationType.Set);
        }
    }
}
