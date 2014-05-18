<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="EditAuth.aspx.cs" Inherits="Eva.Evaluation.Admin.EditAuth1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server" class="form-horizontal">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">修改权限</a>
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
                                修改权限</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                    姓名</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" class="span6" placeholder="姓名">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    权限</label>
                                <div class="controls">
                                    <asp:DropDownList ID="AuthList" runat="server" class="span5">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-success" 
                                    onclick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
