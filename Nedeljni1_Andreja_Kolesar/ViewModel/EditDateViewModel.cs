using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class EditDateViewModel:ViewModelBase
    {
        EditDate editDate;
        #region property
        private tblAdministrator _editAdministrator;
        public tblAdministrator editAdministrator
        {
            get
            {
                return _editAdministrator;
            }
            set
            {
                _editAdministrator = value;
                OnPropertyChanged("editAdministrator");
            }
        }

        private bool _isUpdated;
        public bool isUpdated
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                _isUpdated = value;
            }
        }
        #endregion

        #region  constructor
        public EditDateViewModel(EditDate open, vwAdministrator user)
        {
            editDate = open;
            editAdministrator = Service.Service.GetAdminById(user.administratorId);

        }
        #endregion

        #region Save
        private ICommand _save;
        public ICommand save
        {
            get
            {
                if (_save == null)
                {
                    _save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return _save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                Service.Service.AddAdministrator(editAdministrator);
                isUpdated = true;
                editDate.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }
        #endregion
    }
}
