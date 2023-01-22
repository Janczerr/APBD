using System;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            var z = LinqTasks.Task14();
            foreach (var task in z)
            {
                Console.WriteLine(task);
            }
        }
    }
}
