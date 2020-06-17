using com.sun.org.apache.bcel.@internal.generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AliPayment
{
    partial class Program
    {
    }
    public enum HisPaymentMethodEnum
    {
        [Description("健康卡付"), PaymentsPlugin("Payments.HealthCard")]
        HealthCard = 0,
        [Description("微信"), PaymentsPlugin("Payments.TenPay")]
        TenPay = 5,
        [Description("支付宝"), PaymentsPlugin("Payments.AliPay")]
        AliPay = 10,
        [Description("银联"), PaymentsPlugin("Payments.UnionPay")]
        UnionPay = 15,
        [Description("工行缴费中心平台"), PaymentsPlugin("Payments.ICBCPay")]
        ICBCPay = 20,
        [Description("银联微信支付"), PaymentsPlugin("Payments.UnionWeChatPay")]
        UnionWeChatPay = 25,
        [Description("支付宝手机网页"), PaymentsPlugin("Payments.AliWapPay")]
        AliWapPay = 30,
        [Description("农行缴费中心平台"), PaymentsPlugin("Payments.ABCPay")]
        ABCPay = 35,
        [Description("未设置"), PaymentsPlugin("None")]
        None = 100,

    }

    public class PaymentsPluginAttribute : DescriptionAttribute
    {
        public string KeyWord { get; private set; }
        public PaymentsPluginAttribute(string keyword)
        {
            this.KeyWord = keyword;
        }
        public static T Get<T>(string name) where T : Enum
        {
            System.Type enumType = typeof(T);
            var items = Enum.GetNames(enumType);

            foreach (var item in items)
            {
                FieldInfo fieldInfo = enumType.GetField(item);
                PaymentsPluginAttribute attr = Attribute.GetCustomAttribute(fieldInfo, typeof(PaymentsPluginAttribute), false) as PaymentsPluginAttribute;
                if (name == attr.KeyWord)
                {
                    return (T)fieldInfo.GetValue(item);
                }
            }
            return (T)Enum.GetValues(enumType).GetValue(items.Length - 1);
        }
    }
}
