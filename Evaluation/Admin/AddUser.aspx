<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true"
    CodeBehind="AddUser.aspx.cs" Inherits="Eva.Evaluation.Admin.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>主页</a>
                <a href="#" class="current">添加用户</a>
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
                                添加用户</h5>
                        </div>
                        <div class="widget-content nopadding">

                            <form action="#" method="get" class="form-horizontal" runat="server">
                            
                            <div class="control-group">
                                <label class="control-label">
                                        用户名 :</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtLogin" runat="server" class="span6" placeholder="用户名"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    真实姓名 :</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" class="span6" placeholder="真实姓名"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    密码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPassWord" runat="server" class="span6" placeholder="密码" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    重复密码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtPassWordC" runat="server" class="span6" placeholder="重复密码" TextMode="Password">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    身份证</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtIdCard" runat="server" class="span11" placeholder="Company name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                   学院</label>
                                <div class="controls">
                                    <asp:DropDownList ID="CollegeList" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="CollegeList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    专业</label>
                                <div class="controls">
                                    <asp:DropDownList ID="MajorList" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="MajorList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    班级</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ClassList" runat="server">
                                    </asp:DropDownList>
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
