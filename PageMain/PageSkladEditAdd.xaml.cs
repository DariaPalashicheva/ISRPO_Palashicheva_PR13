using ISRPO_Palashicheva_PR13.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ISRPO_Palashicheva_PR13.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageSkladEditAdd.xaml
    /// </summary>
    public partial class PageSkladEditAdd : Page
    {
        private Sklad _currentSklad = new Sklad();
        public PageSkladEditAdd(Sklad selectedSklad)
        {
            InitializeComponent();
            if (selectedSklad != null)
                _currentSklad = selectedSklad;
            
            DataContext = _currentSklad;
            ComboStrana.ItemsSource = TovarsEntities.GetContext().Strana.ToList();
        }
    }
}
