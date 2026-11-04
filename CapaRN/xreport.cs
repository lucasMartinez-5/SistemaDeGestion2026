using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public string Titulo { get => _titulo;
                               set => _titulo = value; }
        public string Descripcion { get => _descripcion;
                                    set => _descripcion = value; }
        public bool Hoja { get => _hoja;
                           set => _hoja = value; }
        public bool Orientacion { get => _orientacion;
                                  set => _orientacion = value; }
        public int Letra { get => _letra;
                           set => _letra = value; }
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

        #region Metodos
        public void generarReporte()
        {
            // Implementación para generar el reporte
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Nombre del archivo a guardar";
            Guardar.Filter = "Archivo PDF|*.pdf";

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                Rectangle Hoja = new Rectangle(0, 0, 0, 0);
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

                HeaderFooter footer = new HeaderFooter(new Phrase("Biometric Control V 1.0 - P�gina N� ", Fondo11), true);
                footer.Alignment = Element.ALIGN_RIGHT;
                footer.BorderColor = new Color(System.Drawing.Color.Gray);
                footer.BorderWidthBottom = 0;

                Documento.Footer = footer;

                //3er. PASO: Abrir el documento para escritura
                Documento.Open();

                iTextSharp.text.Font Fondo1 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            13,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));



                iTextSharp.text.Font Fondo2 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            Letra,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo3 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            Letra,
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
                Celda.Add(new Paragraph(13, "Sistema de Gestion SUR MARKET \n" +
                                        "Bermejo - Bolivia \n", Fondo1));
                Celda.Add(new Paragraph(9, "Rep.Gen.: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " \n", Fondo11));

                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);
                Documento.Add(Tabla);

                //Titulo del Reporte
                Paragraph Parrafo = new Paragraph(this.Titulo + " \n", FondoT);
                Parrafo.Alignment = Element.ALIGN_CENTER;
                Documento.Add(Parrafo);

                //Descripcion del Reporte
                Tabla = new Table(2);
                Tabla.Width = 100;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla3 = { 20, 80 };
                Tabla.Widths = AnchosDeTabla3;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

                Celda = new Cell(new Phrase(12, "Descripci�n del Reporte: ", Fondo22));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell(new Phrase(12, Descripcion, Fondo33));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Documento.Add(Tabla);

                //Contenido del Reporte
                Tabla = new Table(1);
            }
        }
        #endregion
    }
}
