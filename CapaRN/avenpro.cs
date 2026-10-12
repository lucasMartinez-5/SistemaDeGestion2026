using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class avenpro {

		#region Campos
            private decimal _cavpmontot;
            private bool _cavpestven;
            private DateTime _cavpfechor;
            private DateTime _cavpfeccre;
            private DateTime _cavpfecmod;
            private string _favpcodcli;
            private string _cavpobsven;
            private string _favpusucre;
            private string _favpusumod;
            private string _pavpcodven;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public decimal cavpmontot
            { 
                get{ return this._cavpmontot;}
                set{ this._cavpmontot = value;}
            } 
		    public bool cavpestven
            { 
                get{ return this._cavpestven;}
                set{ this._cavpestven = value;}
            } 
		    public DateTime cavpfechor
            { 
                get{ return this._cavpfechor;}
                set{ this._cavpfechor = value;}
            } 
		    public DateTime cavpfeccre
            { 
                get{ return this._cavpfeccre;}
                set{ this._cavpfeccre = value;}
            } 
		    public DateTime cavpfecmod
            { 
                get{ return this._cavpfecmod;}
                set{ this._cavpfecmod = value;}
            } 
		    public string favpcodcli
            { 
                get{ return this._favpcodcli;}
                set{ this._favpcodcli = value;}
            } 
		    public string cavpobsven
            { 
                get{ return this._cavpobsven;}
                set{ this._cavpobsven = value;}
            } 
		    public string favpusucre
            { 
                get{ return this._favpusucre;}
                set{ this._favpusucre = value;}
            } 
		    public string favpusumod
            { 
                get{ return this._favpusumod;}
                set{ this._favpusumod = value;}
            } 
		    public string pavpcodven
            { 
                get{ return this._pavpcodven;}
                set{ this._pavpcodven = value;}
            } 
        #endregion

        #region Constructor
            public avenpro()
            { 
		        this._cavpmontot = 0;
		        this._cavpestven = true;
		        this._cavpfechor = DateTime.Now;
		        this._cavpfeccre = DateTime.Now;
		        this._cavpfecmod = DateTime.Now;
		        this._favpcodcli = "";
		        this._cavpobsven = "";
		        this._favpusucre = "";
		        this._favpusumod = "";
		        this._pavpcodven = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "cavpmontot," +
                                     "cavpestven," +
                                     "cavpfechor," +
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "favpcodcli," +
                                     "cavpobsven," +
                                     "favpusucre," +
                                     "favpusumod," +
                                     "pavpcodven " + 
                             "from avenpro " +
                             "where "+
                                    "pavpcodven = @pavpcodven";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._cavpmontot=ResultadoConsulta.GetDecimal(0);
                    this._cavpestven=ResultadoConsulta.GetBoolean(1);
                    this._cavpfechor=ResultadoConsulta.GetDateTime(2);
                    this._cavpfeccre=ResultadoConsulta.GetDateTime(3);
                    this._cavpfecmod=ResultadoConsulta.GetDateTime(4);
                    this._favpcodcli=ResultadoConsulta.GetString(5);
                    this._cavpobsven=ResultadoConsulta.GetString(6);
                    this._favpusucre=ResultadoConsulta.GetString(7);
                    this._favpusumod=ResultadoConsulta.GetString(8);
                    this._pavpcodven=ResultadoConsulta.GetString(9);
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
                                     "cavpmontot," +
                                     "cavpestven," +
                                     "cavpfechor," +
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "favpcodcli," +
                                     "cavpobsven," +
                                     "favpusucre," +
                                     "favpusumod," +
                                     "pavpcodven " + 
                             "from avenpro " +
                             "where " +
                                    "pavpcodven = @pavpcodven";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

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
			        string sql = "insert into avenpro (" +
                                                       "cavpmontot," +
                                                       "cavpestven," +
                                                       "cavpfechor," +
                                                       "cavpfeccre," +
                                                       "cavpfecmod," +
                                                       "favpcodcli," +
                                                       "cavpobsven," +
                                                       "favpusucre," +
                                                       "favpusumod," +
                                                       "pavpcodven" +
                                                       ") " +
	                             "values (" + 
                                          "@cavpmontot," +
                                          "@cavpestven," +
                                          "@cavpfechor," +
                                          "@cavpfeccre," +
                                          "@cavpfecmod," +
                                          "@favpcodcli," +
                                          "@cavpobsven," +
                                          "@favpusucre," +
                                          "@favpusumod," +
                                          "@pavpcodven" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroDecimal("@cavpmontot",this._cavpmontot);
                    this.Conexion.AsignarParametroLogico("@cavpestven",this._cavpestven);
                    this.Conexion.AsignarParametroFechaHora("@cavpfechor",this._cavpfechor);
                    this.Conexion.AsignarParametroFechaHora("@cavpfeccre",this._cavpfeccre);
                    this.Conexion.AsignarParametroFechaHora("@cavpfecmod",this._cavpfecmod);
                    this.Conexion.AsignarParametroCadena("@favpcodcli",this._favpcodcli);
                    this.Conexion.AsignarParametroCadena("@cavpobsven",this._cavpobsven);
                    this.Conexion.AsignarParametroCadena("@favpusucre",this._favpusucre);
                    this.Conexion.AsignarParametroCadena("@favpusumod",this._favpusumod);
                    this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

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
			        string sql = "update avenpro set " +
                                                     "cavpmontot = @cavpmontot, " +
                                                     "cavpestven = @cavpestven, " +
                                                     "cavpfechor = @cavpfechor, " +
                                                     "cavpfeccre = @cavpfeccre, " +
                                                     "cavpfecmod = @cavpfecmod, " +
                                                     "favpcodcli = @favpcodcli, " +
                                                     "cavpobsven = @cavpobsven, " +
                                                     "favpusucre = @favpusucre, " +
                                                     "favpusumod = @favpusumod" +
                                 " where " +
                                        "pavpcodven = @pavpcodven";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroDecimal("@cavpmontot",this._cavpmontot);
                    this.Conexion.AsignarParametroLogico("@cavpestven",this._cavpestven);
                    this.Conexion.AsignarParametroFechaHora("@cavpfechor",this._cavpfechor);
                    this.Conexion.AsignarParametroFechaHora("@cavpfeccre",this._cavpfeccre);
                    this.Conexion.AsignarParametroFechaHora("@cavpfecmod",this._cavpfecmod);
                    this.Conexion.AsignarParametroCadena("@favpcodcli",this._favpcodcli);
                    this.Conexion.AsignarParametroCadena("@cavpobsven",this._cavpobsven);
                    this.Conexion.AsignarParametroCadena("@favpusucre",this._favpusucre);
                    this.Conexion.AsignarParametroCadena("@favpusumod",this._favpusumod);
                    this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<avenpro> Lista(string where)
            { 
                List<avenpro> ListaResultado = new List<avenpro>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "cavpmontot," +
                                     "cavpestven," +
                                     "cavpfechor," +
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "favpcodcli," +
                                     "cavpobsven," +
                                     "favpusucre," +
                                     "favpusumod," +
                                     "pavpcodven " + 
                             "from avenpro " ;
 
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
                          avenpro Auxiliar = new avenpro();
                          Auxiliar.cavpmontot = ResultadoConsulta.GetDecimal(0);
                          Auxiliar.cavpestven = ResultadoConsulta.GetBoolean(1);
                          Auxiliar.cavpfechor = ResultadoConsulta.GetDateTime(2);
                          Auxiliar.cavpfeccre = ResultadoConsulta.GetDateTime(3);
                          Auxiliar.cavpfecmod = ResultadoConsulta.GetDateTime(4);
                          Auxiliar.favpcodcli = ResultadoConsulta.GetString(5);
                          Auxiliar.cavpobsven = ResultadoConsulta.GetString(6);
                          Auxiliar.favpusucre = ResultadoConsulta.GetString(7);
                          Auxiliar.favpusumod = ResultadoConsulta.GetString(8);
                          Auxiliar.pavpcodven = ResultadoConsulta.GetString(9);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

