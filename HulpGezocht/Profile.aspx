<%@ Page Title="Profiel" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="HulpGezocht.Profile" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-8">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="tbName" ID="lblName" CssClass="col-md-2 control-label">Naam</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tbName" CssClass="form-control textbox-register" TextMode="SingleLine" ReadOnly="True" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="dobDateOfBirth" ID="lblDOB" CssClass="col-md-2 control-label">Geboortedatum</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="dobDateOfBirth" CssClass="form-control textbox-register" TextMode="Date" ReadOnly="True" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="tbPhoneNumber" ID="lblPhoneNumber" CssClass="col-md-2 control-label">Telefoonnummer</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tbPhoneNumber" CssClass="form-control textbox-register" TextMode="Number" ReadOnly="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbPhoneNumber" ID="ValidatorPhoneNumber"
                            CssClass="text-danger" ErrorMessage="Het telefoonnummer veld is verplicht." Display="Dynamic" Enabled ="false"/>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="tbBio" ID="lblBio" CssClass="col-md-2 control-label">Biografie</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="tbBio" CssClass="form-control textbox-register" TextMode="MultiLine" ReadOnly="True" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbBio" ID="ValidatorBio"
                            CssClass="text-danger" ErrorMessage="De biografie is verplicht om in te vullen." Display="Dynamic" Enabled="False" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:CheckBox ID="chckDriversLicense" runat="server" CssClass="checkbox" Text="Ik ben in het bezit van een rijbewijs" Enabled="False" Checked="True" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fileuploadProfilePicUpload" ID="lblProfilePicUpload" CssClass="col-md-2 control-label" Visible="False">Profielfoto uploaden</asp:Label>
                    <div class="col-md-10">
                        <asp:FileUpload ID="fileuploadProfilePicUpload" runat="server" onclick="UploadButton_Click" Enabled="False" Visible="False" />
                        <asp:RequiredFieldValidator ID="ValidatorProfilePic" runat="server" ControlToValidate="fileuploadProfilePicUpload"
                            CssClass="text-danger" ErrorMessage="Profielfoto moet worden geupload." Display="Dynamic" Enabled="False"/>
                        <br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblVOG" AssociatedControlID="fileuploadVOG" CssClass="col-md-2 control-label" Visible="False">VOG uploaden</asp:Label>
                    <div class="col-md-10">
                        <asp:FileUpload ID="fileuploadVOG" runat="server" onclick="UploadButton_Click" Enabled="False" Visible ="False"/>
                        <asp:RequiredFieldValidator ID="ValidatorVOG" runat="server" ControlToValidate="fileuploadVOG"
                            CssClass="text-danger" ErrorMessage="VOG moet worden geupload." Display="Dynamic" Enabled="False"/>
                        <br />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:Button ID="btnEdit" runat="server" Text="Profiel bewerken" CssClass="btn btn-default" OnClick="btnEdit_Click"/>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:HyperLink runat="server" ID="HyperlinkReport" ViewStateMode="Disabled">Rapporteer dit profiel</asp:HyperLink>
                    </div>
                </div>

            </div>
            <div class="col-md-2">
                <div class="form-group">
                    <asp:Image ID="ProfilePic" runat="server" ImageUrl="http://i.imgur.com/DRyxvPp.jpg" AlternateText="Profielfoto" Height="150px" Width="150px" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnRecensie" runat="server" Text="Recensie geven" CssClass="btn btn-default" Width="150px" OnClick="btnRecensie_Click"/>
                    <asp:Button ID="btnAfspraak" runat="server" Text="Afspraak maken" CssClass="btn btn-default" Width="150px" OnClick="btnAfspraak_Click"/>
                    <asp:Button ID="btnChat" runat="server" Text="Chat starten" CssClass="btn btn-default" Width="150px" OnClick="btnChat_Click"/>
                    <asp:Button ID="btnVOG" runat="server" Text="VOG openen" CssClass="btn btn-default" Width="150px" OnClick="btnVOG_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
