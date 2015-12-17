<%@ Page Title="Afspraken" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Appointment.aspx.cs" Inherits="HulpGezocht.Appointment" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbNaam" CssClass="col-md-2 control-label">Naam</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbNaam" CssClass="form-control textbox-register" TextMode="SingleLine" ReadOnly="True"/>
                <asp:RequiredFieldValidator ID="ValidatorTbNaam" runat="server" ControlToValidate="tbNaam"
                    CssClass="text-danger" ErrorMessage="Het naam veld is verplicht." Display="Dynamic" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbOnderwerp" CssClass="col-md-2 control-label">Onderwerp</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbOnderwerp" CssClass="form-control textbox-register" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbOnderwerp"
                    CssClass="text-danger" ErrorMessage="Het onderwerp veld is verplicht." Display="Dynamic" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbLocatie" CssClass="col-md-2 control-label">Locatie</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbLocatie" CssClass="form-control textbox-register" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbLocatie"
                    CssClass="text-danger" ErrorMessage="Het locatie veld is verplicht." Display="Dynamic" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbVervoer" CssClass="col-md-2 control-label">Vervoerstype</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbVervoer" CssClass="form-control textbox-register" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbVervoer"
                    CssClass="text-danger" ErrorMessage="Het vervoerstype veld is verplicht." Display="Dynamic" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="tbReisTijd" CssClass="col-md-2 control-label">Reistijd</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="tbReisTijd" TextMode="Password" CssClass="form-control textbox-register" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="tbReisTijd"
                    CssClass="text-danger" ErrorMessage="Het reistijd veld is verplicht." Display="Dynamic" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="dobDateOfBirth" CssClass="col-md-2 control-label">Geboortedatum</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="dobDateOfBirth" CssClass="form-control textbox-register" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="dobDateOfBirth"
                    CssClass="text-danger" ErrorMessage="Het geboortedatum veld is verplicht." Display="Dynamic" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnBevestig" Text="Bevestigen" CssClass="btn btn-default" onclick="btnBevestig_Click" Width="350px"/>
            </div>
        </div>

        <hr/>
        <%--AGENDA UIT DEMO MOET HIER NOG--%>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:ListBox ID="lbAfspraken" runat="server" Width="350px" CssClass="list-group"></asp:ListBox>
            </div>
            
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" ID="btnVerwijder" Text="Verwijder geselecteerde afspraak" CssClass="btn btn-default" onclick="btnVerwijder_Click" Width="350px"/>
            </div>
        </div>
    </div>
</asp:Content>
