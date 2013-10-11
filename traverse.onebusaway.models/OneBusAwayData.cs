using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class OneBusAwayData<T>
    {
        public bool LimitExceeded { get; set; }

        public T Entry { get; set; }

        public List<T> List { get; set; }
    }
}