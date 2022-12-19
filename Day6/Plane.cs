using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Plane
    {
        private List<Group> m_groups = new List<Group>();

        public void AddGroup(Group group)
        {
            m_groups.Add(group);
        }

        public void AddGroups(IEnumerable<Group> groups)
        {
            m_groups.AddRange(groups);
        }

        public int Sum
        {
            get
            {
                return m_groups.Sum(g => g.YesCount);
            }
        }
    }
}
