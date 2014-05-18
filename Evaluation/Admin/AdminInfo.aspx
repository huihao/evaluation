<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Eva.Evaluation.Admin.AdminInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server" class="form-horizontal">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">用户信息</a>
            </div>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">                        
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                    原始密码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtOldPassWord" runat="server" class="span6" placeholder="原始密码"
                                        TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    新密码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPassWord" runat="server" class="span6" placeholder="密码" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    重复重复密码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPassWordC" runat="server" class="span6" placeholder="重复密码" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-success" 
                                    onclick="Button1_Click"  />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
