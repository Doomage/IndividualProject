
namespace IndividualProject
{
    public enum userenum {user = 1, userview = 2, userviewedit = 3, uservieweditdelete=4 ,superadmin = 5}

    abstract class AbstractUser
    {
        
        public string Name { get; set; }
        public userenum userlist { get; set; }
       
    }

}
