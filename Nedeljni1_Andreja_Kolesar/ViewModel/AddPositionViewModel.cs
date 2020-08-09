using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class AddPositionViewModel:ViewModelBase
    {
        AddPosition addPosition;
        #region property
        private tblPosition _position;
        public tblPosition position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged("position");
            }
        }
        #endregion

        #region  constructor
        public AddPositionViewModel(AddPosition open)
        {
            addPosition = open;
            position = new tblPosition();
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
                Service.Service.AddPosition(position);
                addPosition.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(position.name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
