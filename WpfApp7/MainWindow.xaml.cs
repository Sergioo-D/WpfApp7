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
using WpfApp7.dto;
using WpfApp7.gui;
using WpfApp7.logic;

namespace WpfApp7
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LogicClinica logic {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            logic = new LogicClinica();
            TabVisit.DataContext = logic;

        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            DialogVisita dialogVisita = new DialogVisita(logic);
            dialogVisita.ShowDialog();

        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            if(TabVisit.SelectedIndex != -1)
            {
                Visita visitaMod = (Visita)TabVisit.SelectedItem;
                int posicioMod = TabVisit.SelectedIndex;
                DialogVisita dialogVisita = new DialogVisita(logic, posicioMod, visitaMod);
                dialogVisita.ShowDialog();
            }
        }
    }
}
