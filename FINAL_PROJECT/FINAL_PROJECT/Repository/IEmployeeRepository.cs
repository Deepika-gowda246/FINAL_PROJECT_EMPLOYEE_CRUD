using FINAL_PROJECT.Models;
using FINAL_PROJECT.Viewmodel;

namespace FINAL_PROJECT.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeViewModel>> GetEmployees();

        Task<EmployeeViewModel> GetEmployee(int? EmployeeId);

        Task<int> PostEmployee(Employee employee);
        Task<int> DeleteEmployee(int? EmployeeId);

        Task PutEmployee(Employee employee);
    }
}
