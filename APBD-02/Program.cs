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
            FileInfo source = new FileInfo("/Users/lukaszjanowski/RiderProjects/APBD/APBD-02/Data/dane.csv");
            FileInfo destination = new FileInfo("/Users/lukaszjanowski/RiderProjects/APBD/APBD-02/Data/konwersja.json");
            FileInfo logs = new FileInfo("/Users/lukaszjanowski/RiderProjects/APBD/APBD-02/Data/logs.txt");
            
            
            
            
            
            FileService fileService = new FileService();

            HashSet<Student> students = fileService.getStudentFromFile(source, logs);
            fileService.saveUczenlniaToFile(students, destination, "Śmietnik");

        }
    }
}