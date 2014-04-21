<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Teacher.Master" AutoEventWireup="true"
    CodeBehind="Evaluation.aspx.cs" Inherits="Eva.Evaluation.Teacher.Evaluation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="index.html" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>
                    首页</a> <a href="#">综合评价</a> 
            </div>
            <h1>
                学生综合评价</h1>
        </div>
        <div class="container-fluid">
            <hr>
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-info-sign"></i></span>
                            <h5>
                                评价表格填写</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <form class="form-horizontal" method="post" action="#" >
                            <div class="control-group">
                                <label class="control-label">
                                    评价指标</label>
                                <div class="controls">
                                    <select>
                                    <option>思想品德</option>
                                    <option>社会实践</option>
                                    </select>
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                    评价分数</label>
                                <div class="controls">
                                    <input type="text" name="score" id="score">
                                </div>
                            </div>
                            <div class="control-group">
                                <label class="control-label">
                                   文字评价</label>
                                <div class="controls">
                                    <textarea id="TextArea1" cols="20" rows="3"></textarea>
                                </div>
                            </div>
                       
                            <div class="form-actions">
                                <input type="submit" value="确定" class="btn btn-success">
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
