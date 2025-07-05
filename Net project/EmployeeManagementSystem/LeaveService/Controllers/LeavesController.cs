using System.Collections.Generic;
using System.Web.Http;

public class LeavesController : ApiController {
    static List<Leave> leaves = new List<Leave>();

    [HttpGet]
    public IEnumerable<Leave> Get() => leaves;

    [HttpPost]
    public IHttpActionResult Post(Leave leave) {
        leave.Id = leaves.Count + 1;
        leaves.Add(leave);
        return Ok(leave);
    }

    [HttpPut]
    public IHttpActionResult Put(int id, Leave leave) {
        var l = leaves.Find(x => x.Id == id);
        if (l == null) return NotFound();
        l.EmployeeId = leave.EmployeeId; l.StartDate = leave.StartDate;
        l.EndDate = leave.EndDate; l.Reason = leave.Reason;
        return Ok(l);
    }

    [HttpDelete]
    public IHttpActionResult Delete(int id) {
        var l = leaves.Find(x => x.Id == id);
        if (l == null) return NotFound();
        leaves.Remove(l);
        return Ok();
    }
}