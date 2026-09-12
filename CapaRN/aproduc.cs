using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aproduc {

        #region Campos
        private decimal _capdpreven;
        private decimal _capdpremin;
        private bool _capdestpro;
        private DateTime _capdfeccre;
        private DateTime _capdfecmod;
        private int _capdstopro;
        private string _capdcolpro;
        private string _capdgenpro;
        private string _capdtalpro;
        private string _capddespro;
        private string _capdfotpro;
        private string _papdcodpro;
        private string _fapdcodcat;
        private string _cacpnomcat;
        private string _capdcodbar;
        private string _capdmodpro;
        private string _capdnompro;
        private string _capdmarpro;
        private string _capdmatpro;
        //Instancia para conexion a PostgreSQL 8.2

        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public decimal capdpreven
        {
            get { return this._capdpreven; }
            set { this._capdpreven = value; }
        }
        public decimal capdpremin
        {
            get { return this._capdpremin; }
            set { this._capdpremin = value; }
        }
        public bool capdestpro
        {
            get { return this._capdestpro; }
            set { this._capdestpro = value; }
        }
        public DateTime capdfeccre
        {
            get { return this._capdfeccre; }
            set { this._capdfeccre = value; }
        }
        public DateTime capdfecmod
        {
            get { return this._capdfecmod; }
            set { this._capdfecmod = value; }
        }
        public int capdstopro
        {
            get { return this._capdstopro; }
            set { this._capdstopro = value; }
        }
        public string capdcolpro
        {
            get { return this._capdcolpro; }
            set { this._capdcolpro = value; }
        }
        public string capdgenpro
        {
            get { return this._capdgenpro; }
            set { this._capdgenpro = value; }
        }
        public string capdtalpro
        {
            get { return this._capdtalpro; }
            set { this._capdtalpro = value; }
        }
        public string capddespro
        {
            get { return this._capddespro; }
            set { this._capddespro = value; }
        }
        public string capdfotpro
        {
            get { return this._capdfotpro; }
            set { this._capdfotpro = value; }
        }
        public string papdcodpro
        {
            get { return this._papdcodpro; }
            set { this._papdcodpro = value; }
        }
        public string fapdcodcat
        {
            get { return this._fapdcodcat; }
            set { this._fapdcodcat = value; }
        }
        public string cacpnomcat
        {
            get { return this._cacpnomcat; }
            set { this._cacpnomcat = value; }
        }
        public string capdcodbar
        {
            get { return this._capdcodbar; }
            set { this._capdcodbar = value; }
        }
        public string capdmodpro
        {
            get { return this._capdmodpro; }
            set { this._capdmodpro = value; }
        }
        public string capdnompro
        {
            get { return this._capdnompro; }
            set { this._capdnompro = value; }
        }
        public string capdmarpro
        {
            get { return this._capdmarpro; }
            set { this._capdmarpro = value; }
        }
        public string capdmatpro
        {
            get { return this._capdmatpro; }
            set { this._capdmatpro = value; }
        }
        #endregion

        #region Constructor
        public aproduc()
        {
            this._capdpreven = 0;
            this._capdpremin = 0;
            this._capdestpro = true;
            this._capdfeccre = DateTime.Now;
            this._capdfecmod = DateTime.Now;
            this._capdstopro = 0;
            this._capdcolpro = "";
            this._capdgenpro = "";
            this._capdtalpro = "";
            this._capddespro = "";
            this._capdfotpro = "";
            this._papdcodpro = "";
            this._fapdcodcat = "";
            this._capdcodbar = "";
            this._capdmodpro = "";
            this._capdnompro = "";
            this._capdmarpro = "";
            this._capdmatpro = "";
            this.Conexion = new CLConexionPGSQL();
        }
        #endregion

        #region Metodos
        public bool ObtenerDatos()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdpreven," +
                                 "capdpremin," +
                                 "capdestpro," +
                                 "capdfeccre," +
                                 "capdfecmod," +
                                 "capdstopro," +
                                 "capdcolpro," +
                                 "capdgenpro," +
                                 "capdtalpro," +
                                 "capddespro," +
                                 "capdfotpro," +
                                 "papdcodpro," +
                                 "fapdcodcat," +
                                 "capdcodbar," +
                                 "capdmodpro," +
                                 "capdnompro," +
                                 "capdmarpro," +
                                 "capdmatpro " +
                         "from aproduc " +
                         "where " +
                                "papdcodpro = @papdcodpro";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@papdcodpro", this._papdcodpro);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._capdpreven = ResultadoConsulta.GetDecimal(0);
                this._capdpremin = ResultadoConsulta.GetDecimal(1);
                this._capdestpro = ResultadoConsulta.GetBoolean(2);
                this._capdfeccre = ResultadoConsulta.GetDateTime(3);
                this._capdfecmod = ResultadoConsulta.GetDateTime(4);
                this._capdstopro = ResultadoConsulta.GetInt32(5);
                this._capdcolpro = ResultadoConsulta.GetString(6);
                this._capdgenpro = ResultadoConsulta.GetString(7);
                this._capdtalpro = ResultadoConsulta.GetString(8);
                this._capddespro = ResultadoConsulta.GetString(9);
                this._capdfotpro = ResultadoConsulta.GetString(10);
                this._papdcodpro = ResultadoConsulta.GetString(11);
                this._fapdcodcat = ResultadoConsulta.GetString(12);
                this._capdcodbar = ResultadoConsulta.GetString(13);
                this._capdmodpro = ResultadoConsulta.GetString(14);
                this._capdnompro = ResultadoConsulta.GetString(15);
                this._capdmarpro = ResultadoConsulta.GetString(16);
                this._capdmatpro = ResultadoConsulta.GetString(17);
                this.Conexion.Desconectar();

                return true;
            }
            else
            {
                this.Conexion.Desconectar();
                return false;
            }
        }
        public bool ObtenerDatosCodBarra(bool modificar, string codbarr)
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                     "capdpreven," +
                                     "capdpremin," +
                                     "capdestpro," +
                                     "capdfeccre," +
                                     "capdfecmod," +
                                     "capdstopro," +
                                     "capdcolpro," +
                                     "capdgenpro," +
                                     "capdtalpro," +
                                     "capddespro," +
                                     "capdfotpro," +
                                     "papdcodpro," +
                                     "fapdcodcat," +
                                     "capdcodbar," +
                                     "capdmodpro," +
                                     "capdnompro," +
                                     "capdmarpro," +
                                     "capdmatpro " +
                             "from aproduc " +
                             "where " +
                                "capdcodbar = @capdcodbar";

            if (modificar)
            {
                sql += " and capdcodbar!='" + codbarr + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@capdcodbar", this._capdcodbar);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._capdpreven = ResultadoConsulta.GetDecimal(0);
                this._capdpremin = ResultadoConsulta.GetDecimal(1);
                this._capdestpro = ResultadoConsulta.GetBoolean(2);
                this._capdfeccre = ResultadoConsulta.GetDateTime(3);
                this._capdfecmod = ResultadoConsulta.GetDateTime(4);
                this._capdstopro = ResultadoConsulta.GetInt32(5);
                this._capdcolpro = ResultadoConsulta.GetString(6);
                this._capdgenpro = ResultadoConsulta.GetString(7);
                this._capdtalpro = ResultadoConsulta.GetString(8);
                this._capddespro = ResultadoConsulta.GetString(9);
                this._capdfotpro = ResultadoConsulta.GetString(10);
                this._papdcodpro = ResultadoConsulta.GetString(11);
                this._fapdcodcat = ResultadoConsulta.GetString(12);
                this._capdcodbar = ResultadoConsulta.GetString(13);
                this._capdmodpro = ResultadoConsulta.GetString(14);
                this._capdnompro = ResultadoConsulta.GetString(15);
                this._capdmarpro = ResultadoConsulta.GetString(16);
                this._capdmatpro = ResultadoConsulta.GetString(17);
                this.Conexion.Desconectar();

                return true;
            }
            else
            {
                this.Conexion.Desconectar();
                return false;
            }
        }
        public bool VerificarExistencia()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdpreven," +
                                 "capdpremin," +
                                 "capdestpro," +
                                 "capdfeccre," +
                                 "capdfecmod," +
                                 "capdstopro," +
                                 "capdcolpro," +
                                 "capdgenpro," +
                                 "capdtalpro," +
                                 "capddespro," +
                                 "capdfotpro," +
                                 "papdcodpro," +
                                 "fapdcodcat," +
                                 "capdcodbar," +
                                 "capdmodpro," +
                                 "capdnompro," +
                                 "capdmarpro," +
                                 "capdmatpro " +
                         "from aproduc " +
                         "where " +
                                "papdcodpro = @papdcodpro";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@papdcodpro", this._papdcodpro);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.HasRows)
            {
                this.Conexion.Desconectar();

                return true;
            }
            else
            {

                this.Conexion.Desconectar();
                return false;
            }
        }
        public bool Grabar()
        {
            if (this.VerificarExistencia())
            {
                return false;
            }
            else
            {
                this.Conexion.Conectar();
                string sql = "insert into aproduc (" +
                                                   "capdpreven," +
                                                   "capdpremin," +
                                                   "capdestpro," +
                                                   "capdfeccre," +
                                                   "capdfecmod," +
                                                   "capdstopro," +
                                                   "capdcolpro," +
                                                   "capdgenpro," +
                                                   "capdtalpro," +
                                                   "capddespro," +
                                                   "capdfotpro," +
                                                   "papdcodpro," +
                                                   "fapdcodcat," +
                                                   "capdcodbar," +
                                                   "capdmodpro," +
                                                   "capdnompro," +
                                                   "capdmarpro," +
                                                   "capdmatpro" +
                                                   ") " +
                             "values (" +
                                      "@capdpreven," +
                                      "@capdpremin," +
                                      "@capdestpro," +
                                      "@capdfeccre," +
                                      "@capdfecmod," +
                                      "@capdstopro," +
                                      "@capdcolpro," +
                                      "@capdgenpro," +
                                      "@capdtalpro," +
                                      "@capddespro," +
                                      "@capdfotpro," +
                                      "@papdcodpro," +
                                      "@fapdcodcat," +
                                      "@capdcodbar," +
                                      "@capdmodpro," +
                                      "@capdnompro," +
                                      "@capdmarpro," +
                                      "@capdmatpro" +
                                                   ")";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroDecimal("@capdpreven", this._capdpreven);
                this.Conexion.AsignarParametroDecimal("@capdpremin", this._capdpremin);
                this.Conexion.AsignarParametroLogico("@capdestpro", this._capdestpro);
                this.Conexion.AsignarParametroFechaHora("@capdfeccre", this._capdfeccre);
                this.Conexion.AsignarParametroFechaHora("@capdfecmod", this._capdfecmod);
                this.Conexion.AsignarParametroEntero("@capdstopro", this._capdstopro);
                this.Conexion.AsignarParametroCadena("@capdcolpro", this._capdcolpro);
                this.Conexion.AsignarParametroCadena("@capdgenpro", this._capdgenpro);
                this.Conexion.AsignarParametroCadena("@capdtalpro", this._capdtalpro);
                this.Conexion.AsignarParametroCadena("@capddespro", this._capddespro);
                this.Conexion.AsignarParametroCadena("@capdfotpro", this._capdfotpro);
                this.Conexion.AsignarParametroCadena("@papdcodpro", this._papdcodpro);
                this.Conexion.AsignarParametroCadena("@fapdcodcat", this._fapdcodcat);
                this.Conexion.AsignarParametroCadena("@capdcodbar", this._capdcodbar);
                this.Conexion.AsignarParametroCadena("@capdmodpro", this._capdmodpro);
                this.Conexion.AsignarParametroCadena("@capdnompro", this._capdnompro);
                this.Conexion.AsignarParametroCadena("@capdmarpro", this._capdmarpro);
                this.Conexion.AsignarParametroCadena("@capdmatpro", this._capdmatpro);

                this.Conexion.EjecutarTransaccion();
                this.Conexion.Desconectar();

                return true;
            }
        }
        public bool Modificar()
        {
            if (!this.VerificarExistencia())
            {
                return false;
            }
            else
            {
                this.Conexion.Conectar();
                string sql = "update aproduc set " +
                                                 "capdpreven = @capdpreven, " +
                                                 "capdpremin = @capdpremin, " +
                                                 "capdestpro = @capdestpro, " +
                                                 "capdfeccre = @capdfeccre, " +
                                                 "capdfecmod = @capdfecmod, " +
                                                 "capdstopro = @capdstopro, " +
                                                 "capdcolpro = @capdcolpro, " +
                                                 "capdgenpro = @capdgenpro, " +
                                                 "capdtalpro = @capdtalpro, " +
                                                 "capddespro = @capddespro, " +
                                                 "capdfotpro = @capdfotpro, " +
                                                 "fapdcodcat = @fapdcodcat, " +
                                                 "capdcodbar = @capdcodbar, " +
                                                 "capdmodpro = @capdmodpro, " +
                                                 "capdnompro = @capdnompro, " +
                                                 "capdmarpro = @capdmarpro, " +
                                                 "capdmatpro = @capdmatpro" +
                             " where " +
                                    "papdcodpro = @papdcodpro";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroDecimal("@capdpreven", this._capdpreven);
                this.Conexion.AsignarParametroDecimal("@capdpremin", this._capdpremin);
                this.Conexion.AsignarParametroLogico("@capdestpro", this._capdestpro);
                this.Conexion.AsignarParametroFechaHora("@capdfeccre", this._capdfeccre);
                this.Conexion.AsignarParametroFechaHora("@capdfecmod", this._capdfecmod);
                this.Conexion.AsignarParametroEntero("@capdstopro", this._capdstopro);
                this.Conexion.AsignarParametroCadena("@capdcolpro", this._capdcolpro);
                this.Conexion.AsignarParametroCadena("@capdgenpro", this._capdgenpro);
                this.Conexion.AsignarParametroCadena("@capdtalpro", this._capdtalpro);
                this.Conexion.AsignarParametroCadena("@capddespro", this._capddespro);
                this.Conexion.AsignarParametroCadena("@capdfotpro", this._capdfotpro);
                this.Conexion.AsignarParametroCadena("@papdcodpro", this._papdcodpro);
                this.Conexion.AsignarParametroCadena("@fapdcodcat", this._fapdcodcat);
                this.Conexion.AsignarParametroCadena("@capdcodbar", this._capdcodbar);
                this.Conexion.AsignarParametroCadena("@capdmodpro", this._capdmodpro);
                this.Conexion.AsignarParametroCadena("@capdnompro", this._capdnompro);
                this.Conexion.AsignarParametroCadena("@capdmarpro", this._capdmarpro);
                this.Conexion.AsignarParametroCadena("@capdmatpro", this._capdmatpro);

                this.Conexion.EjecutarTransaccion();
                this.Conexion.Desconectar();

                return true;
            }
        }
        /*
        public List<aproduc> Lista(string where)
        {
            List<aproduc> ListaResultado = new List<aproduc>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdpreven," +
                                 "capdpremin," +
                                 "capdestpro," +
                                 "capdfeccre," +
                                 "capdfecmod," +
                                 "capdstopro," +
                                 "capdcolpro," +
                                 "capdgenpro," +
                                 "capdtalpro," +
                                 "capddespro," +
                                 "capdfotpro," +
                                 "papdcodpro," +
                                 "fapdcodcat," +
                                 "capdcodbar," +
                                 "capdmodpro," +
                                 "capdnompro," +
                                 "capdmarpro," +
                                 "capdmatpro " +
                         "from aproduc ";

            if (where.Replace(" ", "") != "")
            {
                sql += "where " + where;
            }


            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    aproduc Auxiliar = new aproduc();
                    Auxiliar.capdpreven = ResultadoConsulta.GetDecimal(0);
                    Auxiliar.capdpremin = ResultadoConsulta.GetDecimal(1);
                    Auxiliar.capdestpro = ResultadoConsulta.GetBoolean(2);
                    Auxiliar.capdfeccre = ResultadoConsulta.GetDateTime(3);
                    Auxiliar.capdfecmod = ResultadoConsulta.GetDateTime(4);
                    Auxiliar.capdstopro = ResultadoConsulta.GetInt32(5);
                    Auxiliar.capdcolpro = ResultadoConsulta.GetString(6);
                    Auxiliar.capdgenpro = ResultadoConsulta.GetString(7);
                    Auxiliar.capdtalpro = ResultadoConsulta.GetString(8);
                    Auxiliar.capddespro = ResultadoConsulta.GetString(9);
                    Auxiliar.capdfotpro = ResultadoConsulta.GetString(10);
                    Auxiliar.papdcodpro = ResultadoConsulta.GetString(11);
                    Auxiliar.fapdcodcat = ResultadoConsulta.GetString(12);
                    Auxiliar.capdcodbar = ResultadoConsulta.GetString(13);
                    Auxiliar.capdmodpro = ResultadoConsulta.GetString(14);
                    Auxiliar.capdnompro = ResultadoConsulta.GetString(15);
                    Auxiliar.capdmarpro = ResultadoConsulta.GetString(16);
                    Auxiliar.capdmatpro = ResultadoConsulta.GetString(17);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }*/
        public List<aproduc> Lista(string where)
        {
            List<aproduc> ListaResultado = new List<aproduc>();
            this.Conexion.Conectar();

            // 1. Modificamos el SELECT agregando los alias (p.) y el campo c.cacpnomcat al final
            string sql = "select " +
                                 "p.capdpreven," +
                                 "p.capdpremin," +
                                 "p.capdestpro," +
                                 "p.capdfeccre," +
                                 "p.capdfecmod," +
                                 "p.capdstopro," +
                                 "p.capdcolpro," +
                                 "p.capdgenpro," +
                                 "p.capdtalpro," +
                                 "p.capddespro," +
                                 "p.capdfotpro," +
                                 "p.papdcodpro," +
                                 "p.fapdcodcat," +
                                 "p.capdcodbar," +
                                 "p.capdmodpro," +
                                 "p.capdnompro," +
                                 "p.capdmarpro," +
                                 "p.capdmatpro," +
                                 "c.cacpnomcat " + // <--- Posición 18: El nombre de la categoría
                         "from aproduc p " +
                         "inner join acatpro c on p.fapdcodcat = c.pacpcodcat "; // <--- El puente de unión

            if (where.Replace(" ", "") != "")
            {
                // Añadimos el alias "p." a los filtros comunes para evitar errores de ambigüedad
                string whereFormateado = where.Replace("capd", "p.capd")
                                              .Replace("papd", "p.papd")
                                              .Replace("fapd", "p.fapd")
                                              .Replace("limit", "limit"); // Mantiene el limit intacto

                sql += "where " + whereFormateado;
            }

            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    aproduc Auxiliar = new aproduc();
                    Auxiliar.capdpreven = ResultadoConsulta.GetDecimal(0);
                    Auxiliar.capdpremin = ResultadoConsulta.GetDecimal(1);
                    Auxiliar.capdestpro = ResultadoConsulta.GetBoolean(2);
                    Auxiliar.capdfeccre = ResultadoConsulta.GetDateTime(3);
                    Auxiliar.capdfecmod = ResultadoConsulta.GetDateTime(4);
                    Auxiliar.capdstopro = ResultadoConsulta.GetInt32(5);
                    Auxiliar.capdcolpro = ResultadoConsulta.GetString(6);
                    Auxiliar.capdgenpro = ResultadoConsulta.GetString(7);
                    Auxiliar.capdtalpro = ResultadoConsulta.GetString(8);
                    Auxiliar.capddespro = ResultadoConsulta.GetString(9);
                    Auxiliar.capdfotpro = ResultadoConsulta.GetString(10);
                    Auxiliar.papdcodpro = ResultadoConsulta.GetString(11);
                    Auxiliar.fapdcodcat = ResultadoConsulta.GetString(12);
                    Auxiliar.capdcodbar = ResultadoConsulta.GetString(13);
                    Auxiliar.capdmodpro = ResultadoConsulta.GetString(14);
                    Auxiliar.capdnompro = ResultadoConsulta.GetString(15);
                    Auxiliar.capdmarpro = ResultadoConsulta.GetString(16);
                    Auxiliar.capdmatpro = ResultadoConsulta.GetString(17);

                    // 2. Guardamos el valor de la columna combinada en nuestra propiedad de memoria
                    Auxiliar.cacpnomcat = ResultadoConsulta.GetString(18);

                    ListaResultado.Add(Auxiliar);
                }
            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }

        public List<String> Combo(String campo)
        {
            List<String> ListaResultado = new List<String>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "distinct " + campo + " " +
                         "from aproduc " +
                         "where capdestpro=true " +
                         "order by " + campo;

            this.Conexion.PrepararComando(sql);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    String Auxiliar = "";
                    Auxiliar = ResultadoConsulta.GetString(0);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        #endregion

    }
}

