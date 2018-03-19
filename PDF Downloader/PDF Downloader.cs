using Excel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Downloader
{
    public partial class PDFDownloader : Form
    {
        private SemaphoreSlim SemCrawl { get; set; }
        private SemaphoreSlim SemFiles { get; set; }
        private SemaphoreSlim SemExcel { get; set; }

        private bool RunMe { get; set; }

        private String __currentData { get; set; }
        private String __currentFolder { get; set; }
        private String __thisFolder { get; set; }


        private int CounterPDFFound { get; set; }
        private int CounterPDFDownload { get; set; }
        private int CounterRssFound { get; set; }
        private int CounterLinkCrawled { get; set; }
        private int CounterLinkFound { get; set; }
        private int CounterErrors { get; set; }
        List<String> LinksCrawled = new List<String>();
        List<String> LinksCrawledSite = new List<String>();
        List<String> LinksSavedPdf = new List<String>();
        Dictionary<String, String> LinksRss = new Dictionary<String, String>();
        List<String> LinksJunk = new List<String>();
        List<String> LinksError = new List<String>();
        Queue<String> LinksNew = new Queue<String>();
        Queue<String> LinksPDF = new Queue<String>();
        Queue<String> LinksSites = new Queue<String>();
        Queue<String> Logs = new Queue<String>();
        public PDFDownloader()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            //set data directort to current folder 
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            //set download folder label
            __currentFolder = System.IO.Directory.GetCurrentDirectory();
            __currentData = System.IO.Directory.GetCurrentDirectory();
            labelMessage.Text = "Download Folder:" + this.__currentFolder;
            //set file download semaphore
            SemFiles = new SemaphoreSlim(0, 5);
        }
        private HttpWebRequest CreateRequest(String link)
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            ServicePointManager.Expect100Continue = false;
            HttpWebRequest __webrequest = (HttpWebRequest)HttpWebRequest.Create(link);
            __webrequest.Headers.Add("Cache-Control", "no-cache");
            __webrequest.AllowAutoRedirect = false;
            __webrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:24.0) Gecko/20100101 Firefox/24.0";
            __webrequest.Timeout = 25000;
            __webrequest.Method = "GET";
            __webrequest.AutomaticDecompression = System.Net.DecompressionMethods.GZip;
            __webrequest.ProtocolVersion = HttpVersion.Version11;
            __webrequest.KeepAlive = true;
            __webrequest.Proxy = null;
            __webrequest.ServicePoint.ConnectionLeaseTimeout = 0;
            __webrequest.ServicePoint.MaxIdleTime = 50;
            __webrequest.ServicePoint.Expect100Continue = false;
            __webrequest.AllowWriteStreamBuffering = true;
            return __webrequest;
        }
        private void CrawlPDF(String link, String original,String name)
        {
            original = ConvertURLToHTML(original);
            String __link;
            HttpWebRequest __webrequest;
            HttpWebResponse __webResponse;
            if (link[0] == '/')
                __link = ConvertURLToHTML(original + link);
            else
                __link = ConvertURLToHTML(link);
            try
            {
                __webrequest = CreateRequest(link);
                __webrequest.Timeout = 120000; //timeout set to 2 minutes
                __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                var __code = __webResponse.StatusCode;
                if (__code == System.Net.HttpStatusCode.MovedPermanently ||
                    __code == System.Net.HttpStatusCode.SeeOther)
                {
                    __webrequest = CreateRequest(link);
                    __webrequest.AllowAutoRedirect = true;
                    __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                    __code = __webResponse.StatusCode;
                }
                if (__code == HttpStatusCode.OK)
                {
                    var __size = __webResponse.ContentLength; //accept file less than 5MB, skip if no Content Length recieved
                    if ((__size > 0 && __size < 10000000) || __size==-1)
                    {
                        System.IO.Stream __stream = __webResponse.GetResponseStream();
                        var buffer = new Byte[10000000];
                        System.IO.MemoryStream __memoryStream = new System.IO.MemoryStream();
                        int count = 0;
                        do
                        {
                            count = __stream.Read(buffer, 0, buffer.Length);
                            __memoryStream.Write(buffer, 0, count);
                            if (count == 0)
                            {
                                break;
                            }
                        } while (true);
                        __webrequest.Abort();
                        __webResponse.Close();
                        __stream.Close();
                        var s = new Thread(() => SavePDF(__memoryStream, link, original,name));
                        s.Start();
                        SemFiles.WaitAsync();
                        GC.Collect();
                    }
                }
                else
                {
                    LinksError.Add(__link);
                    AddToLog("Error in " + __link);
                }
            }
            catch (Exception e)
            {
                LinksError.Add(__link);
                AddToLog(e.Message);
            }
            finally
            {
                SemCrawl.Release();
                UpdateLinkDatabase(link);
            }
        }
        void Crawl(String link, String original)
        {
            HtmlAgilityPack.HtmlDocument __htmlSite = new HtmlAgilityPack.HtmlDocument();
            original = ConvertURLToHTML(original);
            String __link;
            String __htmlString;
            HtmlNodeCollection __allElements = null;
            HttpWebRequest __webrequest;
            HttpWebResponse __webResponse;
            bool ReleaseAgain = true;
            if (link[0] == '/')
                __link = ConvertURLToHTML(original + link);
            else
                __link = ConvertURLToHTML(link);
            try
            {
                __webrequest = CreateRequest(link);
                __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                var __code = __webResponse.StatusCode;
                if (__code == System.Net.HttpStatusCode.MovedPermanently ||
                    __code == System.Net.HttpStatusCode.SeeOther ||
                    __code == System.Net.HttpStatusCode.Found)
                {
                    __webrequest = CreateRequest(link);
                    __webrequest.AllowAutoRedirect = true;
                    __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                    __code = __webResponse.StatusCode;
                }
                if (__code == System.Net.HttpStatusCode.OK)
                {
                    var __type = __webResponse.ContentType;
                    if (__type.Contains("text/html") || __type.Contains("application/xhtml+xml"))
                    {
                        System.IO.Stream __stream = __webResponse.GetResponseStream();
                        System.IO.BufferedStream __buffer = new System.IO.BufferedStream(__stream);
                        System.IO.StreamReader __reader = new System.IO.StreamReader(__buffer);
                        __htmlString = __reader.ReadToEnd();
                        __htmlString = __htmlString.TrimStart();
                        __link = __webResponse.ResponseUri.AbsoluteUri;
                        __webrequest.Abort();
                        __webResponse.Close();
                        __buffer.Close();
                        __reader.Close();
                        __stream.Close();
                        GC.Collect();
                        if (__htmlString != null && __htmlString != "")
                        {
                            __htmlSite.LoadHtml(__htmlString);
                            __allElements = __htmlSite.DocumentNode.SelectNodes("//a");
                            SaveFile(__htmlString, link, original);
                        }
                        GC.Collect();
                    }
                    else if (__type.Contains("application/pdf"))
                    { 
                        var __name = __webResponse.Headers["Content-Disposition"];
                        if (__name != null)
                        {
                            __name = __name.Substring(__name.LastIndexOf("=\"") + 1).Replace("\"", "").Replace(";","");
                        }
                        ReleaseAgain = false;
                        CrawlPDF(link,original,__name);
                    }
                }
                else
                {
                    LinksError.Add(__link);
                    AddToLog("Error in: " + __link);
                }
            }
            catch (Exception e)
            {
                LinksError.Add(__link);
                AddToLog(e.Message);
            }
            if (__allElements != null)
            {
                foreach (HtmlNode linkin in __allElements)

                {
                    try
                    {
                        if (linkin != null)
                        {
                            if (linkin.Attributes["href"] != null)
                            {
                                String temp = linkin.Attributes["href"].Value;
                                temp = temp.Trim();
                                if (!IsJunk(temp))
                                {
                                    LinksJunk.Add(temp);
                                    temp = ConvertURLToHTML(MakeOriginalUri(temp, original, __link));
                                    if (temp != null && temp != "" && CorrectFormat(original, temp, true) && !IsAdded(temp) && !IsCrawled(temp))
                                    {
                                        LinksNew.Enqueue(temp);
                                        AddToLinkDatabase(original, temp);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }

                }
                GC.Collect();
            }
            UpdateLinkDatabase(link);
            if (ReleaseAgain)
                SemCrawl.Release();
        }
        private void AddToLog(string message)
        {
            Logs.Enqueue(message + " -> " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
        }
        void SavePDF(System.IO.MemoryStream file, String link, String original,String name)
        {
            String Filename = "";
            if (name != null && name != "")
                Filename = name;
            if (link[0] == '/')
            {
                if (link[link.Length - 1] == '/')
                    link = link.Substring(0, link.Length - 1);
                LinksCrawled.Add(original + link);
                LinksSavedPdf.Add(original + link);

            }
            else if (link == original)
            {
                LinksCrawled.Add(link);
                LinksSavedPdf.Add(link);
                if (Filename=="")
                    Filename = link.Substring(link.LastIndexOf("/") + 1)+".pdf";
                link = link.Replace(original, "/");
            }
            else
            {
                if (link[link.Length - 1] == '/')
                    link = link.Substring(0, link.Length - 1);
                LinksCrawled.Add(link);
                LinksSavedPdf.Add(link);
                link = GetRelativeUrl(original, link);
            }
            if (Filename =="")
                Filename= DecodeURL(link);
            Filename = this.__thisFolder + "\\" + Filename.Substring(Filename.LastIndexOf("/") + 1);
            if (!System.IO.File.Exists(Filename))
            {
                try
                {
                    var result = file.ToArray();
                    System.IO.FileStream fs = new System.IO.FileStream(Filename, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                    fs.Write(result, 0, result.Length);
                    fs.Close();
                    file.Close();
                    AddToLog("Downloaded: " + Filename);
                }
                catch (Exception e)
                {
                    AddToLog(e.Message);
                }
                finally
                {
                    SemFiles.Release();
                }
            }

            GC.Collect();
        }
        void SaveFile(String html, String link, String original)
        {
            if (link[0] == '/')
            {
                if (link[link.Length - 1] == '/')
                    link = link.Substring(0, link.Length - 1);
                LinksCrawled.Add(original + link);
            }
            else if (link == original)
            {
                LinksCrawled.Add(link);
                link = link.Replace(original, "/");
            }
            else
            {
                if (link[link.Length - 1] == '/')
                    link = link.Substring(0, link.Length - 1);
                LinksCrawled.Add(link);
            }
            GC.Collect();
        }
        private void RefreshLabels()
        {
            labelLinksCrawled.Text = "" + this.LinksCrawled.Count;
            labelLinksFound.Text = "" + (this.LinksJunk.Count);
            labelPDFFound.Text = "" + (this.LinksPDF.Count + this.LinksSavedPdf.Count);
            labelPDFDownload.Text = "" + this.LinksSavedPdf.Count;
            labelErrors.Text = "" + this.LinksError.Count;
            labelRSSFound.Text = "" + this.LinksRss.Count;
            while (Logs.Count > 0)
                listBoxLog.Items.Add(Logs.Dequeue());
        }
        bool IsAdded(String link)
        {
            if (LinksNew.Contains(link) ||
                LinksNew.Contains(link.Replace("www.", "")) ||
                LinksNew.Contains(link.Replace("https://", "http://")))
                return true;
            if (LinksPDF.Contains(link) ||
                LinksPDF.Contains(link.Replace("www.", "")) ||
                LinksPDF.Contains(link.Replace("https://", "http://")))
                return true;
            return false;
        }
        bool IsJunk(String link)
        {
            if (this.LinksJunk.Contains(link))
                return true;
            return false;
        }
        bool IsCrawled(String link)
        {
            if (this.LinksCrawled.Contains(link) ||
                this.LinksCrawled.Contains(link.Replace("www.", "")) ||
                this.LinksCrawled.Contains(link.Replace("https://", "http://")))
                return true;
            if (this.LinksError.Contains(link))
                return true;
            return false;
        }
        bool CorrectFormat(String original, String link, bool type)
        {
            String extensions = link.Substring(link.LastIndexOf(".") + 1);
            if (extensions.Length == 3 || extensions.Length == 4)
            {
                if (extensions.ToLower() != "pdf")
                    return false;
            }
            if (extensions.Length == 3)
            {
                if (extensions.ToLower() == "pdf")
                {
                    if (!IsAdded(link) && !IsCrawled(link))
                    {
                        LinksPDF.Enqueue(link);
                        if (type)
                            AddToLinkDatabase(original, link);
                    }
                    return false;
                }
            }
            if (link.ToLower().Contains("javascript:") || link.Contains("/../")
                || link.ToLower().Contains("&amp;&amp;") ||
                link.ToLower().Contains("&amp;amp;"))
            { //inline javascript
                return false;
            }
            return true;
        }
        String ConvertURLToHTML(String URL)
        {
            if (URL != null)
            {
                if (!URL.Contains("http://") && !URL.Contains("https://"))
                {
                    URL = "http://" + URL;
                }
                if (URL[URL.Length - 1] == '/')
                {
                    URL = URL.Substring(0, URL.Length - 1);
                }
                return URL;
            }
            return null;
        }
        String DecodeURL(String URL)
        {
            return Uri.UnescapeDataString(URL);
        }
        String EncodeURL(String URL)
        {
            return Uri.EscapeDataString(URL);
        }
        String MakeOriginalUri(String link, String original, String current)
        {
            link = link.Trim();
            if (link.Length == 0) //root
                return original;
            else
            {
                int result = IsSubDomain(link, original);
                GC.Collect();
                if (result == 0)
                { //this is inside relative page
                    if (current != original)
                    {
                        if (current.LastIndexOf("/") != current.Length)
                        {
                            current = current.Substring(0, current.LastIndexOf("/"));
                        }
                        if (link[0] != '/')
                            return current + "/" + link;
                        else
                            return current + link;
                    }
                    else
                    {
                        if (link[0] != '/')
                            return current + "/" + link;
                        else
                            return current + link;
                    }
                }
                else if (result == 1 || result == 8 || result == 9)
                    return null;
                else if (result == 2)
                { //subdomain
                    return null;
                }
                else if (result == 4)
                { //a link in subdomain
                    return null;
                }
                else if (result == 5)
                {  // (./) root (../) one up
                    current = current.Substring(0, current.LastIndexOf("/"));
                    while (link.StartsWith("../") || link.StartsWith("./"))
                    {
                        if (current.Equals(""))
                            return null;
                        if (link.StartsWith("../"))
                            link = link.Substring(3, link.Length - 3);
                        else
                            link = link.Substring(2, link.Length - 2);
                        if (!current.Equals(original))
                            current = current.Substring(0, current.LastIndexOf("/"));

                    }
                    return current + "/" + link;
                }
                else if (result == 7) //relative to base href
                {
                    return original + link;
                }
                else if (result == 10)
                {
                    if (current != original)
                    {
                        if (current.Contains("?"))
                            current = current.Substring(0, current.LastIndexOf("?"));
                        return current + link;
                    }
                    else
                    {
                        return current + link;
                    }
                }
            }
            return link;//absolute link
        }
        String GetRelativeUrl(String original, String link)
        {
            if (original.Contains("www.") && !link.Contains("www."))
            {
                original = original.Replace("www.", "");
            }
            if (!original.Contains("www.") && link.Contains("www."))
            {
                link = link.Replace("www.", "");
            }
            if (!original.Contains("https://") && link.Contains("https://"))
            {
                link = link.Replace("https://", "http://");
            }
            if (original.Contains("https://") && !link.Contains("https://"))
            {
                original = original.Replace("https://", "http://");
            }
            link = link.Replace(original, "");
            return link;
        }
        int IsSubDomain(String link, String original)
        {
            if (link.Length > 1)
            {
                if (link[0] == '/' && link[1] == '/')
                {
                    link = link.Replace("//", "");
                    link = ConvertURLToHTML(link);
                }
            }
            if (link[0] == '/' && link.Length > 1)
            {
                if (!link.Contains("http://") && !link.Contains("://"))
                    return 7; //relative to base href
                else
                    return 1;  //redirect to other sites
            }
            else
            {
                try
                {
                    Uri outUri;
                    if (Uri.TryCreate(link, UriKind.Absolute, out outUri)
                        && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps))
                    {
                        var linkURI = new Uri(link);
                        var leftURI = linkURI.GetLeftPart(UriPartial.Authority);
                        var hostLink = linkURI.Host.Replace("www.", "");
                        var originalURL = new Uri(original);
                        var hostOriginal = originalURL.Host.Replace("www.", "");
                        link = ConvertURLToHTML(link);
                        if (hostLink.Contains(hostOriginal) && hostLink != hostOriginal)
                        {
                            if (link == leftURI)
                            {
                                return 2; //subdomain
                            }
                            else
                            {
                                return 4; //a link in subdomain
                            }
                        }
                        else if (hostLink.Contains(hostOriginal) && hostLink == hostOriginal)
                        {
                            return 6; //absolute link
                        }
                        return 1; //external links to other sites
                    }
                    else
                    {
                        if (link.Contains("./"))
                        { // ./ links 
                            return 5;
                        }
                        if (link[0] == '#')
                        { //anchor in current page
                            return 8;
                        }
                        if (link.Contains("http://") || link.Contains("https://") || link.Contains("www."))
                            return 9; //no well format
                        if (link[0] == '?')
                        { //cut from question mark in query
                            return 10;
                        }
                        return 0; //a relative path inside a page
                    }
                }
                catch (Exception)
                {

                }
            }
            return 0; //a relative path inside a page
        }
        bool CheckType(String link)
        {
            System.Net.HttpWebRequest __webrequest;
            System.Net.HttpWebResponse __webResponse;
            try
            {
                __webrequest = CreateRequest(link);
                __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                var __type = __webResponse.ContentType;
                __webrequest.Abort();
                __webResponse.Close();
                if (__type.Contains("application/rss+xml") || __type.Contains("application/atom+xml") || __type.Contains("text/xml"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        String FindRssLink(String link, String original, int level)
        {
            int __thisLevel = level;
            __thisLevel++;
            if (__thisLevel > 2)
            {
                SemCrawl.Release();
                return null;
            }
            link = ConvertURLToHTML(link);
            HtmlAgilityPack.HtmlDocument __htmlSite = new HtmlAgilityPack.HtmlDocument();
            List<String> __secondChance = new List<String>();
            String __htmlString;
            String __rssLink = null;
            bool __found = false;
            HtmlNodeCollection __linkRSSTag;
            HtmlNodeCollection __linkAtomTag;
            HtmlNodeCollection __aTag;
            HttpWebRequest __webrequest;
            HttpWebResponse __webResponse;
            try
            {
                __webrequest = CreateRequest(link);
                __webResponse = (HttpWebResponse)__webrequest.GetResponse();
                var __type = __webResponse.ContentType;
                if (__type.Contains("text/html") || __type.Contains("application/xhtml+xml"))
                {
                    System.IO.Stream __stream = __webResponse.GetResponseStream();
                    System.IO.BufferedStream __buffer = new System.IO.BufferedStream(__stream);
                    System.IO.StreamReader __reader = new System.IO.StreamReader(__buffer);
                    __htmlString = __reader.ReadToEnd();
                    __htmlString = __htmlString.TrimStart();
                    __webrequest.Abort();
                    __webResponse.Close();
                    __buffer.Close();
                    __reader.Close();
                    __stream.Close();
                    GC.Collect();
                    if (__htmlString != null)
                    {
                        __htmlSite.LoadHtml(__htmlString);
                        __linkRSSTag = __htmlSite.DocumentNode.SelectNodes("//link[contains(@type,'application/rss+xml')]");
                        __linkAtomTag = __htmlSite.DocumentNode.SelectNodes("//link[contains(@type,'application/atom+xml')]");
                        __aTag = __htmlSite.DocumentNode.SelectNodes("//a[contains(translate(@href,'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'), 'rss') or contains(translate(@href,'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'), 'atom') or contains(translate(@href,'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'), 'feed')]");
                        if (__linkRSSTag != null)
                        {
                            foreach (HtmlNode l in __linkRSSTag)
                            {
                                if (l.Attributes["href"].Value != null)
                                {
                                    __found = true;
                                    __rssLink = MakeOriginalUri(l.Attributes["href"].Value, original, link);
                                    this.LinksRss.Add(original, __rssLink);
                                    SemCrawl.Release();
                                    break;
                                }
                            }
                        }
                        else if (__linkAtomTag != null && !__found)
                        {
                            foreach (HtmlNode l in __linkAtomTag)
                            {
                                if (l.Attributes["href"].Value != null)
                                {
                                    __found = true;
                                    __rssLink = MakeOriginalUri(l.Attributes["href"].Value, original, link);
                                    this.LinksRss.Add(original, __rssLink);
                                    SemCrawl.Release();
                                    break;
                                }
                            }
                        }
                        else if (__aTag != null && !__found)
                        {
                            foreach (HtmlNode l in __aTag)
                            {
                                if (l.Attributes["href"].Value != null)
                                {
                                    String ll = MakeOriginalUri(l.Attributes["href"].Value, original, link);
                                    if (CheckType(ll))
                                    {
                                        __found = true;
                                        __rssLink = ll;
                                        this.LinksRss.Add(original, __rssLink);
                                        SemCrawl.Release();
                                        break;
                                    }
                                    else
                                    {
                                        __secondChance.Add(ll);
                                    }
                                }
                            }
                            if (!__found)
                            {
                                foreach (String l in __secondChance)
                                {
                                    String rss = FindRssLink(l, original, __thisLevel);
                                    if (rss != null)
                                    {
                                        __rssLink = rss;
                                        __found = true;
                                        this.LinksRss.Add(original, __rssLink);
                                        SemCrawl.Release();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                SemCrawl.Release();
                return null;
            }
            if (__rssLink == null)
                SemCrawl.Release();
            return __rssLink;
        }
        private async Task StartCrawling()
        {
            this.RunMe = true;
            SemCrawl = new SemaphoreSlim(0, 1);
            if (this.LinksSites.Count == 0 && textBoxUrl.Text != "")
            {
                this.LinksSites.Enqueue(textBoxUrl.Text);
            }
            try
            {
                while (this.LinksSites.Count > 0)
                {
                    if (!RunMe)
                    {
                        AddToLog("Program Stopped!");
                        break;
                    }
                    ResetLists();
                    var baseLink = LinksSites.Dequeue();
                    labelCurrentSite.Text = baseLink;
                    CreateFolder(baseLink);
                    AddToLog("Start Crawling " + baseLink);
                    RefreshLabels();
                    var r = new Thread(() => FindRssLink(baseLink, baseLink, 0));
                    r.Start();
                    await SemCrawl.WaitAsync();
                    if (LinksRss.ContainsKey(baseLink))
                        if (LinksRss[baseLink] != "")
                            AddToLog("RSS link found!");
                    RefreshLabels();
                    this.LinksNew.Enqueue(baseLink);
                    AddToSiteDatabase(baseLink);
                    FillFromDatabase(baseLink);
                    while (this.LinksNew.Count > 0)
                    {
                        if (!RunMe)
                        {
                            break;
                        }
                        try
                        {
                            RefreshLabels();
                            var link = this.LinksNew.Dequeue();
                            labelCurrentLink.Text = link;
                            var t = new Thread(() => Crawl(link, baseLink));
                            t.Start();
                            await SemCrawl.WaitAsync();
                        }
                        catch (Exception)
                        {

                        }
                        while (this.LinksPDF.Count > 0)
                        {
                            if (!RunMe)
                            {
                                break;
                            }
                            try
                            {
                                RefreshLabels();
                                var link = this.LinksPDF.Dequeue();
                                labelCurrentLink.Text = link;
                                var p = new Thread(() => CrawlPDF(link, baseLink,""));
                                p.Start();
                                await SemCrawl.WaitAsync();
                            }
                            catch (Exception)
                            {

                            }
                            finally
                            {

                            }
                        }
                    }
                    AddToLog("Crawling " + baseLink + " Finished!");
                }

            }
            catch (Exception)
            {

            }
            RefreshLabels();
        }

        private void btnPDFSave_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.__currentFolder = folderBrowserDialog1.SelectedPath;
                labelMessage.Text = "Download Folder:" + this.__currentFolder;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            await StartCrawling();
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUrl.Text != "")
                btnStart.Enabled = true;
            else
                btnStart.Enabled = false;

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            this.RunMe = false;
        }
        private void AddToSiteDatabase(String link)
        {
            var rss = "";
            if (LinksRss.ContainsKey(link))
                if (LinksRss[link] != "")
                    rss = this.LinksRss[link];
            DataAccessLayer d = new DataAccessLayer(this.__currentData);
            var s = d.Select("select * from site where link='" + link + "'");
            if (s.Tables[0].Rows.Count == 0)
            {
                var l = new List<SqlCeParameter>();
                l.Add(new SqlCeParameter("link", link));
                l.Add(new SqlCeParameter("rss", rss));
                d.Insert("insert into site(Link,Rss) values(@link,@rss)", l);
            }
        }
        private void AddToLinkDatabase(String original, String link)
        {
            DataAccessLayer d = new DataAccessLayer(this.__currentData);
            var siteid = d.Select("select id from site where link='" + original + "'");
            var s = d.Select("select * from link where link='" + link + "'");
            if (s.Tables[0].Rows.Count == 0)
            {
                var l = new List<SqlCeParameter>();
                l.Add(new SqlCeParameter("link", link));
                l.Add(new SqlCeParameter("siteid", siteid.Tables[0].Rows[0].ItemArray[0]));
                l.Add(new SqlCeParameter("crawled", false));
                d.Insert("insert into Link(Link,SiteId,Crawled) values(@link,@siteid,@crawled)", l);
            }
        }
        private void UpdateLinkDatabase(String link)
        {
            DataAccessLayer d = new DataAccessLayer(this.__currentData);
            d.Insert("update Link set crawled = 1 where link='" + link + "'", null);
        }
        private void FillFromDatabase(String original)
        {
            DataAccessLayer d = new DataAccessLayer(this.__currentData);
            var crawledlinks = d.Select("select Link from Link where crawled = 1 and siteid in (select id from site where link='" + original + "')");
            var notcrawledlinks = d.Select("select Link from Link where crawled = 0 and siteid in (select id from site where link='" + original + "')");
            if (notcrawledlinks.Tables[0].Rows.Count > 0 || crawledlinks.Tables[0].Rows.Count > 0)
            {
                this.LinksNew.Dequeue();
            }
            for (var i = 0; i < notcrawledlinks.Tables[0].Rows.Count; i++)
            {
                var l = (String)notcrawledlinks.Tables[0].Rows[i].ItemArray[0];
                if (CorrectFormat(original, l, false))
                    this.LinksNew.Enqueue(l);
            }
            for (var i = 0; i < crawledlinks.Tables[0].Rows.Count; i++)
            {
                this.LinksCrawled.Add((String)crawledlinks.Tables[0].Rows[i].ItemArray[0]);
            }
        }

        void CreateFolder(String original)
        {
            String folder;
            try
            {
                if (original.Contains("https://"))
                    folder = original.Replace("https://", "").Replace("/", "");
                else
                    folder = original.Replace("http://", "").Replace("/", "");
                if (folder.Contains(":"))
                    folder = folder.Substring(0, folder.IndexOf(":"));
                System.IO.Directory.SetCurrentDirectory(__currentFolder);
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                    __thisFolder = __currentFolder + "\\" + folder;
                    System.IO.Directory.SetCurrentDirectory(__thisFolder);
                }
            }
            catch (Exception)
            {
                __thisFolder = __currentFolder;
                System.IO.Directory.SetCurrentDirectory(__thisFolder);
            }
        }
        private void ResetLists()
        {
            LinksCrawled.Clear();
            LinksError.Clear();
            LinksJunk.Clear();
            LinksPDF.Clear();
            LinksSavedPdf.Clear();
            LinksNew.Clear();
            LinksRss.Clear();
        }
        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxLog.SelectedItem != null)
            {
                Clipboard.SetText(this.listBoxLog.SelectedItem.ToString());
                MessageBox.Show("Selected log Copied to clipboard", "Log info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            var logs = "";
            if (listBoxLog.Items != null)
            {
                foreach (var item in listBoxLog.Items)
                {
                    logs += item.ToString() + "\r\n";
                }
            }
            try
            {
                var path = this.__currentFolder + "\\Log - " + DateTime.Now.ToOADate() + ".txt";
                File.WriteAllText(path, logs);
                AddToLog(path + " created!");
            }
            catch (Exception ex)
            {
                AddToLog(ex.Message);
            }
            finally
            {
                RefreshLabels();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF Downloader 1.0.1\r\nDeveloper: @MehrdadEP\r\nCopyright 2018", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void importUrlsFromXlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                await ReadFromExcel();
                btnStart.Enabled = true;
            }
            catch (Exception)
            {
                AddToLog("Error in reading from excel file, try again");
            }
            finally
            {
                RefreshLabels();
            }
        }

        private async Task ReadFromExcel()
        {

            openFileDialog1.Title = "Open Excel Files";
            openFileDialog1.Filter = "XLSX files|*.xlsx";
            openFileDialog1.FileName = "*.xlsx";
            openFileDialog1.InitialDirectory = @"Documents";
            try
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    AddToLog("Read from file started. be patient");
                    RefreshLabels();
                    this.SemExcel = new SemaphoreSlim(0, 1);
                    var r = new Thread(() => ReadFromExcelToQueue(openFileDialog1.FileName));
                    r.Start();
                    await this.SemExcel.WaitAsync();
                }
            }
            catch (Exception)
            {

            }
            RefreshLabels();

        }
        private void ReadFromExcelToQueue(String fileName)
        {
            this.LinksSites.Clear();
            List<String> headers = new List<String>();
            List<List<String>> content = new List<List<String>>();
            try
            {
                foreach (var worksheet in Workbook.Worksheets(fileName))
                {
                    if (worksheet.Rows.Count() == 0) //this is an empty worksheet
                        break;
                    try
                    {
                        for (int i = 0; i < worksheet.NumberOfColumns; i++)
                        {
                            if (worksheet.Rows[0].Cells[i] != null)
                                headers.Add(worksheet.Rows[0].Cells[i].Text);
                            else
                                headers.Add("");
                        }
                    }
                    catch (NullReferenceException)
                    {

                    }
                    for (int j = 1; j < worksheet.Rows.Count(); j++)
                    {
                        try
                        {
                            content.Add(new List<String>());
                            for (int i = 0; i < worksheet.NumberOfColumns; i++)
                            {
                                if (worksheet.Rows[j].Cells[i] != null)
                                    content[j - 1].Add(worksheet.Rows[j].Cells[i].Text);
                                else
                                    content[j - 1].Add("");
                            }
                        }
                        catch (NullReferenceException)
                        {

                        }
                    }
                }
                AddToLog("Reading from file finished!");
            }
            catch (IOException)
            {
                AddToLog("I/O error, file is in use");
            }
            catch (NullReferenceException)
            {
                AddToLog("Error: delete empty rows in excel file");
            }
            catch (Exception e)
            {
                AddToLog(e.Message);
            }
            try
            {
                //add sites to queue
                //find header number
                var index = headers.FindIndex(delegate (String site)
                {
                    if (site == "نشانی پایگاه" || site.ToLower() == "site" || site == "سایت")
                        return true;
                    return false;
                });
                foreach (var item in content)
                {
                    var website = item[index];
                    if (website != null && website != "")
                    {
                        this.LinksSites.Enqueue(website);
                        AddToSiteDatabase(website);
                    }

                }
            }
            catch (Exception)
            {
            }
            finally
            {
                AddToLog(this.LinksSites.Count + " site added from excel file to queue and database");
                this.SemExcel.Release();
            }
        }
        private void exportRssToXlsxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportRss();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void clearDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("All data will be lost, Are you sure?", "Clear Database", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataAccessLayer d = new DataAccessLayer(__currentData);
                    d.Insert("delete from Link", null);
                    d.Insert("delete from Site", null);
                    AddToLog("Clearing database finished");
                }
                catch (Exception)
                {
                    AddToLog("Clearing database failed, try again");
                }
                finally
                {
                    RefreshLabels();
                }

            }
        }

        private void importUrlsFromTxtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Choose a txt file";
                openFileDialog1.FileName = "*.txt";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.LinksSites.Clear();
                    var read = File.ReadAllLines(openFileDialog1.FileName);
                    foreach (var item in read)
                    {
                        try
                        {
                            if (item != null && item != "")
                            {
                                this.LinksSites.Enqueue(item);
                                AddToSiteDatabase(item);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    AddToLog(this.LinksSites + " site added to queue and database");
                    btnStart.Enabled = true;
                    RefreshLabels();
                }

            }
            catch (Exception)
            {


            }
        }

        private void loadSiteFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.LinksSites.Clear();
                DataAccessLayer d = new DataAccessLayer(this.__currentData);
                var sites = d.Select("select link from site");
                if (sites.Tables[0].Rows.Count > 0)
                {
                    for(var i=0;i<sites.Tables[0].Rows.Count;i++)
                    {
                        this.LinksSites.Enqueue(sites.Tables[0].Rows[i].ItemArray[0].ToString());
                    }
                    AddToLog(this.LinksSites.Count + " site added to queue");
                    btnStart.Enabled = true;
                }
                else
                {
                    AddToLog("there is No site in database");
                }

            }
            catch(Exception ex)
            {
                AddToLog(ex.Message);
            }
            finally
            {
                RefreshLabels();
            }
        }

        private void clearSiteQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = this.LinksSites.Count;
            this.LinksSites.Clear();
            AddToLog(c + " removed from queue");
            btnStart.Enabled = false;
            RefreshLabels();
        }

        private void labelCurrentLink_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.labelCurrentLink.Text);
            MessageBox.Show("Current Link Copied to Clipboard", "Log info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportRss_Click(object sender, EventArgs e)
        {
            ExportRss();
        }

        private void ExportRss()
        {
            try
            {
                DataAccessLayer d = new DataAccessLayer(this.__currentData);
                var rss = d.Select("select link, rss from site where rss <> ''");
                var filename = this.__currentFolder + "\\RSS Export - " + DateTime.Now.ToOADate() + ".xls";
                FileStream stream = new FileStream(filename, FileMode.OpenOrCreate);
                ExcelWriter writer = new ExcelWriter(stream);
                writer.BeginWrite();
                writer.WriteCell(0, 0, "Site");
                writer.WriteCell(0, 1, "RSS");
                for (var i = 0; i < rss.Tables[0].Rows.Count; i++)
                {
                    writer.WriteCell(i+1, 0, rss.Tables[0].Rows[i].ItemArray[0].ToString());
                    writer.WriteCell(i+1, 1, rss.Tables[0].Rows[i].ItemArray[1].ToString());
                }
                writer.EndWrite();
                stream.Close();
                AddToLog(filename + " exported!");
            }
            catch (Exception e)
            {
                AddToLog(e.Message);
            }
            finally
            {
                RefreshLabels();
            }
        }

        private void clearLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBoxLog.Items.Clear();
            }
            catch (Exception)
            {
                
            }
        }
    }
}