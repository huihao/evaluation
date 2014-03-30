<%@ Page Title="WebUser" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Eva.Web.WebUser.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="LoginId" HeaderText="登录名" SortExpression="LoginId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="PassWord" HeaderText="密码" SortExpression="PassWord" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="AuthorityId" HeaderText="权限" SortExpression="AuthorityId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Name" HeaderText="真实姓名" SortExpression="Name" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="StudentId" HeaderText="学号" SortExpression="StudentId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Sex" HeaderText="性别" SortExpression="Sex" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="CollegeId" HeaderText="学院ID" SortExpression="CollegeId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="ClassId" HeaderText="班级ID" SortExpression="ClassId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="MajorId" HeaderText="专业ID" SortExpression="MajorId" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="IdCard" HeaderText="身份证号码" SortExpression="IdCard" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Address" HeaderText="联系地址" SortExpression="Address" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Phone" HeaderText="电话号码" SortExpression="Phone" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
