<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="App_Themes/SiteStyles.css" />
    <title>Lab 8 Register Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Registrations</h1>

            <%-- dropdown list for student name selection --%>
            <div class="displayPanel">
                <label class="label">Student: </label> 
                <asp:DropDownList runat="server" ID="drpStuName" AutoPostBack="true" OnSelectedIndexChanged="drpStudent_SelectedChanged" CssClass="dropdown"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvStudent" ControlToValidate="drpStuName" CssClass="error" Display="Dynamic" ErrorMessage="Must select a student"></asp:RequiredFieldValidator>
            </div>

            <%-- display student selection message --%>
            <div class="row">
                <asp:Label ID="lbMessage" runat="server" CssClass="distinct"></asp:Label>  
            </div>
            <br />

            <%-- available course list display --%>
            <div class="listLabel">
                <p>Following courses are currently available for registration</p>
                
                <%-- display validation error message--%>
                <asp:Label ID="lbError" runat="server" CssClass="emphsis"></asp:Label>
                <br />
                <asp:CheckBoxList ID="cblCourses" runat="server" AutoPostBack="true"></asp:CheckBoxList>
                <br />
                <asp:Button ID="btnSave" Text="Save" OnClick="btnClickSave" runat="server" CssClass="button"/>
            </div>
            <br />
            <a href="AddStudent.aspx" > < Back to Add Students</a>
        </div>
    </form>
</body>
</html>
