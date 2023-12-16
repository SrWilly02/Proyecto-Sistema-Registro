using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace SistemaProyecto
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void Mantenimiento(String accion)
        {
            objent.codigo = txtCodigo.Text;
            objent.nombre = txtNombre.Text;
            objent.correo = txtCorreo.Text;
            objent.telefono = Convert.ToInt32(txtTelefono.Text);
            objent.edad = Convert.ToInt32(txtEdad.Text);
            objent.DNI = Convert.ToInt32(txtDNI.Text);
            objent.accion = accion;
            String men = objneg.N_Mantenimiento_Clientes(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtDNI.Text = "";
            txtBuscar.Text = "";
            dataGridView1.DataSource = objneg.N_Listar_Clientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_Listar_Clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if(MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information)==System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1"); //El 1 es para registrar
                    Limpiar();
                }
                
            }

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("2"); //El 2 es para modificar
                    Limpiar();
                }

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("3"); //El 3 es para eliminar
                    Limpiar();
                }

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.nombre = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_Buscar_Clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_Listar_Clientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtCodigo.Text = dataGridView1[0, fila].Value.ToString();
            txtNombre.Text = dataGridView1[1, fila].Value.ToString();
            txtCorreo.Text = dataGridView1[2, fila].Value.ToString();
            txtTelefono.Text = dataGridView1[3, fila].Value.ToString();
            txtEdad.Text = dataGridView1[4, fila].Value.ToString();
            txtDNI.Text = dataGridView1[5, fila].Value.ToString();
        }
    }
}
