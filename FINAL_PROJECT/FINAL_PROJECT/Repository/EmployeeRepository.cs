using FINAL_PROJECT.Models;
using FINAL_PROJECT.Viewmodel;
using Microsoft.EntityFrameworkCore;

namespace FINAL_PROJECT.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        EmployeeDetailsContext db;
        public EmployeeRepository(EmployeeDetailsContext _db)
        {
            db = _db;
        }



        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            if (db != null)
            {
                return await (from e in db.Employees

                              select new EmployeeViewModel
                              {
                                  EmployeeId = e.EmployeeId,
                                  EmployeeName = e.EmployeeName,
                                  Band = e.Band,
                                  Role = e.Role,
                                  Designation = e.Designation,
                                  Responsibilities = e.Responsibilities,
                                  ImageUrl = e.ImageUrl,

                              }).ToListAsync();
            }

            return null;
        }

        public async Task<EmployeeViewModel> GetEmployee(int? EmployeeId)
        {
            if (db != null)
            {
                return await (from e in db.Employees.Where(e => e.EmployeeId == EmployeeId)

                              select new EmployeeViewModel
                              {
                                  EmployeeId = e.EmployeeId,
                                  EmployeeName = e.EmployeeName,
                                  Band = e.Band,
                                  Role = e.Role,
                                  Designation = e.Designation,
                                  Responsibilities = e.Responsibilities,
                                  ImageUrl = e.ImageUrl,
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<int> PostEmployee(Employee employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();

                return employee.EmployeeId;
            }

            return 0;
        }

        public async Task<int> DeleteEmployee(int? EmployeeId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the Employee for specific Employee id
                var employee = await db.Employees.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);

                if (employee != null)
                {
                    //Delete that Employee
                    db.Employees.Remove(employee);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }


        public async Task PutEmployee(Employee employee)
        {
            if (db != null)
            {
                //update  Employee
                db.Employees.Update(employee);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}

