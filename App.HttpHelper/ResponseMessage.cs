using System.Runtime.Serialization;

namespace App.HttpHelper
{
    /// <summary>
    /// 返回对象
    /// 注意：请使用CreateResult.For()创建对象
    /// </summary>
    [DataContract()]
    public class ResponseMessage<T> 
    {
        /// <summary>
        /// 返回对象
        /// 注意：请使用CreateResult.For()创建对象
        /// </summary>
        public ResponseMessage()
        {
            Success = true;
            this.Message = "success";
            this.Code = "00000";
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        public ResponseMessage(T data, int total = 0, string message = "")
        {
            Success = true;
            this.Message = message;
            this.Code = "00000";
            Data = data;
            Total = total;
        }

        /// <summary>
        /// 返回对象
        /// </summary>
        public ResponseMessage(string code, string msg)
        {
            Success = false;
            this.Code = code;
            this.Message = msg;
        }
        /// <summary>
        /// 错误码
        /// </summary>
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        [DataMember]
        public bool Success { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember]
        public string Message { get; set; }
        /// <summary>
        /// 返回对象
        /// </summary>
        [DataMember]
        public T Data { get; set; }
        /// <summary>
        /// 集合条数（如果是集合）
        /// </summary>
        [DataMember]
        public int Total { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class CreateResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="total"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseMessage<T> For<T>(T t, int total = 1, string msg = "") 
        {
            return new ResponseMessage<T>(t, total, msg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseMessage<T> For<T>(string code, string msg) 
        {
            return new ResponseMessage<T>(code, msg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseMessage<object> For(string code, string msg)
        {
            return new ResponseMessage<object>(code, msg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ResponseMessage<object> For()
        {
            return new ResponseMessage<object>();
        }
    }
    /// <summary>
    /// 提交批量数据
    /// </summary>
    public class PostData
    {
        /// <summary>
        /// 需要批量删除对象json字符串
        /// </summary>
        public string Json { get; set; }
    }
}