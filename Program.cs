using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public enum WeekDay
    {
        Понедельник,
        Вторник,
        Среда,
        Четверг,
        Пятница,
        Суббота,
        Воскресенье
    }

    public class Lesson
    {
        private static char nextLabel = 'A';
        private static Random rand = new Random();
        public string Label { get; set; }
        public int Number { get; set; }
        public int WeekNumber { get; set; }
        public WeekDay WeekDay { get; set; }
        public string GroupNumber { get; set; }

        public Lesson()
        {
            Label = nextLabel.ToString();
            nextLabel = (char)(nextLabel + 1);

            Number = rand.Next(1, 5);
            WeekNumber = rand.Next(0, 3); 
            WeekDay = (WeekDay)rand.Next(0, 7);
            GroupNumber = GenerateGroupNumber();
        }

        public Lesson(string label, int number, int weekNumber, WeekDay weekDay, string groupNumber)
        {
            Label = label;
            Number = number;
            WeekNumber = weekNumber;
            WeekDay = weekDay;
            GroupNumber = groupNumber;
        }

        private string GenerateGroupNumber()
        {
            List<string> groups = new List<string> { "11", "12", "13" };
            return groups[rand.Next(groups.Count)];
        }

        public override string ToString()
        {
            return $"{Label}, {Number} пара {WeekDay}, {GroupNumber} группа, " +
                   $"{(WeekNumber == 0 ? "каждую" : $"в {WeekNumber}")} неделю";
        }
    }

    public class Schedule
    {
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }

        public Schedule(string name)
        {
            Name = name;
            Lessons = new List<Lesson>();
        }

        private void Add(Lesson lesson)
        {
            Lessons.Add(lesson);
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Lessons.Count; i++)
            {
                result += $"{i + 1}. {Lessons[i]}\n";
            }
            return result;
        }

        public int Count(Func<Lesson, bool> dayfilter)
        {
            return Lessons.Count(dayfilter);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
