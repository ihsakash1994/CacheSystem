using System;
using System.Collections.Generic;

namespace FlipkartCache
{
    /// <summary>
    /// Custom policy.
    /// </summary>
    public class CustomPolicy : IPolicy
    {
        /// <summary>
        /// Remove key.
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <param name="KeyScore"></param>
        /// <param name="maxScore"></param>
        void IPolicy.RemoveKey(
            Dictionary<string, string> KeyValue,
            Dictionary<string, DateTime> KeyScore,
            int maxScore)
        {
            DateTime minimumScore = DateTime.Now;
            string key = string.Empty;
            foreach (KeyValuePair<string, DateTime> item in KeyScore)
            {
                if (DateTime.Compare(item.Value, minimumScore) < 0)
                {
                    minimumScore = item.Value;
                    key = item.Key;
                }
            }

            KeyValue.Remove(key);
            KeyScore.Remove(key);
        }

        /// <summary>
        /// Update Score.
        /// </summary>
        /// <param name="KeyScore"></param>
        /// <param name="key"></param>
        /// <param name="opType"></param>
        void IPolicy.UpdateScore(
            Dictionary<string, DateTime> KeyScore,
            string key,
            OperationType opType)
        {
            KeyScore[key] = DateTime.Now;
        }

        //private int GetCurrentTimeS
    }
}
