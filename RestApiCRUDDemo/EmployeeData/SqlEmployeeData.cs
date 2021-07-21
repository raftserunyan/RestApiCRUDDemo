using System;
using System.Collections.Generic;
using System.Linq;
using RestApiCRUDDemo.Models;

namespace RestApiCRUDDemo.EmployeeData
{
	public class SqlEmployeeData : IEmployeeData
	{
		private readonly EmployeeContext _context;
		public SqlEmployeeData(EmployeeContext context)
		{
			_context = context;
		}

		public Employee AddEmployee(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			_context.Employees.Add(employee);

			_context.SaveChanges();
			return employee;
		}

		public void DeleteEmployee(Employee employee)
		{
			_context.Employees.Remove(employee);
			_context.SaveChanges();
		}

		public Employee EditEmployee(Employee employee)
		{
			var existingEmployee = _context.Employees.Find(employee.Id);

			if (existingEmployee != null)
			{
				_context.Employees.Update(employee);
				_context.SaveChanges();
			}

			return employee;
		}

		public Employee GetEmployee(Guid id)
		{
			return _context.Employees.Find(id);
		}

		public List<Employee> GetEmployees()
		{
			return _context.Employees.ToList();
		}
	}
}
