using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HulpGezocht
{
    public partial class TopicDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Reply> list = new List<Reply>();
            list.Add(new Reply("1", "stan"));
            list.Add(new Reply("2", "max"));

            gvReplies.DataSource = list;
            gvReplies.DataBind();
        }

        protected void gvReplies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Reply
    {
        public string Naam;
        public string Datum;

        public Reply(string datum, string naam)
        {
            Naam = naam;
            Datum = datum;
        }
    }
}