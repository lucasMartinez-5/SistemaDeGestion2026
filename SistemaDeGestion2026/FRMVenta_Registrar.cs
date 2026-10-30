using CapaRN;
using SistemaDeGestion2026.Properties;
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
        private avenpro venta = new avenpro();
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codVenMod = "";

        private aclient cliente = new aclient();
        private bool clienteOk = false;
        private List<liteven> listaItems = new List<liteven>();

        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();
        private bool productoOk = false;

        private double total = 0;
        public bool actualizar = false;
        private aiteven item = new aiteven();
        private liteven itemModificar = new liteven();
        private bool modificarItem = false;
        #endregion

        #region Constructor
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void TXTNitCliente_Leave(object sender, EventArgs e)
        {
            cliente.caclnitcli = TXTNitCliente.Text;
            if (cliente.ObtenerDatosNIT())
            {
                TXTNombreCliente.Text = cliente.caclrazcli;
                clienteOk = true;

            }
            else
            {
                TXTNombreCliente.Text = "Nombre del cliente";
                clienteOk = false;
            }
        }

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
        {
            FRMCliente_Buscar a = new FRMCliente_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.cliente = a.cliente;
                this.clienteOk = true;
                TXTNitCliente.Text = cliente.caclnitcli;
                TXTNombreCliente.Text = cliente.caclrazcli;
            }
            else
            {
                this.clienteOk = false;
                TXTNitCliente.Text = "";
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
                    AgregarProducto(producto);
                    // lectorCBHabilitado = true;
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;

                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;
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
        private void BTNBuscarProducto_Click(object sender, EventArgs e)
        {
            FRMProducto_Buscar a = new FRMProducto_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.producto = a.producto;
                this.productoOk = true;
                AgregarProducto(producto);
            }
            else
            {
                this.productoOk = false;
            }
        }

        private void FRMVenta_Registrar_Load(object sender, EventArgs e)
        {
            
            LBLUsuario.Text = "Usuario: " +
                  persona.capsapepat + " " +
                  persona.capsapemat + " " +
                  persona.capsnomper;
            LBLTotalNumero.Text = "0";
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
            
        }

        private void BTNCodigoDeBarras_Leave(object sender, EventArgs e)
        {
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
        }

        #endregion

        #region Metodos
        private bool Verificar_Integridad()
        {
            return true;
        }
        private void LimpiarProducto()
        {
            DINCantidad.Value = 0;
            DINPrecio.Value = 0;
            TXTDescripcion.WatermarkText = "";
            TXTDescripcion.Text = "Descripción del producto";
            //listaItems.Clear();
            ActualizarGridItems();
        }
        private void AgregarProducto(aproduc pro)
        {
            liteven item = new liteven();
            item = listaItems.Find(x => x.faivcodpro == pro.papdcodpro);

            if (item != null)
            {
                if ((pro.capdstopro - item.caivcanite) > 0)
                {
                    item.caivcanite += 1;
                    item.caivsubtot = item.caivpreuni * item.caivcanite;
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock para agregar", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (pro.capdstopro > 0)
                {
                    item = new liteven();
                    item.faivcodpro = pro.papdcodpro;
                    item.capdmodpro = pro.capdmodpro;
                    item.capdcodbar = pro.capdcodbar;
                    item.capdnompro = pro.capdnompro;
                    item.capdtalpro = pro.capdtalpro;
                    item.capddespro = pro.capddespro;
                    item.caivcanite = 1;
                    item.caivpreuni = pro.capdpreven;

                    item.capdstopro = pro.capdstopro;//stock por defecto

                    item.caivsubtot = item.caivpreuni * item.caivcanite;
                    item.caivestite = true;
                    listaItems.Add(item);
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock para agregar", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            ActualizarGridItems();
            CalcularTotal();
        }

        private void ActualizarGridItems()
        {
            DTGLista.Rows.Clear();
            foreach (liteven item in listaItems)
            {
                DTGLista.Rows.Add();
                DTGLista[0, DTGLista.RowCount - 1].Value = item.faivcodpro;
                DTGLista[1, DTGLista.RowCount - 1].Value = item.capdmodpro;
                DTGLista[2, DTGLista.RowCount - 1].Value = item.capdcodbar;
                DTGLista[3, DTGLista.RowCount - 1].Value = item.capdnompro;
                DTGLista[4, DTGLista.RowCount - 1].Value = item.capdtalpro;
                DTGLista[5, DTGLista.RowCount - 1].Value = item.capddespro;
                DTGLista[6, DTGLista.RowCount - 1].Value = item.caivcanite;
                DTGLista[7, DTGLista.RowCount - 1].Value = item.caivpreuni;
                DTGLista[8, DTGLista.RowCount - 1].Value = item.caivsubtot;

            }
            CalcularTotal();
        }
        #endregion

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (DTGLista.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro que desea borrar este producto?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
                }
            }
            */

            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (MessageBox.Show("¿Está seguro que desea borrar este producto + " + producto.papdcodpro + "?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
                    MessageBox.Show("Producto eliminado correctamente");
                    ActualizarGridItems();
                }
                
            }
        }
        private void CalcularTotal()
        {
            total = 0;

            foreach (liteven item in listaItems)
            {
                total += double.Parse(item.caivsubtot.ToString());
            }
            LBLTotalNumero.Text = total.ToString("F2");
            string numeroEnLetras = MetodosGenerales.ConvertirNumeroALetras(total);
            LBLTotalALiteral.Text = "SON: " + numeroEnLetras;
        }
        private void EliminarItem(string CodPro)
        {
            listaItems.RemoveAll(x => x.faivcodpro == CodPro);
            ActualizarGridItems();

        }

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            List<aproduc> listaProductos = new List<aproduc>();
            listaProductos = listaItems.Select(x => new aproduc
            {
                papdcodpro = x.faivcodpro,
                capdmodpro = x.capdmodpro,
                capdcodbar = x.capdcodbar,
                capdnompro = x.capdnompro,
                capdtalpro = x.capdtalpro,
                capddespro = x.capddespro,
                capdstopro = x.capdstopro - x.caivcanite,
                capdpreven = x.caivpreuni
            }).ToList();



            if (Verificar_Integridad())
            {
                venta = new avenpro();
                correlativo.pxnctipcor = "avenpro";
                if (correlativo.ObtenerSiguiente())
                {
                    venta.pavpcodven = correlativo.pxnctipcor + "-" +
                                       correlativo.cxncnumcor.ToString("D12");
                }
                venta.cavpestven = true;
                venta.cavpfeccre = DateTime.Now;
                venta.cavpfechor = DateTime.Now;
                venta.cavpfecmod = DateTime.Now;
                venta.cavpmontot = listaItems.Sum(x => x.caivsubtot);
                venta.cavpobsven = TXTObservaciones.Text;
                venta.favpcodcli = cliente.paclcodcli;
                venta.favpusucre = usuario.pauscodusu;
                venta.favpusumod = usuario.pauscodusu;

                //Grabado de los items de la venta
                correlativo.pxnctipcor = "aiteven";
                if (correlativo.ObtenerSiguiente(listaItems.Count))
                {
                    correlativo.cxncnumcor -= listaItems.Count - 1;
                    foreach (liteven item in listaItems)
                    {

                        item.paivcodite = correlativo.pxnctipcor + "-" +
                                          correlativo.cxncnumcor.ToString("D12");
                        item.faivcodven = venta.pavpcodven;
                        correlativo.cxncnumcor++;
                    }

                }

                if (venta.Grabar() && item.Grabar(listaItems) && producto.ActualizarStock(listaProductos))
                {
                    MessageBox.Show("Venta guardada correctamente!!",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    //LimpiarCasillas();
                    if (PDGDialogo.ShowDialog() == DialogResult.OK)
                    {
                        PRDRecibo.Print();
                    }
                    this.actualizar = true;
                    //this.FormClosing -= FRMVenta_Registrar_FormClosing;                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Venta no se pudo guardar!!",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void DTGLista_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if (e.KeyCode == Keys.Delete)
            {
                // Acción al presionar la tecla Suprimir
                //MessageBox.Show("Has presionado la tecla Suprimir");

                if (DTGLista.SelectedRows.Count > 0)
                {
                    producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                    if (MessageBox.Show("¿Está seguro que desea borrar este producto + " + producto.papdcodpro + "?",
                                "Pregunta",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
                        MessageBox.Show("Producto eliminado correctamente");
                        ActualizarGridItems();
                    }

                }
            }

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            itemModificar = listaItems.Find(x => x.faivcodpro == DTGLista[0, e.RowIndex].Value.ToString());
            modificarItem = true;
            if (itemModificar != null)
            {
                TXTDescripcion.Text = itemModificar.capddespro;
                DINCantidad.Value = itemModificar.caivcanite;
                DINPrecio.Value = (Double)itemModificar.caivpreuni;
                producto.papdcodpro = itemModificar.faivcodpro;
                if (producto.ObtenerDatos())
                {
                    if (producto.capdfotpro == "")
                    {

                        PCBFotografia.Image = Resources.no_image;
                    }
                    else
                    {
                        PCBFotografia.Image = MetodosGenerales.ConvertBase64StringToImage(producto.capdfotpro);
                    }
                }
            }
        }

        private void BTNModificarProducto_Click(object sender, EventArgs e)
        {
            if ((int)DINCantidad.Value > producto.capdstopro)
            {
                MessageBox.Show("La cantidad ingresada excede el stock disponible");
            }
            else
            {
                if (modificarItem)
                {
                    itemModificar.caivpreuni = (Decimal)DINPrecio.Value;
                    itemModificar.capddespro = TXTDescripcion.Text;
                    itemModificar.caivcanite = (int)DINCantidad.Value;

                    //itemModificar.caivpreuni = (Decimal)DINPrecio.Value;
                    itemModificar.caivsubtot = itemModificar.caivcanite * itemModificar.caivpreuni;
                    ActualizarGridItems();
                    modificarItem = false;
                    //LimpiarProducto();
                }

            }

            
        }

        private void BTNLimpiarProducto_Click(object sender, EventArgs e)
        {
            modificarItem = false;
            LimpiarProducto();
        }

        private void PDDRecibo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            /* Formato PDF Horizontal
            Graphics g = e.Graphics;
            Rectangle area = e.MarginBounds;

            const float anchoDiseno = 590f;
            const float altoDisenoBase = 835f;

            float xTabla = 20f;
            float yTabla = 330f;
            float altoCabecera = 58f;
            float altoFila = 24f;

            int cantidadFilas = Math.Max(1, listaItems.Count);
            float yTotales = yTabla + altoCabecera + altoFila * cantidadFilas;
            float yPie = Math.Max(620f, yTotales + 70f);
            float altoDiseno = Math.Max(altoDisenoBase, yPie + 115f);

            float escala = Math.Min(
                area.Width / anchoDiseno,
                area.Height / altoDiseno);

            float offsetX = area.Left + (area.Width - anchoDiseno * escala) / 2f;
            float offsetY = area.Top + (area.Height - altoDiseno * escala) / 2f;

            System.Drawing.Drawing2D.GraphicsState estado = g.Save();

            try
            {
                using (System.Drawing.Drawing2D.Matrix transformacion =
                    new System.Drawing.Drawing2D.Matrix(
                        escala, 0, 0, escala, offsetX, offsetY))
                {
                    g.Transform = transformacion;
                }

                using (Font normal = new Font("Arial", 8.5f))
                using (Font pequena = new Font("Arial", 7f))
                using (Font negrita = new Font("Arial", 8.5f, FontStyle.Bold))
                using (Font titulo = new Font("Arial", 18f, FontStyle.Bold))
                using (Font subtitulo = new Font("Arial", 9f))
                using (Pen linea = new Pen(Color.Black, 1f))
                using (StringFormat centrado = new StringFormat())
                using (StringFormat izquierda = new StringFormat())
                using (StringFormat derecha = new StringFormat())
                {
                    centrado.Alignment = StringAlignment.Center;
                    centrado.LineAlignment = StringAlignment.Center;

                    izquierda.Alignment = StringAlignment.Near;
                    izquierda.LineAlignment = StringAlignment.Center;
                    izquierda.Trimming = StringTrimming.EllipsisCharacter;
                    izquierda.FormatFlags = StringFormatFlags.NoWrap;

                    derecha.Alignment = StringAlignment.Far;
                    derecha.LineAlignment = StringAlignment.Center;

                    // Reemplaza estos datos de ejemplo por los de tu empresa.
                    string razonSocial = "LOCAL";
                    string sucursal = "DE DIETER";
                    string direccion = "Calle y número";
                    string telefono = "Teléfono";
                    string ciudad = "La Paz";
                    string nitEmpresa = "CONFIGURAR NIT";
                    string cuf = "CUF PENDIENTE";
                    string actividad =
                        "venta por mayor de diversos productos sin especialización";

                    // Emisor: columna izquierda
                    g.DrawString(razonSocial, negrita, Brushes.Black,
                        new RectangleF(20, 20, 245, 18), centrado);
                    g.DrawString(sucursal, negrita, Brushes.Black,
                        new RectangleF(20, 39, 245, 18), centrado);
                    g.DrawString(direccion, normal, Brushes.Black,
                        new RectangleF(20, 58, 245, 18), centrado);
                    g.DrawString(telefono, normal, Brushes.Black,
                        new RectangleF(20, 77, 245, 18), centrado);
                    g.DrawString(ciudad, normal, Brushes.Black,
                        new RectangleF(20, 96, 245, 18), centrado);

                    // Datos fiscales: columna derecha
                    g.DrawString("NIT:", negrita, Brushes.Black, 310, 20);
                    g.DrawString(nitEmpresa, normal, Brushes.Black, 385, 20);

                    g.DrawString("FACTURA N°:", negrita, Brushes.Black, 310, 40);
                    string numeroFactura = String.IsNullOrWhiteSpace(venta.pavpcodven)
                        ? "PENDIENTE"
                        : venta.pavpcodven;
                    g.DrawString(numeroFactura, normal, Brushes.Black, 385, 40);

                    g.DrawString("CUF:", negrita, Brushes.Black, 310, 60);
                    g.DrawString(cuf, pequena, Brushes.Black, 385, 60);

                    g.DrawString("ACTIVIDAD:", negrita, Brushes.Black, 310, 85);
                    g.DrawString(actividad, pequena, Brushes.Black,
                        new RectangleF(385, 82, 185, 45), izquierda);

                    // Título
                    g.DrawString("FACTURA", titulo, Brushes.Black,
                        new RectangleF(20, 155, 550, 30), centrado);
                    g.DrawString("(Con Derecho a Crédito Fiscal)", subtitulo,
                        Brushes.Black, new RectangleF(20, 186, 550, 20), centrado);

                    // Datos del cliente
                    g.DrawString("Fecha:", negrita, Brushes.Black, 20, 245);
                    g.DrawString(DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                        normal, Brushes.Black, 115, 245);

                    g.DrawString("NIT/CI/CEX:", negrita, Brushes.Black, 340, 245);
                    g.DrawString(TXTNitCliente.Text, normal, Brushes.Black,
                        new RectangleF(430, 243, 140, 20), derecha);

                    g.DrawString("Nombre/Razón Social:", negrita, Brushes.Black,
                        20, 270);
                    g.DrawString(TXTNombreCliente.Text, normal, Brushes.Black,
                        new RectangleF(155, 268, 415, 20), izquierda);

                    // Tabla: las columnas se ajustan al ancho vertical
                    float[] anchos = { 78f, 50f, 165f, 85f, 80f, 92f };
                    string[] encabezados =
                    {
                "CÓDIGO\nPRODUCTO",
                "CANT.",
                "DESCRIPCIÓN",
                "PRECIO\nUNITARIO",
                "DESCUENTO",
                "SUBTOTAL"
            };

                    float x = xTabla;

                    for (int i = 0; i < anchos.Length; i++)
                    {
                        g.DrawRectangle(linea, x, yTabla, anchos[i], altoCabecera);
                        g.DrawString(encabezados[i], negrita, Brushes.Black,
                            new RectangleF(x + 2, yTabla + 2,
                                anchos[i] - 4, altoCabecera - 4), centrado);
                        x += anchos[i];
                    }

                    // Filas de productos
                    float y = yTabla + altoCabecera;

                    if (listaItems.Count == 0)
                    {
                        g.DrawRectangle(linea, xTabla, y, 550f, altoFila);
                    }
                    else
                    {
                        foreach (liteven itemVenta in listaItems)
                        {
                            string descripcion = itemVenta.capdnompro;

                            if (!String.IsNullOrWhiteSpace(itemVenta.capdmodpro))
                                descripcion += " - " + itemVenta.capdmodpro;

                            if (!String.IsNullOrWhiteSpace(itemVenta.capdtalpro))
                                descripcion += " Talla " + itemVenta.capdtalpro;

                            if (!String.IsNullOrWhiteSpace(itemVenta.capddespro))
                                descripcion += " - " + itemVenta.capddespro;

                            string[] valores =
                            {
                        itemVenta.faivcodpro,
                        itemVenta.caivcanite.ToString(),
                        descripcion,
                        itemVenta.caivpreuni.ToString(
                            "0.00",
                            System.Globalization.CultureInfo.InvariantCulture),
                        "0.00",
                        itemVenta.caivsubtot.ToString(
                            "0.00",
                            System.Globalization.CultureInfo.InvariantCulture)
                    };

                            x = xTabla;

                            for (int i = 0; i < anchos.Length; i++)
                            {
                                g.DrawRectangle(linea, x, y, anchos[i], altoFila);

                                StringFormat formatoCelda =
                                    (i == 2) ? izquierda : centrado;

                                g.DrawString(valores[i], pequena, Brushes.Black,
                                    new RectangleF(x + 2, y + 1,
                                        anchos[i] - 4, altoFila - 2),
                                    formatoCelda);

                                x += anchos[i];
                            }

                            y += altoFila;
                        }
                    }

                    // Totales
                    decimal totalFactura = listaItems.Sum(
                        itemVenta => itemVenta.caivsubtot);

                    g.DrawRectangle(linea, 350, yTotales, 220, 19);
                    g.DrawRectangle(linea, 350, yTotales + 19, 220, 19);
                    g.DrawLine(linea, 495, yTotales, 495, yTotales + 38);

                    g.DrawString("TOTAL BS", negrita, Brushes.Black,
                        new RectangleF(350, yTotales, 145, 19), derecha);
                    g.DrawString(totalFactura.ToString(
                        "0.00",
                        System.Globalization.CultureInfo.InvariantCulture),
                        normal, Brushes.Black,
                        new RectangleF(495, yTotales, 75, 19), derecha);

                    g.DrawString("IMPORTE BASE CRÉDITO FISCAL", pequena,
                        Brushes.Black,
                        new RectangleF(350, yTotales + 19, 145, 19), derecha);
                    g.DrawString(totalFactura.ToString(
                        "0.00",
                        System.Globalization.CultureInfo.InvariantCulture),
                        normal, Brushes.Black,
                        new RectangleF(495, yTotales + 19, 75, 19), derecha);

                    string montoLiteral =
                        MetodosGenerales.ConvertirNumeroALetras((double)totalFactura);

                    g.DrawString("Son: " + montoLiteral + " Bolivianos",
                        negrita, Brushes.Black,
                        new RectangleF(20, yTotales + 25, 310, 28), izquierda);

                    // Pie de factura y espacio reservado para el QR
                    g.DrawString(
                        "ESTA FACTURA CONTRIBUYE AL DESARROLLO DE NUESTRO PAÍS. " +
                        "EL USO ILÍCITO DE ÉSTA SERÁ SANCIONADO DE ACUERDO A LEY.",
                        pequena, Brushes.Black,
                        new RectangleF(20, yPie + 8, 420, 42), centrado);

                    g.DrawString(
                        "Ley N° 453: Tienes derecho a recibir información sobre " +
                        "las características y contenidos de los servicios que utilices.",
                        pequena, Brushes.Black,
                        new RectangleF(20, yPie + 52, 420, 35), centrado);

                    g.DrawRectangle(linea, 455, yPie + 5, 100, 100);
                    g.DrawString("QR", negrita, Brushes.Black,
                        new RectangleF(455, yPie + 5, 100, 100), centrado);
                }
            }
            finally
            {
                g.Restore(estado);
            }

            e.HasMorePages = false;
            */

            Graphics g = e.Graphics;
            Rectangle area = e.MarginBounds;

            // Ancho aproximado de un ticket térmico de 80 mm.
            // En una hoja PDF Carta/A4, el ticket queda centrado y angosto.
            float anchoTicket = Math.Min(280f, area.Width - 10f);
            float xTicket = area.Left + (area.Width - anchoTicket) / 2f;
            float margen = 8f;
            float anchoTexto = anchoTicket - margen * 2;
            float y = area.Top + 10f;

            using (Font empresa = new Font("Arial", 10f, FontStyle.Bold))
            using (Font titulo = new Font("Arial", 12f, FontStyle.Bold))
            using (Font negrita = new Font("Arial", 8f, FontStyle.Bold))
            using (Font normal = new Font("Arial", 8f))
            using (Font pequena = new Font("Arial", 7f))
            using (Pen separador = new Pen(Color.Black, 0.8f))
            using (StringFormat centro = new StringFormat())
            using (StringFormat izquierda = new StringFormat())
            using (StringFormat derecha = new StringFormat())
            {
                centro.Alignment = StringAlignment.Center;
                centro.LineAlignment = StringAlignment.Center;

                izquierda.Alignment = StringAlignment.Near;
                izquierda.LineAlignment = StringAlignment.Center;
                izquierda.Trimming = StringTrimming.EllipsisCharacter;
                izquierda.FormatFlags = StringFormatFlags.NoWrap;

                derecha.Alignment = StringAlignment.Far;
                derecha.LineAlignment = StringAlignment.Center;

                // Encabezado
                g.DrawString("LOCAL DE DIETER", empresa,
                    Brushes.Black,
                    new RectangleF(xTicket, y, anchoTicket, 18), centro);
                y += 20;

                g.DrawString("Bermejo - Tarija - Bolivia", normal,
                    Brushes.Black,
                    new RectangleF(xTicket, y, anchoTicket, 14), centro);
                y += 16;

                g.DrawString("COMPROBANTE DE VENTA", titulo,
                    Brushes.Black,
                    new RectangleF(xTicket, y, anchoTicket, 22), centro);
                y += 26;

                string codigoVenta = String.IsNullOrWhiteSpace(venta.pavpcodven)
                    ? "Pendiente"
                    : venta.pavpcodven;

                g.DrawString("N° de venta: " + codigoVenta, normal,
                    Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 14), izquierda);
                y += 15;

                g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    normal, Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 14), izquierda);
                y += 18;

                g.DrawLine(separador, xTicket + margen, y,
                    xTicket + anchoTicket - margen, y);
                y += 7;

                // Cliente
                string nombreCliente = cliente == null
                    ? "Consumidor final"
                    : cliente.caclrazcli;

                string nitCliente = cliente == null
                    ? ""
                    : cliente.caclnitcli;

                g.DrawString("CLIENTE", negrita, Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 14), izquierda);
                y += 15;

                SizeF tamNombre = g.MeasureString(
                                    nombreCliente ?? "",
                                    normal,
                                    new SizeF(anchoTexto, 1000f));

                g.DrawString(nombreCliente ?? "", normal, Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto,
                        Math.Max(14f, tamNombre.Height)), izquierda);
                y += Math.Max(15f, tamNombre.Height);

                g.DrawString("NIT/CI: " + (nitCliente ?? ""), normal,
                    Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 14), izquierda);
                y += 18;

                g.DrawLine(separador, xTicket + margen, y,
                    xTicket + anchoTicket - margen, y);
                y += 7;

                // Encabezado de productos
                g.DrawString("DETALLE", negrita, Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 14), izquierda);
                y += 16;

                foreach (liteven itemVenta in listaItems)
                {
                    string nombreProducto =
                        String.IsNullOrWhiteSpace(itemVenta.capdnompro)
                            ? "Producto"
                            : itemVenta.capdnompro.Trim();

                    // Nombre y subtotal en la misma línea
                    g.DrawString(
                        itemVenta.caivcanite.ToString() + " x " + nombreProducto,
                        negrita, Brushes.Black,
                        new RectangleF(xTicket + margen, y, anchoTexto - 62, 16),
                        izquierda);

                    g.DrawString(itemVenta.caivsubtot.ToString("N2"),
                        negrita, Brushes.Black,
                        new RectangleF(xTicket + anchoTicket - margen - 62,
                            y, 62, 16), derecha);
                    y += 17;

                    string codigo = itemVenta.faivcodpro ?? "";
                    string modelo = itemVenta.capdmodpro ?? "";
                    string talla = itemVenta.capdtalpro ?? "";

                    string datosProducto = "P. unitario: Bs " +
                        itemVenta.caivpreuni.ToString("N2");

                    if (!String.IsNullOrWhiteSpace(modelo))
                        datosProducto += " | Modelo: " + modelo;

                    if (!String.IsNullOrWhiteSpace(talla))
                        datosProducto += " | Talla: " + talla;

                    if (!String.IsNullOrWhiteSpace(codigo))
                        datosProducto += " | Código: " + codigo;

                    SizeF tamDatos = g.MeasureString(
                                        datosProducto,
                                        pequena,
                                        new SizeF(anchoTexto, 1000f));

                    g.DrawString(datosProducto, pequena, Brushes.Black,
                        new RectangleF(xTicket + margen, y, anchoTexto,
                            Math.Max(12f, tamDatos.Height)), izquierda);
                    y += Math.Max(13f, tamDatos.Height);

                    string descripcion = itemVenta.capddespro ?? "";

                    if (!String.IsNullOrWhiteSpace(descripcion))
                    {
                        SizeF tamDescripcion = g.MeasureString(
                                                descripcion,
                                                pequena,
                                                new SizeF(anchoTexto, 1000f));

                        g.DrawString(descripcion, pequena, Brushes.Gray,
                            new RectangleF(xTicket + margen, y, anchoTexto,
                                tamDescripcion.Height), izquierda);
                        y += tamDescripcion.Height + 2f;
                    }

                    y += 5f;
                }

                g.DrawLine(separador, xTicket + margen, y,
                    xTicket + anchoTicket - margen, y);
                y += 9;

                // Total
                g.DrawString("TOTAL A PAGAR", negrita, Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto - 75, 18),
                    izquierda);

                g.DrawString("Bs " + total.ToString("N2"), negrita,
                    Brushes.Black,
                    new RectangleF(xTicket + anchoTicket - margen - 75,
                        y, 75, 18), derecha);
                y += 23;

                string montoEnLetras =
                    MetodosGenerales.ConvertirNumeroALetras(total);

                g.DrawString("Son: " + montoEnLetras + " Bolivianos", pequena,
                    Brushes.Black,
                    new RectangleF(xTicket + margen, y, anchoTexto, 32), centro);
                y += 36;

                g.DrawLine(separador, xTicket + margen, y,
                    xTicket + anchoTicket - margen, y);
                y += 8;

                g.DrawString("¡Gracias por su compra!", negrita,
                    Brushes.Black,
                    new RectangleF(xTicket, y, anchoTicket, 18), centro);
            }

            e.HasMorePages = false;
        }
    }
}
