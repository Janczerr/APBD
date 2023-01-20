using APBD_03.Models;
using APBD_03.Service;
using Microsoft.AspNetCore.Mvc;

namespace APBD_03.Controllers;

[Route("api/students")]
[ApiController]
public class StudentsController : ControllerBase
{
    private static readonly FileService _fileService = new FileService("/Users/lukaszjanowski/RiderProjects/APBD/APBD-02/Data/dane.csv");
    HashSet<Student> students = _fileService.getStudentFromFile();
    
    [HttpGet]
    public IActionResult getStudents()
    {
        return Ok(students);
    }

    [HttpGet("{indexNumber}")]
    public IActionResult getStudent(String indexNumber)
    {
        foreach (var student in students)
        {
            if (student.indexNumber == indexNumber)
            {
                return Ok(student);
            }
        }
        return NotFound();
    }

    [HttpPost("{indexNumber}")]
    public IActionResult addStudent(String indexNumber)
    {
        if (getStudent(indexNumber) == NotFound())
        {
            Console.WriteLine("Nie istnieje");
        }
        else
        {
            Console.WriteLine("Istnieje w bazie");
        }
        return Ok("Added student" + getStudent(indexNumber).ToString());
    }
}