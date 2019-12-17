<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="NumberSearch.Pages.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 313px;
        }
        .style2
        {
            width: 575px;
        }
        .style4
        {
            width: 575px;
            font-family: "Trebuchet MS", sans-serif;
            color: #000066;
        }
        .style5
        {
            width: 64px;
            height: 64px;
        }
        .style6
        {
            color: #000000;
        }
        .style7
        {
            width: 32px;
            height: 32px;
        }
        .style8
        {
            width: 313px;
            height: 23px;
        }
        .style9
        {
            width: 575px;
            height: 23px;
        }
        .style10
        {
            height: 23px;
        }
        .auto-style1 {
            width: 288px;
            height: 57px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                <br />
                <br />
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8">
                </td>
            <td class="style9" bgcolor="#666666">
                <img alt="Interconnect Nigeria" class="auto-style1" src="../images/interconnect-logo.png" /><br />
            </td>
            <td class="style10">
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2" bgcolor="Silver" >
                <img alt="Help" class="style5" src="../images/Help2.png" /><br />
                <br />
                <span class="style6" 
                    style="font-family: &quot;Times New Roman&quot;,&quot;sans-serif&quot;;">Please 
                follow the steps below to carry out a quick search on a number’s status:</span><span 
                    style="font-family:&quot;Trebuchet MS&quot;,&quot;sans-serif&quot;;color:#00B050"><br />
                </span>
                <br />
                *<span class="style6" 
                    style="font-family: &quot;Times New Roman&quot;,&quot;sans-serif&quot;;">&nbsp; Enter the 
                captcha characters as shown on the screen to verify identity before access can be granted, once successful, click on the Enter site link, but 
                if unsuccessful, you will be required to try again.<br />
                <br />
                *&nbsp; Enter Mobile 
                Number. Note:<br />
                &nbsp;&nbsp;&nbsp;&nbsp; -Numbers can 
                only be in numeric format e.g. 08023389898<br />
                &nbsp;&nbsp;&nbsp;&nbsp; -Number format 
                is 08023389898 not 2348023389898<br />
                <br />
                *&nbsp; Numbers can 
                not be more than 11 characters.<br />
                <br />
                *&nbsp; Click on the 
                search button to view status.<br />
                <br />
                <br />
                <a href="ResolveCaptcha.aspx">Click here to continue.</a><br />
                <br />
                </span>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
