using FINAL_PROJECT.Controllers;
using FINAL_PROJECT.Models;
using FINAL_PROJECT.Repository;
using FINAL_PROJECT.Viewmodel;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEmployee.Test
{
    public class EmployeeUnitTestController
    {
        private EmployeeRepository repository;
        public static DbContextOptions<EmployeeDetailsContext> dbContextOptions { get; }
        public static string connectionString = "Server=BLR1-LHP-N80939\\SQLEXPRESS;Initial Catalog=EmployeeDetails;MultipleActiveResultSets=true;Trusted_Connection=True;Encrypt=False";

        static EmployeeUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeDetailsContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public EmployeeUnitTestController()
        {
            var context = new EmployeeDetailsContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new EmployeeRepository(context);

        }

        //GET BY ID

        [Fact]
        public async void Task_GetEmployeeById_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 2;

            //Act  
            var data = await controller.GetEmployee(EmployeeId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public async void Task_GetEmployeeById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 7;

            //Act  
            var data = await controller.GetEmployee(EmployeeId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            int? EmployeeId = null;

            //Act  
            var data = await controller.GetEmployee(EmployeeId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }




        [Fact]
        public async void Task_GetEmployeeById_MatchResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            int EmployeeId = 1;

            //Act  
            var data = await controller.GetEmployee(EmployeeId);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject ;
            var employee = okResult.Value.Should().BeAssignableTo<EmployeeViewModel>().Subject;

            Assert.Equal("Deepika", employee.EmployeeName);
            Assert.Equal("Z", employee.Band);
            Assert.Equal("Developer", employee.Role);
            Assert.Equal("Trainee", employee.Designation);
            Assert.Equal("Developing", employee.Responsibilities);
            Assert.Equal("https://cdn-icons-png.flaticon.com/512/4974/4974985.png", employee.ImageUrl);
        }




        // GET ALL 


        [Fact]
        public async void Task_GetEmployees_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);

            //Act  
            var data = await controller.GetEmployees();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetEmployees_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);

            //Act  
            var data = controller.GetEmployees();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetEmployees_MatchResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);

            //Act  
            var data = await controller.GetEmployees();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var employee = okResult.Value.Should().BeAssignableTo<List<EmployeeViewModel>>().Subject;


            Assert.Equal("Deepika", employee[0].EmployeeName);
            Assert.Equal("Z", employee[0].Band);
            Assert.Equal("Developer", employee[0].Role);
            Assert.Equal("Trainee", employee[0].Designation);
            Assert.Equal("Developing", employee[0].Responsibilities);
            Assert.Equal("https://cdn-icons-png.flaticon.com/512/4974/4974985.png", employee[0].ImageUrl);

            Assert.Equal("Disha", employee[1].EmployeeName);
            Assert.Equal("X", employee[1].Band);
            Assert.Equal("Testing", employee[1].Role);
            Assert.Equal("Trainee", employee[1].Designation);
            Assert.Equal("Manual Testing", employee[1].Responsibilities);
            Assert.Equal("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRofOJbCvrNDtiX96xv8dKFrmzTJZA3IDio5A&usqp=CAU", employee[1].ImageUrl);



        }




        // ADD NEW EMPLOYEE

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var employee = new Employee() { EmployeeName = "Ragavi", Band = "Z", Role = "Developer", Designation = "TSE", Responsibilities = "Developing", ImageUrl = "https://cdn-icons-png.flaticon.com/512/4974/4974985.png "};

            //Act  
            var data = await controller.PostEmployee(employee);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new EmployeesController(repository);

            Employee employee = new Employee() { EmployeeId = 1, EmployeeName = "", Band = "Z", Role = "Developer", Designation = "TSE", Responsibilities = "Developing", ImageUrl = "https://cdn-icons-png.flaticon.com/512/4974/4974985.png" };

            //Act              
            var data = await controller.PostEmployee(employee);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }




        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var employee = new Employee() { EmployeeName = "Deepika", Band = "Z", Role = "Developer", Designation = "TSE", Responsibilities = "Developing", ImageUrl = "https://cdn-icons-png.flaticon.com/512/4974/4974985.png" };

            //Act  
            var data = await controller.PostEmployee(employee);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;


            Assert.Equal(5, okResult.Value);

        }


        // UPDATE THE EMPLOYEE


        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 2;

            //Act  
            var existingPost = await controller.GetEmployee(EmployeeId);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<EmployeeViewModel>().Subject;

            var employee = new Employee();
            employee.EmployeeName = "Chandrika";
            employee.Band = result.Band;
            employee.Role = result.Role;
            employee.Designation= result.Designation;
            employee.Responsibilities = result.Responsibilities;
            employee.ImageUrl = result.ImageUrl;


            var updatedData = await controller.PutEmployee(employee);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 2;

            //Act  
            var existingPost = await controller.GetEmployee(EmployeeId);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<EmployeeViewModel>().Subject;

            var employee = new Employee();
            employee.EmployeeId = 1;
            employee.EmployeeName = "Chandrika";
            employee.Band = result.Band;
            employee.Role = result.Role;
            employee.Designation = result.Designation;
            employee.Responsibilities = result.Responsibilities;
            employee.ImageUrl = result.ImageUrl;
            var data = await controller.PutEmployee(employee);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }



        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 2;

            //Act  
            var existingEmployee = await controller.GetEmployee(EmployeeId);
            var okResult = existingEmployee.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<EmployeeViewModel>().Subject;

            var employee = new Employee();
            employee.EmployeeId = 8;
            employee.EmployeeName = "Chandrika";
            employee.Band = result.Band;
            employee.Role = result.Role;
            employee.Designation = result.Designation;
            employee.Responsibilities = result.Responsibilities;
            employee.ImageUrl = result.ImageUrl;
            var data = await controller.PutEmployee(employee);

          

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }


        // DELETE EMPLOYEE

        [Fact]
        public async void Task_Delete_Employee_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 2;

            //Act  
            var data = await controller.DeleteEmployee(EmployeeId);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Delete_Employee_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            var EmployeeId = 7;

            //Act  
            var data = await controller.DeleteEmployee(EmployeeId);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }


        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeesController(repository);
            int? EmployeeId = null;
           

            //Act  
            var data = await controller.DeleteEmployee(EmployeeId);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }



    }
}
