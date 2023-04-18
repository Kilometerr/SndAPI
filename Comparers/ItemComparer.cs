using System.Diagnostics.CodeAnalysis;
using SndAPI.Models;

namespace SndAPI.Comparers
{
    public class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item? x, Item? y)
        {
            return x.GameId == y.GameId;
        }

        public int GetHashCode([DisallowNull] Item obj)
        {
            return obj.GameId.GetHashCode();
        }
    }
}