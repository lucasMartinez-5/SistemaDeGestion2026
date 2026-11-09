using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using System.Drawing;

namespace CapaRN
{
    public class xreport
    {
        #region Campos
        private string _titulo;
        private string _descripcion;
        private bool _hoja;
        private bool _orientacion;

        private int _letra;

        #endregion

        #region Propiedades
        public string titulo
        {
            get => _titulo;
            set => _titulo = value;
        }
        public string descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }
        public bool hoja
        {
            get => _hoja;
            set => _hoja = value;
        }
        public bool orientacion
        {
            get => _orientacion;
            set => _orientacion = value;
        }
        public int letra
        {
            get => _letra;
            set => _letra = value;
        }
        #endregion

        #region Constructor
        public xreport()
        {
            this._titulo = "";
            this._descripcion = "";
            this._hoja = true;
            this._orientacion = true;
            this._letra = 0;
        }
        #endregion

        #region Métodos

        public void GenerarReporte(int columnas, float[] anchoColumnas, List<string> titulosColumnas)
        {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Nombre del archivo a guardar";
            Guardar.Filter = "Archivo PDF|*.pdf";

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Rectangle Hoja = new iTextSharp.text.Rectangle(0, 0, 0, 0);
                if (this._hoja)
                { Hoja = PageSize.A4; }
                else
                { Hoja = PageSize.LETTER; }

                if (this._orientacion)
                {
                    Hoja = Hoja.Rotate();
                }

                iTextSharp.text.Font Fondo11 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            9,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));

                //1er. PASO: Crear el Documento PDF
                Document Documento = new Document(Hoja, 24, 24, 24, 24);

                //2do. PASO: Crear un escritor de documento PDF
                PdfWriter escritor = PdfWriter.GetInstance(Documento, new FileStream(Guardar.FileName, FileMode.Create));

                HeaderFooter footer = new HeaderFooter(new Phrase("SurMarket V 1.0 - Página Nº ", Fondo11), true);
                footer.Alignment = Element.ALIGN_RIGHT;
                footer.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
                footer.BorderWidthBottom = 0;

                Documento.Footer = footer;

                //3er. PASO: Abrir el documento para escritura
                Documento.Open();

                iTextSharp.text.Font Fondo1 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            13,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));

                iTextSharp.text.Font Fondo2 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo3 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo22 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo33 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));


                iTextSharp.text.Font FondoT = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            14,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                //4to. PASO: Escribir en el Documento

                //Encabezado del Documento

                Table Tabla = new Table(2);
                Tabla.Width = 50;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla = { 20, 80 };
                Tabla.Widths = AnchosDeTabla;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

                iTextSharp.text.Image Foto = iTextSharp.text.Image.GetInstance(
                                            Application.StartupPath + "\\imagenes\\surmarket.png");
                Foto.Alignment = Element.ALIGN_CENTER;
                Foto.ScaleToFit(50, 70);

                Cell Celda = new Cell(Foto);
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell();
                Celda.Add(new Paragraph(13, "Sistema de Gestión SUR MARKET \n" +
                                        "Bermejo - Bolivia \n", Fondo1));
                Celda.Add(new Paragraph(9, "Rep.Gen.: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " \n", Fondo11));

                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);
                Documento.Add(Tabla);

                //Titulo del Reporte
                Paragraph Parrafo = new Paragraph(this._titulo + " \n", FondoT);
                Parrafo.Alignment = Element.ALIGN_CENTER;
                Documento.Add(Parrafo);

                //Descripción del Reporte
                Tabla = new Table(2);
                Tabla.Width = 100;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla3 = { 20, 80 };
                Tabla.Widths = AnchosDeTabla3;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

                Celda = new Cell(new Phrase(12, "Descripción del Reporte: ", Fondo22));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell(new Phrase(12, this.descripcion, Fondo33));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Documento.Add(Tabla);

                //Contenido del Reporte - Titulos de las Columnas

                Tabla = new Table(columnas);

                Tabla.Widths = anchoColumnas;
                Tabla.Alignment = Element.ALIGN_LEFT;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                Tabla.BorderWidth = 1.5F;
                Tabla.Width = 100;
                Tabla.DefaultCellBorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                Tabla.Cellpadding = 2;

                foreach (string a in titulosColumnas)
                {
                    Celda = new Cell(new Phrase(10, a, Fondo2));
                    Celda.BorderWidth = 1.5F;
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);
                    Tabla.AddCell(Celda);
                }

                //Contenido del Reporte - Contenido de las Columnas

                Documento.Add(Tabla);

                //5to. PASO: Cerrar el Documento
                Documento.Close();

                //MOSTRAR MENSAJE

                // iniciamos la instancia de la clase process
                System.Diagnostics.Process proc = new System.Diagnostics.Process();

                // nombre del archivo a abrir
                proc.StartInfo.FileName = Guardar.FileName;

                // arrancamos el proceso
                proc.Start();

                // liberamos recursos
                proc.Close();   // atención: close no termina el proceso
            }
        }
        #endregion
    }
}
