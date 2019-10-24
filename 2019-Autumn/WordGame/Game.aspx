<%@ Page Title="Игрулечка" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="WordGame.Game" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="word" runat="server" Enabled="False" Font-Bold="True" Font-Size="XX-Large" Width="1800px" MaxLength="100"></asp:TextBox>
    <asp:Panel ID="panel" runat="server" Font-Size="Large"></asp:Panel>
    <asp:Button ID="back" runat="server" Text="<=" Width="64" Height="64" Font-Size="XX-Large" OnClick="back_Click" BackColor="Yellow" />
    <asp:Button ID="clear" runat="server" Text="[X]" Height="64" Width="64" Font-Size="XX-Large" OnClick="clear_Click" BackColor="Red" />
    <asp:Button ID="enter" runat="server" Text="(v)" Height="64" Width="64" Font-Size="XX-Large" BackColor="Lime" />
    <asp:Label ID="error" runat="server" Text=""></asp:Label>
</asp:Content>
