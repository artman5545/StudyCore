using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alipay.EasySDK;
using Newtonsoft.Json;
namespace AliPayment
{
    public class Class4
    {
        public static void TestLogin()
        {
            Alipay.EasySDK.Kernel.Config config =  new Alipay.EasySDK.Kernel.Config
            {
                Protocol = "https",
                GatewayHost = "openapi.alipay.com",
                SignType = "RSA2",
                AppId = "2021001187627112",
                MerchantPrivateKey = "MIIEpAIBAAKCAQEAu6+BHCtJWxIYfL58gDQwywwm/IXuIPG56bvfEYfnnQNEWC6guH0l24jQB6ZAELBLlKFP5Xn+PUg+/HiEsjNaHRgLDX3N0Ajks7DAI5f4Q26ZUMFxZPw21swlbcUwZOp369xWx0ez9bqjSHZGCXadV0cloNiGvVHkC1LwHvSEpAYATkxrxhue4lbSlZxVVATe+upbTE4tMWisdMxajq+8jo6XXdU4m0crH5aJQCs4cGQRRuPmA6Vs8M7HLXMwqirjl3wbo4rZoOFsoad4ueop0niA6fgjOUeqUeLn0YUcJfUFrZ0KhG54E7nfCEQ6OqDd4+LbMcFvbGmg9DuKl70ACQIDAQABAoIBAH2TQrZfO/iEFgA4z0JUKSVh3x/sWFSQh4ycl/a50L0cN3ks0Xo+ubq2QkIr+QdxfVBX0gY+5l2IXiQ8WsSEWVHICXUgbDk6ChM0OopWHtS3RjtjAoTHv8Vd19knK2cJ/ezAgwtYrU7HboKIJ/oi88k2oDWLSjOXfBYbiu+bOLgo6DWDFKZT2MaxrMY+WKGkkZF+ArcjaO1Kuxc2hlZPNLWzWbWUNu8jpG2AQXbmHXqCPWDHupL07lSoBsCF51pUAmXHv3lgCPe0gDWGOUvLFf9NygJZXkLF1U/4VpsTPpqDMFNcX5hcoegmz+xPqcvwMWV845aY1pK8rqYqQFvE+VECgYEA9+fjL7QbP8LqYaTaTRfLGCRP2aUfhsKgIWNhaQIEBPEctyCSojccHu+VUEmopMJhKYTCViNMQiQTDRNfAT657e4LqNwxF2xZWpt8UWxWpFUDoZmFK0nW1pg+9RTHZfR2xYSim72nN+3+IUHDlLD0c6qqu0iuJgzICedYmtSOGJUCgYEAwdBEl9JEwQbIn7d7/Gg3KnGa1oi2Ow1Z8pj0R1BaXJAOtKDTVNZ0KAL5+L3bw97eAKn+yxngCj4OjqUSQOXg08ot2y1P5tXwIB4OV80Orgu/L2bxCRBWql5NtWGLCy6C1CfabYjT4gZgwJO34aIE2C6veBONPXpN9g55nLC4iKUCgYEAsVred/RcQkOKNw0feGP7Umw4DDdL1LdMpFZbDCr7ASYWKxVMkmzm22L/6Y6o7iZ6KJ/oAIQEPJVeY85l+5gKoKPbB5VwMZe8XUw7pmzhl3OSw3v3f761ypTlBaU1+kTo6+o2A0Gtbh//3X8VEz19xXpl5tLadDJUsnEmPK6wcfkCgYEAgpPIwujdfZcOb9z04bdtA2GKymNNMzfpk/LNEYbnellsLvHzr8LUe2iV9aokeDCdLaFakoeaVAw/ToeUZrj54nbisjozDPiyUVEupKT48PXlFxCp8EtbuGjUvhE71oq9hiZbmVSIPE3DvbtINfIshWHewm2ZyQOvpslV0eWWTikCgYBOegeMMATMlu6QpTtG3b4czNrl+xsZs90peTgyD1LyJgCVPNmii57H2FVTdWKJDElV64q8idEE/d8Ggucd8gTNEIi8WbPfPGIQi1FxxQ68KKPNRc0Ur+A+y03lRp74rsQhxd3sXuQWkUks2NBe1ly5p2VbngoWV8Puw4ms4snwiA==",
                AlipayPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnnSAgH/TJAmh4HvZmSumsVYlqRiC0ClZoiMCPzuo7+Xg8WANhBrwtNP361Zo4+f+jMCy9YH+rHYSisg3AGjcu5J6yGtsBmW6YFFF18J570CSeBFEL02Fv0tfmFRLQ1vpaehccfu9ykl5dY0k4u5kVBPl3dZxDLALJqY6v42vMkSOKLRtR6lGmHYdknbqmzJOFHv2H0JwFwvRD8Vrj4wH2h8nRMTcKYTLQ5r9Io9hp0S1w6FGRbO0GI5eM+3QYqioIHAQUcox1wNX8PHm5izV5+iKYeyXxxCrFtpQLBxfWZwxJKHI5jgKk93JRWxUyN6syiZxRi5imFgt1GD1Tfw9zQIDAQAB"
            };
            Console.WriteLine("input code");
            var code = Console.ReadLine();
            var response = new Alipay.EasySDK.Base.OAuth.Client(new Alipay.EasySDK.Kernel.Client(new Alipay.EasySDK.Kernel.Context(config, "2.0"))).GetToken(code);
            Console.WriteLine(JsonConvert.SerializeObject(response));
            var aliuserinfo = new Alipay.EasySDK.Member.Identification.Client(new Alipay.EasySDK.Kernel.Client(new Alipay.EasySDK.Kernel.Context(config, "2.0"))).Auth(response.AccessToken);
            Console.WriteLine(JsonConvert.SerializeObject(aliuserinfo));
            Console.ReadLine();
        }
    }
}
