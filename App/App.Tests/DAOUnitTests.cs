using Microsoft.VisualStudio.TestTools.UnitTesting;
using static App.Util.AutofacConfig;
using Autofac;
using CodeFirst;
using App.Controllers;
using App.Service.Interfaces;
using System.Web.Mvc;
using App.Util;
using System.Web;
using App.DAL;
using App.Models.DatabaseModel;
using App.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using App.Service;

namespace App.Tests
{
    [TestClass]
    public class UnitTests
    {
        private EmployeeDataAccessObject employeeDAO;
        private Mock<IDatabaseContextAccessor> mock;
        private IEmployeeService employeeService;
        private Mock<IEmployeeDAO> employeeDataAccessObjectMock;
        private Mock<IProjectDAO> projectDataAccessObjectMock;

        [TestMethod]
        public void EmployeeDAOTest()
        {
            mock = new Mock<IDatabaseContextAccessor>();
            //found no other way to create an instance of DbSet<EmployeeModel>
            mock.Setup(x => x.GetEmployeeSet()).Returns(() => new DatabaseModelContainer().EmployeeSet);
            employeeDAO = new EmployeeDataAccessObject(mock.Object);
            employeeDAO.Add(new Models.EmployeeModel()
            {
                Id = 12312,
                Name = "AAA",
                Position = (Roles)1,
                Surname = "ZZZ",
                ActualProjects = new List<ProjectModel>(),
                AbsenceList = new List<ManagingDateModel>()
            });
        }

        [TestMethod]
        public void EmployeeServiceTest()
        {
            int employeeId = 5;
            employeeDataAccessObjectMock = new Mock<IEmployeeDAO>();
            //if this could be named as a test
            employeeDataAccessObjectMock.Setup(x => x.GetSingle(It.IsAny<int>())).Returns(() => new EmployeeModel() {  });
            projectDataAccessObjectMock = new Mock<IProjectDAO>();
            employeeService = new EmployeeService(employeeDataAccessObjectMock.Object, projectDataAccessObjectMock.Object);
            employeeService.GetSingle(employeeId);
        }
    }
}
