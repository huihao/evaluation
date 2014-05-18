<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="ShowMark.aspx.cs" Inherits="Eva.Evaluation.Student.ShowMark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server">
        <div>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb">
                        <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                        <a href="#" class="current">成绩查看</a>
                    </div>
                    <h1>
                        学生姓名：
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
                </div>
                <div class="container-fluid">
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
                                        课程列表</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <table class="table table-bordered data-table">
                                        <thead>
                                            <tr>
                                                <th>
                                                    课程名称
                                                </th>
                                                <th>
                                                    最高分数
                                                </th>
                                                <th>
                                                    学分
                                                </th>
                                                <th>
                                                    加分
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="MarkRepeater" runat="server" 
                                                onitemcommand="MarkRepeater_ItemCommand">
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
                                                        <td>
                                                            <asp:Button ID="btnMarkAddApply" runat="server" Text="加分申请"  CommandArgument='<%#Eval("Id")%>' CommandName="apply"/>
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
        </div>
        </form>
</asp:Content>
