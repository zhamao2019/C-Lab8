<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab 8 Add Students</title>
    <link rel="stylesheet" href="App_Themes/SiteStyles.css" />
 </head>
<body>
    <form id="form1" runat="server" class="form">
        <div>
            <h1>Students</h1>

            <%--form select field--%>
            <div class="displayPanel">
                <label class="label">Student Name: </label>
                <asp:TextBox runat="server" ID="stuName" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rqvStuName" ErrorMessage="Required!" CssClass="error" Display="Dynamic" ControlToValidate="stuName" EnableClientScript="true"></asp:RequiredFieldValidator>
            </div>
            <div class="displayPanel">
                <label class="label">Student Type: </label>
                <asp:DropDownList runat="server" ID="stuType" CssClass="dropdown"></asp:DropDownList>    
                <asp:RequiredFieldValidator runat="server" ID="rqvStuType" ErrorMessage="Must select one!" CssClass="error" Display="Dynamic" ControlToValidate="stuType" EnableClientScript="true"></asp:RequiredFieldValidator>
            </div>
            <div class="displayPanel">
                <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="ClickAdd" CssClass="button" />
            </div>
            <%--form select field end--%>

            <%--table field--%>
            <div class="displayPanel">
                <asp:Table runat="server" CssClass="table" ID="stuTable">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
            <%--table field end--%>

            <div class="displayPanel">
                <a href="RegisterCourse.aspx">> Go to Register Courses</a>
            </div>
        </div>
    </form>
</body>
</html>
