<%@ Page Title="Overzicht hulpvragen" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="TopicsVolunteer.aspx.cs" Inherits="HulpGezocht.TopicsVolunteer" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    
    <div class="form-horizontal">
        <hr/>
        <div class="form-group">
            <div class="col-md-10">
                <asp:ListBox runat="server" ID="lbTopics" CssClass="form-group list-group"/>
            </div>
        </div>
    </div>
</asp:Content>