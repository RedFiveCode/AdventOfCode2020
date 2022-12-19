using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day7
{
    //[DebuggerDisplay("{Name} ({Count})")]
    class Bag
    {
        public string Name { get; private set; }
        public List<Bag> Contents { get; private set; }

        public int Count { get; private set; }

        public Bag(string name) : this(name, 0)
        { }

        public Bag(string name, int count)
        {
            Name = name;
            Contents = new List<Bag>();
            Count = count;
        }

        public void AddContainedBag(string name, int count)
        {
            Contents.Add(new Bag(name, count));
        }

        public bool IsEmpty
        {
            get { return !Contents.Any(); }
        }

        public bool ContainsBag(string colour)
        {
            // TODO - recurse???
            return Contents.Any(b => b.Name == colour);
        }

        public override string ToString()
        {
            if (IsEmpty)
            {
                return Name;
            }
            return $"{Name} ({Contents.Count})";
        }
    }
}
