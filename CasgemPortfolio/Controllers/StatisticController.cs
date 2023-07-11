using CasgemPortfolio.Models.Entities;
using System.Linq;
using System.Web.Mvc;


namespace CasgemPortfolio.Controllers
{
    public class StatisticController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            ViewBag.employeeCount = db.TblEmployee.Count();
            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(y => y.EmployeeName + " " + y.EmployeeSurName).FirstOrDefault();

            ViewBag.totalCityCount=db.TblEmployee.Distinct().Select(x=>x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);

            ViewBag.countSoftwareDepartment = db.TblEmployee.Where(x => x.EmployeeDepartment == db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepartmentID).FirstOrDefault()).Count();

            ViewBag.cityAnkaraOrAdanaSumSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Adana" || x.EmployeeCity == "Ankara").Sum(y => y.EmployeeSalary);

            ViewBag.sumSalaryFromSoft = db.TblEmployee.Where(x => x.EmployeeCity == "Ankara"&& x.EmployeeDepartment ==db.TblDepartment.Where(z=>z.DepartmentName=="Yazılım").Select(y=>y.DepartmentID).FirstOrDefault()).Sum(w=>w.EmployeeSalary);

            return View();
        }
    }
}