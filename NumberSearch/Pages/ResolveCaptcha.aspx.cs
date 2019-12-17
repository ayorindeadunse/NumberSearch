using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NumberSearch.Pages
{
    public partial class ResolveCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             captcha1.ValidateCaptcha(TextBox1.Text.Trim());
        if (captcha1.UserValidated)
        {
          Label1.ForeColor = System.Drawing.Color.Green;
          Label1.Text = "You have Entered Valid Captcha Characters";
          Label1.Visible = true;
          Button1.Visible = false;
          siteLinkButton.Visible = true;
        }
        else
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "You have Entered InValid Captcha Characters. Please try again";
            Label1.Visible = true;
        }
    }
        }
    }
