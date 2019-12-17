<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResolveCaptcha.aspx.cs" Inherits="NumberSearch.Pages.ResolveCaptcha" %>

<%@ Register Assembly ="MSCaptcha" Namespace="MSCaptcha" TagPrefix="rsv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 288px;
            height: 57px;
            text-align: center;
            float: left;
        }
        .style4
        {
            width: 425px;
        }
        .style5
        {
            width: 444px;
        }
        .auto-style2
        {
            width: 423px;
        }
        </style>
</head>
<body>
    <table style="width:100%;">
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5" bgcolor="#999999">
        <img alt="Interconnect Nigeria" class="style1" 
            src="../images/interconnect-logo.png" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" rowspan="2">
                &nbsp;</td>
            <td class="style5">
    <form id="form1" runat="server">
    <div style="margin-left: 0px; margin-right: 0px">
        <br />
        <asp:Label ID="Label2" runat="server" 
            Text="Please verify the following information before you can be granted access."></asp:Label>
        <br />
        <br />
        <br />
    <rsv:CaptchaControl ID="captcha1" runat="server" CaptchaLength="5"
        CaptchaHeight = "60" CaptchaWidth="200" CaptchaLineNoise="None"
        CaptchaMinTimeout="5" CaptchaMaxTimeout="240" ForeColor="#00FFCC"
        BackColor="White" CaptchaChars="ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789"
        FontColor="Red" Width="382px" />
        <br />
        
        <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Verify" />
    
        <br />
    
        <br />
        <asp:LinkButton ID="siteLinkButton" runat="server" 
            PostBackUrl="~/Pages/NumberSearch.aspx" Visible="False">Enter Site</asp:LinkButton>
        <br />
    </div>
    </form>
            </td>
            <td rowspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </body>
</html>
