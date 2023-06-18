using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LAB_RAMEN.Model;
using LAB_RAMEN.Dataset;
using LAB_RAMEN.Repository;
using LAB_RAMEN.Report;

namespace LAB_RAMEN.View.Admin
{
    public partial class AdminTransactionReport : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseRamenEntities1 db = DBSingleton.GetInstance();
            CrystalReport2 report = new CrystalReport2();
            DataSet2 data = GetData(db.Headers.ToList());
            crystalReport.ReportSource = report;
            report.SetDataSource(data);
        }

        public DataSet2 GetData(List<Header> hd)
        {
            DataSet2 data = new DataSet2();
            var header = data.Header;
            var detail = data.Detail;
            var incometable = data.income;
            decimal totalIncome = 0;
            foreach(var h in hd)
            {
                decimal subtotal = 0;
                var headerRow = header.NewRow();
                headerRow["id"] = h.id;
                headerRow["CustomerID"] = h.CustomerID;
                headerRow["StaffID"] = h.StaffID;
                headerRow["Date"] = h.Date;
                header.Rows.Add(headerRow);
                foreach(var hs in h.Details)
                {
                    var detailRow = detail.NewRow();
                    detailRow["HeaderID"] = hs.HeaderID;
                    detailRow["RamenID"] = hs.RamenID;
                    detailRow["Quantity"] = hs.Quantity;
                    detailRow["subTotal"] = hs.Quantity * int.Parse(hs.Raman.Price);
                    detail.Rows.Add(detailRow);

                    decimal price = AdminRepository.GetRamenPrice(hs.RamenID);
                    subtotal += hs.Quantity * int.Parse(hs.Raman.Price);
                }

                headerRow["Total"] = subtotal;

                totalIncome += subtotal;
            }
            var jrow = incometable.NewRow();
            jrow["grandIncome"] = totalIncome;
            incometable.Rows.Add(jrow);

            return data;
        }
    }
}