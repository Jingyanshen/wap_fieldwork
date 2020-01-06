using Microsoft.Practices.EnterpriseLibrary.Data;
using SH3H.WAP.FieldWork.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.DataAccess.SqlServer
{
    public class PaginationHelper
    {

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <typeparam name="T">返回的分页模型</typeparam>
        /// <param name="database">数据库链接</param>
        /// <param name="tableName">表名</param>
        /// <param name="orderbystr">排序语句 例如 "id desc"</param>
        /// <param name="wherestr">筛选语句 以And开头 例如"And Id = 1 And Name = b"</param>
        /// <param name="pagesize">页数</param>
        /// <param name="currentpage">页码</param>
        /// <param name="addparamsfunc">添加筛选语句参数</param>
        /// <param name="selectlistFunc">将cmd转换为模型对象的方法 例如:SelectList</param>
        /// <param name="executeScalarFunc">将cmd转换为执行结果的方法 例如:ExecuteScalar</param>
        /// <param name="columns">查询的列 默认查询所有列</param>
        /// <returns></returns>
        public static PaginationDto<T> SelectPage<T>(Database database,
                                        string tableName,
                                        string orderbystr,
                                        string wherestr,
                                        int pagesize,
                                        int pageindex,
                                        Action<DbCommand> addparamsfunc,
                                        Func<DbCommand, IEnumerable<T>> selectlistFunc,
                                        Func<DbCommand, DbTransaction, int> executeScalarFunc,
                                        string columns = "*",
                                        bool isPaging = true)
            where T : class
        {
            //初始化值
            PaginationDto<T> result = null;
            int count = 0;

            //查询列表基础SQL
            string baseListSqlText = @"SELECT TOP (@PageSize) * 
                                        FROM ( select ROW_NUMBER() OVER(ORDER BY {0}) AS ROWID ,{1}  FROM {2}  WHERE 1=1  {3} )AS A
                                        WHERE ROWID> (@PageSize)*((@PageIndex)-1)";
            if (!isPaging)
            {
                baseListSqlText = @"  select {0}  FROM {1}  WHERE 1=1  {2}  ORDER BY {3}";
            }

            //查询总数基础SQL
            string baseCountSqlText = @"  SELECT COUNT(*) FROM {0} WHERE 1=1  {1}";

            //查询总数
            string sqlCountText = string.Format(baseCountSqlText, tableName, wherestr);
            using (DbCommand cmd = database.GetSqlStringCommand(sqlCountText))
            {
                //调用筛选参数赋值
                addparamsfunc(cmd);

                count = executeScalarFunc(cmd, null);
            }

            //查询列表
            string sqlListText = string.Format(baseListSqlText, orderbystr, columns, tableName, wherestr);
            if (!isPaging)
            {
                sqlListText = string.Format(baseListSqlText, columns, tableName, wherestr, orderbystr);
            }

            using (DbCommand cmd = database.GetSqlStringCommand(sqlListText))
            {
                if (isPaging)
                {
                    database.AddInParameter(cmd, "@PageSize", DbType.Int32, pagesize);
                    database.AddInParameter(cmd, "@PageIndex", DbType.Int32, pageindex);
                }

                //调用筛选参数赋值
                addparamsfunc(cmd);
                //获取列表
                IEnumerable<T> list = selectlistFunc(cmd);

                //拼接返回对象
                result = new PaginationDto<T>(list, count);
                //返回
                return result;
            }
        }


        /// < summary>
        /// 分析用户请求是否正常
        /// < /summary>
        /// < param name="Str">传入用户提交数据< /param>
        /// <param name="type">排查模式 0严格1简单</param>
        /// < returns>返回是否含有SQL注入式攻击代码< /returns>
        public static bool SqlSafeCheck(string Str, int type = 0)
        {
            string SqlStr;
            if (type == 1)
                SqlStr = "exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
            else
                SqlStr = "'|and|exec|insert|select|delete|update|count|*|chr|mid|master|truncate|char|declare";
            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }

        /// <summary>
        /// 过滤标记
        /// </summary>
        /// <param name="NoHTML">包括HTML，脚本，数据库关键字，特殊字符的源码 </param>
        /// <returns>已经去除标记后的文字</returns>
        public static string NoHtml(string Htmlstring)
        {
            if (Htmlstring == null)
            {
                return "";
            }
            else
            {
                //删除脚本
                Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
                //删除HTML
                Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);

                //删除与数据库相关的词
                Htmlstring = Regex.Replace(Htmlstring, "select", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "insert", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete from", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "count''", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop table", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "truncate", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "asc", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "mid", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "char", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "exec master", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "and", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net user", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "or", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "net", "", RegexOptions.IgnoreCase);
                //Htmlstring = Regex.Replace(Htmlstring, "*", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "-", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "delete", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "drop", "", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "script", "", RegexOptions.IgnoreCase);

                //特殊的字符
                Htmlstring = Htmlstring.Replace("<", "");
                Htmlstring = Htmlstring.Replace(">", "");
                Htmlstring = Htmlstring.Replace("*", "");
                Htmlstring = Htmlstring.Replace("-", "");
                Htmlstring = Htmlstring.Replace("?", "");
                Htmlstring = Htmlstring.Replace("'", "''");
                Htmlstring = Htmlstring.Replace(",", "");
                Htmlstring = Htmlstring.Replace("/", "");
                Htmlstring = Htmlstring.Replace(";", "");
                Htmlstring = Htmlstring.Replace("*/", "");
                Htmlstring = Htmlstring.Replace("\r\n", "");
                //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
                Htmlstring = Htmlstring.Trim();

                return Htmlstring;
            }
        }

        /// <summary>  
        /// 检测是否有Sql危险字符  
        /// </summary>  
        /// <param name="str">要判断字符串</param>  
        /// <returns>判断结果</returns>  
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>  
        /// 删除SQL注入特殊字符  
        /// 解然 20070622加入对输入参数sql为Null的判断  
        /// </summary>  
        public static string StripSQLInjection(string sql)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                //过滤 ' --  
                string pattern1 = @"(\%27)|(\')|(\-\-)";

                //防止执行 ' or  
                string pattern2 = @"((\%27)|(\'))\s*((\%6F)|o|(\%4F))((\%72)|r|(\%52))";

                //防止执行sql server 内部存储过程或扩展存储过程  
                string pattern3 = @"\s+exec(\s|\+)+(s|x)p\w+";

                sql = Regex.Replace(sql, pattern1, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern2, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern3, string.Empty, RegexOptions.IgnoreCase);
            }
            return sql;
        }

    }

}
