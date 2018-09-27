using System;
using System.Collections.Generic;

namespace FlipkartCache
{
    /// <summary>
    /// Interface for policy implementation.
    /// </summary>
    public interface IPolicy
    {
        void UpdateScore(
            Dictionary<string, DateTime> KeyScore,
            string key,
            OperationType opType);

        void RemoveKey(
            Dictionary<string, string> KeyValue,
            Dictionary<string, DateTime> KeyScore,
            int maxScore);
    }
}