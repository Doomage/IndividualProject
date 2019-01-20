
namespace IndividualProject
{
    public enum UserRole {User = 1, Userview = 2, Userviewedit = 3, Uservieweditdelete=4 ,Superadmin = 5}

    abstract class AbstractUser
    {
        
        public string Name { get; set; }
        public UserRole Role { get; set; }
       
    }

}
