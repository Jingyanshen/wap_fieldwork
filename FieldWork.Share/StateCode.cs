using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Share
{
    // <summary>
    /// 定义权限认证系统返回码
    /// </summary>
    /// 统一以0x1002开头的十六进制数
    public static class StateCode
    {

        #region 业务无关级别状态码

        /// <summary>
        /// 模型转换错误
        /// </summary>
        public const int CODE_MODEL_CONVERT_ERROR = 0x1000000D;

        /// <summary>
        /// SQL执行异常
        /// </summary>
        public const int CODE_SQL_EXECUTE_ERROR = 0x1000000E;

        /// <summary>
        /// 模型不存在
        /// </summary>
        public const int CODE_MODEL_NOT_EXIST = 0x1000000F;
        /// <summary>
        /// 缓存异常
        /// </summary>
        public static int CODE_CACHE_ERROR = 0x10000010;

        /// <summary>
        /// 参数不允许为空
        /// </summary>
        public const int CODE_ARGUMENT_NULL = 0x10000011;

        /// <summary>
        /// 参数超长
        /// </summary>
        public const int CODE_ARGUMENT_LENGTH = 0x10000012;

        /// <summary>
        /// 参数类型错误
        /// </summary>
        public const int CODE_ARGUMENT_TYPE_ERROR = 0x10000013;

        /// <summary>
        /// 获取序号错误
        /// </summary>
        public const int CODE_GET_SEQ_ERROR = 0x10000014;

        /// <summary>
        /// 参数范围错误
        /// </summary>
        public const int CODE_ARGUMENT_LIMIT_ERROR = 0x10000015;

        /// <summary>
        /// 参数不一致
        /// </summary>
        public const int CODE_ARGUMENT_NOT_EQUAL = 0x10000016;

        /// <summary>
        /// 命名重复
        /// </summary>
        public const int CODE_ARGUMENT_DATA_REPEAT = 0x10000017;

        /// <summary>
        /// 应用标识已存在
        /// </summary>
        public const int CODE_APP_EXIST = 0x10000018;

        /// <summary>
        /// 用户无权限
        /// </summary>
        public const int CODE_USER_NO_AUTHORITY = 0x10000019;

        #endregion

        /// <summary>
        /// 获取返回码消息
        /// </summary>
        /// <param name="code">返回状态码</param>
        /// <returns>返回码消息</returns>
        public static string GetMessage(int code)
        {
            string message = "";
            _errorCodeDic.TryGetValue(code, out message);
            return message;
        }

        private static readonly Dictionary<int, string> _errorCodeDic;

        static StateCode()
        {
            _errorCodeDic = new Dictionary<int, string>();

            _errorCodeDic.Add(CODE_MODEL_CONVERT_ERROR, "模型转换错误");
            _errorCodeDic.Add(CODE_SQL_EXECUTE_ERROR, "SQL执行异常");
            _errorCodeDic.Add(CODE_MODEL_NOT_EXIST, "模型不存在");
            _errorCodeDic.Add(CODE_CACHE_ERROR, "缓存异常");
            _errorCodeDic.Add(CODE_ARGUMENT_NULL, "参数不允许为空");
            _errorCodeDic.Add(CODE_ARGUMENT_LENGTH, "参数超长");
            _errorCodeDic.Add(CODE_ARGUMENT_TYPE_ERROR, "参数类型错误");
            _errorCodeDic.Add(CODE_GET_SEQ_ERROR, "获取序号错误");
            _errorCodeDic.Add(CODE_ARGUMENT_LIMIT_ERROR, "参数范围错误");
            _errorCodeDic.Add(CODE_ARGUMENT_NOT_EQUAL, "参数不一致");
            _errorCodeDic.Add(CODE_ARGUMENT_DATA_REPEAT, "命名重复");


            _errorCodeDic.Add(CODE_USER_NO_AUTHORITY, "用户无权限");

        }

    }
}
