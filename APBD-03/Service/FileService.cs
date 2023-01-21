using System.Text.Json;
using APBD_03.Models;

namespace APBD_03.Service;

public class FileService
{
    public FileInfo sourceInfo { get; set; }
    public string sourcePath { get; set; }
    
    public FileService(String sourcePath)
    {
        this.sourcePath = sourcePath;
        sourceInfo = new FileInfo(sourcePath);
    }
    public HashSet<Student> getStudentFromFile()
    {
        HashSet<Student> students = new HashSet<Student>();
        StreamReader streamReader = new StreamReader(sourceInfo.OpenRead());

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
            students.Add(student);
        }
        return students;
    }
    public void SaveStudents(HashSet<Student> students)
    {
        var streamWriter = new StreamWriter(sourcePath, false);
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(students, options);
        streamWriter.WriteLine(jsonString);
        streamWriter.Close();
    }
    public void SaveStudent(Student student)
    {
        var streamWriter = new StreamWriter(sourcePath, true);
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(student, options);
        streamWriter.WriteLine(jsonString);
        streamWriter.Close();
    }
    
}