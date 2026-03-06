using ModelViewLib.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewLib.Model
{
    public class MemoryUsersModel : IUsersModel
    {
        List<User> allUsers_ = new List<User>();
        public MemoryUsersModel() 
        {
          allUsers_.Add(new User("qwe", "123", "Bars"));
            allUsers_.Add(new User("zxc", "456", "Vadim"));
            allUsers_.Add(new User("asd", "789", "Diana"));
        }

        public List<User> Load()
        {
            return allUsers_;
        }
        public bool Register(User user)
        {
            int countListUser = allUsers_.Count;
            allUsers_.Add(user);
            if (allUsers_.Count > countListUser)
            {
                return true;
            }
            return false;
        }

        public void Remove(List<User> selectedUsers)
        {
            foreach (User u in selectedUsers)
            {
                selectedUsers.Remove(u);
            }
        }

        public void RemoveUsers(List<User> users)
        {
            foreach (User u in users)
            {
                int TargetIndex = allUsers_.FindIndex(local => local.Login == u.Login );
                if (TargetIndex >= 0)
                {
                    allUsers_.RemoveAt(TargetIndex);
                }
            }
        }

        public List<User> UpUserData()
        {
            return allUsers_;
        }
        public bool AddUser(User user)
        {
            foreach (User u in allUsers_) 
            {
                if (u.Login == user.Login)
                {
                    return false;
                }

            }
            allUsers_.Add (user);
            return true;    
        }
    }
}
