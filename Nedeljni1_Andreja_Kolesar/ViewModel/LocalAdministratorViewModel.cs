using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class LocalAdministratorViewModel:ViewModelBase
    {
        LocalAdministrator la;
        #region property
        //manager
        private List<vwManager> _managerList;
        public List<vwManager> managerList
        {
            get
            {
                return _managerList;
            }
            set
            {
                _managerList = value;
                OnPropertyChanged("managerList");
            }
        }

        private vwManager _manager;
        public vwManager manager
        {
            get
            {
                return _manager;
            }
            set
            {
                _manager = value;
                OnPropertyChanged("manager");
            }
        }
        //employee
        private List<vwEmployee> _employeeList;
        public List<vwEmployee> employeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                OnPropertyChanged("employeeList");
            }
        }

        private vwEmployee _employee;
        public vwEmployee employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged("employee");
            }
        }
        //administrator
        private List<vwAdministrator> _administratorList;
        public List<vwAdministrator> administratorList
        {
            get
            {
                return _administratorList;
            }
            set
            {
                _administratorList = value;
                OnPropertyChanged("administratorList");
            }
        }

        private vwAdministrator _administrator;
        public vwAdministrator administrator
        {
            get
            {
                return _administrator;
            }
            set
            {
                _administrator = value;
                OnPropertyChanged("administrator");
            }
        }

        #endregion

        public LocalAdministratorViewModel(LocalAdministrator open)
        {
            la = open;
            //manager
            manager = new vwManager();
            managerList = Service.Service.GetVwManagerList();
            //employee
            employee = new vwEmployee();
            employeeList = Service.Service.GetVwEmployeeList();
            //admin
            administrator = new vwAdministrator();
            administratorList = Service.Service.GetVwAdministratorList();

        }

        #region ASSIGN LEVEL OF RESPONSIBILITY
        private ICommand _assignLevel;
        public ICommand assignLevel
        {
            get
            {
                if (_assignLevel == null)
                {
                    _assignLevel = new RelayCommand(param => AssignLevelExecute(), param => CanAssignLevelExecute());
                }
                return _assignLevel;
            }
        }

        private void AssignLevelExecute()
        {

            try
            {
                AssignLevel assignLevel = new AssignLevel(manager);
                assignLevel.ShowDialog();

                if ((assignLevel.DataContext as AssignLevelViewModel).isUpdated == true)
                {
                    managerList = Service.Service.GetVwManagerList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAssignLevelExecute()
        {
            return true;
        }
        #endregion
        #region log out
        private ICommand _logOut;
        public ICommand logOut
        {
            get
            {
                if (_logOut == null)
                {
                    _logOut = new RelayCommand(param => LogOutExecute(), param => CanLogOutExecute());
                }
                return _logOut;
            }
        }

        private void LogOutExecute()
        {
            try
            {
                Login login = new Login();
                la.Close();
                login.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogOutExecute()
        {
            return true;
        }
        #endregion
    }
}
