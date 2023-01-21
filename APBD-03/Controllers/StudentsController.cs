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

    [HttpPost]
    public IActionResult addStudent(Student student)
    {
        if (students.Add(student))
        {
            _fileService.SaveStudent(student);
            return Ok();
        }
        return Conflict();
    }


    [HttpPut("{indexNumber}")]
    public IActionResult updateStudent(String indexNumber, Student student)
    {
        foreach (var stud in students)
        {
            if (stud.indexNumber == indexNumber)
            {
                stud.fname = student.fname;
                stud.lname = student.lname;
                stud.studiesName = student.studiesName;
                stud.studiesMode = student.studiesMode;
                stud.birthdate = student.birthdate;
                stud.email = student.email;
                stud.mothersName = student.mothersName;
                stud.fathersName = student.fathersName;
                _fileService.SaveStudents(students);
                return Ok();
            }
        }
        return NotFound();
    }

    [HttpDelete("{indexNumber}")]
    public IActionResult deleteStudent(String indexNumber)
    {
        foreach (var student in students)
        {
            if (student.indexNumber == indexNumber)
            {
                students.Remove(student);
                _fileService.SaveStudents(students);
            }
        }
        return NotFound();
    }
}