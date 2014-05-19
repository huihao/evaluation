<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="ApplyList.aspx.cs" Inherits="Eva.Evaluation.Teacher.ApplyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">加分申请列表</a>
            </div>
            <h1>
                加分申请列表</h1>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-th"></i></span>
                            <h5>
                                加分申请列表</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <table class="table table-bordered data-table">
                                <thead>
                                    <tr>
                                        <th>
                                            学生名称
                                        </th>
                                        <th>
                                            加分课程
                                        </th>
                                        <th>
                                            分数
                                        </th>
                                        <th>
                                            请求加分的分数
                                        </th>
                                        <th>
                                            理由
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="MarkRepeater" runat="server" OnItemCommand="MarkRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%#Eva.BLL.Utils.GetStudentName(Convert.ToInt32(Eval("StudentId"))) %>
                                                </td>
                                                <td>
                                                    <%#Eva.BLL.Utils.GetCourseName(Convert.ToInt16( Eval("CourseId")))%>
                                                </td>
                                                <td>
                                                    <%#Eval("Score")%>
                                                </td>
                                                <td>
                                                    <%#Eval("BonusPoint")%>
                                                </td>
                                                <td>
                                                    <%#Eval("Reason") %>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAgree" runat="server" Text="同意" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="yes" />
                                                    <asp:Button ID="btnDisagree" runat="server" Text="不同意" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="no" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
