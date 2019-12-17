<%@ Page Title="Search" Language="C#" MasterPageFile="~/SharedPages/numberSearch.Master" AutoEventWireup="true" CodeBehind="NumberSearch.aspx.cs" Inherits="NumberSearch.Pages.NumberSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/YahooGridView.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
    {
        width: 288px;
        height: 57px;
    }
        .style3
        {
            width: 338px;
        }
        .style4
        {
            width: 204px;
        }
        .style5
        {
            width: 390px;
        }
        .auto-style2
        {
            width: 346px;
        }
        .auto-style3
        {
            width: 308px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <%--<span>Number Search</span>
            <p></p>--%>
            </div>
        <div style="margin-left:300px; margin-top:30px">
            <div>
                <table class="style1">
                    <tr>
                        <td bgcolor="#666666" class="style5">
                            <img alt="" class="style2" src="../images/interconnect-logo.png" /></td>
                        <td>
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Powered by <a href="http://www.coure-tech.com">COURE</a><br />
                                        <br />
                                        <a href="Help.aspx">Help</a></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td><label for="" >Number</label></td>
                        <td>
                            <asp:TextBox ID="txtSearch" runat="server" Width="250px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtSearch" ValidationGroup="valSearch" 
                                Font-Size="11px" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style4">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                                ValidationGroup="valSearch" onclick="btnSearch_Click"/>
                        </td>
                        <td>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ErrorMessage="Invalid Entry" ControlToValidate="txtSearch" 
                            ValidationGroup="valSearch1" Font-Size="11px" ForeColor="Red">
                            </asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                </table>
            </div>
            
        </div>
        <br />
        <br />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="formatErro" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <div style="margin-left:40px">
                <asp:Panel ID="pnlSearch" runat="server" Visible="true">
                    <asp:GridView ID="grvNumberSearch" runat="server" Width="55%" 
                    AutoGenerateColumns="false" CssClass="GridViewStyle" EmptyDataText="Result Not Found!"
                     Font-Size="12px"  ShowHeaderWhenEmpty="True" AllowPaging="true" PageSize="10" 
                        BackColor="#999999" BorderColor="#999999">
                        <Columns>
                            <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate> 
                                        <%# Container.DataItemIndex + 1 %> 
                                    </ItemTemplate> 
                                           <HeaderStyle HorizontalAlign="Left" Width="5%" Font-Bold="True" />
                                    <ItemStyle Width="2%" /> 
                                </asp:TemplateField>
                                <asp:BoundField DataField="Number" HeaderText="Number" 
                                    HeaderStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Network" 
                                    HeaderStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
                                </asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="RowStyle" BackColor="#999999" BorderColor="#CCCCCC" 
                            ForeColor="Black" />
                        <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                        <PagerSettings PageButtonCount="15" />
                        <PagerStyle CssClass="PagerStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" BackColor="#999999" 
                            BorderColor="#999999" />
                        <HeaderStyle CssClass="HeaderStyle" ForeColor="Black" />
                        <EditRowStyle CssClass="EditRowStyle" BackColor="#999999" 
                            BorderColor="#999999" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </asp:Panel>
        </div>
        <br /><br />
    </div>
    <table style="width:100%;">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
