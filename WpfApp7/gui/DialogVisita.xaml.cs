using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WpfApp7.dto;
using WpfApp7.logic;

namespace WpfApp7.gui
{
    /// <summary>
    /// Lógica de interacción para DialogVisita.xaml
    /// </summary>
    public partial class DialogVisita : Window
    {
        public LogicClinica logicSecund {  get; set; }
        public Visita visitaTreball { get; set; }
        public Boolean modificar {  get; set; }
        public int posicio { get; set; }

        private Visita visitaOriginal;

        private int numErrors = 0;

        public DialogVisita(LogicClinica logicRebut)
        {
            InitializeComponent();
            this.logicSecund = logicRebut;
            this.visitaTreball = new Visita();
            this.DataContext = visitaTreball;
            this.modificar = false;
        }

        public DialogVisita(LogicClinica logicRebut, int posicioRebuda, Visita visitaRebuda)
        {
            InitializeComponent();
            this.logicSecund = logicRebut;
            this.visitaOriginal = (Visita)visitaRebuda.Clone();
            this.visitaTreball = visitaRebuda;
            this.posicio = posicioRebuda;
            this.DataContext = visitaTreball;
            this.modificar = true;
        }

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            if (this.modificar)
            {
                visitaTreball.Pacient = visitaOriginal.Pacient;
                visitaTreball.Data = visitaOriginal.Data;
                visitaTreball.Motiu = visitaOriginal.Motiu;
            } 
            this.Close();
        }

        private void butto_aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(this.modificar)
            {
                logicSecund.modificarVisita(visitaTreball, posicio);
            }
            else
            {
                logicSecund.afegirVisita(visitaTreball);
            }
            this.Close() ;
        }

     

        public void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                numErrors++;
                
            }
            else
            {
                numErrors--;
            }

            if (numErrors == 0)
            {
                butto_aceptar.IsEnabled = true;
                
            }
            else
            {
               
                butto_aceptar.IsEnabled = false;
            }

            Console.WriteLine(numErrors);
            LaErr.Content = "";
            foreach (string error in visitaTreball.errorsActuals)
            {
                if (!error.Equals(""))
                {
                    LaErr.Content += error + "\n";
                }
            }

        }

    }
}

