using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using sun.security.provider;
using System.Security.Cryptography;

namespace AliPayment
{
    partial class Program
    {
        static void Main(string[] e)
        {
            //var json = Refund("0.01");
            Dictionary<string, string> args = new Dictionary<string, string>
            {
                { "appId", "6840E617-CCE3-42D7-828E-EBB0934C0E33" },
                { "idNo", "513021195304251499" },
                { "idType", "01" }
            };
            StringBuilder sb = new StringBuilder();
            foreach (var key in args.Keys)
            {
                sb.Append($"{key}={args[key]}&");
            }
            var signTemp = sb.Append($"key={secret}").ToString();
            var sign = Encode_md5(signTemp).ToUpper();
            Console.WriteLine(sign);
            var json = AESEncrypt(JsonConvert.SerializeObject(args));
            Console.WriteLine(json);
            json = AESDecrypt(json);
            Console.WriteLine(json);

            Console.ReadLine();
        }


        private static string APPID = "2016102100733619";
        private static string APP_PRIVATE_KEY = "MIIEogIBAAKCAQEAsYvW6suj9oechyCkYtSmGrooFQkbvlMCBorPnorXxU5vBKRYOa2QMhPe4S9sVuoJqBBaL7yv3PrvONnRKEqsWopt0yeZ1gvRPT2PYaq2GmuMLUWgBsJ5Ljh6wpUaAP/Ve1UUMz82lfzMN7xm4CRcIyswjAE5qkQ7QC/KwSmy1z87gyMy+tffVX47dtT0iKvq3NPrlx+cwWdSYv82uAcr6qnAGp46AgMqp43CUpAkNBjuggDTWMrngOmMbp8cLECzy/FTB6L35XvjFrvM2pGpV+3NbaNLKUf1J0J1+YcK+6r4EwTaH3wm4jAFbtO8f/sJN+2o3x28JVZcSkvMycfIOwIDAQABAoIBADdkmL4SoOpGryhdn8wR6m0GTYEaoWRFA6nE3zfou58cdHivSbNdGlL1biE1qYiIZlDgITMpnHjGdaJ4GtCGU7W/4LnzbgShFTwVG8nt9/jQOyDYyy+wtxwblPlmiYFsUE+1YKMIguBSyehNyI7/6Rsz22ai7znXJeFFx+1yNBEBbVjJufOmX7NPN+MVKluGba316rpxYeek7wTvml5TDFIocCXd/6CM16Qrk0hi2o5uEpBwaioQfBe58EeLvYfgZiPNTazkwX19W05oryRPsX6gVqXnosKAiJm7W2UjaKiEd/YfcWOd2GR5PDtPaZsXi10+aI8OFJ09Y7LxvYqmzdECgYEA29JceiHLaZ2qeS6uML/JvMcyTzCSeJfap97ccZm89kEm7di6JtWaR7mfqutaymzD/GLTX48BS5eM6mdB3tIoeLJQWmL8zyTIZMyz0sQ15CFPh62rcHrQ+4JhFJ2lfl9FJZQ1XlSL4iiUsWnP7EZE8lnPFGS+099aliAHZQ50qjMCgYEAzsROi06ou3Wb52m0cAQef+lXCDt7BSyueYnzLU/m8QyMcgxtjYBQZQOMt2LsvzaqdWoZOYNqgPpgWfGt1MAsKatlSBf99VeCMQFNNOHTbZfaHY6cL4qg2pc4rpCLGZn+BiVshIfz4v0R8rGFthO17vGHUE/4K8DLOLuokrIxcdkCgYBx3foBWdggkYdo1oFsxywdGaI52xNEXITrSEownk5/0Sf1NLrYuvT8Cm9m/hs9mDG9XwPXECC/o3VfRrWcUoicXOG6sGP8eTVE4bSUjQbNcWPdCF0yGqx+W/8lyrObToZm/OrYPjtnn1XGwOTvo0a7s0HNcpJW9e/arCSoeGB+eQKBgE+0/VJWkFUzkVY0OYq1C8zjdtmFlHb6MohH1aayFqT14W5VvCXAQT2vkJ9hU0KjIDMDI5Y4QuZVnq8Nq6VIL74ghHq2RQA/K8EYb1rjc03cLAkY4LyzBC8//GnO7tB/vJ1B8ANnJW1rgW+9X35BOvFRyof7TAAR4kWMkf97EfSBAoGAf8gVzJoHmr2FROiOYlmCy/fpOdw/iX8tKiH00vp9wJLBXdpDzOtFo6Tb+xg5umGYdPHJzCh3j9nhqsyFy4gsMbFD5H5iaG/kqqbdZnBkDBEoFsw/39+yOwzXG7prjtwrclDRwLFhOX5Ofn43vrRSMs6/ADIMsJgHrW79gw60dJw=";
        private static string APP_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAldogSp166OX6NbElWwHP8+5HblBZ4KDvlqSeOdfCPN91q9nzb3C0b/YgDEmMD77k+3I0ooyn8QrFHqrAZUY7LWbIq2HcSJRY/YGfdlt0dCTjcYs2flZR8t4Fl4ecKDb4WcD4v/PKJioy5dprFPnmCK9B+NTfgwqjHClQ4jMe1rF0Rw9FNAAUGimtMnvFMVvsIV+cN/1aFcrlgjLxiRVlIbwmgCTQvvNoZEvLp14CuPptA8CvrzExDuxvj5gbWJApOo53ycgY2QpuBQuayk1pRwhEwuqToA8lFxLGDIm7d9hx2NIg/UpDptn22a72H7qFN4SYZ6pbVR1dFoDfbNtCEwIDAQAB";
        private static string ALIPAY_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjwaCuO/Y7Joc0s8PEZmDylw+o4fvYGUkL0g2j7xDKENdmcd3KnTYKYd9g7M+Jy4WZ0Vi7uvfSBlcIqBrXQJP8OlpLpx5bhsjBWd4P6txkpu19TOOpts00UYd0wJd3MSIiQzPZW6P7vG/BVp0c2M3gwOqdv1LRVstJLctNRk9XniXDxa9EqdSBcFSXkbW2pfpqgwOg/GD4+6w2q7p8ZfkDlNvzasRCnkMb5s4oCwocAZPllDn3O9Cd7dMXnt5reOlxV68DUZhoYUCLHAyzwBgPuvCGvXtb9Z3g7fH+casH8jvZQEgCl59GEDFdxFFgSiUpTZrSQtF3GEzBFAPg8OFwQIDAQAB";
        private static string CHARSET = "utf-8";
        private static string GetOrderInfo(string amount)
        {
            //EnvUtils.setEnv(EnvUtils.EnvEnum.SANDBOX);
            IAopClient client = new DefaultAopClient("https://openapi.alipaydev.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel
            {
                Body = HttpUtility.UrlEncode("门诊挂号"),//"我是测试数据",
                Subject = HttpUtility.UrlEncode("门诊挂号缴费"),// "App支付测试DoNet",
                TotalAmount = amount,//"0.01",
                ProductCode = "QUICK_WAP_WAY",
                OutTradeNo = "2020060111510",
                //TimeoutExpress = "120m",
                TimeExpire = DateTime.Now.AddMinutes(60).ToString("yyyy-MM-dd HH:mm"),
                QuitUrl = "http://www.taobao.com/product/113714.html",

            };
            request.SetBizModel(model);
            //request.SetNotifyUrl("外网商户可以访问的异步地址");
            request.SetReturnUrl("https://wwww.baidu.com");
            AlipayTradeWapPayResponse response = client.pageExecute(request);
            return response.Body;
            //HttpUtility.HtmlEncode是为了输出到页面时防止被浏览器将关键参数html转义，实际打印到日志以及http传输不会有这个问题
            //Response.Write(HttpUtility.HtmlEncode(response.Body));
        }

        private static RefundResponse Refund(string amount)
        {
            IAopClient client = new DefaultAopClient("https://openapi.alipaydev.com/gateway.do", APPID, APP_PRIVATE_KEY, "json", "1.0", "RSA2", ALIPAY_PUBLIC_KEY, CHARSET, false);
            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            AlipayTradeRefundModel mode = new AlipayTradeRefundModel
            {
                OutTradeNo = "2020060111510",
                RefundAmount = amount,
                RefundReason = HttpUtility.UrlEncode("挂号退款")
            };
            request.SetBizModel(mode);
            var response = client.Execute(request);
            var body = JsonConvert.DeserializeObject<RefundResponse>(response.Body);
            return body;
        }
    }
    [Serializable]
    public class RefundResponse
    {
        public alipay_trade_refund_response alipay_trade_refund_response { get; set; }
        public string sign { get; set; }
    }
    [Serializable]
    public class alipay_trade_refund_response
    {
        public string code { get; set; }
        public string msg { get; set; }
        public string buyer_logon_id { get; set; }
        public string buyer_user_id { get; set; }
        public string fund_change { get; set; }
        public string gmt_refund_pay { get; set; }
        public string out_trade_no { get; set; }
        public string refund_fee { get; set; }
        public string send_back_fee { get; set; }
        public string trade_no { get; set; }
    }
}
