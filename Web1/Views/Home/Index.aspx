<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="keywords" content="<%= this.Html.Language("Keywords") %>" />
    <meta name="description" content="<%= this.Html.Language("Description") %>" />
    <title>
        <%= this.Html.Language("CompanyName") %>
        --
        <%= this.Html.Language("Home") %></title>
    <% var language = HttpContext.Current.Session["isCN"];
       var isCN = language == null || language.ToString() != false.ToString(); %>
    <link href="/Content/Site.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin: 60px 0 0 0;
        }
    </style>
</head>
<body>
    <div id="body">
        <div id="headc">
            <div id="name">
                <img src="/Images/<%= this.Html.Language("LogoImage") %>.jpg" alt="logo" style="border-width: 0px;" /></div>
            <div id="title">
                <img alt="中文" src="/Images/list1.jpg" /><a href="/Home/ChangeLanguage/?language=zh-CN">中文</a>
                <img alt="English" src="/Images/list1.jpg" /><a href="/Home/ChangeLanguage/?language=en-US">English</a>
                <span>
                    <%= DateTime.Now.ToString(this.Html.Language("DateTimeToString"))%></span></div>
            <div id="menu">
                <span><a href="/Index.html"><font color="#ffffff">
                    <%= this.Html.Language("Home") %>
                </font></a>|
                    <% foreach (var item in this.ViewData["ForumList"] as IEnumerable<Domain.Forum>)
                       { %>
                    <a href="/<%= item.ID %>/Category.html"><font color="#ffffff">
                        <%= isCN ? item.Name : item.NameEn%></font></a> |
                    <%} %>
                </span>
            </div>
        </div>
        <div id="middle">
            <div id="index">
                <div class="flashbg">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                        width="920" height="276">
                        <param name="movie" value="/Images/flashbg1.swf" />
                        <param name="quality" value="high" />
                        <param name="wmode" value="transparent" />
                        <embed src="/Images/flashbg1.swf" width="920" height="276" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
                            type="application/x-shockwave-flash" wmode="transparent"></embed>
                    </object>
                </div>
                <img id="ctl00_ContentPlaceHolder1_Image1" src="/Images/<%= this.Html.Language("IndexImage") %>.jpg" alt="欢迎光临<%= this.Html.Language("CompanyName") %>"
                    style="border-width: 0px;" /></div>
        </div>
        <div id="bottom">
            <div class="hr">
            </div>
            <div id="copy">
                <div class="gs">
                    <img alt="copy" src="/Images/gs.jpg" /></div>
                <div class="txt">
                    <%= this.Html.Language("Address") %>
                    Email：postmaster@91realsoft.com
                    <br />
                    <%= this.Html.Language("Telephone") %>
                    : +86-991-6684302
                    <%= this.Html.Language("Fax") %>
                    ：+86-991-3839396
                    <br />
                    新ICP2009019
                    &nbsp;&nbsp;
                    <script src="http://s21.cnzz.com/stat.php?id=3163441&web_id=3163441&show=pic" language="JavaScript"></script>
                     </div>
            </div>
        </div>
    </div>
</body>
</html>
