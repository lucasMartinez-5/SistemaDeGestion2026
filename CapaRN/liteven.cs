using CapaAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class liteven
    {
        #region Campos
        private decimal _caivpreuni;
        private bool _caivestite;
        private int _caivcanite;
        private decimal _caivsubtot;
        private string _faivcodpro;
        private string _faivcodven;
        private string _paivcodite;
        private string _capdmodpro;
        private string _capdcodbar;
        private string _capdnompro;
        private string _capdtalpro;
        private string _capddespro;
        //Instancia para conexion a PostgreSQL 8.2
        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public decimal caivpreuni
        {
            get { return this._caivpreuni; }
            set { this._caivpreuni = value; }
        }
        public bool caivestite
        {
            get { return this._caivestite; }
            set { this._caivestite = value; }
        }
        public int caivcanite
        {
            get { return this._caivcanite; }
            set { this._caivcanite = value; }
        }
        public decimal caivsubtot
        {
            get { return this._caivsubtot; }
            set { this._caivsubtot = value; }
        }
        public string faivcodpro
        {
            get { return this._faivcodpro; }
            set { this._faivcodpro = value; }
        }
        public string faivcodven
        {
            get { return this._faivcodven; }
            set { this._faivcodven = value; }
        }
        public string paivcodite
        {
            get { return this._paivcodite; }
            set { this._paivcodite = value; }
        }
        public string capdmodpro
        {
            get { return this._capdmodpro; }
            set { this._capdmodpro = value; }
        }
        public string capdcodbar
        {
            get { return this._capdcodbar; }
            set { this._capdcodbar = value; }
        }
        public string capdnompro
        {
            get { return this._capdnompro; }
            set { this._capdnompro = value; }
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
        #endregion

        #region Constructor
        public liteven()
        {
            this._caivpreuni = 0;
            this._caivestite = true;
            this._caivcanite = 0;
            this._caivsubtot = 0;
            this._faivcodpro = "";
            this._faivcodven = "";
            this._paivcodite = "";

            this._capdmodpro = "";
            this._capdcodbar = "";
            this._capdnompro = "";
            this._capdtalpro = "";
            this._capddespro = "";
            this.Conexion = new CLConexionPGSQL();
        }
        #endregion


    }
}
