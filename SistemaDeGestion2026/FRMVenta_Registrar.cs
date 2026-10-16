using CapaRN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestion2026
{
    public partial class FRMVenta_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aclient cliente = new aclient();
        private bool clienteok = false;
        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();
        public bool productoOk = false;
        private List<liteven> listaItems = new List<liteven>();
        public bool actualizar = false;
        #endregion

        #region Constructor
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ActualizarGridItems()
        {
            DTGLista.Rows.Clear();
            foreach (liteven item in listaItems)
            {
                DTGLista.Rows.Add();

                DTGLista[0, DTGLista.Rows.Count - 1].Value = item.faivcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = item.capdmodpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = item.capdcodbar;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = item.capdnompro;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = item.capdtalpro;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = item.capddespro;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = item.caivcanite;
                DTGLista[7, DTGLista.Rows.Count - 1].Value = item.caivpreuni;
                DTGLista[8, DTGLista.Rows.Count - 1].Value = item.caivsubtot;
            }
        }
        private void AgregarProductoALista(aproduc pro)
        {
            liteven item = new liteven();

            item = listaItems.Find(x => x.faivcodpro == pro.papdcodpro);

            if (item != null)
            {
                item.caivcanite += 1; // Incrementar la cantidad en 1
                item.caivsubtot = item.caivcanite * item.caivpreuni; // Actualizar el subtotal
            }
            else
            {
                item = new liteven();
                item.faivcodpro = pro.papdcodpro;
                item.capdmodpro = pro.capdmodpro;
                item.capdcodbar = pro.capdcodbar;
                item.capdnompro = pro.capdnompro;
                item.capdtalpro = pro.capdtalpro;
                item.capddespro = pro.capddespro;
                item.caivcanite = 1; // Cantidad por defecto
                item.caivpreuni = pro.capdpreven; // Precio por defecto
                item.caivsubtot = item.caivcanite * item.caivpreuni;
                item.caivestite = true; // Estado activo            
                listaItems.Add(item);
            }
            ActualizarGridItems();

        }
        #endregion

        #region Eventos
        private void TXTNITCliente_Leave(object sender, EventArgs e)
        {
            cliente.caclnitcli = TXTNITCliente.Text;
            if (cliente.ObtenerDatosNIT())
            {
                TXTNombreCliente.Text = cliente.caclrazcli;
                clienteok = true;
            }
            else
            {
                TXTNombreCliente.Text = "Nombre del cliente";
                clienteok = false;
            }
        }

        private void BTNBuscarUsuario_Click(object sender, EventArgs e)
        {
            FRMCliente_Buscar a = new FRMCliente_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.cliente = a.cliente;
                this.clienteok = true;
                TXTNITCliente.Text = cliente.caclnitcli;
                TXTNombreCliente.Text = cliente.caclrazcli;
            }
            else
            {
                this.clienteok = false;
                TXTNITCliente.Text = "";
                TXTNombreCliente.Text = "Nombre del cliente";
            }
        }

        private void BTNCodigoDeBarras_Click(object sender, EventArgs e)
        {
            if (!lectorCBHabilitado)
            {
                lectorCBHabilitado = true;
                LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            }
            else
            {
                producto.capdcodbar = LBLCodigoDeBarras.Text;
                if (producto.ObtenerDatosCodigo(false, producto.capdcodbar))
                {
                    AgregarProductoALista(producto);
                    //lectorCBHabilitado = true;
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;
                }
                else
                {
                    MessageBox.Show("Producto no encontrado", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;
                    //BTNCodigoDeBarras.Focus();
                }
            }
        }

        private void BTNCodigoDeBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LBLCodigoDeBarras.Text == "LECTOR ACTIVO")
            {
                LBLCodigoDeBarras.Text = "" + e.KeyChar;
            }
            else
            {
                LBLCodigoDeBarras.Text += e.KeyChar;
            }
        }
        #endregion

        private void BTNCodigoDeBarras_Leave(object sender, EventArgs e)
        {
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
        }

        private void FRMVenta_Registrar_Load(object sender, EventArgs e)
        {
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(DTGLista.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("¿Está seguro de eliminar el producto seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
                    /*
                    int selectedIndex = DTGLista.SelectedRows[0].Index;
                    string codigoProducto = DTGLista[0, selectedIndex].Value.ToString();
                    liteven itemToRemove = listaItems.Find(x => x.faivcodpro == codigoProducto);
                    if (itemToRemove != null)
                    {
                        listaItems.Remove(itemToRemove);
                        ActualizarGridItems();
                    }
                    */
                }
            }
        }
        private void EliminarItem(string codPro)
        {
            listaItems.RemoveAll(x => x.faivcodpro == codPro);
            ActualizarGridItems();
            /*
            liteven itemToRemove = listaItems.Find(x => x.faivcodpro == codPro);
            if (itemToRemove != null)
            {
                listaItems.Remove(itemToRemove);
                ActualizarGridItems();
            }
            */
        }

        private void LBLCodigoDeBarras_Enter(object sender, EventArgs e)
        {

        }

        private void BTNBuscar_Producto_Click(object sender, EventArgs e)
        {
            FRMProducto_Buscar a = new FRMProducto_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.producto = a.producto;
                this.productoOk = true;
                AgregarProductoALista(producto);
            }
            else
            {
                this.productoOk = false;
            }
        }
    }
}
