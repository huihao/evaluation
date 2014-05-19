<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="ListUser.aspx.cs" Inherits="Eva.Evaluation.Admin.ListUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>管理员界面</a>
                <a href="#" class="current">用户管理</a>
            </div>
            <h1>
                用户管理</h1>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-th"></i></span>
                            <h5>
                                用户列表</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form runat="server">
                            <table class="table table-bordered data-table">
                                <thead>
                                    <tr>
                                        <th>
                                            真实姓名
                                        </th>
                                        <th>
                                            权限
                                        </th>
                                        <th>
                                            性别
                                        </th>
                                        <th>
                                            操作
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="UserRepeater" runat="server" OnItemCommand="UserRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr class="gradeX">
                                                <td>
                                                    <%# Eval("Name") %>
                                                </td>
                                                <td>
                                                    <%# Eva.BLL.Utils.GetAuthNamebyId(Convert.ToInt32(Eval("AuthorityId")))%>
                                                </td>
                                                <td>
                                                    <%# Eval("Sex") %>
                                                </td>
                                                <td class="center">
                                                    <asp:Button ID="BtnInfo" runat="server" Text="信息修改" CommandArgument='<%#Eval("id") %>'
                                                        CommandName="EditInfo" class="btn btn-info btn-mini" />
                                                    <asp:Button ID="BtnAu" runat="server" Text="权限修改" CommandArgument='<%#Eval("id") %>'
                                                        CommandName="EditAuth" class="btn btn-primary btn-mini" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                            <div>
                                <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
