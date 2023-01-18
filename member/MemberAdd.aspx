<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberAdd.aspx.cs" Inherits="허혜민_인사관리.member.MemberAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 93px;
        }
        .auto-style6 {
            width: 93px;
            height: 27px;
        }
        .auto-style7 {
            height: 27px;
        }
        .auto-style8 {
            width: 93px;
            height: 24px;
        }
        .auto-style9 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td colspan="3">
                <h1 class="auto-style2">회원 가입</h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">id</td>
            <td>
                <asp:TextBox ID="txtID" runat="server" MaxLength="10"></asp:TextBox>
                (10문자 내)</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">pwd</td>
            <td>
                <asp:TextBox ID="txtPwd" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
                (8~20문자 내) </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">이름</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style5">E-mail</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:ImageButton ID="btsave" runat="server" ImageUrl="~/img/btn_save.gif" OnClick="btsave_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Text="Label"></asp:Label>
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
