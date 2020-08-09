using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for AddSector.xaml
    /// </summary>
    public partial class AddSector : Window
    {
        public AddSector()
        {
            InitializeComponent();
            this.DataContext = new AddSectorViewModel(this);
        }
    }
}
