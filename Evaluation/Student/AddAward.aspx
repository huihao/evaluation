<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="AddAward.aspx.cs" Inherits="Eva.Evaluation.Student.AddAward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server" class="form-horizontal">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">添加奖项</a>
            </div>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-align-justify"></i></span>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                    学年</label>
                                <div class="controls">
                                    <asp:DropDownList ID="YearList" runat="server" class="span5">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    学期</label>
                                <div class="controls">
                                    <asp:DropDownList ID="Termlist" runat="server" class="span5">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    赛事</label>
                                <div class="controls">
                                    <asp:DropDownList ID="txtName" runat="server" class="span5" placeholder="赛事">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    级别</label>
                                <div class="controls">
                                    <asp:DropDownList ID="GradeList" runat="server" class="span5" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                               <div class="control-group">
                                <label class="control-label">
                                    奖项</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ScoreList" runat="server" class="span5">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="btnSave" runat="server" Text="保存" class="btn btn-success" onclick="btnSave_Click" 
                                      />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
