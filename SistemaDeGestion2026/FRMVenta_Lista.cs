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
    public partial class FRMVenta_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        //private aclient cliente = new aclient();
        //private List<aclient> lista = new List<aclient>();
        private avenpro venta = new avenpro();
        private List<avenpro> lista = new List<avenpro>();
        #endregion
        public FRMVenta_Lista()
        {
            InitializeComponent();
        }
        #region Metodos
        private void Estado_2()
        {
            foreach (Form s in MdiChildren)
            {
                s.Close();
            }
            FRMFondo2 a = new FRMFondo2();
            a.MdiParent = this;
            a.persona = this.persona;
            a.usuario = this.usuario;
            a.Show();
            
        }
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista.Clear();
            lista = venta.Lista("(pavpcodven like '%" + TXTFiltrar.Text + "%' or " +
                                            "cavpestven like '%" + TXTFiltrar.Text + "%' or " +
                                            "cavpfeccre like '%" + TXTFiltrar.Text + "%' or " +
                                            "cavpfechor like '%" + TXTFiltrar.Text + "%') limit " +
                                           IINFilas.Value.ToString()
                                           );

            foreach (avenpro a in lista)
            {
                DTGLista.Rows.Add();

                if (a.cavpestven)
                {
                    if (DTGLista.Rows.Count % 2 == 0)
                    {
                        DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                }
                else
                {
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Tomato;
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                }
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.pavpcodven;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.cavpestven;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.cavpfechor;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.cavpfeccre;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.cavpfecmod;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.cavpmontot;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = a.cavpobsven;
                DTGLista[7, DTGLista.Rows.Count - 1].Value = a.favpusucre;
                DTGLista[8, DTGLista.Rows.Count - 1].Value = a.favpusumod;
                DTGLista[9, DTGLista.Rows.Count - 1].Value = a.favpcodcli;

            }

        }

        #endregion

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMVenta_Registrar a = new FRMVenta_Registrar();

            a.usuario = this.usuario;
            a.persona = this.persona;

            a.ShowDialog();

            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void FRMVenta_Lista_Load(object sender, EventArgs e)
        {

        }
    }
}
