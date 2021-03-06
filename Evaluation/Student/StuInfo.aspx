﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Student.Master" AutoEventWireup="true"
    CodeBehind="StuInfo.aspx.cs" Inherits="Eva.Evaluation.Student.StuInfo" %>

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
                        <div class="widget-title">
                            <span class="icon"><i class="icon-align-justify"></i></span>
                            <h5>
                                个人信息</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="control-group">
                                <label class="control-label">
                                    真实姓名 :</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtName" runat="server" class="span5" placeholder="真实姓名"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    身份证</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtIdCard" runat="server" class="span5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    手机号码</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtTel" runat="server" class="span5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    学院</label>
                                <div class="controls">
                                    <asp:DropDownList ID="CollegeList" runat="server" class="span5" 
                                        AutoPostBack="True" onselectedindexchanged="CollegeList_SelectedIndexChanged">
                                    </asp:DropDownList>                               
                                </div>
                            </div>
                             <div class="control-group">
                                <label class="control-label">
                                    专业</label>
                                <div class="controls">
                                    <asp:DropDownList ID="MajorList" runat="server" class="span5" 
                                         
                                        AutoPostBack="True" 
                                        onselectedindexchanged="MajorList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    班级</label>
                                <div class="controls">
                                    <asp:DropDownList ID="ClassList" runat="server" class="span5">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    性别</label>
                                <div class="controls">
                                    <asp:TextBox ID="txtSex" runat="server" class="span5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-actions">
                                <asp:Button ID="Save" runat="server" Text="保存" class="btn btn-success" 
                                    onclick="Save_Click"  />
                            </div>
                        </div>
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
                                <asp:Button ID="Button1" runat="server" Text="保存" class="btn btn-success" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
