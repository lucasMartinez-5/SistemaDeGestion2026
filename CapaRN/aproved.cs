using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aproved {

		#region Campos
            private bool _caprestpro;
            private string _caprnumcel;
            private string _paprcodpro;
            private string _caprnitpro;
            private string _caprsocpro;
            private string _faprcntpro;
            private string _caprdirpro;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool caprestpro
            { 
                get{ return this._caprestpro;}
                set{ this._caprestpro = value;}
            } 
		    public string caprnumcel
            { 
                get{ return this._caprnumcel;}
                set{ this._caprnumcel = value;}
            } 
		    public string paprcodpro
            { 
                get{ return this._paprcodpro;}
                set{ this._paprcodpro = value;}
            } 
		    public string caprnitpro
            { 
                get{ return this._caprnitpro;}
                set{ this._caprnitpro = value;}
            } 
		    public string caprsocpro
            { 
                get{ return this._caprsocpro;}
                set{ this._caprsocpro = value;}
            } 
		    public string faprcntpro
            { 
                get{ return this._faprcntpro;}
                set{ this._faprcntpro = value;}
            } 
		    public string caprdirpro
            { 
                get{ return this._caprdirpro;}
                set{ this._caprdirpro = value;}
            } 
        #endregion

        #region Constructor
            public aproved()
            { 
		        this._caprestpro = true;
		        this._caprnumcel = "";
		        this._paprcodpro = "";
		        this._caprnitpro = "";
		        this._caprsocpro = "";
		        this._faprcntpro = "";
		        this._caprdirpro = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "caprestpro," +
                                     "caprnumcel," +
                                     "paprcodpro," +
                                     "caprnitpro," +
                                     "caprsocpro," +
                                     "faprcntpro," +
                                     "caprdirpro " + 
                             "from aproved " +
                             "where "+
                                    "paprcodpro = @paprcodpro";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@paprcodpro",this._paprcodpro);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._caprestpro=ResultadoConsulta.GetBoolean(0);
                    this._caprnumcel=ResultadoConsulta.GetString(1);
                    this._paprcodpro=ResultadoConsulta.GetString(2);
                    this._caprnitpro=ResultadoConsulta.GetString(3);
                    this._caprsocpro=ResultadoConsulta.GetString(4);
                    this._faprcntpro=ResultadoConsulta.GetString(5);
                    this._caprdirpro=ResultadoConsulta.GetString(6);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }
            public bool ObtenerDatosNIT(bool modificar, string nit)
            {
                this.Conexion.Conectar();
            string sql = "select " +
                                 "caprestpro," +
                                 "caprnumcel," +
                                 "paprcodpro," +
                                 "caprnitpro," +
                                 "caprsocpro," +
                                 "faprcntpro," +
                                 "caprdirpro " +
                         "from aproved " +
                         "where " +
                                "caprnitpro = @caprnitpro";

            if (modificar)
            {
                sql += " and caprnitpro!='" + nit + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@caprnitpro", this._caprnitpro);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._caprestpro = ResultadoConsulta.GetBoolean(0);
                this._caprnumcel = ResultadoConsulta.GetString(1);
                this._paprcodpro = ResultadoConsulta.GetString(2);
                this._caprnitpro = ResultadoConsulta.GetString(3);
                this._caprsocpro = ResultadoConsulta.GetString(4);
                this._faprcntpro = ResultadoConsulta.GetString(5);
                this._caprdirpro = ResultadoConsulta.GetString(6);
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
                                     "caprestpro," +
                                     "caprnumcel," +
                                     "paprcodpro," +
                                     "caprnitpro," +
                                     "caprsocpro," +
                                     "faprcntpro," +
                                     "caprdirpro " + 
                             "from aproved " +
                             "where " +
                                    "paprcodpro = @paprcodpro";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@paprcodpro",this._paprcodpro);

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
			        string sql = "insert into aproved (" +
                                                       "caprestpro," +
                                                       "caprnumcel," +
                                                       "paprcodpro," +
                                                       "caprnitpro," +
                                                       "caprsocpro," +
                                                       "faprcntpro," +
                                                       "caprdirpro" +
                                                       ") " +
	                             "values (" + 
                                          "@caprestpro," +
                                          "@caprnumcel," +
                                          "@paprcodpro," +
                                          "@caprnitpro," +
                                          "@caprsocpro," +
                                          "@faprcntpro," +
                                          "@caprdirpro" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@caprestpro",this._caprestpro);
                    this.Conexion.AsignarParametroCadena("@caprnumcel",this._caprnumcel);
                    this.Conexion.AsignarParametroCadena("@paprcodpro",this._paprcodpro);
                    this.Conexion.AsignarParametroCadena("@caprnitpro",this._caprnitpro);
                    this.Conexion.AsignarParametroCadena("@caprsocpro",this._caprsocpro);
                    this.Conexion.AsignarParametroCadena("@faprcntpro",this._faprcntpro);
                    this.Conexion.AsignarParametroCadena("@caprdirpro",this._caprdirpro);

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
			        string sql = "update aproved set " +
                                                     "caprestpro = @caprestpro, " +
                                                     "caprnumcel = @caprnumcel, " +
                                                     "caprnitpro = @caprnitpro, " +
                                                     "caprsocpro = @caprsocpro, " +
                                                     "faprcntpro = @faprcntpro, " +
                                                     "caprdirpro = @caprdirpro" +
                                 " where " +
                                        "paprcodpro = @paprcodpro";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@caprestpro",this._caprestpro);
                    this.Conexion.AsignarParametroCadena("@caprnumcel",this._caprnumcel);
                    this.Conexion.AsignarParametroCadena("@paprcodpro",this._paprcodpro);
                    this.Conexion.AsignarParametroCadena("@caprnitpro",this._caprnitpro);
                    this.Conexion.AsignarParametroCadena("@caprsocpro",this._caprsocpro);
                    this.Conexion.AsignarParametroCadena("@faprcntpro",this._faprcntpro);
                    this.Conexion.AsignarParametroCadena("@caprdirpro",this._caprdirpro);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aproved> Lista(string where)
            { 
                List<aproved> ListaResultado = new List<aproved>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "caprestpro," +
                                     "caprnumcel," +
                                     "paprcodpro," +
                                     "caprnitpro," +
                                     "caprsocpro," +
                                     "faprcntpro," +
                                     "caprdirpro " + 
                             "from aproved " ;
 
                if (where.Replace(" ", "") != "")
                {
                    sql+= "where " + where;
                }

 
                this.Conexion.PrepararComando(sql); 
                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta!=null)
                {
                    while (ResultadoConsulta.Read())
                    {
                          aproved Auxiliar = new aproved();
                          Auxiliar.caprestpro = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.caprnumcel = ResultadoConsulta.GetString(1);
                          Auxiliar.paprcodpro = ResultadoConsulta.GetString(2);
                          Auxiliar.caprnitpro = ResultadoConsulta.GetString(3);
                          Auxiliar.caprsocpro = ResultadoConsulta.GetString(4);
                          Auxiliar.faprcntpro = ResultadoConsulta.GetString(5);
                          Auxiliar.caprdirpro = ResultadoConsulta.GetString(6);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

