using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps7.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apps7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> TablaEstudiante;
        public Consulta()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            get();
            
        }

        public async void get()
        {
            var ResultadoRegistro = await con.Table<Estudiante>().ToListAsync();
            TablaEstudiante = new ObservableCollection<Estudiante>(ResultadoRegistro);
            ListaUsuarios.ItemsSource = TablaEstudiante;
          

        }


        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();
            int ID = Convert.ToInt32(item);
            Navigation.PushAsync(new Elemento(ID));

        }
    }
}