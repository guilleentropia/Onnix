<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
     protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void ShowReport()
        {
            ReportViewer1.Reset();

            DataTable dt = GetData(456789);
            ReportDataSource rdc = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rdc);


            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");

            ReportParameter[] par = new ReportParameter[] { new ReportParameter("ReportParameter1", (TextBox1.Text)) };

            ReportViewer1.LocalReport.SetParameters(par);

            ReportViewer1.LocalReport.Refresh();


        }

        private DataTable GetData(int numerofactura)
        {
            DataTable dt = new DataTable();
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ProyectoFinal"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("ObtenerFactura", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@numerofactura", SqlDbType.Int).Value = numerofactura;

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);


            }
            return dt;
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server"  Text="Button" />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
