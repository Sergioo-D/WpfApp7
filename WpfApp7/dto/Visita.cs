using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp7.dto
{
    public class Visita : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        public List<string> errorsActuals { get; set; }

        private String pacient;
        public String Pacient
        {
            get { return pacient; }
            set
            {
                pacient = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pacient"));
            }
        }

        private DateTime data;
        public DateTime Data
        {
            get { return data; }
            set
            {
                data = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data"));
            }
        }

        private String motiu;
        public String Motiu
        {
            get { return motiu; }
            set
            {
                motiu = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Motiu"));
            }
        }

        public string Error
        {
            get { return ""; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";

                // Limpiar errores previos para el campo actual
                errorsActuals.RemoveAll(error => error.StartsWith(columnName));
         
                if (columnName == "Pacient")
                {
                    
                    if (string.IsNullOrEmpty(pacient)) { 
                        result = "El pacient no pot estar buït";
                        errorsActuals.Add($"{columnName}: {result}");
                    }
                }
                else if (columnName == "Motiu")
                {
                    if (string.IsNullOrEmpty(motiu))
                    {
                        result = "El motiu no pot estar buït";
                        errorsActuals.Add($"{columnName}: {result}");
                    }
                }
                else if (columnName == "Data")
                {

                    if (data <= DateTime.Now.AddDays(-2))
                    {
                        result = "Data no válida, selecciona data posterior al dia actual";
                        errorsActuals.Add($"{columnName}: {result}");
                    }
                }
                foreach(string error in errorsActuals)
                {
                    Console.WriteLine(error);
                }
                
                return result;
            }
        }


        /*private int GetIndexOfColumnName(string columnName)
        {
            switch (columnName)
            {
                case "Pacient":
                    return 0;
                case "Motiu":
                    return 1;
                case "Data":
                    return 2;
                default:
                    return -1;
            }
        }*/
        public Visita(string pacient, string motiu, DateTime data)
        {
            Pacient = pacient;
            Data = data;
            Motiu = motiu;
        }

        public Visita()
        {
            Data = DateTime.Now;
            Pacient = "";
            Motiu = "";
            errorsActuals = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            {
                Visita clon = new Visita();
                clon.pacient = this.pacient;
                clon.data = this.data;
                clon.motiu = this.motiu;
                return clon;
            };
        }
    }
}
