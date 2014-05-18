<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Eva.Evaluation.Admin.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server" class="form-horizontal">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">修改课程</a>
            </div>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-align-justify"></i></span>
                            <h5>
                                修改课程</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                    课程</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" class="span6" placeholder="姓名">
                                    </asp:TextBox>
                                </div>
                            </div>
                           <div class="control-group">
                                <label class="control-label">
                                    学分</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtGpa" runat="server" class="span6" placeholder="姓名">
                                    </asp:TextBox>
                                </div>
                            </div>
                             <div class="control-group">
                                <label class="control-label">
                                   课程介绍</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtIntr" runat="server" class="span6" placeholder="姓名">
                                    </asp:TextBox>
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
