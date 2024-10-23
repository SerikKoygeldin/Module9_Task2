using System.IO;

namespace Module9_Task2
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            NumberReader numberReader  = new NumberReader();
            numberReader.NumberEnteredEvent += Sort;

            try
            {
                numberReader.Read();
                Console.ReadKey();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некоректное значение!") ;
            }
        }

        static void Sort(int number)
        {
            List<string> people = new List<string>() { "Андрей", "Сергей", "Роман", "Павел", "Михаил" };

            switch (number) { 

                case 1:
                    
                    people.Sort();

                    foreach (string p in people) Console.WriteLine(p);
                    break;

                case 2:

                    people.Sort();

                    for (int i = people.Count-1; i >= 0; i--) Console.WriteLine(people[i]);
                    break;
            }
        }     
    }

    class NumberReader     
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите значение 1 - сортировка по алфавиту или 2 - обратная сортировка:");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2) throw new FormatException();

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number) 
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
