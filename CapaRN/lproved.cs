using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class lproved
    {
        #region Campos
        private bool _caprestpro;
        private string _caprnumcel;
        private string _paprcodpro;
        private string _caprnitpro;
        private string _caprsocpro;
        private string _faprcntpro;
        private string _caprdirpro;

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
        public bool caprestpro
        {
            get { return this._caprestpro; }
            set { this._caprestpro = value; }
        }
        public string caprnumcel
        {
            get { return this._caprnumcel; }
            set { this._caprnumcel = value; }
        }
        public string paprcodpro
        {
            get { return this._paprcodpro; }
            set { this._paprcodpro = value; }
        }
        public string caprnitpro
        {
            get { return this._caprnitpro; }
            set { this._caprnitpro = value; }
        }
        public string caprsocpro
        {
            get { return this._caprsocpro; }
            set { this._caprsocpro = value; }
        }
        public string faprcntpro
        {
            get { return this._faprcntpro; }
            set { this._faprcntpro = value; }
        }
        public string caprdirpro
        {
            get { return this._caprdirpro; }
            set { this._caprdirpro = value; }
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
        public lproved()
        {
            this._caprestpro = true;
            this._caprnumcel = "";
            this._paprcodpro = "";
            this._caprnitpro = "";
            this._caprsocpro = "";
            this._faprcntpro = "";
            this._caprdirpro = "";
            this.Conexion = new CLConexionPGSQL();
        }
        #endregion

        #region Metodos
        public List<lproved> Lista(string where)
        {
            List<lproved> ListaResultado = new List<lproved>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caprestpro," +
                                 "caprnumcel," +
                                 "paprcodpro," +
                                 "caprnitpro," +
                                 "caprsocpro," +
                                 "faprcntpro," +
                                 "caprdirpro, " +
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
                         "from arpoved,aperson " +
                         "where papscodper=faprcntpro ";

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
                    lproved Auxiliar = new lproved();
                    Auxiliar.caprestpro = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.caprnumcel = ResultadoConsulta.GetString(1);
                    Auxiliar.paprcodpro = ResultadoConsulta.GetString(2);
                    Auxiliar.caprnitpro = ResultadoConsulta.GetString(3);
                    Auxiliar.caprsocpro = ResultadoConsulta.GetString(4);
                    Auxiliar.faprcntpro = ResultadoConsulta.GetString(5);
                    Auxiliar.caprdirpro = ResultadoConsulta.GetString(6);
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
