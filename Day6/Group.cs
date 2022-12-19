using System.Collections.Generic;
using System.Linq;

namespace Day6
{


    class Group
    {
        private Dictionary<char, Question> m_questions = new Dictionary<char, Question>();
        private Dictionary<char, int> m_questionCounts = new Dictionary<char, int>();
        private int groupSize = 0; // number of people in the group

        public void AddQuestions(IEnumerable<Question> questions)
        {
            // add questions for a person
            groupSize++;

            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }
        public void AddQuestion(Question question)
        {
            m_questions[question.Key] = question;

            if (!m_questionCounts.ContainsKey(question.Key))
            {
                m_questionCounts[question.Key] = 0;
            }


            if (m_questionCounts.ContainsKey(question.Key))
            {
                m_questionCounts[question.Key] = m_questionCounts[question.Key] + 1;
            }
        }

        public int YesCount
        {
            get
            {
                return m_questions.Values.Count(q => q.Answer == "yes");
            }
        }

        public bool EveryoneAnsweredYes
        {
            get
            {
                return groupSize == YesCount;
            }
        }

    }
}
