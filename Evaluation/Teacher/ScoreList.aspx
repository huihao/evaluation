<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="ScoreList.aspx.cs" Inherits="Eva.Evaluation.Teacher.ScoreList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                                <td>
                                                    <%#Eval("BonusPoint")%>
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
</asp:Content>
