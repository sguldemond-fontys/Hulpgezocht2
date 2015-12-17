using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HulpGezocht
{
    public partial class Profile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            HyperlinkReport.NavigateUrl = "Report";
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Profiel bewerken")
            {
                tbPhoneNumber.ReadOnly = false;
                tbBio.ReadOnly = false;

                lblProfilePicUpload.Visible = true;
                fileuploadProfilePicUpload.Enabled = true;
                fileuploadProfilePicUpload.Visible = true;

                lblVOG.Visible = true;
                fileuploadVOG.Enabled = true;
                fileuploadVOG.Visible = true;

                chckDriversLicense.Enabled = true;

                ValidatorBio.Enabled = true;
                ValidatorPhoneNumber.Enabled = true;
                ValidatorProfilePic.Enabled = true;
                ValidatorVOG.Enabled = true;

                btnEdit.Text = "Opslaan";
            }
            else
            {
                tbPhoneNumber.ReadOnly = true;
                tbBio.ReadOnly = true;

                lblProfilePicUpload.Visible = false;
                fileuploadProfilePicUpload.Enabled = false;
                fileuploadProfilePicUpload.Visible = false;

                lblVOG.Visible = false;
                fileuploadVOG.Enabled = false;
                fileuploadVOG.Visible = false;

                chckDriversLicense.Enabled = false;

                ValidatorBio.Enabled = false;
                ValidatorPhoneNumber.Enabled = false;
                ValidatorProfilePic.Enabled = false;
                ValidatorVOG.Enabled = false;

                btnEdit.Text = "Profiel bewerken";
            }
            
        }

        public void btnRecensie_Click(object sender, EventArgs e)
        {
            
        }

        public void btnAfspraak_Click(object sender, EventArgs e)
        {

        }

        public void btnChat_Click(object sender, EventArgs e)
        {

        }

        public void btnVOG_Click(object sender, EventArgs e)
        {

        }
    }
}