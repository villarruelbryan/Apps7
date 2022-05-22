using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps7.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Apps7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> Rupdate;
        IEnumerable<Estudiante> Rdelete;
        public Elemento(int id)
        {
            InitializeComponent();
            idSeleccionado = id;
            con = DependencyService.Get<Database>().GetConnection();
        }

        public static IEnumerable<Estudiante> Delete (SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("Delete from estudiante where Id= ?", id);
        }

        public static IEnumerable<Estudiante> Update (SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("Update from estudiante set Nombre= ?, Usuario = ?, Contrasena = ? where Id = ?", nombre, usuario, contrasena, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                Rupdate = Update(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new Consulta());
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                Rdelete = Delete(db, idSeleccionado);
                Navigation.PushAsync(new Consulta());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}