<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Layout.Master" AutoEventWireup="true" CodeBehind="Report_TransAll.aspx.cs" Inherits="WebToolsStore.Report_TransAll" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <h1><small></small></h1>
    <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
        <li class="active">รายงาน</li>
    </ol>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div class="box box-primary">
        <br />
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2 text-right">
                        <label class="control-label">หวมดเอกสาร</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlDocTypeID" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="ddlDocTypeID_SelectedIndexChanged">
                            <asp:ListItem Text="เลือกทั้งหมด" Value="0"></asp:ListItem>
                            <asp:ListItem Text="สั่งทำ" Value="8"></asp:ListItem>
                            <asp:ListItem Text="รับเข้า" Value="5"></asp:ListItem>
                            <asp:ListItem Text="ขาย" Value="2"></asp:ListItem>
                            <asp:ListItem Text="เปลี่ยน" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2 text-right">
                        <label class="control-label">ประเภทเอกสาร</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlSubDocTypeID" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2 text-right" style="display:none">
                        <label class="control-label">คลัง</label>
                    </div>
                    <div class="col-sm-4" style="display:none">
                        <asp:DropDownList ID="ddlWarehouseID" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2 text-right">
                        <label class="control-label">สินค้า</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:DropDownList ID="ddlProductID" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-2 text-right">
                        <label class="control-label">ตั้งแต่วันที่</label>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group date" data-provide="datepicker" data-date-language="th">
                            <asp:TextBox ID="txtDateFrom" runat="server" type="text" class="form-control" />
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2 text-right">
                        <label class="control-label">ถึงวันที่</label>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group date" data-provide="datepicker" data-date-language="th">
                            <asp:TextBox ID="txtDateTo" runat="server" type="text" class="form-control" />
                            <div class="input-group-addon">
                                <span class="glyphicon glyphicon-th"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="row">
                <div class="col-md-12">
                    <div class="box-footer" style="text-align: center;">
                        <asp:Button ID="btnSearch" runat="server" Text="ค้นหารายงาน" type="button" Visible="false" class="btn btn-default" OnClick="btnSearch_Click"></asp:Button>
                        <asp:Button ID="btnPrint" runat="server" Text="พิมพ์" type="button" class="btn btn-default" OnClick="btnPrint_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>

    <%--</div>--%>
    <%--<div class="col-sm-12">
                <div class="portlet light ">
                    <div class="popover-title">
                        <div class="caption font-dark">
                            <i class="icon-basket font-dark"></i>
                            <span class="caption-subject bold uppercase">รายงาน</span>
                        </div>
                    </div>
                    <div class="portlet-body">

                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
                    </div>
                </div>
            </div>--%>
    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
