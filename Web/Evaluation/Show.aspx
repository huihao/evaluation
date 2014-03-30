<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Eva.Web.Evaluation.Show" Title="显示页" %>
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
		学生编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStudentId" runat="server"></asp:Label>
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
		平均绩点
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblGpa" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		平均分
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAve" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		教师评价
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTeacherEvaluation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学生自评
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSelfEvaluation" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		教师ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTeacherId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		学期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblSchoolTerm" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




