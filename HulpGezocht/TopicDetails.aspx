<%@ Page Title="Details vraag" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopicDetails.aspx.cs" Inherits="HulpGezocht.TopicDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="form-horizontal">
        <hr />
        <div class="form-group">
            <div class="col-md-2">
                <asp:Image CssClass="col-md-1" ID="imageProfilePic" runat="server" Height="150px" Width="150px" ImageUrl="/Images/default.jpg"/>
                <asp:HyperLink CssClass="col-md-1" ID="hpName" runat="server" Text="Naam hulpbehoevende"></asp:HyperLink>
            </div>
            <div class="col-md-8">
                <h3><asp:Label runat="server" ID="TopicHeader" Text="Topic header"></asp:Label></h3>
                <asp:Label CssClass="lblTopicBody" runat="server" ID="TopicBody" Style="word-wrap: break-word;" Text="Welke zoektermen gebruiken we het meest? Google houdt het elk jaar bij. In 2015 staat op één 'Agario', een game voor op je mobiel. Op de tweede plaats staat het tv-programma 'Boer zoekt Vrouw'. En op drie staat 'Charlie Hebdo'. Uit het top-10-lijstje van dit jaar blijkt dat we vooral benieuwd zijn naar entertainment, populaire tv-programma's en grote nieuwsgebeurtenissen."></asp:Label>
                <ul>
                    <li><asp:Label ID="lblDate" runat="server" Text="Datum: "></asp:Label><asp:Label ID="Date" runat="server" Text="15/12/15"></asp:Label></li>
                    <li><asp:Label ID="lblLocation" runat="server" Text="Locatie: "></asp:Label><asp:Label ID="Location" runat="server" Text="Thuis"></asp:Label></li>
                    <li><asp:Label ID="lblTraveltime" runat="server" Text="Reistijd (in minuten): "></asp:Label><asp:Label ID="Traveltime" runat="server" Text="30"></asp:Label></li>
                    <li><asp:Label ID="lblTransport" runat="server" Text="Transportvorm: "></asp:Label><asp:Label ID="Transport" runat="server" Text="nvt"></asp:Label></li>
                </ul>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-2">
                <asp:Button CssClass="col-md-1 btn btn-default" ID="btnReport" runat="server" Text="Rapporteren" />
                <asp:Button CssClass="col-md-1 btn btn-default" ID="Button2" runat="server" Text="Vraag verwijderen" />
                <asp:Button CssClass="col-md-1 btn btn-default" ID="Button1" runat="server" Text="Afspraak maken" />
            </div>
            <asp:TextBox CssClass="col-md-5 form-control textbox-register" ID="tbReply" runat="server" Height="75px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button CssClass="col-md-1 btn btn-default" ID="btnReply" runat="server" Text="Reactie plaatsen" Height="75px" />
            
        </div>
        <div class="form-group">
            <div class="col-md-2"></div>
                <asp:GridView CssClass="col-md-6 table table-hover" ID="gvReplies" runat="server" Height="202px" Width="813px" AutoGenerateColumns="False" OnSelectedIndexChanged="gvReplies_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Datum" AccessibleHeaderText="Date" >
                        <ItemStyle CssClass="col-md-1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Reactie" AccessibleHeaderText="Text" >
                        <ItemStyle CssClass="col-md-3"/>
                        </asp:BoundField>
                        <asp:ButtonField HeaderText="Rapporteren" AccessibleHeaderText="Report" Text="Rapporteer" >
                        <ItemStyle CssClass="col-md-1" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
        </div>
    </div>
</asp:Content>
