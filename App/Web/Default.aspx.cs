using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Modelo;

namespace App.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ahorros cuenta1 = new Ahorros("Edwin Puertas","123456789","12",2000000.0,0.2F);
            Label1.Text = cuenta1.ToString().Replace("\n", "</br>") 
                         + cuenta1.depositar(10000).ToString().Replace("\n", "</br>") 
                         + cuenta1.retitar(500000.0).ToString().Replace("\n", "</br>");

        }
    }
}