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
               学生姓名： 李小明</h1>
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
                                    <tr class="gradeX">
                                        <td>
                                            高等数学
                                        </td>
                                        <td>
                                            90
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            计算机基础
                                        </td>
                                        <td>
                                            88
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            c#高级编程
                                        </td>
                                        <td>
                                            77
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            离散数学
                                        </td>
                                        <td>
                                            76
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            毛泽东概论
                                        </td>
                                        <td>
                                            33
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            英语
                                        </td>
                                        <td>
                                            92
                                        </td>
                                        <td>
                                            4
                                        </td>
                                        <td class="center">
                                            0
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
