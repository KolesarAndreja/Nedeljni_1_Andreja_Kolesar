using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.View
{
    class ManagerAccessViewModel:ViewModelBase
    {
        ManagerAccess access;

        private int _attempts;
        public int attempts
        {
            get
            {
                return _attempts;
            }
            set
            {
                _attempts = value;
                OnPropertyChanged("attempts");
            }
        }
        private string _currentPassword;
        public string currentPassword
        {
            get
            {
                return _currentPassword;
            }
            set
            {
                _currentPassword = value;
            }
        }

        private bool _isSuccessful = false;
        public bool isSuccessful
        {
            get
            {
                return _isSuccessful;
            }
            set
            {
                _isSuccessful = value;
            }
        }
        public ManagerAccessViewModel(ManagerAccess open)
        {
            access = open;
            attempts = 3;
            isSuccessful = false;
        }
        #region command
        private ICommand _save;
        public ICommand save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return _save;
            }
        }

        private void SaveExecute(object obj)
        {
            try
            {
                currentPassword = (obj as PasswordBox).Password;
                string validPsw = Model.Startup.managerAccess;
                
               if (currentPassword == validPsw)
               {
                        isSuccessful = true;
                        access.Close();
               }
               else
               {
                    attempts --;
                    currentPassword = "";
                    if (attempts == 0)
                    {
                        MessageBox.Show("You cannot create a manager account.");
                        access.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            //if (!String.IsNullOrEmpty(newUser.fullname) && !String.IsNullOrEmpty(newUser.JMBG) && !String.IsNullOrEmpty(newUser.username) && !String.IsNullOrEmpty(newUser.password) && !String.IsNullOrEmpty(newPatient.cardNumber) && selectedGender.doctorId != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        #endregion
    }
}
