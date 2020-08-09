using Nedeljni1_Andreja_Kolesar.ViewModel;
using System.Windows;

namespace Nedeljni1_Andreja_Kolesar.View
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class Owner : Window
    {
        public Owner()
        {
            InitializeComponent();
            this.DataContext = new OwnerViewModel(this);
        }
    }
}
