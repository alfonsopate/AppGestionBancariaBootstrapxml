using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Modelo
{
    public abstract class Cuentas
    {
        #region "Atributos"
        private string cliente;        
        private string identificacion;        
        private string idcliente;        
        private double balance;
        #endregion

        #region "Propiedades"
        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        public string Idcliente
        {
            get { return idcliente; }
            set { idcliente = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        #endregion

        #region "Constructores"
        public Cuentas()
        {
            ///<summary>
            ///Contructor de Cuentas
            ///</summary>
            this.cliente = "Nombre del Cliente";
            this.identificacion = "Num. de Cuenta";
            this.idcliente = "Num. Cedula";
            this.balance = 0.0;
        }
        ///<summary>
        ///Contructor de inicialización Cuentas
        ///</summary>
        ///<param name="nombre">Nombre del Cliente</param>
        ///<param name="cliente">Numero de cuenta del Cliente</param>
        ///<param name="id">Numero de cedula del Cliente</param>
        ///<param name="monto">Balance actual del Cliente  </param>
        ///
        public Cuentas(string cliente, string identificacion, string idcliente, double balance)
        {
            this.cliente = cliente;
            this.identificacion = identificacion;
            this.idcliente = idcliente;
            this.balance = balance;
        }
        #endregion

        #region "Metodos Sobre Escritos"
        public override string ToString()
        {
            return  "Nombre de la Clase" +
                "\n=============================================" +
                     "\nNombre:  " + this.cliente  +
                     "\nNum Cuenta:  " + this.identificacion  +
                     "\nIdentificacion Cliente: " + this.idcliente  +
                     "\nBalance Actual: " + this.balance;
        }

        public override bool Equals(object obj)
        {
            Cuentas o = (Cuentas)obj;
            bool result = false;

            if ((this.cliente == o.cliente) &&
                (this.identificacion == o.identificacion) &&
                (this.idcliente == o.idcliente) &&
                (this.balance == o.balance))

                result = true;

            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        #endregion

        public abstract string depositar(double valor);

        public abstract string retitar(double valor);

        public abstract string balanceActual(double valor, char movimiento);
    }
}