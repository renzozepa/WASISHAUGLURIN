using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCalidad.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : MasterDetailPage
    {
        public Principal()
        {
            InitializeComponent();
            MyMenu();
        }

        public void MyMenu()
        {
            Detail = new NavigationPage(new Feed());
            List<Menu> menu = new List<Menu>
            {
                new Menu{ Page= new Sincronizar(),MenuTitle="Sincronizar",  MenuDetail="Sincronizar",icon="actualizar.png",Id=1},
                new Menu{ Page= new Proyectos(),MenuTitle="Proyectos",  MenuDetail="Proyectos",icon="user.png",Id=2},
            };
            ListMenu.ItemsSource = menu;

        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                IsPresented = false;
                Detail = new NavigationPage(menu.Page);
            }
        }

        public class Menu
        {
            public int Id
            {
                get;
                set;
            }
            public string MenuTitle
            {
                get;
                set;
            }
            public string MenuDetail
            {
                get;
                set;
            }

            public ImageSource icon
            {
                get;
                set;
            }

            public Page Page
            {
                get;
                set;
            }
        }
    }
}