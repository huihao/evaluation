<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="Eva.Evaluation.Admin.EditItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<form id="Form1" runat="server" class="form-horizontal">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">修改评价指标</a>
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
                                修改评价指标</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                       评价指标</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" class="span6" placeholder="评价指标">
                                    </asp:TextBox>
                                </div>
                            </div>
                           <div class="control-group">
                                <label class="control-label">
                                    分值</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtValue" runat="server" class="span6" placeholder="分值">
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
