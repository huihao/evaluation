<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="AwardList.aspx.cs" Inherits="Eva.Evaluation.Student.AwardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div>
        <div id="content">
            <div id="content-header">
                <div id="breadcrumb">
                    <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                    <a href="#" class="current">奖项查看</a>
                </div>
                <h1>
                    学生姓名：
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
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
                        </div>
                        <div class="widget-box">
                            <div class="widget-title">
                                <span class="icon"><i class="icon-th"></i></span>
                               
                            </div>
                            <div class="widget-content nopadding">
                                <table class="table table-bordered data-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                赛事
                                            </th>
                                            <th>
                                                级别
                                            </th>
                                            <th>
                                                奖项
                                            </th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="AwardRepeater" runat="server" >
                                            <ItemTemplate>
                                                <tr class="gradeX">
                                                    <td>
                                                        <%#  Eval("Name") %>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Grade") %>
                                                    </td>
                                                    <td>
                                                        <%#  Eval("Score") %>
                                                    </td>
                                                   
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <asp:Button ID="btnAdd" runat="server" Text="Button" onclick="btnAdd_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
