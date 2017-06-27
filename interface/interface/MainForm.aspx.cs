using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace web_interface
{
	public partial class MainForm : System.Web.UI.Page
	{
        _interface.SQLWebServiceReference1.WebService1SoapClient client = null;
        DataTable terminalsName;
        DataTable report;


		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                GetTerminalsName();
            }
            //GetReport();
		}


        protected void Button1_Click(object sender, EventArgs e)
        {
            GetTerminalsName();
        }

        private void GetTerminalsName()
        {
            client = new _interface.SQLWebServiceReference1.WebService1SoapClient();
            Clear_lbl_exception();
            terminalsName = new DataTable();

            string selectedTerminalName = null;

            if (ddl_terminalView.Items.Count > 1)
            {
                selectedTerminalName = ddl_terminalView.SelectedItem.Text;
            }

            try
            {
                terminalsName = client.GetTerminalsName();
            

            //ddl_terminalView.Items.Capacity = terminalsName.Tables[0].Rows.Count + 1
            
                ddl_terminalView.DataSource = terminalsName;
                ddl_terminalView.DataTextField = "Имя терминала"; // field to display in dropdown
                //ddl_terminalView.DataValueField = "Value Field";
                ddl_terminalView.DataBind();

                ddl_terminalView.Items.Add(ListItem.FromString("Все"));

                
            }
            catch (Exception e)
            {
                lbl_exception.Text = e.Message;
            }

            if ((selectedTerminalName != null) && (ddl_terminalView.Items.Contains(ListItem.FromString(selectedTerminalName))))
            {
                ddl_terminalView.Items.FindByText(selectedTerminalName).Selected = true;
            }
            else
            {
                ddl_terminalView.Items.FindByText("Все").Selected = true;
            }

           
         

        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            GetReport();
        }

        private void Clear_lbl_exception()
        {
            lbl_exception.Text = ""; ;
        }

        void SetSortExpression(GridView grid)
        {
            grid.Columns[0].SortExpression = "Имя терминала";
            
        }

        private void GetReport()
        {
            client = new _interface.SQLWebServiceReference1.WebService1SoapClient();
            Clear_lbl_exception();

           // report = new DataTable();

            try
            {
                report = client.GetOrderSQL(ddl_terminalView.SelectedItem.Text, DateTime.Now, DateTime.Now);
                
                grid_report.DataSource = report;
                grid_report.DataBind();

                //grid_report.Columns[0].SortExpression = "Имя терминала";


            }
            catch (Exception e)
            {
                lbl_exception.Text = e.Message;

              
                
            }


        }

        

        protected void ddl_sortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_report.Sort(ddl_sortColumn.SelectedItem.Text, SortDirection.Ascending);
        }

        protected void btn_AscSort_Click(object sender, ImageClickEventArgs e)
        {
            if (grid_report.Rows.Count > 0)
            grid_report.Sort(ddl_sortColumn.SelectedItem.Text, SortDirection.Ascending);
        }

        protected void btn_DescSort_Click(object sender, ImageClickEventArgs e)
        {
            if (grid_report.Rows.Count > 0)
                grid_report.Sort(ddl_sortColumn.SelectedItem.Text, SortDirection.Descending);
        }

        protected void grid_report_Sorting1(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = new DataTable();

            foreach (DataControlField column in grid_report.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            foreach (GridViewRow row in grid_report.Rows)
            {
                DataRow dr = dataTable.NewRow();
                for (int j = 0; j < grid_report.Columns.Count; j++)
                {
                    dr[grid_report.Columns[j].HeaderText] = row.Cells[j].Text;
                }

                dataTable.Rows.Add(dr);
            }

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                grid_report.DataSource = dataView;
                grid_report.DataBind();
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

   
    
	}
}