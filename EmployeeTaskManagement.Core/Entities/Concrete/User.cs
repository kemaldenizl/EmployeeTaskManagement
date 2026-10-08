namespace EmployeeTaskManagement.Core.Entities.Concrete
{
    public class User:IEntity
	{
        public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }
    }
}