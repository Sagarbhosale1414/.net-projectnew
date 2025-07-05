using System.Web.Mvc;
using EmployeePortal.Models;

public class AuthController : Controller {
    public ActionResult Login() => View();

    [HttpPost]
    public ActionResult Login(UserModel user) {
        if(user.Username == "admin" && user.Password == "admin") {
            Session["User"] = user.Username;
            return RedirectToAction("Dashboard", "Home");
        }
        ViewBag.Error = "Invalid credentials";
        return View();
    }

    public ActionResult Logout() {
        Session.Clear();
        return RedirectToAction("Login");
    }
}