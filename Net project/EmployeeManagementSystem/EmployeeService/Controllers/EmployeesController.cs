using System.Collections.Generic;
using System.Web.Http;

public class EmployeesController : ApiController {
    static List<Employee> employees = new List<Employee>();

    [HttpGet]
    public IEnumerable<Employee> Get() => employees;

    [HttpPost]
    public IHttpActionResult Post(Employee emp) {
        emp.Id = employees.Count + 1;
        employees.Add(emp);
        return Ok(emp);
    }

    [HttpPut]
    public IHttpActionResult Put(int id, Employee emp) {
        var e = employees.Find(x => x.Id == id);
        if (e == null) return NotFound();
        e.Name = emp.Name; e.Email = emp.Email; e.Department = emp.Department;
        return Ok(e);
    }

    [HttpDelete]
    public IHttpActionResult Delete(int id) {
        var e = employees.Find(x => x.Id == id);
        if (e == null) return NotFound();
        employees.Remove(e);
        return Ok();
    }
}