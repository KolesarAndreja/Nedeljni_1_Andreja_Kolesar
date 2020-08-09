using Nedeljni1_Andreja_Kolesar.Service;
using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for EditDate.xaml
    /// </summary>
    public partial class EditDate : Window
    {
        public EditDate(vwAdministrator a)
        {
            InitializeComponent();
            this.DataContext = new EditDateViewModel(this, a);
        }
    }
}
