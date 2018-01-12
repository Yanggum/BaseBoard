<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonClientScript.ascx.cs" Inherits="Pc.PcBoard.Web.Base.StaticHeader.CommonClientScript" %>

<%--Favicon--%>
<link rel="shortcut icon" href="<%= this.GetSiteUrl("favicon.ico") %>">

<%-- meta tag --%>
<meta http-equiv="Content-Type" content="text/html" />
<meta http-equiv="Page-Enter" content="revealTrans(Duration=0.2,Transition=12)">
<meta http-equiv="Page-Exit" content="revealTrans(Duration=0.2, Transition=12)">

<%-- design --%>
<link type="text/css" rel="stylesheet" href="<%=this.GetSiteUrl("css/bootstrap.min.css")%>"/>
<link type="text/css" rel="stylesheet" href="<%=this.GetSiteUrl("css/bootstrap-theme.min.css")%>"/>
<link type="text/css" rel="stylesheet" href="<%=this.GetSiteUrl("css/dashboard.css")%>"/>

<%-- script --%>
<script type="text/javascript" src="<%=this.GetSiteUrl("js/Common/jquery-3.2.1.js")%>"></script>
<script type="text/javascript" src="<%=this.GetSiteUrl("js/Common/vue.js")%>"></script>
<script type="text/javascript" src="<%=this.GetSiteUrl("js/Common/bootstrap.js")%>"></script>

