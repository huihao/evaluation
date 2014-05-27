<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="Evaluation.aspx.cs" Inherits="Eva.Evaluation.Teacher.Evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.wizard.js" charset="gb2312"></script>
    <script src="../js/matrix.js" charset="gb2312"></script>
    <script src="../js/matrix.wizard.js" charset="gb2312"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-pencil"></i></span>
                            <h5>
                                综合评价</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form id="formwizard" class="form-horizontal" runat="server" 
                            method="post">
                            <input id="studentId" name="studentId" type="hidden" runat="server" />
                            <asp:Repeater ID="ItemRepeater" runat="server" OnItemDataBound="ItemRepeater_ItemDataBound">
                                <ItemTemplate>
                                    <div id="formwizard-<%#Eval("Id") %>" class="step">
                                        <asp:HiddenField ID="ItemId" runat="server" Value='<%#Eval("Id") %>' />
                                        <div class="control-group">
                                            <label class="control-label">
                                                评价指标</label>
                                            <div class="controls">
                                                <%#Eval("Name") %>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                评价分数</label>
                                            <div class="controls">
                                                <asp:TextBox ID="score" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                文字评价</label>
                                            <div class="controls">
                                                <asp:TextBox ID="word" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                获奖成果</label>
                                            <div class="controls">
                                                <ul>
                                                    <asp:Repeater ID="ExplainRepeater" runat="server" EnableViewState="True" OnItemCommand="ExplainRepeater_ItemCommand">
                                                        <ItemTemplate>
                                                            <li>赛事:
                                                                <%#Eval("Name") %>
                                                                &nbsp; 级别:
                                                                <%#Eval("Grade") %>
                                                                奖项 &nbsp;
                                                                <%#Eval("Score") %>
                                                                <asp:Button ID="btnOK" runat="server" Text="确认" CssClass="btn-success" CommandName="yes"
                                                                    CommandArgument='<%#Eval("Id") %>' />
                                                                <asp:Button ID="btnNo" runat="server" Text="否决" CssClass="btn-danger" CommandName="no"
                                                                    CommandArgument='<%#Eval("Id") %>' />
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="form-actions">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="提交" OnClick="Button1_Click" />
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
