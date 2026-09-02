using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class lclient
    {
        #region Campos
        private bool _caclestcli;
        private string _caclnumcel;
        private string _paclcodcli;
        private string _caclnitcli;
        private string _caclsoccli;
        private string _faclcntcli;
        private string _cacldircli;

        private DateTime _capsfecnac;
        private bool _capssexper;
        private bool _capsestper;
        private string _capsapemat;
        private string _capsnomper;
        private string _capsnumcel;
        private string _capscorele;
        private string _capsdirper;
        private string _papscodper;
        private string _capsfotper;
        private string _capsnumcid;
        private string _capsapepat;
        //Instancia para conexion a PostgreSQL 8.2
        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public bool caclestcli
        {
            get { return this._caclestcli; }
            set { this._caclestcli = value; }
        }
        public string caclnumcel
        {
            get { return this._caclnumcel; }
            set { this._caclnumcel = value; }
        }
        public string paclcodcli
        {
            get { return this._paclcodcli; }
            set { this._paclcodcli = value; }
        }
        public string caclnitcli
        {
            get { return this._caclnitcli; }
            set { this._caclnitcli = value; }
        }
        public string caclsoccli
        {
            get { return this._caclsoccli; }
            set { this._caclsoccli = value; }
        }
        public string faclcntcli
        {
            get { return this._faclcntcli; }
            set { this._faclcntcli = value; }
        }
        public string cacldircli
        {
            get { return this._cacldircli; }
            set { this._cacldircli = value; }
        }

        public DateTime capsfecnac
        {
            get { return this._capsfecnac; }
            set { this._capsfecnac = value; }
        }
        public bool capssexper
        {
            get { return this._capssexper; }
            set { this._capssexper = value; }
        }
        public bool capsestper
        {
            get { return this._capsestper; }
            set { this._capsestper = value; }
        }
        public string capsapemat
        {
            get { return this._capsapemat; }
            set { this._capsapemat = value; }
        }
        public string capsnomper
        {
            get { return this._capsnomper; }
            set { this._capsnomper = value; }
        }
        public string capsnumcel
        {
            get { return this._capsnumcel; }
            set { this._capsnumcel = value; }
        }
        public string capscorele
        {
            get { return this._capscorele; }
            set { this._capscorele = value; }
        }
        public string capsdirper
        {
            get { return this._capsdirper; }
            set { this._capsdirper = value; }
        }
        public string papscodper
        {
            get { return this._papscodper; }
            set { this._papscodper = value; }
        }
        public string capsfotper
        {
            get { return this._capsfotper; }
            set { this._capsfotper = value; }
        }
        public string capsnumcid
        {
            get { return this._capsnumcid; }
            set { this._capsnumcid = value; }
        }
        public string capsapepat
        {
            get { return this._capsapepat; }
            set { this._capsapepat = value; }
        }
        #endregion

        #region Constructor
        public lclient()
        {
            this._caclestcli = true;
            this._caclnumcel = "";
            this._paclcodcli = "";
            this._caclnitcli = "";
            this._caclsoccli = "";
            this._faclcntcli = "";
            this._cacldircli = "";
            this.Conexion = new CLConexionPGSQL();
        }
        #endregion

        #region Metodos
        public List<lclient> Lista(string where)
        {
            List<lclient> ListaResultado = new List<lclient>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caclestcli," +
                                 "caclnumcel," +
                                 "paclcodcli," +
                                 "caclnitcli," +
                                 "caclsoccli," +
                                 "faclcntcli," +
                                 "cacldircli, " +
                                 "capsfecnac," +
                                 "capssexper," +
                                 "capsestper," +
                                 "capsapemat," +
                                 "capsnomper," +
                                 "capsnumcel," +
                                 "capscorele," +
                                 "capsdirper," +
                                 "papscodper," +
                                 "capsfotper," +
                                 "capsnumcid," +
                                 "capsapepat " +
                         "from aclient,aperson " +
                         "where papscodper=faclcntcli ";

            if (where.Replace(" ", "") != "")
            {
                sql += "and " + where;
            }


            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    lclient Auxiliar = new lclient();
                    Auxiliar.caclestcli = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.caclnumcel = ResultadoConsulta.GetString(1);
                    Auxiliar.paclcodcli = ResultadoConsulta.GetString(2);
                    Auxiliar.caclnitcli = ResultadoConsulta.GetString(3);
                    Auxiliar.caclsoccli = ResultadoConsulta.GetString(4);
                    Auxiliar.faclcntcli = ResultadoConsulta.GetString(5);
                    Auxiliar.cacldircli = ResultadoConsulta.GetString(6);
                    Auxiliar.capsfecnac = ResultadoConsulta.GetDateTime(7);
                    Auxiliar.capssexper = ResultadoConsulta.GetBoolean(8);
                    Auxiliar.capsestper = ResultadoConsulta.GetBoolean(9);
                    Auxiliar.capsapemat = ResultadoConsulta.GetString(10);
                    Auxiliar.capsnomper = ResultadoConsulta.GetString(11);
                    Auxiliar.capsnumcel = ResultadoConsulta.GetString(12);
                    Auxiliar.capscorele = ResultadoConsulta.GetString(13);
                    Auxiliar.capsdirper = ResultadoConsulta.GetString(14);
                    Auxiliar.papscodper = ResultadoConsulta.GetString(15);
                    Auxiliar.capsfotper = ResultadoConsulta.GetString(16);
                    Auxiliar.capsnumcid = ResultadoConsulta.GetString(17);
                    Auxiliar.capsapepat = ResultadoConsulta.GetString(18);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        #endregion
    }
}
