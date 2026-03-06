using ModelViewLib.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewLib.Model
{
    public interface IUsersModel
    {
          List<User> UpUserData();
          bool Register (User user);
        void RemoveUsers(List<User> users);
        List<User> Load();
        bool AddUser (User u);
    }
}
