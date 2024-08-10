using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.Models;

namespace WebAPI.Service.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                if(newEmployee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Informar dados!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Add(newEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Employees.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<EmployeeModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found!";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();


            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if(employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found!";
                    serviceResponse.Success = false;
                }

                serviceResponse.Data = employee;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Data = _context.Employees.ToList();

                if(serviceResponse.Data.Count == 0)
                {
                    serviceResponse.Message = "No data found!";
                }

            }catch(Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<EmployeeModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.FirstOrDefault(x => x.Id == id);

                if(employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found!";
                    serviceResponse.Success = false;
                }
                employee.Active = false;
                employee.DateModified = DateTime.Now.ToLocalTime();

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeModel editEmployee)
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                EmployeeModel employee = _context.Employees.AsNoTracking().FirstOrDefault(x => x.Id == editEmployee.Id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "User not found!";
                    serviceResponse.Success = false;
                }

                employee.DateModified = DateTime.Now.ToLocalTime();
                _context.Employees.Update(editEmployee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
