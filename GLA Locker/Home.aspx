<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GLA_Locker.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home || GLA Locker</title>
    <link rel="stylesheet" type="text/css" media="screen" href="/Style/homecss.css" runat="server" />
</head>
<body>
    <form runat="server">
        <div id="main" runat="server">
            <div id="slide" runat="server">
                <div id="title">
                    <div>
                        <p>GLA Locker</p>
                    </div>
                </div>
                <div id="profile">
                    <div id="pic">
                        <img style="width: 90%;" src="Style/images/user.png" />
                    </div>
                    <asp:Label ID="disp_name" runat="server"></asp:Label>
                    <p></p>
                    <asp:Label ID="mail" runat="server"></asp:Label>
                    <asp:Button CssClass="btn" ID="Button1" OnClick="logout" Text="Logout" runat="server" />
                </div>
            </div>
            <div id="cont" runat="server">
                <div id="nav">
                    <img id="dash_icn" src="Style/icons/dashboard.png" /><p>Dashboard</p>
                    <div id="spc"></div>
                    <asp:TextBox autocomplete="off" CssClass="right" placeholder="Search" ID="itm" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="search_btn" OnClick="search" runat="server">
                                    <img id="im" class="right" src="Style/icons/search.png" />
                    </asp:LinkButton>
                </div>
                <div id="cont_main">
                    <div id="top">
                        <div id="top_left">
                            <asp:Label ID="storage" CssClass="si" runat="server" Text="20MB "></asp:Label><p></p>
                            <asp:Label CssClass="si" runat="server" Text="used Out of "></asp:Label><p></p>
                            <asp:Label runat="server" ID="total" CssClass="si" Text="20GB."></asp:Label>
                        </div>
                        <div id="top_right">
                            <div id="progress">
                                <div id="pro2">
                                    <asp:Label ID="percent" runat="server" Text="Hello"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="add">
                        <asp:FileUpload  ID="in_file" runat="server"/>
                        <asp:Button ID="in_sub" runat="server" Text="Upload" OnClick="upload" />
                    </div>
                    <div id="_cont">
                        <asp:GridView BorderStyle="None" ID="_cont_files" runat="server" AutoGenerateColumns="false" EmptyDataRowStyle-CssClass="emp" EmptyDataText="No files uploaded !!">
                            <Columns>
                                <asp:BoundField DataField="Text" HeaderText="Uploaded Files"/>
                                <asp:TemplateField>
                                    <ItemTemplate >
                                        <asp:LinkButton ID="down" Text="Download" OnClick="download" runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="del" Text="Delete" runat="server" OnClick="delete" ></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
