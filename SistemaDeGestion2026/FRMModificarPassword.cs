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
    public partial class FRMModificarPassword : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        public bool modificar = false;
        public bool actualizar = false;
        public String codUsuMod = "";
        public bool loginExitoso = false;
        #endregion

        #region Constructor        
        public FRMModificarPassword()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private bool VerificarIntegridad()
        {
            bool respuesta = true;

            if (TXTNombreLogin.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el LOGIN del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombreLogin.Focus();
                respuesta = false;
            }
            else if (TXTPassword.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PASSWORD del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTPassword.Focus();
                respuesta = false;
            }

            return respuesta;
        }
        private void JalarDatos()
        {
            usuario.pauscodusu = this.codUsuMod;
            usuario.ObtenerDatos();
            TXTNombreLogin.Text = usuario.causnomlog;
            TXTPassword.Text = usuario.causpasswo;
        }
        #endregion

        #region Eventos
        private void BTNConfirmarPassword_Click(object sender, EventArgs e)
        {
            if (TXTConfirmarPassword.PasswordChar == '*')
            {
                TXTConfirmarPassword.PasswordChar = '\0';
            }
            else
            {
                TXTConfirmarPassword.PasswordChar = '*';
            }
        }

        private void BTNPassword_Click(object sender, EventArgs e)
        {
            if (TXTPassword.PasswordChar == '*')
            {
                TXTPassword.PasswordChar = '\0';
            }
            else
            {
                TXTPassword.PasswordChar = '*';
            }
        }
        #endregion

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMModificarPassword_Load(object sender, EventArgs e)
        {
            // Forzar al label a mantener sus dimensiones fijas asignadas en el diseñador
            LBLMensaje.AutoSize = false;

            // Centrar el texto tanto horizontal como verticalmente
            //LBLMensaje.Text = ContentAlignment.MiddleCenter;

            // Estado inicial visual antes de que el usuario empiece a escribir
            LBLMensaje.BackColor = Color.LightGray;
            LBLMensaje.ForeColor = Color.Black;
            LBLMensaje.Text = "Ingrese una contraseña";

            if (this.modificar)
            {
                JalarDatos();
                BTNIngresar.Text = "&Modificar";
                this.Text = "Modificar Usuario";
                GPPanelPrincipal.Text = "Modificar Usuario";
                TXTNombreLogin.Focus();
            }
        }

        private void TXTNombreLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = TXTPassword.Text;

            // Estado inicial: Si el campo está completamente vacío, se queda gris neutral
            if (string.IsNullOrEmpty(pass))
            {
                LBLMensaje.BackColor = Color.LightGray;
                LBLMensaje.Text = "Ingrese una contraseña";
                LBLMensaje.ForeColor = Color.Black;
                return;
            }

            // Invocamos la función estática desde el archivo externo "MetodosGenerales"
            int nivelSeguridad = MetodosGenerales.ValidadPassword(pass);

            // Mapeo exacto de las 4 condiciones de tu función
            switch (nivelSeguridad)
            {
                case -1:
                    // CONDICIÓN 1: Menos de 8 caracteres (Inadmisible)
                    LBLMensaje.BackColor = Color.LightGray; // Mantiene el gris solicitado
                    LBLMensaje.ForeColor = Color.Black;
                    LBLMensaje.Text = "Inadmisible (Mínimo 8 caracteres)";
                    break;

                case 0:
                    // CONDICIÓN 2: Mayor o igual a 8 caracteres, pero solo letras (Seguridad Baja)
                    LBLMensaje.BackColor = Color.Red; // Rojo
                    LBLMensaje.ForeColor = Color.White;
                    LBLMensaje.Text = "Seguridad Baja";
                    break;

                case 1:
                    // CONDICIÓN 3: Incluye letras y números, sin caracteres especiales (Seguridad Media)
                    LBLMensaje.BackColor = Color.Yellow; // Amarillo
                    LBLMensaje.ForeColor = Color.Black; // Texto negro para mejor legibilidad en fondo amarillo
                    LBLMensaje.Text = "Seguridad Media";
                    break;

                case 2:
                    // CONDICIÓN 4: Cumple las 4 condiciones y tiene 8+ caracteres (Alta y Admisible)
                    LBLMensaje.BackColor = Color.Green; // Verde
                    LBLMensaje.ForeColor = Color.White;
                    LBLMensaje.Text = "Seguridad Alta (Admisible)";
                    break;

                default:
                    // Por si acaso cayera en el retorno de precaución de tu código
                    LBLMensaje.BackColor = Color.Red;
                    LBLMensaje.ForeColor = Color.White;
                    LBLMensaje.Text = "Seguridad Baja";
                    break;
            }
        }
    }
}
