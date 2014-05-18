<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="ShowEva.aspx.cs" Inherits="Eva.Evaluation.Student.ShowEva" %>

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
                                <h5>
                                    评价列表</h5>
                            </div>
                            <div class="widget-content nopadding">
                                <table class="table table-bordered data-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                评价指标
                                            </th>
                                            <th>
                                                评价分数
                                            </th>
                                            <th>
                                                文字评价
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="EvaRepeater" runat="server" OnItemCommand="EvaRepeater_ItemCommand">
                                            <ItemTemplate>
                                                <tr class="gradeX">
                                                    <td>
                                                        <%# Eva.BLL.Utils.GetItemName(Convert.ToInt16(Eval("ItemId")))%>
                                                    </td>
                                                    <td>
                                                        <%#  Eval("Score") %>
                                                    </td>
                                                    <td>
                                                        <%#Eval("Evaluation")%>
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
