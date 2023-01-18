<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="허혜민_인사관리.Board.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style4 {
        width: 100%;
    }
    .auto-style5 {
            width: 36px;
        }
    .auto-style6 {
        width: 36px;
        height: 24px;
    }
    .auto-style7 {
        height: 24px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style4">
    <tr>
        <td class="auto-style6"></td>
        <td class="auto-style7">글목록</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                
                <Columns>

                   
                    <asp:BoundField DataField="id" HeaderText="번호">
                    <HeaderStyle Width="60px" />

                    <ItemStyle HorizontalAlign="Center" />

                    </asp:BoundField>

                    <asp:TemplateField HeaderText="제목" HeaderStyle-Width="330px">
                        <ItemTemplate>

                            <%# ShowDepth((int)Eval("depth")) %>
                            <%# ShowReplayIcon((int)Eval("inner_id")) %>
                            <%# ShowTitle( (int)Eval("ID"),
                                Eval("title").ToString(),
                                Eval("del_flag").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="writer" HeaderText="이름">
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="날짜" HeaderStyle-Width="70px">
                        <ItemTemplate>
                            <%# ShowDate(Eval("reg_date").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="read_count" HeaderText="조회">
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <%--<asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />--%>
                    <%--<asp:BoundField DataField="writer" HeaderText="writer" SortExpression="writer" />--%>
                    <%--<asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />--%>
                    <%--<asp:BoundField DataField="inner_id" HeaderText="inner_id" SortExpression="inner_id" />>--%>
                    <%--<asp:BoundField DataField="ref_id" HeaderText="ref_id" SortExpression="ref_id" />
                    <asp:BoundField DataField="depth" HeaderText="depth" SortExpression="depth" />
                    <asp:BoundField DataField="read_count" HeaderText="read_count" SortExpression="read_count" />--%>
                    <%--<asp:BoundField DataField="del_flag" HeaderText="del_flag" SortExpression="del_flag" />--%>
                    <%--<asp:BoundField DataField="reg_date" HeaderText="reg_date" SortExpression="reg_date" />--%>
                </Columns>
                
                <EmptyDataTemplate>
                등록된 게시물이 없습니다.
                </EmptyDataTemplate>
                
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>" SelectCommand="SELECT [id], [writer], [title], [ref_id], [inner_id], [depth], [read_count] ,[reg_date] , [del_flag] FROM [board] order by ref_id DESC, inner_id ASC "></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/btn_write.gif" PostBackUrl="~/Board/Write.aspx" />
        </td>
    </tr>
</table>
</asp:Content>
