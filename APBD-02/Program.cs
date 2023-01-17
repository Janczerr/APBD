using APBD_02.Models;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace APBD_02
{
    public class Program
    {
        public static void Main(String[] args)
        {
            // 1. Argumenty
            

            // 2. Kolekcja
            HashSet<Student> set = new HashSet<Student>();

            // 3. Klasa modelowa - Student

            
            // 4. Odczytt bazy z pliku
            FileInfo source = new FileInfo(args[0]);
            FileInfo destination = new FileInfo(args[1]);

            StreamReader streamReader = new StreamReader(source.OpenRead());

            string line = null;
            int counterPowtorki = 0;

            // Odczyt pliku
            while((line = streamReader.ReadLine()) != null)
            {
                //Podzielenie pliku
                string[] splits = line.Split(',');

                //Utworzenie obiektu i przypisanie zmiennych
                Student student = new Student
                {
                   fname= splits[0],
                   lname= splits[1],
                   studiesName= splits[2],
                   studiesMode= splits[3],
                   indexNumber= "s" + splits[4],
                   birthdate= splits[5],
                   email= splits[6],
                   mothersName= splits[7],
                   fathersName= splits[8]
                };

                //Zapis pliku do hashsetu
                set.Add(student);
                counterPowtorki++;
            }

            StreamWriter streamWriter = new StreamWriter(destination.OpenWrite());
            var options = new JsonSerializerOptions { WriteIndented = true };

            Uczelnia uczelnia = new Uczelnia
            {
                createdAt = DateTime.Now.ToString(),
                author = "Jan",
                students = set
            };

            var jsonString = JsonSerializer.Serialize(uczelnia, options);
            streamWriter.WriteLine(jsonString);

            streamWriter.Close();
        }
    }
}