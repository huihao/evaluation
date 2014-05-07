<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="Evaluation.aspx.cs" Inherits="Eva.Evaluation.Teacher.Evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <script src="../js/jquery.wizard.js"></script>
    <script src="../js/matrix.js"></script>
    <script src="../js/matrix.wizard.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#">Form elements</a> <a href="#" class="current">Form wizard</a>
            </div>
            <h1>
                Form wizard</h1>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-pencil"></i></span>
                            <h5>
                                综合评价</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form id="form-wizard" class="form-horizontal" method="post" action="EvaluationHandler.ashx">
                            <input id="studentId" name="studentId" type="hidden" runat="server" />
                            <asp:Repeater ID="ItemRepeater" runat="server">
                                <ItemTemplate>
                                    <div id="formwizard-<%#Eval("Id") %>" class="step">
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
                                                <input type="text" name="score<%#Eval("Id") %>" id="score<%#Eval("Id") %>">
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                文字评价</label>
                                            <div class="controls">
                                                <textarea id="word<%#Eval("Id") %>" name="word<%#Eval("Id") %>" cols="20" rows="3"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="form-actions">
                                <input id="back" class="btn btn-primary" type="reset" value="上一项" />
                                <input id="next" class="btn btn-primary" type="submit" value="下一项" />
                                <div id="status">
                                </div>
                            </div>
                            <div id="submitted">
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
