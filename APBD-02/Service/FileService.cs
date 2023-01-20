using APBD_02.Models;
using System.Text.Json;

namespace APBD_02.Service;

public class FileService
{
    public HashSet<Student> getStudentFromFile(FileInfo fileInfo, FileInfo logsFile)
    {
        HashSet<Student> students = new HashSet<Student>();
        HashSet<Student> logs = new HashSet<Student>();

        StreamReader streamReader = new StreamReader(fileInfo.OpenRead());

        string line = null;
        while((line = streamReader.ReadLine()) != null)
        {
            string[] splits = line.Split(',');
            
            Student student = new Student
            {
                fname = splits[0],
                lname = splits[1],
                studiesName = splits[2],
                studiesMode = splits[3],
                indexNumber = "s" + splits[4],
                birthdate = splits[5],
                email = splits[6],
                mothersName = splits[7],
                fathersName = splits[8]
            };
            if (students.Add(student))
            {
                Console.WriteLine("Dodano studenta");
            }
            else
            {
                logs.Add(student);
            }
        }

        //saveLogs(logs, logsFile);
        return students;
    }

    public void saveLogs(HashSet<Student> logs, FileInfo logsFile)
    {
        StreamWriter streamWriter = new StreamWriter(logsFile.OpenWrite());
        foreach (var student in logs)
        {        
            streamWriter.WriteLine("Student o indeksie " + student.indexNumber + " juz istnieje w bazie");
        }
        streamWriter.Close();
    }
    public void saveUczenlniaToFile(HashSet<Student> students, FileInfo destination, String author)
    {
        StreamWriter streamWriter = new StreamWriter(destination.OpenWrite());
        var options = new JsonSerializerOptions { WriteIndented = true };

        Uczelnia uczelnia = new Uczelnia
        {
            createdAt = DateTime.Now.ToString(),
            author = author,
            students = students
        };

        var jsonString = JsonSerializer.Serialize(uczelnia, options);
        streamWriter.WriteLine(jsonString);
        streamWriter.Close();
    }
}