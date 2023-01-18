<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="허혜민_인사관리.Board.Write" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
            float: left;
        }
        .auto-style5 {
            width: 18px;
        }
        .auto-style7 {
            width: 125px;
        }
        .auto-style8 {
            width: 125px;
            height: 24px;
        }
        .auto-style9 {
            height: 24px;
        }
        .auto-style10 {
            text-align: center;
            font-size: xx-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="left" class="auto-style4">
        <tr>
            <td class="auto-style5" rowspan="4">&nbsp;</td>
            <td class="auto-style10" colspan="2">
                <asp:Label ID="lbTitle" runat="server" Text="글쓰기"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">제목</td>
            <td class="auto-style9">
                <asp:TextBox ID="txttitle" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">내용</td>
            <td>
                <asp:TextBox ID="txtmes" runat="server" Height="220px" TextMode="MultiLine" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">파일</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Label ID="lbFile1" runat="server" Text="lbFile1"></asp:Label>
                <br />
                <asp:ImageButton ID="ibtsave" runat="server" ImageUrl="~/img/btn_save.gif" OnClick="ibtsave_Click" />
                <asp:ImageButton ID="ibt_rt" runat="server" ImageUrl="~/img/btn_return.gif" OnClick="ibt_rt_Click" />
                <asp:ImageButton ID="ibt_list" runat="server" ImageUrl="~/img/btn_list.gif" />
                <asp:ImageButton ID="ibt_home" runat="server" ImageUrl="~/img/w_home.gif" />
            </td>
        </tr>
    </table>
</asp:Content>
