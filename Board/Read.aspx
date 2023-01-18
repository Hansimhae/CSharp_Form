<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="허혜민_인사관리.Board.Read" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            font-size: xx-large;
            text-align: center;
        }
        .auto-style6 {
            height: 24px;
        }
        .auto-style7 {
            height: 24px;
            width: 151px;
        }
        .auto-style8 {
            width: 151px;
        }
        .auto-style10 {
            height: 24px;
            width: 17px;
        }
        .auto-style11 {
            width: 17px;
        }
        .auto-style12 {
            width: 17px;
            height: 23px;
        }
        .auto-style13 {
            width: 151px;
            height: 23px;
        }
        .auto-style14 {
            height: 23px;
        }
    </style>

    <script type="text/javascript">
       function ConfirmDelete() {
       return confirm("정말 삭제할까요?");
       }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style5" colspan="3"><strong>글 읽기</strong></td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style7">제목</td>
            <td class="auto-style6">
                <asp:Label ID="lb_title" runat="server" Text="lb_title"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
            <td class="auto-style13">글쓴이</td>
            <td class="auto-style14">
                <asp:Label ID="lb_writer" runat="server" Text="lb_writer"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">조회수</td>
            <td>
                <asp:Label ID="lb_count" runat="server" Text="lb_count"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">내용</td>
            <td>
                <asp:Label ID="lb_Message" runat="server" Text="lb_Message"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">날짜</td>
            <td>
                <asp:Label ID="lbDate" runat="server" Text="lbDate"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style8">파일</td>
            <td>
                <asp:HyperLink ID="HyperLink7" runat="server">HyperLink</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ImageButton ID="Imgbt_reply" runat="server" ImageUrl="~/img/btn_reply.gif" OnClick="Imgbt_reply_Click" />
                <asp:ImageButton ID="Imgbt_edit" runat="server" ImageUrl="~/img/btn_edit.gif" OnClick="Imgbt_edit_Click" style="height: 20px" />
                <asp:ImageButton ID="Imgbt_del" runat="server" ImageUrl="~/img/btn_delete.gif" OnClick="Imgbt_del_Click" OnClientClick="return ConfirmDelete()" />
                <asp:ImageButton ID="Imgbt_list" runat="server" ImageUrl="~/img/btn_list.gif" OnClick="Imgbt_list_Click" PostBackUrl="~/Board" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/singo.jpg" OnClick="ImageButton2_Click" PostBackUrl="~/Board/complain.aspx" Width="30px" />
            </td>
        </tr>
    </table>
</asp:Content>
