<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="허혜민_인사관리.Board.Reply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            width: 10px;
        }
        .auto-style6 {
            width: 60px;
        }
        .auto-style7 {
            width: 10px;
            height: 24px;
        }
        .auto-style8 {
            width: 60px;
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
            <td class="auto-style5">&nbsp;</td>
            <td colspan="2">
                <h1><strong>답변글</strong></h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">제목</td>
            <td>
                <asp:TextBox ID="txt_title" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">내용</td>
            <td>
                <asp:TextBox ID="txt_mes" runat="server" Height="150px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:ImageButton ID="imgbt_save" runat="server" ImageUrl="~/img/btn_save.gif" OnClick="imgbt_save_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
