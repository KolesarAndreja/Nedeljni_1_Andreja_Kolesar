using Nedeljni1_Andreja_Kolesar.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni1_Andreja_Kolesar.Model
{
    class Person
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role
        {
            get
            {
                if(username == "WPFMaster" && password == "WPFAccess")
                {
                    return "owner";
                }
                else
                {
                    tblUser user = Service.Service.GetUser(username, password);
                    if (user != null)
                    {
                        //check employee list
                        if (Service.Service.isEmployee(user) != null)
                        {
                            return "employee";
                        }
                        else if (Service.Service.isManager(user) != null)
                        {
                            tblManager m = Service.Service.isManager(user);
                            if (m.levelOfResponsibility!=null)
                            {
                                return "manager";
                            }
                            else
                            {
                                return "pending manager";
                            }
                        }
                        else
                        {
                            return "administrator";

                        }
                        
                    }
                }
                return null;
            }
        }
    }
}
