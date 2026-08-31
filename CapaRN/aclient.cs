using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aclient {

		#region Campos
            private bool _caclestcli;
            private string _caclnumcel;
            private string _paclcodcli;
            private string _caclnitcli;
            private string _caclsoccli;
            private string _faclcntcli;
            private string _cacldircli;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool caclestcli
            { 
                get{ return this._caclestcli;}
                set{ this._caclestcli = value;}
            } 
		    public string caclnumcel
            { 
                get{ return this._caclnumcel;}
                set{ this._caclnumcel = value;}
            } 
		    public string paclcodcli
            { 
                get{ return this._paclcodcli;}
                set{ this._paclcodcli = value;}
            } 
		    public string caclnitcli
            { 
                get{ return this._caclnitcli;}
                set{ this._caclnitcli = value;}
            } 
		    public string caclsoccli
            { 
                get{ return this._caclsoccli;}
                set{ this._caclsoccli = value;}
            } 
		    public string faclcntcli
            { 
                get{ return this._faclcntcli;}
                set{ this._faclcntcli = value;}
            } 
		    public string cacldircli
            { 
                get{ return this._cacldircli;}
                set{ this._cacldircli = value;}
            } 
        #endregion

        #region Constructor
            public aclient()
            { 
		        this._caclestcli = true;
		        this._caclnumcel = "";
		        this._paclcodcli = "";
		        this._caclnitcli = "";
		        this._caclsoccli = "";
		        this._faclcntcli = "";
		        this._cacldircli = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "caclestcli," +
                                     "caclnumcel," +
                                     "paclcodcli," +
                                     "caclnitcli," +
                                     "caclsoccli," +
                                     "faclcntcli," +
                                     "cacldircli " + 
                             "from aclient " +
                             "where "+
                                    "paclcodcli = @paclcodcli";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@paclcodcli",this._paclcodcli);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._caclestcli=ResultadoConsulta.GetBoolean(0);
                    this._caclnumcel=ResultadoConsulta.GetString(1);
                    this._paclcodcli=ResultadoConsulta.GetString(2);
                    this._caclnitcli=ResultadoConsulta.GetString(3);
                    this._caclsoccli=ResultadoConsulta.GetString(4);
                    this._faclcntcli=ResultadoConsulta.GetString(5);
                    this._cacldircli=ResultadoConsulta.GetString(6);
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
                                     "caclestcli," +
                                     "caclnumcel," +
                                     "paclcodcli," +
                                     "caclnitcli," +
                                     "caclsoccli," +
                                     "faclcntcli," +
                                     "cacldircli " + 
                             "from aclient " +
                             "where " +
                                    "paclcodcli = @paclcodcli";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@paclcodcli",this._paclcodcli);

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
			        string sql = "insert into aclient (" +
                                                       "caclestcli," +
                                                       "caclnumcel," +
                                                       "paclcodcli," +
                                                       "caclnitcli," +
                                                       "caclsoccli," +
                                                       "faclcntcli," +
                                                       "cacldircli" +
                                                       ") " +
	                             "values (" + 
                                          "@caclestcli," +
                                          "@caclnumcel," +
                                          "@paclcodcli," +
                                          "@caclnitcli," +
                                          "@caclsoccli," +
                                          "@faclcntcli," +
                                          "@cacldircli" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@caclestcli",this._caclestcli);
                    this.Conexion.AsignarParametroCadena("@caclnumcel",this._caclnumcel);
                    this.Conexion.AsignarParametroCadena("@paclcodcli",this._paclcodcli);
                    this.Conexion.AsignarParametroCadena("@caclnitcli",this._caclnitcli);
                    this.Conexion.AsignarParametroCadena("@caclsoccli",this._caclsoccli);
                    this.Conexion.AsignarParametroCadena("@faclcntcli",this._faclcntcli);
                    this.Conexion.AsignarParametroCadena("@cacldircli",this._cacldircli);

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
			        string sql = "update aclient set " +
                                                     "caclestcli = @caclestcli, " +
                                                     "caclnumcel = @caclnumcel, " +
                                                     "caclnitcli = @caclnitcli, " +
                                                     "caclsoccli = @caclsoccli, " +
                                                     "faclcntcli = @faclcntcli, " +
                                                     "cacldircli = @cacldircli" +
                                 " where " +
                                        "paclcodcli = @paclcodcli";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@caclestcli",this._caclestcli);
                    this.Conexion.AsignarParametroCadena("@caclnumcel",this._caclnumcel);
                    this.Conexion.AsignarParametroCadena("@paclcodcli",this._paclcodcli);
                    this.Conexion.AsignarParametroCadena("@caclnitcli",this._caclnitcli);
                    this.Conexion.AsignarParametroCadena("@caclsoccli",this._caclsoccli);
                    this.Conexion.AsignarParametroCadena("@faclcntcli",this._faclcntcli);
                    this.Conexion.AsignarParametroCadena("@cacldircli",this._cacldircli);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aclient> Lista(string where)
            { 
                List<aclient> ListaResultado = new List<aclient>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "caclestcli," +
                                     "caclnumcel," +
                                     "paclcodcli," +
                                     "caclnitcli," +
                                     "caclsoccli," +
                                     "faclcntcli," +
                                     "cacldircli " + 
                             "from aclient " ;
 
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
                          aclient Auxiliar = new aclient();
                          Auxiliar.caclestcli = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.caclnumcel = ResultadoConsulta.GetString(1);
                          Auxiliar.paclcodcli = ResultadoConsulta.GetString(2);
                          Auxiliar.caclnitcli = ResultadoConsulta.GetString(3);
                          Auxiliar.caclsoccli = ResultadoConsulta.GetString(4);
                          Auxiliar.faclcntcli = ResultadoConsulta.GetString(5);
                          Auxiliar.cacldircli = ResultadoConsulta.GetString(6);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

