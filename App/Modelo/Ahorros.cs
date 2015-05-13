using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Modelo
{
    public class Ahorros: Cuentas
    {
        #region "Atributos"
        private float tasaInteres;
        private static int count = 0;
        private static int numeroTransaciones = 3;
        #endregion

        #region "Propiedades"

        public float Tasadeinteres
        {
            get { return tasaInteres; }
            set { tasaInteres = value; }
        }
        #endregion

        #region"Constructores"

        ///<summary>
        ///Contructor por defecto  de Cuenta de Ahorros
        ///</summary>
        ///
        public Ahorros():base()
        {
            this.tasaInteres = 0;
        }

        public Ahorros(string cliente, string identificacion, string idcliente,double balance,float tasadeinteres)
                    :base( cliente,  identificacion,  idcliente, balance)
        {
            this.tasaInteres = tasadeinteres;
        }

        #endregion

        #region "Metodos Sobre Escritos"

        public override string ToString()
        {
            return base.ToString() +
                   "\nTasa de Interes: " + this.tasaInteres;
        }
        public override bool Equals(object obj)
        {
            Ahorros o = (Ahorros)obj;
            bool result = false;

            if ((base.Equals(o)) &&
               (this.tasaInteres == o.tasaInteres))
                result = true;

            return result;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override string depositar(double valor)
        {
            this.Balance+= valor;
            return balanceActual(valor, 'D');
        }
        public override string retitar(double valor)
        {
            count++;
            if (count > numeroTransaciones)
                this.Balance = (this.Balance - (valor + this.tasaInteres));

            else
                this.Balance = this.Balance - valor;


            return balanceActual(valor, 'R');
        }

        public override string balanceActual(double valor, char movimiento)
        {
            string result="";

            switch (movimiento)
            {
                case 'R' : 
                            result = "\n=======Movimiento Actual======"
                            + "\nFecha: " + DateTime.Now.ToShortDateString()
                            + "\nHora: " + DateTime.Now.ToShortTimeString()
                            + "\nRetiro por Valor : " + valor 
                            +"\nBalanca actual: " + this.Balance ;
                            break;
                case 'D':
                            result = "\n=======Movimiento Actual======"
                            + "\nFecha: " + DateTime.Now.ToShortDateString()
                            + "\nHora: " + DateTime.Now.ToShortTimeString()
                            + "\nDeposito por Valor : " + valor
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