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
                                    <tr class="gradeX">
                                        <td>
                                            李小明
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button1" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button2" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            张飞
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button3" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button4" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                           王五
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button5" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button6" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            陆星
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button7" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button8" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            刘敏
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button9" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button10" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                           刘国庆
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button11" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button12" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            蔡达
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button13" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button14" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            吴军
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button15" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button16" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            李小明
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button17" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button18" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            李明
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button19" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button20" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            李德华
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button21" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button22" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            李小明
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button23" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button24" runat="server" Text="综合评价" class="btn btn-success" />
                                        </td>
                                    </tr>
                                    <tr class="gradeX">
                                        <td>
                                            李小明
                                        </td>
                                        <td>
                                            男
                                        </td>
                                        <td>
                                            22223123
                                        </td>
                                        <td class="center">
                                            12312312
                                        </td>
                                        <td class="center">
                                            <asp:Button ID="Button25" runat="server" Text="查看成绩" class="btn btn-success" />
                                            <asp:Button ID="Button26" runat="server" Text="综合评价" class="btn btn-success" />
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
    </form>
</asp:Content>
