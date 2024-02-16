using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp7.dto;

namespace WpfApp7.logic
{
    public class LogicClinica
    {
        public ObservableCollection<Visita> llistaVis {  get; set; }

        public LogicClinica()
        { 
            llistaVis = new ObservableCollection<Visita>();
            llistaVis.Add(new Visita("Sergio", "Dolor de cabeza", DateTime.Now.AddDays(2)));
            llistaVis.Add(new Visita("Ana", "Dolor de garganta", DateTime.Now.AddDays(2)));
        }

        public void afegirVisita(Visita visitaRebuda)
        {
            llistaVis.Add(visitaRebuda);
        }

        public void modificarVisita(Visita visitaModificada, int indexVisita) 
        {
            llistaVis[indexVisita] = visitaModificada;
        }
    }
}
