using SufeiUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Douyin
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpHelper http = new HttpHelper();
            var item = new HttpItem()
            {
                URL = "https://v.douyin.com/egkmc6u/ ",//抖音分享链接
                Method = "get",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.77 Safari/537.36",
                Allowautoredirect = true,
                ResultType = ResultType.String,
                Encoding = Encoding.UTF8
            };
            
            HttpResult result =  http.GetHtml(item);
            
            string pattern = "data-react-helmet(?<Text>.*?)id=\"about_douyin";
            var match = Regex.Match(result.Html, pattern);
            string res=match.Groups["Text"].Value;
            res=HttpUtility.UrlDecode(res);
            pattern = "{\"src\":\"(?<video>.*?)\"},";
            match = Regex.Match(res, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);

            Console.WriteLine("无水印视频地址："+match.Groups["video"].ToString());
            Console.ReadLine();




        }
    }
}
