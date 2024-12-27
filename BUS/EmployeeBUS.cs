using SieuThiMini.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieuThiMini.BUS
{
    internal class EmployeeBUS
    {
        private EmployeeDAO employeeDAO;

        public EmployeeBUS()
        {
            employeeDAO = new EmployeeDAO();
        }

        // Hàm lấy danh sách nhân viên
        public List<EmployeeDTO> GetAllEmployees()
        {
            return employeeDAO.GetAllEmployees();
        }
        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            return employeeDAO.GetEmployeeById(employeeId);
        }
        public bool CheckEmailExists(string email)
        {
            return employeeDAO.CheckEmailExists(email);
        }
        public void AddEmployee(EmployeeDTO employee)

        {
           employeeDAO.AddEmployee(employee);
        }

        public void UpdateEmployee(EmployeeDTO updatedEmployee)
        {
            employeeDAO.UpdateEmployee(updatedEmployee);
        }
        public void DeleteEmployee(int employeeId)
        {
            employeeDAO.DeleteEmployee(employeeId);
        }
        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            return employeeDAO.SearchEmployees(keyword);
        }
        public int? Login(string email, string password)

        {
            return employeeDAO.Login(email, password);
        }
        public string GetRoleById(int employeeId)
        {
            return employeeDAO.GetRoleById(employeeId);
        }
        public EmployeeDTO FindEmployeeById(int employeeId)
        {
            return employeeDAO.FindEmployeeById(employeeId);
        }
        public void ChangePassword(int employeeId, string newPassword)
        {
            employeeDAO.ChangePassword(employeeId, newPassword);
        }
        public List<EmployeeDTO> GetEmployeesByGender(string gender)
        {
            return employeeDAO.GetEmployeesByGender(gender);
        }
        public List<EmployeeDTO> GetEmployeesByAgeRange(int minAge, int maxAge)
        {
            return employeeDAO.GetEmployeesByAgeRange(minAge, maxAge);
        }
        public List<EmployeeDTO> GetEmployeesByStatus(string status)
        {
            return employeeDAO.GetEmployeesByStatus(status);
        }
    }

}
