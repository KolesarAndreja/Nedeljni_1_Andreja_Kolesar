using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class AssignLevelViewModel:ViewModelBase
    {
        AssignLevel assign;
        #region property
        private tblManager _editManager;
        public tblManager editManager
        {
            get
            {
                return _editManager;
            }
            set
            {
                _editManager = value;
                OnPropertyChanged("editManager");
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
        public AssignLevelViewModel(AssignLevel open, vwManager user)
        {
            assign = open;
            editManager = Service.Service.GetManagerById(user.managerId);

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
                Service.Service.AddManager(editManager);
                isUpdated = true;
                assign.Close();
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
