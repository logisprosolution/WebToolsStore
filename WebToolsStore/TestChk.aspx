<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestChk.aspx.cs" Inherits="WebToolsStore.TestChk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>ระบบซื้อขายร้านเจดีย์สติล</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.2 -->
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- FontAwesome 4.3.0 -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons 2.0.0 -->
    <link href="http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../assets/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins 
         folder instead of downloading all of them to reduce the load. -->
    <link href="../assets/dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <!-- Morris chart -->
    <link href="../assets/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
    <link href="../assets/plugins/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" type="text/css" />
    <!-- Date Picker -->
    <link href="../assets/plugins/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />
    <!-- Daterange picker -->
    <link href="../assets/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="../assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />

    <!-- jQuery 2.1.3 -->
    <script src="../assets/plugins/jQuery/jQuery-2.1.3.min.js"></script>
    <!-- jQuery UI 1.11.2 -->
    <script src="../assets/plugins/jQueryUI/jquery-ui-1.11.2.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="dgv1" class="table table-bordered table-hover dataTable" aria-describedby="example2_info" runat="server"
                AutoGenerateColumns="False" AllowSorting="True" PageSize="50" DataKeyNames="product_price_id"
                ShowHeaderWhenEmpty="True" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataText="ไม่พบรายการ" OnRowCommand="dgv1_RowCommand" OnRowDeleting="dgv1_RowDeleting" OnRowEditing="dgv1_RowEditing">
                <Columns>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_code" HeaderText="รหัสสินค้า">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="product_price_name" HeaderText="ชื่อสินค้า">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Cash" HeaderText="ราคาเงินสด">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_Credit" HeaderText="ราคาเงินเชื่อ">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="price_CashExtra" HeaderText="ราคาบัตรเครดิต">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkview" runat="server" AutoPostBack="true" OnCheckedChanged="chkview_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="150px">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdfID" runat="server" Value='<%# Eval("product_price_id") %>' />
                            <asp:LinkButton ID="btnGridEdit" runat="server" Text="แก้ไข" class="btn btn-warning fa fa-edit" CommandName="Edit" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
                            <asp:LinkButton ID="btnGridDelete" runat="server" Text="ลบ" class="btn btn-danger fa fa-trash-o" CommandName="Delete" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" OnClientClick="return confirm('ทำการยืนยัน ที่จะลบข้อมูล ?');" />
                            <br />
                        </ItemTemplate>

                        <HeaderStyle Width="150px"></HeaderStyle>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle CssClass="selectedRowStyle" BackColor="LightCyan" ForeColor="DarkBlue"
                    Font-Bold="true" />

                <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>

                <PagerSettings FirstPageText="Frist Page " LastPageText=" Last Page" Mode="NumericFirstLast"
                    NextPageText=" Next " PreviousPageText=" Previous " />
            </asp:GridView>
        </div>
    </form>
        <script>
        $.widget.bridge('uibutton', $.ui.button);

        function PopupCenter(url, title, w, h) {
            // Fixes dual-screen position                         Most browsers      Firefox
            var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
            var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

            var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
            var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

            var left = ((width / 2) - (w / 2)) + dualScreenLeft;
            var top = ((height / 2) - (h / 2)) + dualScreenTop;
            var newWindow = window.open(url, title, 'scrollbars=yes, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

            // Puts focus on the newWindow
            if (window.focus) {
                newWindow.focus();
            }
        }
    </script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="../assets/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- Morris.js charts -->
    <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
    <script src="../assets/plugins/morris/morris.min.js" type="text/javascript"></script>
    <!-- Sparkline -->
    <script src="../assets/plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- jvectormap -->
    <script src="../assets/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
    <script src="../assets/plugins/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>
    <!-- jQuery Knob Chart -->
    <script src="../assets/plugins/knob/jquery.knob.js" type="text/javascript"></script>
    <!-- daterangepicker -->
    <script src="../assets/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <!-- datepicker -->
    <script src="../assets/plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="../assets/plugins/datepicker/bootstrap-datepicker-th.js" charset="UTF-8" type="text/javascript"></script>
    <script src="../assets/plugins/datepicker/locales/bootstrap-datepicker.th.js" charset="UTF-8" type="text/javascript"></script>
    <!-- Bootstrap WYSIHTML5 -->
    <script src="../assets/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <!-- Slimscroll -->
    <script src="../assets/plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <!-- FastClick -->
    <script src='../assets/plugins/fastclick/fastclick.min.js'></script>
    <!-- AdminLTE App -->
    <script src="../assets/dist/js/app.min.js" type="text/javascript"></script>

    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../assets/dist/js/pages/dashboard.js" type="text/javascript"></script>

    <!-- AdminLTE for demo purposes -->
    <script src="../assets/dist/js/demo.js" type="text/javascript"></script>

    <!-- DATA TABLE -->
    <script src="../assets/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="../assets/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>
</body>
</html>
