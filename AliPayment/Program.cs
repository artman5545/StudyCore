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
using System.Xml;
using System.Reflection;

namespace AliPayment
{
    partial class Program
    {
        static void Main(string[] e)
        {
            //Dictionary<string, string> args = new Dictionary<string, string>
            //{
            //    { "appId", "6840E617-CCE3-42D7-828E-EBB0934C0E33" },
            //    { "idNo", "513021195304251499" },
            //    { "idType", "01" }
            //};
            //StringBuilder sb = new StringBuilder();
            //foreach (var key in args.Keys)
            //{
            //    sb.Append($"{key}={args[key]}&");
            //}
            //var signTemp = sb.Append($"key={secret}").ToString();
            //var sign = Encode_md5(signTemp).ToUpper();
            //Console.WriteLine(sign);
            //var json = AESEncrypt(JsonConvert.SerializeObject(args));
            //Console.WriteLine(json);
            //json = AESDecrypt(json);
            //Console.WriteLine(json);

            //Console.ReadLine();

            //            var str = @"<response>
            //<status>1</status> 
            //<message>2</message>
            //<data>
            //   <ehealthCardId>3</ehealthCardId>
            //<mindexId>4</mindexId>
            //<idNo>4</idNo>
            //<idType>5</idType>
            //   <patientId>6</patientId>
            //   <name>7</name>
            //   <idCard>8</idCard>
            //</data>
            //</response>";
            //            XmlDocument doc = new XmlDocument();
            //            doc.LoadXml(str);
            //            var node = doc.GetElementsByTagName("ehealthCardId")[0];
            //            Console.WriteLine(node.Value);
            //            Console.ReadLine();
            ////var b = false;
            ////var data= AnalyzeIDCard("12010119350307147X",out b);
            ////Console.WriteLine(data);
            ////var items = (typeof(HisPaymentMethodEnum)).GetMembers();
            var n = PaymentsPluginAttribute.Get<HisPaymentMethodEnum>("Payments.ABCPay1");
            Console.Read();
        }


    }
}
