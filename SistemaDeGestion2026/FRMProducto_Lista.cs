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
    public partial class FRMProducto_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aproduc producto = new aproduc();
        private List<aproduc> lista_productos = new List<aproduc>();
        #endregion
        public FRMProducto_Lista()
        {
            InitializeComponent();
        }
        #region Métodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_productos.Clear();
            lista_productos = producto.Lista("capdtalpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdmarpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdcolpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdmodpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdmatpro like '%" + TXTFiltrar.Text + "%' or " +
                                           
                                           "capdcatpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capddespro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdnompro like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (aproduc a in lista_productos)
            {
                DTGLista.Rows.Add();

                if (a.capdestpro)
                {
                    if (DTGLista.Rows.Count % 2 == 0)
                    {
                        DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                }
                else
                {
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Salmon;
                }

                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.papdcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.capdestpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capdnompro;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capdtalpro;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capdcolpro;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.capdmarpro;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = a.capdmodpro;
                DTGLista[7, DTGLista.Rows.Count - 1].Value = a.capdgenpro;
                /*if (a.capdgenpro)
                {
                    DTGLista[7, DTGLista.Rows.Count - 1].Value = "M";
                }
                else
                {
                    DTGLista[7, DTGLista.Rows.Count - 1].Value = "F";
                }
                */

                DTGLista[8, DTGLista.Rows.Count - 1].Value = a.capdmatpro;
                DTGLista[9, DTGLista.Rows.Count - 1].Value = a.capdcatpro;
                DTGLista[10, DTGLista.Rows.Count - 1].Value = a.capdpreven;
                DTGLista[11, DTGLista.Rows.Count - 1].Value = a.capdpremin;
                DTGLista[12, DTGLista.Rows.Count - 1].Value = a.capdfeccre;
                DTGLista[13, DTGLista.Rows.Count - 1].Value = a.capdfecmod;
                DTGLista[14, DTGLista.Rows.Count - 1].Value = a.capdstopro;
                DTGLista[15, DTGLista.Rows.Count - 1].Value = a.capddespro;

            }

        }
        #endregion


        private void DTGLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMProducto_Registrar a = new FRMProducto_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void FRMProducto_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registrar F1 = new FRMProducto_Registrar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMProducto_Registrar F1 = new FRMProducto_Registrar();
                    F1.modificar = true;
                    F1.codProMod = DTGLista[0, e.RowIndex].Value.ToString();
                    F1.ShowDialog();
                    if (F1.actualizar)
                    {
                        ActualizarGrid();
                    }
                }
            }
        }

        private void TXTFiltrar_Enter(object sender, EventArgs e)
        {
            TXTFiltrar.SelectAll();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registrar F1 = new FRMProducto_Registrar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void inhabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    producto.capdestpro = false;
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto Inhabilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    producto.capdestpro = true;
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto Habilitado correctamente");
                        ActualizarGrid();
                    }
                }

            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {

                    if (producto.capdestpro)
                    {
                        CMSMenu.Items[2].Visible = false;
                        CMSMenu.Items[1].Visible = true;
                    }
                    else
                    {
                        CMSMenu.Items[2].Visible = true;
                        CMSMenu.Items[1].Visible = false;
                    }
                }

            }
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
    }
}
