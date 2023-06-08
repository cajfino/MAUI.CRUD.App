using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static SQLite.SQLite3;

namespace Employee_CRUD_APP
{
    public class EmployeeRepository
    {
        private readonly SQLiteAsyncConnection _database;

        //Status Message
        public string statusMessage { get; set; }

        public EmployeeRepository(string dbPath)
        { 
            _database= new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Employee>();
        }

        public Task<List<Employee>> GetEmployeeAsync()
        {
            return _database.Table<Employee>().ToListAsync();
        }

        
        //Save Employee + Status message of added 
        public Task<int> SaveEmployeeAsync(Employee employee) 
        {
            int result = 0;

            statusMessage = string.Format("Added (Name: {1}), Surname: {2}, Email: {3}", result,employee.Name,employee.Surname,employee.Email);
          
            return _database.InsertAsync(employee);     
        }

        public Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return _database.UpdateAsync(employee);
            
        }

        public Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return _database.DeleteAsync(employee);

        }

       
    }
}


