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
        private string _caclrazcli;
        private string _paclcodcli;
        private string _cacldircli;
        private string _cacltelcli;
        private string _faclcodper;
        private string _caclnitcli;
        //Instancia para conexion a PostgreSQL 8.2
        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public bool caclestcli
        {
            get { return this._caclestcli; }
            set { this._caclestcli = value; }
        }
        public string caclrazcli
        {
            get { return this._caclrazcli; }
            set { this._caclrazcli = value; }
        }
        public string paclcodcli
        {
            get { return this._paclcodcli; }
            set { this._paclcodcli = value; }
        }
        public string cacldircli
        {
            get { return this._cacldircli; }
            set { this._cacldircli = value; }
        }
        public string cacltelcli
        {
            get { return this._cacltelcli; }
            set { this._cacltelcli = value; }
        }
        public string faclcodper
        {
            get { return this._faclcodper; }
            set { this._faclcodper = value; }
        }
        public string caclnitcli
        {
            get { return this._caclnitcli; }
            set { this._caclnitcli = value; }
        }
        #endregion

        #region Constructor
        public aclient()
            {
            this._caclestcli = true;
            this._caclrazcli = "";
            this._paclcodcli = "";
            this._cacldircli = "";
            this._cacltelcli = "";
            this._faclcodper = "";
            this._caclnitcli = "";
            this.Conexion = new CLConexionPGSQL();            }
        #endregion

        #region Metodos
        public bool ObtenerDatos()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caclestcli," +
                                 "caclrazcli," +
                                 "paclcodcli," +
                                 "cacldircli," +
                                 "cacltelcli," +
                                 "faclcodper," +
                                 "caclnitcli " +
                         "from aclient " +
                         "where " +
                                "paclcodcli = @paclcodcli";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@paclcodcli", this._paclcodcli);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._caclestcli = ResultadoConsulta.GetBoolean(0);
                this._caclrazcli = ResultadoConsulta.GetString(1);
                this._paclcodcli = ResultadoConsulta.GetString(2);
                this._cacldircli = ResultadoConsulta.GetString(3);
                this._cacltelcli = ResultadoConsulta.GetString(4);
                this._faclcodper = ResultadoConsulta.GetString(5);
                this._caclnitcli = ResultadoConsulta.GetString(6);
                this.Conexion.Desconectar();

                return true;
            }
            else
            {
                this.Conexion.Desconectar();
                return false;
            }
        }

        public bool ObtenerDatosNIT()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caclestcli," +
                                 "caclrazcli," +
                                 "paclcodcli," +
                                 "cacldircli," +
                                 "cacltelcli," +
                                 "faclcodper," +
                                 "caclnitcli " +
                         "from aclient " +
                         "where " +
                                "caclnitcli = @caclnitcli and caclestcli = true";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@caclnitcli", this._caclnitcli);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._caclestcli = ResultadoConsulta.GetBoolean(0);
                this._caclrazcli = ResultadoConsulta.GetString(1);
                this._paclcodcli = ResultadoConsulta.GetString(2);
                this._cacldircli = ResultadoConsulta.GetString(3);
                this._cacltelcli = ResultadoConsulta.GetString(4);
                this._faclcodper = ResultadoConsulta.GetString(5);
                this._caclnitcli = ResultadoConsulta.GetString(6);
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
                                 "caclrazcli," +
                                 "paclcodcli," +
                                 "cacldircli," +
                                 "cacltelcli," +
                                 "faclcodper," +
                                 "caclnitcli " +
                         "from aclient " +
                         "where " +
                                "paclcodcli = @paclcodcli";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@paclcodcli", this._paclcodcli);

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
                                                   "caclrazcli," +
                                                   "paclcodcli," +
                                                   "cacldircli," +
                                                   "cacltelcli," +
                                                   "faclcodper," +
                                                   "caclnitcli" +
                                                   ") " +
                             "values (" +
                                      "@caclestcli," +
                                      "@caclrazcli," +
                                      "@paclcodcli," +
                                      "@cacldircli," +
                                      "@cacltelcli," +
                                      "@faclcodper," +
                                      "@caclnitcli" +
                                                   ")";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroLogico("@caclestcli", this._caclestcli);
                this.Conexion.AsignarParametroCadena("@caclrazcli", this._caclrazcli);
                this.Conexion.AsignarParametroCadena("@paclcodcli", this._paclcodcli);
                this.Conexion.AsignarParametroCadena("@cacldircli", this._cacldircli);
                this.Conexion.AsignarParametroCadena("@cacltelcli", this._cacltelcli);
                this.Conexion.AsignarParametroCadena("@faclcodper", this._faclcodper);
                this.Conexion.AsignarParametroCadena("@caclnitcli", this._caclnitcli);

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
                                                 "caclrazcli = @caclrazcli, " +
                                                 "cacldircli = @cacldircli, " +
                                                 "cacltelcli = @cacltelcli, " +
                                                 "faclcodper = @faclcodper, " +
                                                 "caclnitcli = @caclnitcli" +
                             " where " +
                                    "paclcodcli = @paclcodcli";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroLogico("@caclestcli", this._caclestcli);
                this.Conexion.AsignarParametroCadena("@caclrazcli", this._caclrazcli);
                this.Conexion.AsignarParametroCadena("@paclcodcli", this._paclcodcli);
                this.Conexion.AsignarParametroCadena("@cacldircli", this._cacldircli);
                this.Conexion.AsignarParametroCadena("@cacltelcli", this._cacltelcli);
                this.Conexion.AsignarParametroCadena("@faclcodper", this._faclcodper);
                this.Conexion.AsignarParametroCadena("@caclnitcli", this._caclnitcli);

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
                                 "caclrazcli," +
                                 "paclcodcli," +
                                 "cacldircli," +
                                 "cacltelcli," +
                                 "faclcodper," +
                                 "caclnitcli " +
                         "from aclient ";

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
                    aclient Auxiliar = new aclient();
                    Auxiliar.caclestcli = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.caclrazcli = ResultadoConsulta.GetString(1);
                    Auxiliar.paclcodcli = ResultadoConsulta.GetString(2);
                    Auxiliar.cacldircli = ResultadoConsulta.GetString(3);
                    Auxiliar.cacltelcli = ResultadoConsulta.GetString(4);
                    Auxiliar.faclcodper = ResultadoConsulta.GetString(5);
                    Auxiliar.caclnitcli = ResultadoConsulta.GetString(6);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        #endregion
    }
}

