<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="ApplyList.aspx.cs" Inherits="Eva.Evaluation.Student.ApplyList" %>

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
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpdate" runat="server" Text="修改" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="update" />
                                                    <asp:Button ID="btnDelete" runat="server" Text="删除" CommandArgument='<%#Eval("Id") %>'
                                                        CommandName="delete" />
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
