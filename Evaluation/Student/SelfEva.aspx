<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true" CodeBehind="SelfEva.aspx.cs" Inherits="Eva.Evaluation.Student.SelfEva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">自评</a>
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
                                自评</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form id="Form1" action="#" method="get" class="form-horizontal" runat="server">
                            <div class="control-group">
                                <label class="control-label">
                                    自评</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtSelf" runat="server" class="span6" placeholder="自评"  TextMode="MultiLine" Rows="6"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-actions">
                                <asp:Button ID="Save" runat="server" Text="保存" class="btn btn-success" onclick="Save_Click" 
                                     />
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
