<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="HulpGezocht.Chat" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %> - u praat met User.Name</h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tbChatField" CssClass="form-control textbox-register chatborder" TextMode="MultiLine" ToolTip="Vul hier je bericht in." EnableViewState="False" Width="750px" Height="350px" ReadOnly="True"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tbMessage" CssClass="form-control textbox-register chatborder" TextMode="MultiLine" ToolTip="Vul hier je bericht in." EnableViewState="False" Width="750px" Height="50px"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbMessage" ID="ValidatorSend"
                            CssClass="text-danger" ErrorMessage="Vul een bericht in eer u op de verzend knop klikt." Display="Dynamic"/>
                    </div>
                    <div class="col-md-10">
                        <asp:Button ID="btnEdit" runat="server" Text="Bericht verzenden" CssClass="btn btn-default" OnClick="btnSend_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Image ID="ProfilePic" runat="server" ImageUrl="http://i.imgur.com/DRyxvPp.jpg" AlternateText="Profielfoto" Height="150px" Width="150px" />
                </div>
                <div class="form-group">
                    <asp:HyperLink runat="server" ID="HyperlinkProfile" ViewStateMode="Disabled">User.Name</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
