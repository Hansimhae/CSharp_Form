<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="허혜민_인사관리.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        width: 85px;
    }
    .auto-style6 {
        font-size: xx-large;
    }
    .auto-style7 {
        width: 350px;
    }
        .auto-style8 {
            width: 85px;
            height: 24px;
        }
        .auto-style9 {
            width: 350px;
            height: 24px;
        }
        .auto-style10 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6" colspan="2">보고서</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Report_1.aspx" Target="_blank">사원 리스트( 삭제자 포함)</asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Report_2.aspx" Target="_blank">사원 리스트(삭제자)</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style9">
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Board/Complain_Report.aspx">신고 목록</asp:HyperLink>
            </td>
            <td class="auto-style10">
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Report_3.aspx">부서별 사원 번호</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
<p>
</p>
<p>
</p>
</asp:Content>
