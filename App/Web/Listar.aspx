<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site1.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="App.Web.Listar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="jumbotron">
        <h2>Listar Cuentas</h2>
        <div class ="table-responsive">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CssClass="table table-responsive table-bordered table-condensed">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="EmailP" HeaderText="EmailP" SortExpression="EmailP" />
                    <asp:BoundField DataField="EmailW" HeaderText="EmailW" SortExpression="EmailW" />
                    <asp:BoundField DataField="TelefonoP" HeaderText="TelefonoP" SortExpression="TelefonoP" />
                    <asp:BoundField DataField="TelefonoW" HeaderText="TelefonoW" SortExpression="TelefonoW" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getPersonas" TypeName="App.Datos.PersonasRepositories"></asp:ObjectDataSource>
    </div>

    </div>

</form>

</asp:Content>