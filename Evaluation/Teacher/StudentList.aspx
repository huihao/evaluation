<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="StudentList.aspx.cs" Inherits="Eva.Evaluation.Teacher.StudentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">学生列表</a>
            </div>
            <h1>
                学生列表</h1>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-th"></i></span>
                            <h5>
                                学生列表</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <table class="table table-bordered data-table">
                                <thead>
                                    <tr>
                                        <th>
                                            学生名称
                                        </th>
                                        <th>
                                            性别
                                        </th>
                                        <th>
                                            学号
                                        </th>
                                        <th>
                                            手机号码
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="StudentRepeater" runat="server" OnItemCommand="StudentRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%#Eval("Name")%>
                                                </td>
                                                <td>
                                                    <%#Eval("Sex")%>
                                                </td>
                                                <td>
                                                    <%#Eval("StudentId")%>
                                                </td>
                                                <td>
                                                    <%#Eval("Phone")%>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnShowScroe" runat="server" Text="成绩查看" CommandArgument='<%#Eval("StudentId") %>'
                                                        CommandName="view" />
                                                    <asp:Button ID="btnEvaluation" runat="server" Text="综合评价" CommandArgument='<%#Eval("StudentId") %>'
                                                        CommandName="eva" />
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
