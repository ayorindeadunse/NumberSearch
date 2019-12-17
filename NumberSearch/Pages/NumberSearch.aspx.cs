using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NumberSearch.DATA;
using NumberSearch.Repository;

namespace NumberSearch.Pages
{
    public partial class NumberSearch : System.Web.UI.Page
    {
        ICN_NumberSearchEntities icn = new ICN_NumberSearchEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Models.SerachResult rs1;
            Models.SerachResult rst;
            string operatorname = null;
            string Str = null;
            string str1 = null;
            string str2 = null;
            try
            {
                List<vw_NumbersAndOperators> numberList;
                string search = (HttpUtility.HtmlEncode(txtSearch.Text)).Trim();

                //Take into account that Excel crops out first 0 digit and renders phone number in format 80XXXXXXXX or 81XXXXXXXX

                        //return digits with zero stripped from it and append 234 for an effective search.
                if (search.Length == 11)
                {
                    str1 = search.Substring(1, 10);
                    //append 234 to str1 for the search query
                    str2 = "234" + str1;
                

                numberList = new SearchRepository().getNumber(str2);
                List<vw_NumbersAndOperators> numbList = new SearchRepository().getSingleNumber(str2);
                var ls = numberList.FirstOrDefault();

                if (ls == null)
                {
                    //Retrieve code point for appropriate network


                    //throw an error if the value from the textbox is not in number format.
                    Str = str2;

                    long Num;

                    bool isNum = long.TryParse(Str, out Num);

                    //Check if the first three numbers equal 234

                    if (isNum && Str.Length == 13)
                    {
                        // if (search.Substring(0, 3).CompareTo("234"))
                        {

                            string codepoint = "0" + Str.Substring(3, 3);
                            //run queries to retrieve the original status of the phone numbers.
                            //retrieve the Operator ID
                            var pointnumber = from o in icn.CodePoints where o.point_number == codepoint select o;
                            foreach (var pointnumbers in pointnumber)
                            {
                                operatorname = pointnumbers.OperatorName;

                            }

                            //If the record set is null

                            if (operatorname == null)
                            {
                                rst = new Models.SerachResult();
                                rst.Number = search;
                                rst.description = search + "  " + "is not currently associated with any Network.";


                                List<Models.SerachResult> portnotexists = new List<Models.SerachResult>();
                                portnotexists.Add(rst);

                                grvNumberSearch.DataSource = portnotexists;
                                grvNumberSearch.DataBind();
                                grvNumberSearch.Visible = true;
                                formatErro.Visible = false;
                            }

                            else
                            {

                                rst = new Models.SerachResult();
                                rst.Number = search;
                                rst.description = operatorname;

                                List<Models.SerachResult> errorlog = new List<Models.SerachResult>();
                                errorlog.Add(rst);

                                grvNumberSearch.DataSource = errorlog;
                                grvNumberSearch.DataBind();
                                grvNumberSearch.Visible = true;
                                formatErro.Visible = false;
                            }
                        }
                    }

                    else if ((!isNum && Str.Length != 11))
                    {

                        formatErro.Text = "You have not entered valid characters, please try again";
                        formatErro.Visible = true;

                        grvNumberSearch.Visible = false;

                    }
                }

                      else
                {
                    //var ls = numberList.FirstOrDefault();

                    rst = new Models.SerachResult()

                       {
                           Number = "0"+ls.Number.Substring(3,10),
                           description = ls.description



                       };

                   // string finalnumber = ls.Number.Substring(3, 10);
                   // Number = finalnumber;

                    List<Models.SerachResult> result = new List<Models.SerachResult>();
                    result.Add(rst);

                    grvNumberSearch.DataSource = result;
                    grvNumberSearch.DataBind();
                    grvNumberSearch.Visible = true;
                    formatErro.Visible = false;
                }
                }
                     else 
                {
                    formatErro.Text = "Please ensure the phone number is 11 characters.";
                    formatErro.Visible = true;
                    grvNumberSearch.Visible = false;

                }
                   
            
               
                /*else if (isNum && Str.Length != 11)
                {

                    //show error message label.
                    formatErro.Text = "Please ensure that the phone number is 13 characters.";
                    formatErro.Visible = true;
                    grvNumberSearch.Visible = false;


                }*/

               
                    //throw an error if the result set does not exist.

    //Else display ported phone number information.               

                

              

            }
    
            catch (Exception ex)
            {

            }

        }

       
    }
}