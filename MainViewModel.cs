using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_DBP2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nombre;
        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string apellido;
        public string Apellido
        {
            get => apellido;
            set
            {
                apellido = value;
                OnPropertyChanged();
            }
        }

        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get => fechaNacimiento;
            set
            {
                fechaNacimiento = value;
                OnPropertyChanged();
            }
        }

        private string ocupacion;
        public string Ocupacion
        {
            get => ocupacion;
            set
            {
                ocupacion = value;
                OnPropertyChanged();
            }
        }

        private string telefono;
        public string Telefono
        {
            get => telefono;
            set
            {
                telefono = value;
                OnPropertyChanged();
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string nacionalidad;
        public string Nacionalidad
        {
            get => nacionalidad;
            set
            {
                nacionalidad = value;
                OnPropertyChanged();
            }
        }

        private string nivelIngles;
        public string NivelIngles
        {
            get => nivelIngles;
            set
            {
                nivelIngles = value;
                OnPropertyChanged();
            }
        }

        private string aptitudes;
        public string Aptitudes
        {
            get => aptitudes;
            set
            {
                aptitudes = value;
                OnPropertyChanged();
            }
        }

        private string perfil;
        public string Perfil
        {
            get => perfil;
            set
            {
                perfil = value;
                OnPropertyChanged();
            }
        }

        public Lenguajes LenguajesProgramacion { get; set; }
        public Habilidades Habilidades { get; set; }

        public ObservableCollection<ExperienciaLaboral> Experiencia { get; set; }
        public ObservableCollection<Formacion> Formacion { get; set; }

        public ICommand EnviarCommand { get; }

        public MainViewModel()
        {
            Nombre = " ";
            Ocupacion = " ";
            Perfil = " ";
            FechaNacimiento = DateTime.Now;

            LenguajesProgramacion = new Lenguajes();
            Habilidades = new Habilidades();

            Experiencia = new ObservableCollection<ExperienciaLaboral>
            {
                new ExperienciaLaboral { Puesto = "Trabajador Social", Ubicacion = "Mexico DF | 2022 - Actualmente", Descripcion = "Coordinador y mediador..." }
            };

            Formacion = new ObservableCollection<Formacion>
            {
                new Formacion { Titulo = "Grado de trabajo social", Ubicacion = "ESMA, Madrid | 2012 - 2015" }
            };

            EnviarCommand = new Command(Enviar);
        }

        private async void Enviar()
        {
            var cvTemplateViewModel = new CVTemplateViewModel(this);
            var cvTemplatePage = new CVTemplatePage
            {
                BindingContext = cvTemplateViewModel
            };

            await Application.Current.MainPage.Navigation.PushAsync(cvTemplatePage);
        }


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Lenguajes
    {
        public bool CPP { get; set; }
        public bool C { get; set; }
        public bool Java { get; set; }
        public bool Python { get; set; }
    }

    public class Habilidades
    {
        public bool Comunicativo { get; set; }
        public bool PensamientoCritico { get; set; }
        public bool Sociable { get; set; }
    }

    public class ExperienciaLaboral
    {
        public string Puesto { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
    }

    public class Formacion
    {
        public string Titulo { get; set; }
        public string Ubicacion { get; set; }
    }
}
