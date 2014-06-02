<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        ¡Le damos la bienvenida<b><%: Page.User.Identity.Name %></b>!
       
<%
    }
    else {
%> 
       Hola mundo :) 
<%
    }
%>
