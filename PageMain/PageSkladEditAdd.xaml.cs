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
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // проверка заполняемости полей
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSklad.naimenov))
                errors.AppendLine("Укажите название товара");

            if (_currentSklad.kolichestvo <= 0)
                errors.AppendLine("Количество товара не может быть меньше или равно 0");

            if (_currentSklad.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равна 0");


            if (_currentSklad.Strana == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            //добавление
            if (_currentSklad.id == 0)
                TovarsEntities.GetContext().Sklad.Add(_currentSklad);
            try
            {
                TovarsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            AppFrame.FrameMain.Navigate(new PageMain.PageSklad());
        }

    }
}
