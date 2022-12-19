using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day6
{
    //[DebuggerDisplay("{Questions}")]
    class Person
    {
        private Dictionary<char, Question> m_questions = new Dictionary<char, Question>();

        public void AddQuestions(IEnumerable<Question> questions)
        {
            // add questions for a person
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }
        public void AddQuestion(Question question)
        {
            m_questions[question.Key] = question;
        }

        public bool HasYesAnswer(char key)
        {
            return m_questions.ContainsKey(key);
        }

        public int YesCount
        {
            get
            {
                return m_questions.Values.Count(q => q.Answer == "yes");
            }
        }

        public IEnumerable<char> Questions
        {
            get { return m_questions.Keys.ToArray(); }
        }

        public override string ToString()
        {
            return new string(m_questions.Keys.OrderBy(x => x).ToArray());
        }
    }
}
