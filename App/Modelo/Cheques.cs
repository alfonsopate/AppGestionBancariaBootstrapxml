using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Modelo
{
    public class Cheques : Cuentas
    {
        #region "atributos"
        private string idTalonario;
        private static int count = 0;
        private static int numeroTransaciones = 3;
        #endregion

        #region "Propiedades"
        public string IdTalonario
        {
            get { return idTalonario; }
            set { idTalonario = value; }
        }
        #endregion

        #region "Constrctores"

        ///<summary>
        ///Contructor por defecto  de Cuenta Cheques
        ///</summary>
        ///
        public Cheques()
        {
            this.idTalonario = "...";
        }

        public Cheques(string cliente, string identificacion, string idcliente, double balance, string idTalonario)
            : base(cliente, identificacion, idcliente, balance)
        {
            this.idTalonario = idTalonario;
        }

        #endregion

        #region "Metodos Sobre Escritos"

        public override string ToString()
        {
            return base.ToString() +
                   "ID talonario: " + this.idTalonario;
        }
        public override bool Equals(object obj)
        {
            Cheques o = (Cheques)obj;
            bool result = false;

            if (base.Equals(o) &&
               (this.idTalonario == o.idTalonario))
                result = true;

            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string depositar(double valor)
        {
            return "\nA este tipo de cuenta no se le permiten retiro";
        }
        public override string retitar(double valor)
        {
            this.Balance = this.Balance - valor;

            return balanceActual(valor, 'R');
        }

        public override string balanceActual(double valor, char movimiento)
        {
            string result = "";

            switch (movimiento)
            {
                case 'R':
                    result = "\n=======Movimiento Actual======"
                    + "\nFecha: " + DateTime.Now.ToShortDateString()
                    + "\nHora: " + DateTime.Now.ToShortTimeString()
                    + "\nRetiro por Valor : " + valor
                    + "\nBalanca actual: " + this.Balance;
                    break;
                default:
                    result = "\n=======Movimiento Actual======"
                    + "\nFecha: " + DateTime.Now.ToShortDateString()
                    + "\nHora: " + DateTime.Now.ToShortTimeString()
                    + "\nBalanca actual: " + this.Balance;
                    break;

            }


            return result;
        }
        #endregion
    }
    
}