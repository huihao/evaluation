<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="ComEva.aspx.cs" Inherits="Eva.Evaluation.Student.ComEva" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">综合查看</a>
            </div>
            <h1>
                学生姓名：
                <asp:Label ID="Name" runat="server" Text=""></asp:Label></h1>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div>
                        学年<asp:DropDownList ID="YearList" runat="server" Width="100px" AutoPostBack="True"
                            OnSelectedIndexChanged="YearList_SelectedIndexChanged">
                        </asp:DropDownList>
                        学期<asp:DropDownList ID="Termlist" runat="server" Width="100px" AutoPostBack="True"
                            OnSelectedIndexChanged="Termlist_SelectedIndexChanged">
                        </asp:DropDownList>
                        <input value="打印" type="button" onclick="javascript:self.print();" />
                    </div>
                    <div class="widget-content nopadding">
                        <div class="widget-box">
                            <div class="widget-title">
                                <span class="icon"><i class="icon-th"></i></span>
                                <h5>
                                    课程列表</h5>
                            </div>
                            <div class="widget-content nopadding">
                                <table class="table table-bordered data-table">
                                    <thead>
                                        <tr align="center">
                                            <th>
                                                课程名称
                                            </th>
                                            <th>
                                                学分
                                            </th>
                                            <th>
                                                绩点
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="MarkRepeater" runat="server">
                                            <ItemTemplate>
                                                <tr class="gradeX" align="center">
                                                    <td>
                                                        <%# Eva.BLL.Utils.GetCourseName(Convert.ToInt16( Eval("CourseId"))) %>
                                                    </td>
                                                    <td>
                                                        <%#  Eval("Score") %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("Gpa") %>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        
                        <div class="control-group">
                            <label class="control-label">
                                自评 :</label>
                            <div class="controls">
                                <asp:TextBox ID="txtSelf" runat="server" class="span5" placeholder="自评" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                教师评语 :</label>
                            <div class="controls">
                                <asp:TextBox ID="txtTeacherEva" runat="server" class="span5" placeholder="教师评语" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                平均分 :</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAve" runat="server" class="span5" placeholder="平均分" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                总评</label>
                            <div class="controls">
                                <asp:TextBox ID="txtComEva" runat="server" class="span5" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
