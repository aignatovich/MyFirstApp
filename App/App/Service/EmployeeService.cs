using App.DAL;
using App.Models;
using App.Models.ManagingTableModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Service
{
    public class EmployeeService
    {
        private EmployeeDataAccessObject employeeDataAccessObject = new EmployeeDataAccessObject();
        private int pageSize = 25;

        public ICollection<EmployeeModel> GetEmployeesByIds(IEnumerable<Int32> ids)
        {
            ICollection<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (Int32 employeeId in ids)
            {
                employees.Add(employeeDataAccessObject.GetSingle(employeeId));
            }

            return employees;
        }

        public void Add(EmployeeViewModel employee)
        {
            EmployeeModel toTransfer = employee.AsEmployeeModel();
            employeeDataAccessObject.Add(toTransfer);
        }

        public ICollection<EmployeeViewModel> GetAllViewModels()
        {
            ICollection<EmployeeViewModel> toTransfer = new List<EmployeeViewModel>();
            ICollection<EmployeeModel> employees = employeeDataAccessObject.GetAll();

            foreach (EmployeeModel e in employees)
            {
                toTransfer.Add(new EmployeeViewModel(e));
            }

            return toTransfer;
        }

        public EmployeeViewModel GetSingle(int id)
        {
            return new EmployeeViewModel (employeeDataAccessObject.GetSingle(id));
        }

        public void Remove(EmployeeViewModel employee)
        {
            employeeDataAccessObject.Remove(employee.Id);
        }

        public void Edit(EmployeeViewModel employee)
        {
            EmployeeModel toTransfer = employee.AsEmployeeModel();
            employeeDataAccessObject.Edit(toTransfer);
        }

        public IPagedList<EmployeeViewModel> GetAllAsIPagedList(int? monthTransfered, int? yearTransfered, int? page, int? sorting)
        {
            int pageNumber = (page ?? 1);
            int sortingOrder = (sorting ?? 2);
            int month = (monthTransfered ?? 0);
            int year = (yearTransfered ?? 0);
            List<EmployeeViewModel> employees = GetAllViewModels().ToList();
            List<EmployeeViewModel> toTransfer = new List<EmployeeViewModel>();

            if (month != 0 && year != 0)
            {
                switch (sortingOrder)
                {
                    case 1:
                        toTransfer = employees.OrderBy(x => x.Position.ToString()).ToList();
                        break;
                    case 2:
                        toTransfer = employees.OrderBy(x => x.Name).ToList();
                        break;
                    case 3:
                        toTransfer = employees.OrderBy(x => x.Surname).ToList();
                        break;
                }

                foreach (EmployeeViewModel e in toTransfer)
                {
                    e.AbsenceList = e.AbsenceList.Where(x => (x.Month == month && x.Year == year)).ToList();
                }
            }            
            return toTransfer.ToPagedList(pageNumber, pageSize);
        }

        public TableData GetTableData(HttpRequestBase request)
        {
            int year = Convert.ToInt32(request["year"]);          
            int month = Convert.ToInt32(request["month"]);
            int? page = (Convert.ToInt32(request["page"]));
            int? sorting = Convert.ToInt32(request["sorting"]);

            if (page == 0)
            {
                page = null;
            }
          
            if (sorting == 0)
            {
                sorting = null;
            }

            return new TableData(GetAllAsIPagedList(month, year, page, sorting), request);
        }


        public void ApplyAbsence(HttpRequestBase request)
        {
            HttpRequestBase r = request;
            int id = Convert.ToInt32(r["userId"]);

            EmployeeModel employee = employeeDataAccessObject.GetSingle(id);
            employee.AbsenceList.Add(new ManagingDateModel {
                Day = Convert.ToInt32(r["dayValue"]),
                Month = Convert.ToInt32(r["monthValue"]),
                Year = Convert.ToInt32(r["yearValue"]),
                Reason = Convert.ToInt32(r["reasonValue"])
            });
        }
    }
}