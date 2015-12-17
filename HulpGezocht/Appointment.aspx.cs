using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HulpGezocht
{
    public partial class Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbAfspraken.Items.Add("henk");
        }

        public void btnBevestig_Click(object sender, EventArgs e)
        {

        }

        public void btnVerwijder_Click(object sender, EventArgs e)
        {
            
        }
}
}