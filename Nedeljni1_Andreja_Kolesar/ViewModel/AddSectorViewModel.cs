using Nedeljni1_Andreja_Kolesar.Command;
using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.View;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni1_Andreja_Kolesar.ViewModel
{
    class AddSectorViewModel:ViewModelBase
    {
        AddSector addSector;
        #region property
        private tblSector _sector;
        public tblSector sector
        {
            get
            {
                return _sector;
            }
            set
            {
                _sector = value;
                OnPropertyChanged("sector");
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
        public AddSectorViewModel(AddSector open)
        {
            addSector = open;
            sector = new tblSector();
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
                List<tblSector> allsectors = Service.Service.GetSectorList();
                if (allsectors.Count < 15)
                {
                    Service.Service.AddSector(sector);
                    isUpdated = true;
                    addSector.Close();
                }
                else
                {
                    MessageBox.Show("Max number of sectors are 15!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(sector.name))
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
