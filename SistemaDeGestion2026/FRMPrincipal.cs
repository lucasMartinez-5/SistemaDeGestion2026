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
    public partial class FRMPrincipal : DevComponents.DotNetBar.Office2007RibbonForm
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        #endregion

        #region Constructor
        public FRMPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void Estado_1()
        {
            foreach (Form s in MdiChildren)
            {
                s.Close();
            }
            FRMFondo1 a = new FRMFondo1();
            a.MdiParent = this;
            a.Show();
            BTNActualizarPassword.Enabled = false;
            BTNCerrarSesion.Enabled = false;
            BTNLogin.Enabled = true;
            BTNLoginHuella.Enabled = true;
            RBPAdministracion.Enabled = false;
            RTBAdministracion.Enabled = false;
            RBPInventario.Enabled = false;
            RTBInventario.Enabled = false;
            
        }
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
            BTNActualizarPassword.Enabled = true;
            BTNCerrarSesion.Enabled = true;
            BTNLogin.Enabled = false;
            BTNLoginHuella.Enabled = false;
            RBPAdministracion.Enabled = true;
            RTBAdministracion.Enabled = true;
            RBPInventario.Enabled = true;
            RTBInventario.Enabled = true;
        }
        #endregion

        #region Eventos
        private void FRMPrincipal_Load(object sender, EventArgs e)
        {
            FRMSplash banner = new FRMSplash();
            banner.ShowDialog();
            this.Opacity = 1;
            Estado_1();
        }

        private void BTNPersonas_Click(object sender, EventArgs e)
        {
            foreach (Form s in this.MdiChildren)
            {
                s.Close();
            }
            FRMPersona_Lista a = new FRMPersona_Lista();
            a.MdiParent = this;
            a.Show();
        }

        private void BTNUsuarios_Click(object sender, EventArgs e)
        {
            foreach (Form s in this.MdiChildren)
            {
                s.Close();
            }
            FRMUsuario_Lista a = new FRMUsuario_Lista();
            a.MdiParent = this;
            a.Show();
        }

        private void applicationButton1_Click(object sender, EventArgs e)
        {

        }

        private void BTNLogin_Click(object sender, EventArgs e)
        {
            FRMIniciar_Sesion a = new FRMIniciar_Sesion();
            a.ShowDialog();
            if (a.actualizarPassword)
            {
                FRMModificarPassword b = new FRMModificarPassword();
                b.usuario = a.usuario;
                b.persona = a.persona;
                b.ShowDialog();
            }
            if (a.loginExitoso)
            {
                MessageBox.Show("Bienvenido al sistema");
                this.persona = a.persona;
                this.usuario = a.usuario;
                Estado_2();
            }
        }

        private void BTNActualizarPassword_Click(object sender, EventArgs e)
        {
            
        }

        private void BTNLoginHuella_Click(object sender, EventArgs e)
        {
            FRMIniciar_Sesion_Huella a = new FRMIniciar_Sesion_Huella();
            a.ShowDialog();
            if (a.loginExitoso)
            {
                MessageBox.Show("Bienvenido al sistema");
                this.persona = a.persona;
                this.usuario = a.usuario;
                Estado_2();
            }
            Estado_2();
        }
        #endregion

        private void BTNCerrarSesion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea cerrar sesion ???", "Pregunta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Estado_1();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void BTNProductos_Click(object sender, EventArgs e)
        {
            foreach (Form s in this.MdiChildren)
            {
                s.Close();
            }
            FRMProducto_Lista a = new FRMProducto_Lista();
            a.MdiParent = this;
            a.Show();
        }

        private void BTNCategorias_Click(object sender, EventArgs e)
        {
            foreach (Form s in this.MdiChildren)
            {
                s.Close();
            }
            FRMCategoria_Lista a = new FRMCategoria_Lista();
            a.MdiParent = this;
            a.Show();
        }
    }
}
