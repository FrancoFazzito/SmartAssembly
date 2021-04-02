namespace Domain.Employees
{
    public class Employee
    {
        public Employee(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}