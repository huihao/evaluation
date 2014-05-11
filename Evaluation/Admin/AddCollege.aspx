<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddCollege.aspx.cs" Inherits="Eva.Evaluation.Admin.AddCollege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">添加学院</a>
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
                                添加学院</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form id="Form1" action="#" method="get" class="form-horizontal" runat="server">
                            <div class="control-group">
                                <label class="control-label">
                                    学院名</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtCollege" runat="server" class="span6" placeholder="学院"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="Save" runat="server" Text="保存" class="btn btn-success" OnClick="Save_Click" />
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
