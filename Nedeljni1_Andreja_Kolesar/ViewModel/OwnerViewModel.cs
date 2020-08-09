using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class OwnerViewModel:ViewModelBase
    {
        Owner owner;

        public OwnerViewModel(Owner open)
        {
            owner = open;
            adminList = Service.Service.GetVwAdministratorList();
            admin = new vwAdministrator();
        }

        private List<vwAdministrator> _adminList;
        public List<vwAdministrator> adminList
        {
            get
            {
                return _adminList;
            }
            set
            {
                _adminList = value;
                OnPropertyChanged("managerList");
            }
        }

        private vwAdministrator _admin;
        public vwAdministrator admin
        {
            get
            {
                return _admin;
            }
            set
            {
                _admin = value;
                OnPropertyChanged("admin");
            }
        }

        private bool _isDeletedReport;
        public bool isDeletedReport
        {
            get
            {
                return _isDeletedReport;
            }
            set
            {
                _isDeletedReport = value;
            }
        }

        #region REGISTRATION

        private ICommand _registration;
        public ICommand registration
        {
            get
            {
                if (_registration == null)
                {
                    _registration = new RelayCommand(param => RegistrationExecute(), param => CanRegistrationExecute());
                }
                return _registration;
            }
        }

        private void RegistrationExecute()
        {
            try
            {
                RegistrationAdministrator reg = new RegistrationAdministrator();
                reg.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanRegistrationExecute()
        {
            return true;
        }
        #endregion


        #region EDIT
        private ICommand _edit;
        public ICommand edit
        {
            get
            {
                if (_edit == null)
                {
                    _edit = new RelayCommand(param => EditDateExecute(), param => CanEditExecute());
                }
                return _edit;
            }
        }

        private void EditDateExecute()
        {

            try
            {
                EditDate e = new EditDate(admin);
                e.ShowDialog();

                if ((e.DataContext as EditDateViewModel).isUpdated == true)
                {
                    adminList = Service.Service.GetVwAdministratorList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanEditExecute()
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
                owner.Close();
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
