<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExampleUI.aspx.cs" Inherits="PMA.ExampleUI" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="/Scripts/moment.min.js"></script>
    <script type="text/javascript" src="/Scripts/bootstrap-datetimepicker.js"></script>
    <link rel="stylesheet" href="/Content/bootstrap-datetimepicker.css" />

    <div class="row">
        <div class="jumbotron col-md-12">
            <h3>Example UI</h3>
        </div>
    </div>
    <div class="container row">
        <div class="col-sm-6">
            <div class="form-group">
                <div class="input-group date" id="datetimepicker1">
                    <input type="text" class="form-control"/>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(function() {
                $('#datetimepicker1').datetimepicker();
            });
        </script>
    </div>
    <div class="row">
        <div class="col-md-6">
            <asp:Button ID="btnExecute1" runat="server" Text="Execute" OnClick="btnExecute1_Click"/><br/>
            <asp:DropDownList CssClass="dropdown" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="col-md-6">
            <asp:Label ID="Label2" runat="server" Text="Test POST Api"></asp:Label><br/>
            <asp:Button ID="btnExecute2" runat="server" Text="Execute" OnClick="btnExecute2_Click"/><br/>
            <asp:DropDownList CssClass="dropdown" ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>