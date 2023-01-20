using APBD_02.Models;
using APBD_02.Service;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.Json;

namespace APBD_02
{
    public class Program
    {
        public static void Main(String[] args)
        {
            string source = args[0];
            string destination = args[1];
            string logs = "Data/logs.txt";

            FileService fileService = new FileService(source, destination, logs);

            HashSet<Student> students = fileService.getDistinctStudents();
            fileService.saveUczenlniaToFile(students);
        }
    }
}