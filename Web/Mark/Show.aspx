<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Eva.Web.Mark.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		Id
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		课程ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCourseId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学生ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStudentId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		所属评测表ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblEvalutionId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		分数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblScore" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加分
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblBonusPoint" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学年
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAcademicYear" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSchoolTerm" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		加分审核
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCheckStep" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




