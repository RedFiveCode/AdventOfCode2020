using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class GroupOfPeople
    {
        private List<Person> m_people = new List<Person>();

        public void AddPerson(Person person)
        {
            m_people.Add(person);
        }

        public int People
        {
            get { return m_people.Count; }
        }

        public int GetCountForQuestion(char key)
        {
            return m_people.Count(p => p.HasYesAnswer(key));
        }

        public IEnumerable<char> GetQuestions()
        {
            var x = m_people.Select(p => p.Questions).ToList().Distinct();

            return null;
        }

        public int CountQuestionsWhereEveryoneAnsweredYes()
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (var key in "abcdefghijklmnopqrstuvwxyz".ToArray())
            {
                counts[key] = GetCountForQuestion(key);
            }

            var sum = counts.Values.Where(v => v == m_people.Count).Count();

            return sum;
        }
    }
}
