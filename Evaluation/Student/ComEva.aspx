<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="ComEva.aspx.cs" Inherits="Eva.Evaluation.Student.ComEva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">综合查看</a>
            </div>
            <h1>
                学生姓名：
                <asp:Label ID="Name" runat="server" Text=""></asp:Label></h1>
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div>
                        学年<asp:DropDownList 
                            ID="YearList" runat="server" Width="100px" AutoPostBack="True" 
                            onselectedindexchanged="YearList_SelectedIndexChanged">
                        </asp:DropDownList>
                        学期<asp:DropDownList ID="Termlist" runat="server" Width="100px" 
                            AutoPostBack="True" onselectedindexchanged="Termlist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="widget-content nopadding">
                        <div class="control-group">
                            <label class="control-label">
                                平均分 :</label>
                            <div class="controls">
                                <asp:TextBox ID="txtAve" runat="server" class="span5" placeholder="平均分" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                总评</label>
                            <div class="controls">
                                <asp:TextBox ID="txtComEva" runat="server" class="span5" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
