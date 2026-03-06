using ModelViewLib.ModelViews;
using ModelViewLib.Views;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Class_Library
{
    public class UsersTableView : DataGridView, IUsersView
    {
        public List<User> GetSelectedUsers()
        {
            List <User> result = new List<User>();
            foreach (DataGridViewRow row in SelectedRows) 
            {
             result.Add(row.DataBoundItem as User); 
            }
            return result; 
        }

        public void ShowUsers(List<User> users)
        {
            DataSource = null;
            DataSource = users;
        }
       
    }
}
