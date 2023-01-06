using FINAL_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEmployee.Test
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(EmployeeDetailsContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Employees.AddRange(
                new Employee() { EmployeeName = "Deepika", Band = "Z", Role = "Developer", Designation = "Trainee", Responsibilities = "Developing", ImageUrl = "https://cdn-icons-png.flaticon.com/512/4974/4974985.png" },
                new Employee() { EmployeeName = "Disha", Band = "X", Role = "Testing", Designation = "Trainee", Responsibilities = "Manual Testing", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRofOJbCvrNDtiX96xv8dKFrmzTJZA3IDio5A&usqp=CAU" },
                new Employee() { EmployeeName = "Kartik", Band = "B", Role = "Developer", Designation = "Software Engineering", Responsibilities = "Developing", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRE_6ineJBvRJkVjc4XvngUSnouWwn1p-KDac5Nq8N9SjgFCETn8OTlS6qs4lurcrrA4kw&usqp=CAU" },
                new Employee() { EmployeeName = "Shashi", Band = "C", Role = "Developer", Designation = "Software Engineering", Responsibilities = "Developing", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT3kovk957bYIDUIXLBPXK43NBeCxYq3pPXOH5fTEyUUq1QTmCcERcGcZ-CJVAi1wJ7iiw&usqp=CAU" }
            );


            context.SaveChanges();
        }

    }
}
