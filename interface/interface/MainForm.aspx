<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="web_interface.MainForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Select1
        {
            width: 185px;
            height: 20px;
        }
        .style1
        {
            width: 331px;
            height: 100px;
        }
        .overload
        {
            
        }
    </style>
</head>
<body style="height: 499px; width: 1164px;">
    
    <form id="form1" runat="server" visible="True">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    
        <div style="height: 124px; background-color: #FFFFFF;">
            <img class="style1" 
                src="file:///C:/Users/burob/AppData/Local/Microsoft/Windows/INetCache/WebTempDir/logo.png" alt="Приовнешторгбанк"/></div>
    
    </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
    Сортировать по&nbsp; &nbsp;
    <asp:DropDownList ID="ddl_sortColumn" runat="server" 
        onselectedindexchanged="ddl_sortColumn_SelectedIndexChanged">
        <asp:ListItem>Дата события</asp:ListItem>
        <asp:ListItem>Имя терминала</asp:ListItem>
        <asp:ListItem>Сообщение</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;
    &nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Терминал&nbsp;&nbsp;
    <asp:DropDownList ID="ddl_terminalView" runat="server" Height="16px" 
        Width="145px">
        <asp:ListItem Selected="True">Все</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" 
        onclick="Button1_Click" Text="Обновить" Width="89px" 
        UseSubmitBehavior="False" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Отображаемый период: с .... 
    по ....<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    &nbsp;
    <asp:Button ID="btn_report" runat="server" Text="Сформировать отчет" 
        BackColor="#009999" BorderColor="#009999" BorderStyle="Outset" Font-Bold="True" 
        Font-Names="Arial" Font-Size="Larger" ForeColor="White" 
        onclick="btn_report_Click" UseSubmitBehavior="False"/>
        

    <br />
    <asp:Label ID="lbl_exception" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="grid_report" runat="server" onsorting="grid_report_Sorting1" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Имя терминала" HeaderText="Имя терминала" 
                SortExpression="Имя терминала" />
            <asp:BoundField DataField="Дата события" HeaderText="Дата события" 
                SortExpression="Дата события" />
            <asp:BoundField DataField="Сообщение" HeaderText="Сообщение" 
                SortExpression="Сообщение" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="Panel1" runat="server" style="display:none">
        <iframe id="frameDialogWindow" src="DialogWindow.aspx" frameborder="0">
        </iframe>
    </asp:Panel>
    <br />

       

    

    </form>
</body>
</html>
