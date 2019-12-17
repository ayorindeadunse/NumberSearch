using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NumberSearch.DATA;




namespace NumberSearch.Repository
{
    public class SearchRepository
    {
        public List<vw_NumbersAndOperators> getNumber(string number)
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    string search = HttpUtility.HtmlDecode(number);
                    var query = ctx.vw_NumbersAndOperators.Where(v => v.Number.Equals(search));
                    return query.ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

       
        public List<vw_NumbersAndOperators> getSingleNumber(string number)
        {
            try
            {
                using (ICN_NumberSearchEntities ctx = new ICN_NumberSearchEntities())
                {
                    string search = HttpUtility.HtmlDecode(number);
                    var query = ctx.vw_NumbersAndOperators.Where(v => v.Number.Equals(search)).OrderByDescending(w => w.NumberID).FirstOrDefault();
                    List<vw_NumbersAndOperators> nList = new List<vw_NumbersAndOperators>();
                    if (query != null)
                    {
                        nList.Add(query);
                    }
                        //new List<vw_NumbersAndOperators>(new vw_NumbersAndOperators
                        //{
                        //    NumberID = query.NumberID,
                        //    Name = query.Name,
                        //    Number = query.Number,
                        //    NumberOperatorID = query.NumberOperatorID,
                        //    OperatorID = query.OperatorID
                        //});
                    return nList;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
    }
}