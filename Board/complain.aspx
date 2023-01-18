<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="complain.aspx.cs" Inherits="허혜민_인사관리.Board.complain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            height: 24px;
        }
        .auto-style6 {
            height: 24px;
            width: 100px;
        }
        .auto-style7 {
            width: 100px;
        }
        .auto-style8 {
            width: 100px;
            height: 27px;
        }
        .auto-style9 {
            height: 27px;
        }
        .auto-style10 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style2" colspan="2">신고하기</td>
        </tr>
        <tr>
            <td class="auto-style6">제목</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBoxtitle" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">내용</td>
            <td>
                <asp:TextBox ID="TextBoxMes" runat="server" Height="140px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">
                <asp:Button ID="Buttonsave" runat="server" OnClick="Button1_Click" Text="확인" />
                <asp:Button ID="Buttoncancle" runat="server" PostBackUrl="~/" Text="취소" />
            </td>
        </tr>
    </table>
</asp:Content>
