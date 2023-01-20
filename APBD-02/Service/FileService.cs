using System.Reflection;
using APBD_02.Models;
using System.Text.Json;

namespace APBD_02.Service;

public class FileService
{
    public string sourcePath { get; set; }
    public string destinationPath { get; set; }
    public string logsPath { get; set; }
    public FileService(string sourcePath, string destinationPath, string logsPath)
    {
        this.sourcePath = sourcePath;
        this.destinationPath = destinationPath;
        this.logsPath = logsPath;
    }
    public HashSet<Student> getDistinctStudents()
    {
        HashSet<Student> students = new HashSet<Student>();
        
        StreamReader streamReader = new StreamReader(sourcePath);
        string line = null;
        while((line = streamReader.ReadLine()) != null)
        {
            string[] splits = line.Split(',');
            Student student = new Student();
            Type studentType = student.GetType();
            int index = 0;
            
            foreach (PropertyInfo property in studentType.GetProperties())
            {
                if (splits[index] != null & splits[index] != "")
                {
                    property.SetValue(student, splits[index]);
                }
                else
                {
                    AppendLogMessage("Student " + student.indexNumber + ": wartość " + property + " nie może być nullem");
                }
                index++;
            }
            
            if (students.Add(student) != true)
            {
                AppendLogMessage("Student " + student.indexNumber + " już istnieje w bazie");
            }
        }
        return students;
    }
    
    public void AppendLogMessage(string message)
    {
        StreamWriter streamWriter = new StreamWriter(logsPath, true);
        streamWriter.WriteLine(message);
        streamWriter.Close();
    }
    public void saveUczenlniaToFile(HashSet<Student> students)
    {
        StreamWriter streamWriter = new StreamWriter(destinationPath, false);
        var options = new JsonSerializerOptions { WriteIndented = true };

        Uczelnia uczelnia = new Uczelnia
        {
            createdAt = DateTime.Now.ToString(),
            author = "Author",
            students = students
        };

        var jsonString = JsonSerializer.Serialize(uczelnia, options);
        streamWriter.WriteLine(jsonString);
        streamWriter.Close();
    }
}