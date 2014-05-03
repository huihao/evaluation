<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="ShowMark.aspx.cs" Inherits="Eva.Evaluation.Admin.ShowMark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>管理员界面</a>
                <a href="#" class="current">成绩列表</a>
            </div>
            <h1>
                成绩列表</h1>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div>
                        学年<asp:DropDownList ID="YearList" runat="server" 
                            Width="100px" AutoPostBack="True" 
                            onselectedindexchanged="YearList_SelectedIndexChanged">
                        </asp:DropDownList>
                        学期<asp:DropDownList ID="Termlist" runat="server" Width="100px" 
                            AutoPostBack="True" onselectedindexchanged="Termlist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-th"></i></span>
                            <h5>
                                成绩列表</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <table class="table table-bordered data-table">
                                <thead>
                                    <tr>
                                        <th>
                                            课程名称
                                        </th>
                                        <th>
                                            分数
                                        </th>
                                        <th>
                                            绩点
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="MarkRepeater" runat="server">
                                        <ItemTemplate>
                                            <tr class="gradeX">
                                                <td>
                                                    <%# Eva.BLL.Utils.GetCourseName(Convert.ToInt16( Eval("CourseId"))) %>
                                                </td>
                                                <td>
                                                    <%#  Eval("Score") %>
                                                </td>
                                                <td>
                                                    <%# Eva.BLL.Utils.GetCourseGpa(Convert.ToInt16( Eval("CourseId"))) %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
    </form>
    </div> </div> </div> </div> </div> </div>
</asp:Content>
