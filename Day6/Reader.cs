using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Reader
    {
        public List<Group> Read(string filename)
        {
            var groups = new List<Group>();

            var lines = File.ReadAllLines(filename);

            Group currentGroup = null;

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    // end of group / start of next group
                    currentGroup = null;
                }
                if (line.Length > 0)
                {
                    if (currentGroup == null)
                    {
                        currentGroup = new Group();
                        groups.Add(currentGroup);
                    }

                    var questionsForPerson = new List<Question>();
                    foreach (var c in line)
                    {
                        questionsForPerson.Add(new Question(c, "yes"));
                    }

                    currentGroup.AddQuestions(questionsForPerson);
                }
            }

            return groups;
        }

        public List<GroupOfPeople> ReadGroups(string filename)
        {
            var groups = new List<GroupOfPeople>();

            var lines = File.ReadAllLines(filename);

            GroupOfPeople currentGroup = null;

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    // end of group / start of next group
                    currentGroup = null;
                }
                if (line.Length > 0)
                {
                    var currentPerson = new Person();

                    if (currentGroup == null)
                    {
                        currentGroup = new GroupOfPeople();
                        groups.Add(currentGroup);
                    }

                    foreach (var c in line)
                    {
                        currentPerson.AddQuestion(new Question(c, "yes"));
                    }

                    currentGroup.AddPerson(currentPerson);
                }
            }

            return groups;
        }
    }
}
