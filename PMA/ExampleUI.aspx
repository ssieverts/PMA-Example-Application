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
    <div class="row">
        <div class="col-md-6">
            <asp:Label ID="lblApi1" runat="server" Text="Test GET Api"></asp:Label><br/>
            <asp:Label ID="lblApi12" runat="server" Text="Dates generated from previous Sunday of the current week."></asp:Label><br/>
            <asp:Button ID="btnExecuteApi1" runat="server" Text="Execute" OnClick="btnExecuteApi1_Click"/><br/>
            <asp:DropDownList CssClass="dropdown" ID="DropDownListApi1" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListApi1_SelectedIndexChanged">
                <asp:ListItem>Wating for execution</asp:ListItem>
            </asp:DropDownList>
            <div id="divModal" runat="server" class ="modalDialog" visible="false">
                <div>
                    <asp:LinkButton ID="lbtnModalClose" runat="server"  CssClass="close" Text="X" OnClick="CloseModal" />
                    <h2>Details</h2>
                    <p>Day of Week: <%=DayStr %> -- Date: <%=CalDate %></p>
                    <br />
                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="CloseModal" />
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <asp:Label ID="lblApi2" runat="server" Text="Test POST Api"></asp:Label><br/>
            
            <div class="col-sm-6">
                <asp:Label ID="lblApi22" runat="server" Text="Select a day to generate dates from previous Sunday."></asp:Label><br/>
                <div class="form-group">
                    <div class="input-group date" id="datetimepicker1">
                        <input type="text" ID="newDate" runat="server" class="form-control"/>
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker();
                });
            </script>
            <asp:Button ID="btnExecuteApi2" runat="server" Text="Execute" OnClick="btnExecuteApi2_Click"/><br/>
            <asp:DropDownList CssClass="dropdown" ID="DropDownListApi2" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListApi2_SelectedIndexChanged">
                <asp:ListItem>Waiting for execution</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
</asp:Content>