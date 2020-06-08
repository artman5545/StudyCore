using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using javax.crypto;
using java.security;
using System.Security.Cryptography;
using java.lang;
using javax.crypto.spec;
using sun.misc;
using System.Text.RegularExpressions;
using System.Collections;

namespace AliPayment
{
    partial class Program
    {
        private static string secret = "7825a0fc05e04c5eb0283539079afa71";
        private static string key = "2983593B92F868CF";
        public static string AESEncrypt(string content)
        {
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            SecretKeySpec keySpec = new SecretKeySpec(Encoding.UTF8.GetBytes(key), "AES");
            cipher.init(Cipher.ENCRYPT_MODE, keySpec);
            var data = cipher.doFinal(Encoding.UTF8.GetBytes(content));
            System.Text.StringBuilder sb = new System.Text.StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            }
            return sb.ToString();
        }
        public static string AESDecrypt(string content)
        {
            Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
            SecretKeySpec keySpec = new SecretKeySpec(Encoding.UTF8.GetBytes(key), "AES");
            cipher.init(Cipher.DECRYPT_MODE, keySpec);
            byte[] buffer = new byte[content.Length / 2];
            for (int i = 0; i < content.Length; i += 2)
            {
                buffer[i / 2] = Convert.ToByte(content.Substring(i, 2), 16);
            }
            byte[] data = cipher.doFinal(buffer);
            return Encoding.UTF8.GetString(data);
        }

        public static string Encode_md5(string content)
        {
            byte[] data = MD5.Create().ComputeHash(Encoding.GetEncoding("UTF-8").GetBytes(content));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string[] GetCardIdInfo(string cardId)
        {
            string[] info = new string[4];
            System.Text.RegularExpressions.Regex regex;
            if (cardId.Length == 18)
            {
                regex = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
                if (regex.IsMatch(cardId))
                {
                    info.SetValue(cardId.Substring(0, 6), 0);
                    info.SetValue(cardId.Substring(6, 8), 1);
                    info.SetValue(cardId.Substring(14, 3), 2);
                    info.SetValue(Convert.ToInt32(info[2]) % 2 != 0 ? "男" : "女", 3);
                }
            }
            else if (cardId.Length == 15)
            {
                regex = new System.Text.RegularExpressions.Regex(@"^\d{15}");
                if (regex.IsMatch(cardId))
                {
                    info.SetValue(cardId.Substring(0, 6), 0);
                    info.SetValue(cardId.Substring(6, 6), 1);
                    info.SetValue(cardId.Substring(12, 3), 2);
                    info.SetValue(Convert.ToInt32(info[2]) % 2 != 0 ? "男" : "女", 3);
                }
            }

            return info;

        }

        static DistrictCodeTable m_DistrictCode = new DistrictCodeTable();
        /// <summary>
        /// 分析身份证号，返回：生日、性别、地区(简)、地区(全)
        /// </summary>
        public static string[] AnalyzeIDCard(string strIDNum, out bool isOK)
        {
            string[] retInfo = new string[4];
            int strLen = strIDNum.Length;//数据长度

            #region 粗过滤：用正则表达式去校验身份证号的输入
            string rule = string.Empty;
            if (strLen == 15) rule = @"\d{6}\d{2}[0-1]\d[0-3]\d{4}";
            if (strLen == 18) rule = @"\d{6}[1-2]\d{3}[0-1]\d[0-3]\d{4}[0-9X]";
            if (!rule.Equals(string.Empty))
            {
                Regex regex = new Regex(rule);
                isOK = regex.IsMatch(strIDNum);
            }
            else
            {
                isOK = false;
            }
            #endregion

            #region 细过滤：判断前两位数字是否为正确的地区代码
            if (isOK)
            {
                string headAB = strIDNum.Substring(0, 2);
                m_DistrictCode.InitDistrictTable_Short();
                //若前两位数字在地区代码中不存在，则为假
                if (!m_DistrictCode.m_DistrictTB.Contains(headAB))
                {
                    isOK = false;
                }
            }
            #endregion

            #region 细过滤：出生日期是否可转换
            if (isOK)
            {
                //更改15位身份证中的日期格式
                if (strLen == 15) strIDNum = strIDNum.Insert(6, "19");
                string testBir = strIDNum.Substring(6, 8).Insert(4, "-").Insert(7, "-");
                DateTime testRes;
                DateTime.TryParse(testBir, out testRes);
                //若转换结果为最小值，这说明转换失败
                if (testRes == DateTime.MinValue)
                {
                    isOK = false;
                }
            }
            #endregion

            //基础检查完成后的操作
            if (isOK)
            {
                retInfo = GetCardIdInfo(strIDNum);
            }
            return retInfo;
        }

    }
    class DistrictCodeTable
    {
        /// <summary>
        /// 地区代码表(默认为空，需初始化：简称、全称)
        /// </summary>
        public Hashtable m_DistrictTB = new Hashtable();

