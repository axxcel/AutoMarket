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

using ClassLibrary;

namespace car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainCar();
            //var page = new MainCar(this);

        }
        private void Btn(object sender, RoutedEventArgs e)
        {
            //MainWindow main = Application.Current.MainWindow as MainWindow;
            //if (main != null)
            //{
            //    main.Close();
            //}

            this.Close();
        }

        private void BtnBuildCar(object sender, RoutedEventArgs e)
        {
            //MainFrame.Content = new BuildCar();
        }
    }
}
