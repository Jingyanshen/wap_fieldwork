using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH3H.WAP.FieldWork.Share
{
    /// <summary>
    /// 巡查类型
    /// </summary>
    public enum PatrolTypeEnum : int
    {
        /// <summary>
        /// 日常
        /// </summary>
        Daily = 1,
        /// <summary>
        /// 一级排水户
        /// </summary>
        ClassIDrainageHouseholds = 2,
        /// <summary>
        /// 排水口
        /// </summary>
        Outfall = 3,
        /// <summary>
        /// 原水管
        /// </summary>
        RawWaterPipe = 4,
        /// <summary>
        /// 液位仪
        /// </summary>
        LiquidLevelGauge = 5,
        /// <summary>
        /// 井盖
        /// </summary>
        ManholeCover = 6
    }
}
