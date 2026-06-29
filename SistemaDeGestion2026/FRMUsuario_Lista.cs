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
    public partial class FRMUsuario_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private lususis usuario = new lususis();
        private List<lususis> lista_usuarios = new List<lususis>();
        #endregion



        public FRMUsuario_Lista()
        {
            InitializeComponent();
        }

        #region Métodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_usuarios.Clear();
            lista_usuarios = usuario.Lista("capsnumcid like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsapepat like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsapemat like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsnomper like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (lususis a in lista_usuarios)
            {
                DTGLista.Rows.Add();

                if (a.causestusu)
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

                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.pauscodusu;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.causestusu;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capsnumcid;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capsapepat + " " +
                                                             a.capsapemat + " " +
                                                             a.capsnomper;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.causnomlog;
                
            }

        }
        #endregion

        private void BTNReporte_Click(object sender, EventArgs e)
        {

        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
