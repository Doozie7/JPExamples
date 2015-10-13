using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPExamples
{
    public class EntityFramework
    {
        public void Execute()
        {
            NorthWind context = new NorthWind();
            List<Employee> employees = context.Employees.Where(e => e.Gender == "F").ToList();
            foreach(Employee emp in employees)
            {
                Console.WriteLine(emp.MaritalStatus);
            }
        }
    }
}
