<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GLA_Locker.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page || GLA Locker</title>
    <link href="Style/style.css" rel="stylesheet"/>
    <style>
        #pa, #us {
            font-size: 18px;
            font-weight: bold;
            margin: 0px;
            padding: 0px;
        }

        .inn {
            height: 18px;
            font-size: 14px;
            font-weight: 600;
            word-spacing: 2px;
        }

        td {
            margin: 7px;
        }
        #er{
            color: red;
        }
    </style>
</head>
<body>
    <div class="back">
        <p id="title">Welcome To GLA Locker</p>
        <div id="im">
            <div id="im_f"></div>
            <div id="im_m"><img src="Style/images/mornings.png" id="img_hey" /></div>
            <div id="im_l"></div>
        </div>
        <div id="p">
            <div id="f"></div>
            <div id="m">
                <form runat="server" autocomplete="off" method="post">
                    <table width="300px" runat="server" height="200px">
                        <tr>
                            <td width="50%">
                                <p id="us">USER :</p>
                            </td>
                            <td width="50%">
                                <asp:TextBox CssClass="inn" ID="uid" runat="server" placeholder="Enter Your UID."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p id="pa">PASSWORD : </p>
                            </td>
                            <td>
                                <asp:TextBox CssClass="inn" ID="password" TextMode="Password" runat="server" placeholder="Enter Your Password."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="tdd">
                                <asp:Button ID="btn_sub" Text="Login" runat="server" OnClick="btn_sub_Click" />
                                <p id="er"><asp:Label ID="err" runat="server"></asp:Label></p>
                            </td>
                        </tr>
                    </table>
                </form>
                <asp:Label ID="dummy" runat="server"></asp:Label>
            </div>
            <div id="s"></div>
        </div>
    </div>
</body>
</html>