        /// <summary>
        /// 初始化：地区代码：简称
        /// </summary>
        public void InitDistrictTable_Short()
        {
            m_DistrictTB.Clear();
            //11-15 京、津、冀、晋、蒙 
            m_DistrictTB.Add("11", "京");
            m_DistrictTB.Add("12", "津");
            m_DistrictTB.Add("13", "冀");
            m_DistrictTB.Add("14", "晋");
            m_DistrictTB.Add("15", "蒙");
            //21-23 辽、吉、黑 
            m_DistrictTB.Add("21", "辽");
            m_DistrictTB.Add("22", "吉");
            m_DistrictTB.Add("23", "黑");
            //31-37 沪、苏、浙、皖、闽、赣、鲁 
            m_DistrictTB.Add("31", "沪");
            m_DistrictTB.Add("32", "苏");
            m_DistrictTB.Add("33", "浙");
            m_DistrictTB.Add("34", "皖");
            m_DistrictTB.Add("35", "闽");
            m_DistrictTB.Add("36", "赣");
            m_DistrictTB.Add("37", "鲁");
            //41-46 豫、鄂、湘、粤、桂、琼 
            m_DistrictTB.Add("41", "豫");
            m_DistrictTB.Add("42", "鄂");
            m_DistrictTB.Add("43", "湘");
            m_DistrictTB.Add("44", "粤");
            m_DistrictTB.Add("45", "桂");
            m_DistrictTB.Add("46", "琼");
            //50-54 渝、川、贵、云、藏 
            m_DistrictTB.Add("50", "渝");
            m_DistrictTB.Add("51", "川");
            m_DistrictTB.Add("52", "贵");
            m_DistrictTB.Add("53", "云");
            m_DistrictTB.Add("54", "藏");
            //61-65 陕、甘、青、宁、新 
            m_DistrictTB.Add("61", "陕");
            m_DistrictTB.Add("62", "甘");
            m_DistrictTB.Add("63", "青");
            m_DistrictTB.Add("64", "宁");
            m_DistrictTB.Add("65", "新");
            //71 台湾
            m_DistrictTB.Add("71", "台");
            //81-82 港、澳 
            m_DistrictTB.Add("81", "港");
            m_DistrictTB.Add("82", "澳");
            //91 国外
            m_DistrictTB.Add("91", "外");
        }

        /// <summary>
        /// 初始化：地区代码：全称
        /// </summary>
        public void InitDistrictTable_Full()
        {
            m_DistrictTB.Clear();
            //11-15 京、津、冀、晋、蒙 
            m_DistrictTB.Add("11", "北京");
            m_DistrictTB.Add("12", "天津");
            m_DistrictTB.Add("13", "河北");
            m_DistrictTB.Add("14", "山西");
            m_DistrictTB.Add("15", "内蒙古");
            //21-23 辽、吉、黑 
            m_DistrictTB.Add("21", "辽宁");
            m_DistrictTB.Add("22", "吉林");
            m_DistrictTB.Add("23", "黑龙江");
            //31-37 沪、苏、浙、皖、闽、赣、鲁 
            m_DistrictTB.Add("31", "上海");
            m_DistrictTB.Add("32", "江苏");
            m_DistrictTB.Add("33", "浙江");
            m_DistrictTB.Add("34", "安徽");
            m_DistrictTB.Add("35", "福建");
            m_DistrictTB.Add("36", "江西");
            m_DistrictTB.Add("37", "山东");
            //41-46 豫、鄂、湘、粤、桂、琼 
            m_DistrictTB.Add("41", "河南");
            m_DistrictTB.Add("42", "湖北");
            m_DistrictTB.Add("43", "湖南");
            m_DistrictTB.Add("44", "广东");
            m_DistrictTB.Add("45", "广西");
            m_DistrictTB.Add("46", "海南");
            //50-54 渝、川、贵、云、藏 
            m_DistrictTB.Add("50", "重庆");
            m_DistrictTB.Add("51", "四川");
            m_DistrictTB.Add("52", "贵州");
            m_DistrictTB.Add("53", "云南");
            m_DistrictTB.Add("54", "西藏");
            //61-65 陕、甘、青、宁、新 
            m_DistrictTB.Add("61", "陕西");
            m_DistrictTB.Add("62", "甘肃");
            m_DistrictTB.Add("63", "青海");
            m_DistrictTB.Add("64", "宁夏");
            m_DistrictTB.Add("65", "新疆");
            //71 台湾
            m_DistrictTB.Add("71", "台湾");
            //81-82 港、澳 
            m_DistrictTB.Add("81", "香港");
            m_DistrictTB.Add("82", "澳门");
            //91 国外
            m_DistrictTB.Add("91", "国外");
        }

        /// <summary>
        /// 地区代码返回结果类型：Full(全称)、Short(简称)
        /// </summary>
        public enum DistrictResultType
        {
            /// <summary>
            /// 全称
            /// </summary>
            Full,
            /// <summary>
            /// 简称
            /// </summary>
            Short
        }

        /// <summary>
        /// 通过两位地区码得到对应的地区名称
        /// </summary>
        /// <param name="code">两位地区码</param>
        /// <param name="resType">返回类型：Full(全称)、Short(简称)</param>
        /// <returns>对应的地区名称</returns>
        public string GetDistrictCode(string code, int resType)
        {
            try
            {
                string codeStr = "错误地区";
                if (code.Length == 2)
                {
                    //初始化：全称
                    if (resType == (int)DistrictResultType.Full)
                    {
                        InitDistrictTable_Full();
                    }
                    //初始化：简称
                    if (resType == (int)DistrictResultType.Short)
                    {
                        InitDistrictTable_Short();
                    }
                    //获取对应键值的结果
                    if (m_DistrictTB.ContainsKey(code))
                    {
                        codeStr = m_DistrictTB[code].ToString();
                    }
                }
                return codeStr;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
