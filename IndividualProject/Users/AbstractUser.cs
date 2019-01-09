
namespace IndividualProject
{
    public enum UserEnum {user = 1, userview = 2, userviewedit = 3, uservieweditdelete=4 ,superadmin = 5}

    abstract class AbstractUser
    {
        
        public string Name { get; set; }
        public UserEnum UserList { get; set; }
       
    }

}
