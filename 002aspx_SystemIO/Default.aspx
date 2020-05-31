<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_200528study.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>通过web方法输出磁盘调用System.IO</h1>
  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
        <asp:BoundField DataField="DriverName" HeaderText="分区名称" />
        <asp:BoundField DataField="DriveType" HeaderText="分区类型" />
        <asp:BoundField DataField="DriveFormat" HeaderText="文件系统" />
        <asp:BoundField DataField="VolumeLabel" HeaderText="卷标" />
        <asp:BoundField DataField="TotalFreeSpace" HeaderText="空闲容量" />
        <asp:BoundField DataField="TotalSize" HeaderText="总容量" />
        <asp:BoundField DataField="Percent" DataFormatString="{0}%" HeaderText="使用百分比" />
        <asp:BoundField DataField="AvailableFreeSpace" HeaderText="磁盘配额" />
        </Columns>
        </asp:GridView>
        </div>
    </form>
</body>
</html>
