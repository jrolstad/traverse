using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace traverse.onebusaway.models
{
    public class OneBusAwayResponse<T>
    {
        public string Version { get; set; }

        public int? Code { get; set; }

        public long CurrentTime { get; set; }

        public string Text { get; set; }

        public T Data { get; set; }
    }
}
