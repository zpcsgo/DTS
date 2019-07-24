using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DtsClass
    {
        /// <summary>
        /// 该条数据id
        /// </summary>
        public string DTSId { get; set; }
        /// <summary>
        /// 问题单连接地址
        /// </summary>
        public string DTSUrl { get; set; }
        /// <summary>
        /// 问题单号
        /// </summary>
        public string DTSNo { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string projectName { get; set; }
        /// <summary>
        /// 问题所属特性
        /// </summary>
        public string DTSAttribute { get; set; }
        /// <summary>
        /// 问题描述
        /// </summary>
        public string DTSDecription { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string DTSCreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string DTSCreatePerson { get; set; }
        /// <summary>
        /// 缺陷发现活动
        /// </summary>
        public string DTSDefectDiscoveryActivity { get; set; }
        /// <summary>
        /// 缺陷发现阶段
        /// </summary>
        public string DTSDefectDiscoveryStage { get; set; }
        /// <summary>
        /// 问题级别
        /// </summary>
        public string DTSLevel { get; set; }
        /// <summary>
        /// 当前状态
        /// </summary>
        public string DTSCurrentState { get; set; }
        /// <summary>
        /// 当前处理人
        /// </summary>
        public string DTSCurrentHandler { get; set; }
        /// <summary>
        /// 问题修改人
        /// </summary>
        public string DTSModifier { get; set; }
        /// <summary>
        /// 关闭时间
        /// </summary>
        public string DTSCloseTime { get; set; }
        /// <summary>
        /// 活动大类
        /// </summary>
        public string DTSActiveBigClass { get; set; }
        /// <summary>
        /// 活动小类
        /// </summary>
        public string DTSActiveSmallClass { get; set; }
        /// <summary>
        /// 触发因素
        /// </summary>
        public string DTSTriggerElement { get; set; }
        /// <summary>
        /// 引入环节
        /// </summary>
        public string DTSIntroductionPart { get; set; }
        /// <summary>
        /// 问题代码类型
        /// </summary>
        public string DTSCodeType { get; set; }
        /// <summary>
        /// 根因类型
        /// </summary>
        public string DTSReturningType { get; set; }
        /// <summary>
        /// 根因子类
        /// </summary>
        public string DTSReturningTypeOfChild { get; set; }
        /// <summary>
        /// 前端、后端
        /// </summary>
        public string clientOrServer { get; set; }
        /// <summary>
        /// 是否自动化测试发现
        /// </summary>
        public string isAutoDescovery { get; set; }
        /// <summary>
        /// 是否自动化测试
        /// </summary>
        public string isShouldAuto { get; set; }
        /// <summary>
        /// 详细说明
        /// </summary>
        public string DTSDetailedInstruction { get; set; }
        /// <summary>
        /// 改进措施
        /// </summary>
        public string DTSImprovementMeasures { get; set; }
    }
}
