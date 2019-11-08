using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comanda
{
    public partial class Form1 : Form
    {
        
        readonly BaseDatos menus;
        public Form1()
        {
            InitializeComponent();
            this.Text = "San Jorge Restaurant";
            this.BackColor = Color.BurlyWood;
            menus = new BaseDatos();
            menuActivo();
        }

        private void menuActivo()
        {
            comboBoxMenu.DataSource = menus.Listamenu;
            comboBoxMenu.DisplayMember = "Nombre";
            comboBoxMenu.ValueMember = "Id";
        }

        private void comboBoxMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxMenu.SelectedIndex)
            {
                //aqui como instanciamos la clase base datos y le damos un nombre llamamos con su nombre que elegimos junto con l lista que deamos que sea la correcta
                case 1: listBoxSeleccion.DataSource = menus.ListAperitivos;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 2: listBoxSeleccion.DataSource = menus.ListEnsalada;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 3: listBoxSeleccion.DataSource = menus.ListCarnes;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 4: listBoxSeleccion.DataSource = menus.ListPescado;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 5: listBoxSeleccion.DataSource = menus.ListPollo;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 6: listBoxSeleccion.DataSource = menus.ListPasta;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 7: listBoxSeleccion.DataSource = menus.ListSandwich;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 8: listBoxSeleccion.DataSource = menus.ListPaninis;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 9: listBoxSeleccion.DataSource = menus.ListPostre;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;
                case 10: listBoxSeleccion.DataSource = menus.ListBebida;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "Id";
                    break;

                default: listBoxSeleccion.DataSource = menus.Vacio;
                    listBoxSeleccion.DisplayMember = "Nombre";
                    listBoxSeleccion.ValueMember = "ID";


                    break;
            }


        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }
        private void AgregarMenu()
        {
            var valor = listBoxSeleccion.SelectedIndex;
            if (valor != 0)
            {
                //aqui solo se cambio de decimal a double
                var datos = Convert.ToDouble(comboBoxCantidad.Text)*  Convert.ToDouble(textBoxPrecio.Text);
                var total = Convert.ToString(datos);
                dataGridView1.Rows.Add(listBoxSeleccion.Text, comboBoxCantidad.Text, textBoxPrecio.Text, total);


            }

        }
        //Aqui llamamos al metodo limpiar por que es el que cumple con todos los requisitos de limpiar las cajas
        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textBoxPrecio.Text = "";
            comboBoxCantidad.Text = "0";
            comboBoxMenu.Text = "None";
            textBoxTotal.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void LimpiarAgregar()
        {
            textBoxPrecio.Text = "";
            comboBoxCantidad.Text = "0";
            comboBoxMenu.Text = "None";
            textBoxTotal.Text = "";
        }

        private void buttonCobrar_Click(object sender, EventArgs e)
        {
            cobrar();
        }

        private void cobrar()
        {
            decimal suma = 0;
            foreach (DataGridViewRow Celda in dataGridView1.Rows)

                suma += Convert.ToDecimal(Celda.Cells["Total"].Value);
            textBoxTotal.Text = Convert.ToString(suma);
        }



        //Estos fueron creados pero no tienen ninguna refencia y esto hacen que no esten relacinados con los verdaeros botones
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        // al igual que este
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Este tambien
        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarMenu();
        }
        //este
        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpiarAgregar();
        }
        //este
        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobrar();
        }
        //y este tambien no los borro por que puede que se borre el boton y explote el programa y no me la juego jaja
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto POO Mayo 2019", "Acerca de..");
        }
        //estos los seleccione por accidente
        private void ListBoxSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //este
        private void TextBoxPrecio_TextChanged(object sender, EventArgs e)
        {

        }
        //y este
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //aqui solamente les doy click a los botones originales y de ahi solo pongo el codigo necesario para la funcion que sirva el boton
        //en este caso este caso es lmpiar todo
        private void LimpiarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBoxPrecio.Text = "";
            comboBoxCantidad.Text = "0";
            comboBoxMenu.Text = "None";
            textBoxTotal.Text = "";
            dataGridView1.Rows.Clear();

        }
        //Aqui se agrega la eleccion del usuario y la agraga a la tabla/lista
        private void AgregarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var valor = listBoxSeleccion.SelectedIndex;
            if (valor != 0)
            {
                var datos = Convert.ToDouble(comboBoxCantidad.Text) * Convert.ToDouble(textBoxPrecio.Text);
                var total = Convert.ToString(datos);
                dataGridView1.Rows.Add(listBoxSeleccion.Text, comboBoxCantidad.Text, textBoxPrecio.Text, total);


            }

        }
        //aqui se hace la multiplicacion de los productos que adquirio el usuario
        private void CobrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            decimal suma = 0;
            foreach (DataGridViewRow Celda in dataGridView1.Rows)

                suma += Convert.ToDecimal(Celda.Cells["Total"].Value);
            textBoxTotal.Text = Convert.ToString(suma);

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Aqui para mandar el mensaje sobre acerca del restaurante
        private void AcercaDeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Proyecto POO Mayo 2019", "Acerca de..");
        }
        //para cerrar el programa
        private void CerrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //no se muy bien para que sea nuevo xd
        private void NuevoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }
    }

        
}

