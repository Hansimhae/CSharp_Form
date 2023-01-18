<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Insa.aspx.cs" Inherits="허혜민_인사관리.Insa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
        width: 10px;
    }
    .auto-style6 {
        width: 100px;
    }
    .auto-style7 {
        width: 10px;
        height: 30px;
    }
    .auto-style8 {
        width: 100px;
        height: 30px;
    }
    .auto-style9 {
        height: 30px;
    }
    .auto-style10 {
        height: 43px;
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
        <td colspan="3" class="auto-style10">
            <h1>인사관리 </h1>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">사원번호</td>
        <td>
            <asp:TextBox ID="TextBox사원번호" runat="server"></asp:TextBox>
        &nbsp;<asp:Button ID="Button_search" runat="server" Text="검색" OnClick="Button_search_Click" />
        &nbsp;
            <asp:Label ID="lbInsert" runat="server" Text="lnInsert"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">이름</td>
        <td>
            <asp:TextBox ID="TextBox이름" runat="server"></asp:TextBox>
&nbsp; 성별:&nbsp;
            <asp:RadioButton ID="rd_f" runat="server" Text="여" GroupName="성별" />
            <asp:RadioButton ID="rb_m" runat="server" Text="남" GroupName="성별" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">사진</td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Image ID="ImgPic" runat="server" Height="250px" Width="250px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">생년월일</td>
        <td>
            <asp:TextBox ID="TextBox생년월일" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">재직상태</td>
        <td>
            <asp:DropDownList ID="DropDownList재직상태" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">입사일자</td>
        <td>
            <asp:TextBox ID="TextBox입사일자" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
&nbsp;&nbsp; 부서&nbsp;
            <asp:DropDownList ID="DropDownList부서" runat="server" Width="100px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style7"></td>
        <td class="auto-style8">퇴사일자</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBox퇴사일자" runat="server" MaxLength="10" TextMode="Date"></asp:TextBox>
&nbsp;&nbsp; 직급&nbsp;
            <asp:DropDownList ID="DropDownList직급" runat="server" Width="100px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">전화</td>
        <td>
            <asp:TextBox ID="TextBox전화" runat="server" MaxLength="20" TextMode="Phone"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">주소</td>
        <td>
            <asp:TextBox ID="TextBox주소" runat="server" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td>
            <asp:Button ID="Button_save" runat="server" Text="저장" OnClick="Button_save_Click" />
&nbsp;
            <asp:Button ID="Button_delete" runat="server" Text="삭제" OnClick="Button_delete_Click" OnClientClick="return ConfirmDelete()" />
&nbsp;
            <asp:Button ID="Button_clear" runat="server" Text="전체 삭제" OnClick="Button_clear_Click" />
        </td>
    </tr>
</table>
</asp:Content>
