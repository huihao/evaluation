<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="CourseList.aspx.cs" Inherits="Eva.Evaluation.Admin.CourseList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">课程列表</a>
            </div>
            <h1>
                课程列表</h1>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-th"></i></span>
                            <h5>
                                课程列表</h5>
                        </div>
                       
                        <div class="widget-content nopadding">
                            <table class="table table-bordered data-table">
                                <thead>
                                    <tr>
                                        
                                        <th>
                                            课程名
                                        </th>
                                        <th>
                                            学分
                                        </th>
                                        <th>
                                            课程介绍
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="CourseRepeater" runat="server" 
                                        onitemcommand="CourseRepeater_ItemCommand" >
                                        <ItemTemplate>
                                            <tr>
                                                
                                                <td>
                                                    <%#Eval("Name")%>
                                                </td>
                                                <td>
                                                    <%#Eval("Gpa")%>
                                                </td>
                                                <td>
                                                   <%#Eval("Introdution")%>
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
                            <div>
                            <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
