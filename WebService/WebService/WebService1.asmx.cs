using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
//using Oracle.DataAccess.Client;
using System.Data.SqlClient;

namespace WebService
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private string connectionString = "Data Source=." + @"\SQLEXPRESS;" + "Integrated Security=true;Initial Catalog=Prio;";

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataTable GetOrderSQL(string terminalName, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connect;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select \"Имя терминала\", convert(varchar, Дата, 120) as \"Дата события\", Сообщение "
                                          + "from \"Логи терминалов\" ";
                   
                    if (terminalName != "Все")
                        {
                            command.CommandText += "where \"Имя терминала\" like '" + terminalName + "'"; //and (TO_CHAR(Дата, 'DD.MM.YYYY') >= " + startDate.Date + " and TO_CHAR(Дата, 'DD.MM.YYYY') <= " + endDate.Date;
                        }

                        command.CommandText += " order by Дата DESC;";

                        DataSet order = new DataSet();

                        SqlDataAdapter myData = new SqlDataAdapter(command);

                        myData.Fill(order, "Логи терминалов");

                        return order.Tables["Логи терминалов"];
                }
            }
        }

        [WebMethod]
        public DataTable GetTerminalsName()
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connect;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select distinct \"Имя терминала\" from \"Логи терминалов\"";

                    connect.Open();

                    DataSet terminals = new DataSet();

                    SqlDataAdapter myData = new SqlDataAdapter(command);

                    myData.Fill(terminals, "Логи терминалов");

                    return terminals.Tables["Логи терминалов"];
                }
            }
        }

      /*  [WebMethod]
        public string GetOrder(string terminalName, DateTime startDate, DateTime endDate)
        {
            try
            {
                string connectionString = "Data Source=Prio;Password=250711;User=system;";

                using (OracleConnection connect = new OracleConnection(connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        command.Connection = connect;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "select \"Имя терминала\", TO_CHAR(Дата, 'DD.MM.YYYY HH24:MI:SS'), Сообщение "
                                          + "from \"Логи терминалов\" ";

                        if (terminalName != "Все")
                        {
                            command.CommandText += "where \"Имя терминала\" like " + terminalName + " and (TO_CHAR(Дата, 'DD.MM.YYYY') >= " + startDate.Date + " and TO_CHAR(Дата, 'DD.MM.YYYY') <= " + endDate.Date;
                        }

                        command.CommandText += " order by Дата DESC;";

                        OracleDataReader reader = command.ExecuteReader();

                        return reader.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }*/
    }
}
