using Learun.Application.TwoDevelopment.HR_Code.FSConsumptionRecord;
using Learun.Application.TwoDevelopment.HR_Code.MonthlyAttendanceDataAutoClass;
using Learun.Application.TwoDevelopment.HY_Logistics;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.NewVegetablePrices
{
    public class VegetablePricesService : RepositoryFactory
    {
        private FSConsumptionRecordIBLL fsConsumptionRecordBLL = new FSConsumptionRecordBLL();
        private MealSubsidyRulesClassIBLL msrIBLL = new MealSubsidyRulesClassBLL();
        private FSVegetablePricesCalculationIBLL fsvpcIBLL = new FSVegetablePricesCalculationBLL();
        private MonthlyAttendanceDataAutoClassIBLL mdIBLL = new MonthlyAttendanceDataAutoClassBLL();
        private AttendanceMaintenanceClassIBLL amIBLL = new AttendanceMaintenanceClassBLL();
        private FSVegetablePriceSubsidyMonthlyDetailsIBLL fsConsumptionRecordDetailsBLL = new FSVegetablePriceSubsidyMonthlyDetailsBLL();
        private Hr_MealAllowanceStandardEntity breakfastEntity = null;
        private Hr_MealAllowanceStandardEntity lunchEntity = null;
        private Hr_MealAllowanceStandardEntity dinnerEntity = null;
        private Hr_MealAllowanceStandardEntity nightEntity = null;
        public VegetablePricesService() {
             breakfastEntity = msrIBLL.GetVgOneMealAllowanceStandardEntity("早餐");
             lunchEntity = msrIBLL.GetVgOneMealAllowanceStandardEntity("午餐");
             dinnerEntity = msrIBLL.GetVgOneMealAllowanceStandardEntity("晚餐");
             nightEntity = msrIBLL.GetVgOneMealAllowanceStandardEntity("夜宵");
        }
    //消费记录


        public ReturnCommon CalculateVegetablePrice()
        {
            try
            {

                ReturnCommon rc = new ReturnCommon();
                rc.Status = true;
                /**
                 * 业务逻辑代码
                 */
                //1.生成人员信息

                string year = DateTime.Now.Year + "";
                string month = DateTime.Now.Month + "";
                if (DateTime.Now.Month == 1)
                {
                    year = DateTime.Now.Year - 1 +"";
                    month = "12";
                }
                else
                {
                    month = DateTime.Now.Month -1 + "";
                }
                //存放数据 
                List<FS_VegetablePricesEntity> FS_VegetablePricesList = new List<FS_VegetablePricesEntity>();
                List<FS_VegetablePricesEntity> FS_VegetablePricesValueList = new List<FS_VegetablePricesEntity>();

                IEnumerable<AttendanceUserDTO> AttendanceUserDTOList =  mdIBLL.GetInitPageList(year,month);

                IEnumerable<FS_VegetablePricesEntity> FS_VegetablePriceList = fsvpcIBLL.GetList(year, month);
                if (FS_VegetablePriceList.Count() >0)
                {
                    this.BaseRepository().Delete<FS_VegetablePricesEntity>(e => e.F_Year == year && e.F_Month == month);
                }
                 // var dataList = AttendanceUserDTOList.Where(e => e.user_code == "HY002919");
                foreach (var AttendanceUser in AttendanceUserDTOList)
                {
                     FS_VegetablePricesEntity fsEnrity = new FS_VegetablePricesEntity();
                     fsEnrity = new FS_VegetablePricesEntity();
                     fsEnrity.Create();
                     fsEnrity.F_UserId = AttendanceUser.user_code;
                     fsEnrity.F_UserName = AttendanceUser.user_name;
                     fsEnrity.F_Year = AttendanceUser.yearno;
                     fsEnrity.F_Month = AttendanceUser.monthno;
                     fsEnrity.F_DeptId = AttendanceUser.deptid;
                     fsEnrity.F_DeptName = AttendanceUser.deptname;
                     fsEnrity.F_CostCenterno = AttendanceUser.center_cost_code;
                     fsEnrity.F_CostCenterName = AttendanceUser.center_cost;
                     fsEnrity.F_MonBreakfastTogether = 0;
                     fsEnrity.F_MonDinnerTogether = 0;
                     fsEnrity.F_MonLunchTogether = 0;
                     fsEnrity.F_MonSupperTogether = 0;
                     fsEnrity.F_CountMoney = 0;
                     FS_VegetablePricesList.Add(fsEnrity);
                 }
                 foreach (var entity in FS_VegetablePricesList)
                 {
                     //2查找人员本人当前的考勤信息
                     FS_VegetablePricesEntity entityValue = getSubsidiesInformation(entity);
                     FS_VegetablePricesValueList.Add(entityValue);
                 }
                 int count1 = this.BaseRepository().Insert(FS_VegetablePricesValueList);
                 if (count1 > 0)
                 {
                        rc.Status = true;
                        rc.Message = "菜价补贴计算成功!!!";
                     }
                    else
                    {
                        rc.Status = false;
                        rc.Message = "菜价补贴计算失败!!!" ;
                    }
                    return rc;
            }
             catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        public FS_VegetablePricesEntity getSubsidiesInformation(FS_VegetablePricesEntity entity)
        {
       
            try
            {
                FS_VegetablePricesEntity entityDTO = new FS_VegetablePricesEntity();
                entityDTO = entity;

                //查询签卡记录
                IEnumerable<QkAndShiftDTO> qkAndShiftList = mdIBLL.GetQkAndShiftPageList(entity.F_Year, entity.F_Month, entity.F_UserId).Where(e =>e.countTime > 0);

                //1.根据班次查询对应班次时长如果大于等于班次时长补贴金额，否则不补贴金额
                var qkAndShiftLists = qkAndShiftList.ToList().Where(e =>e.countTime > 0);
                IEnumerable<FSRecordsOfConsumptionDTO> monthPersonList = fsConsumptionRecordBLL.GetOneMonthConsumptionPersonList(entity.F_UserId,entity.F_Year,entity.F_Month);
   
                foreach (var qkAndShiftEntity in qkAndShiftLists)
                {
                    Hr_SHIFTTIMETAB_fileEntity shiftEntity = amIBLL.GetOneSHIFTTIMETAB_fileEntity(qkAndShiftEntity.bc);
                    if (shiftEntity == null)
                    {
                        entityDTO.F_Description = "未在班次基础资料找到该班次,请维护好重新计算";
                    }
                    else
                    {
                        if (qkAndShiftEntity.countTime - shiftEntity.timelimit >= 0)
                        {

                            string breakfastBegan = breakfastEntity.startime;
                            string breakfastEnd = breakfastEntity.endtime;
                            string LunchBegan = lunchEntity.startime;
                            string LunchEnd = lunchEntity.endtime;
                            string dinnerBegan = dinnerEntity.startime;
                            string dinnerEnd = dinnerEntity.endtime;
                            string nightBegan = nightEntity.startime;
                            string nightEnd = nightEntity.endtime;
                            string rq = "";
                            string[] b = qkAndShiftEntity.rq.Split(' ');
                            if (b.Length > 0)
                            {
                                rq = b[0];
                            }
                            string nextDay = Time.GetNextDayTime(rq);
                            nightBegan = rq + " " + nightBegan;
                            nightEnd = nextDay + " " + nightEnd;

                            //早餐，午餐，晚餐
                            breakfastBegan = rq + " " + breakfastBegan;
                            breakfastEnd = rq + " " + breakfastEnd;
                            LunchBegan = rq + " " + LunchBegan;
                            LunchEnd = rq + " " + LunchEnd;
                            dinnerBegan = rq + " " + dinnerBegan;
                            dinnerEnd = rq + " " + dinnerEnd;

                            //符合班次时间补贴,寻找当前班次
                            //entityDTO = NumberOfCalculationsVersion(entityDTO, qkAndShiftEntity, shiftEntity);
                            //长白班或者长夜班
                            if (shiftEntity.timelimit > 8)
                            {
                                    //长白长夜补贴一样
                                    var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                    if (monthPersonListBreak != null && monthPersonListBreak >0)
                                    {
                                        entityDTO.F_MonBreakfastTogether += 1;
                                        if (monthPersonListBreak >= breakfastEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += breakfastEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += monthPersonListBreak;
                                        }
                                    }
                                    var lunchListmony= monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(LunchBegan) && e.Comsume_Date <= Convert.ToDateTime(LunchEnd)).Sum(t => t.countMoney);
                                    if (lunchListmony != null && lunchListmony > 0)
                                    {
                                        entityDTO.F_MonLunchTogether += 1;
                                        if (lunchListmony >= lunchEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += lunchEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += lunchListmony;
                                        }
                                    }
                                    var dinnerListmony = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                    if (dinnerListmony != null && dinnerListmony > 0)
                                    {
                                        entityDTO.F_MonDinnerTogether += 1;
                                        if (dinnerListmony >= dinnerEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += dinnerEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += dinnerListmony;
                                        }
                                    }
                                    var nightListMonty = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(nightBegan) && e.Comsume_Date <= Convert.ToDateTime(nightEnd)).Sum(t => t.countMoney);
                                    if (nightListMonty != null && nightListMonty > 0)
                                    {
                                        entityDTO.F_MonSupperTogether += 1;
                                        if (nightListMonty >= nightEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += nightEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += nightListMonty;
                                        }
                                    }
                            }
                            else
                            {
                                if ("夜班".Equals(shiftEntity.shift_type))
                                {
                                    var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                    if (monthPersonListBreak != null && monthPersonListBreak > 0)
                                    {
                                        entityDTO.F_MonBreakfastTogether += 1;
                                        if (monthPersonListBreak >= breakfastEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += breakfastEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += monthPersonListBreak;
                                        }
                                    }
                                    var dinnerListmony = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                    if (dinnerListmony != null && dinnerListmony > 0)
                                    {
                                        entityDTO.F_MonDinnerTogether += 1;
                                        if (dinnerListmony >= dinnerEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += dinnerEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += dinnerListmony;
                                        }
                                    }
                                    var nightListMonty = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(nightBegan) && e.Comsume_Date <= Convert.ToDateTime(nightEnd)).Sum(t => t.countMoney);
                                    if (nightListMonty != null && nightListMonty > 0)
                                    {
                                        entityDTO.F_MonSupperTogether += 1;
                                        if (nightListMonty >= nightEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += nightEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += nightListMonty;
                                        }
                                    }

                                }
                                else
                                {
                                    //长白长夜补贴一样
                                    var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                    if (monthPersonListBreak != null && monthPersonListBreak > 0)
                                    {
                                        entityDTO.F_MonBreakfastTogether += 1;
                                        if (monthPersonListBreak >= breakfastEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += breakfastEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += monthPersonListBreak;
                                        }
                                    }
                                    var lunchListmony = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(LunchBegan) && e.Comsume_Date <= Convert.ToDateTime(LunchEnd)).Sum(t => t.countMoney);
                                    if (lunchListmony != null && lunchListmony > 0)
                                    {
                                        entityDTO.F_MonLunchTogether += 1;
                                        if (lunchListmony >= lunchEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += lunchEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += lunchListmony;
                                        }
                                    }
                                    var dinnerListmony = monthPersonList.ToList().Where(e => e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                    if (dinnerListmony != null && dinnerListmony > 0)
                                    {
                                        entityDTO.F_MonDinnerTogether += 1;
                                        if (dinnerListmony >= dinnerEntity.mas_money)
                                        {
                                            entityDTO.F_CountMoney += dinnerEntity.mas_money;
                                        }
                                        else
                                        {
                                            entityDTO.F_CountMoney += dinnerListmony;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //缺勤或者旷工不符合不计算
                            entityDTO.F_Description = "警告" + qkAndShiftEntity.rq + "考勤缺,请补签卡,确定是否事情";
                        }
                    }
                }

                return entityDTO;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnCommon CalculateVegetablePriceDetil()
        {
            try
            {
                ReturnCommon rc = new ReturnCommon();
                //查询所用的签卡记录
                rc.Status = true;
                /**
                 * 业务逻辑代码
                 */
                //1.生成人员信息

                string year = DateTime.Now.Year + "";
                string month = DateTime.Now.Month + "";
                if (DateTime.Now.Month == 1)
                {
                    year = DateTime.Now.Year - 1 + "";
                    month = "12";
                }
                else
                {
                    month = DateTime.Now.Month - 1 + "";
                }
                IEnumerable<QkAndShiftDTO> qkAndShiftList = mdIBLL.GetQkAndShiftPageListDetil(year, month);
               // var list1 = qkAndShiftList.ToList().Where(e => e.user_code == "HY005841");
                IEnumerable<FSRecordsOfConsumptionDTO> monthPersonList = fsConsumptionRecordBLL.GetOneMonthConsumptionList(year, month);

                this.BaseRepository().Delete<FS_VegetablePriceSubsidyMonthlyDetailsEntity>(e => e.F_Year == year && e.F_Month == month);

                List<FS_VegetablePriceSubsidyMonthlyDetailsEntity> list = new List<FS_VegetablePriceSubsidyMonthlyDetailsEntity>();
                //foreach (var qkEntity in list1)
                foreach (var qkEntity in qkAndShiftList)
                {
                     FS_VegetablePriceSubsidyMonthlyDetailsEntity entity = new FS_VegetablePriceSubsidyMonthlyDetailsEntity();
                     entity.F_UserId = qkEntity.user_code;
                     entity.F_UserName = qkEntity.user_name;
                     entity.F_Year = qkEntity.yearno;
                     entity.F_Month = qkEntity.monthno;
                     entity.F_Qk = Time.ToDate(qkEntity.rq);
                     entity.F_ShiftType = qkEntity.bc;
                     entity.F_Time = qkEntity.countTime;
                     entity.F_ShiftTime = qkEntity.timelimit;
                     entity.F_Breakfast = 0;
                     entity.F_Lunch = 0;
                     entity.F_Dinner = 0;
                     entity.F_Night = 0;
                     entity.F_StandardCombined = 0;
                     entity.Create();
                     //计算早餐，午餐，晚餐，夜宵
                     string breakfastBegan = breakfastEntity.startime;
                     string breakfastEnd = breakfastEntity.endtime;
                     string LunchBegan = lunchEntity.startime;
                     string LunchEnd = lunchEntity.endtime;
                     string dinnerBegan = dinnerEntity.startime;
                     string dinnerEnd = dinnerEntity.endtime;
                     string nightBegan = nightEntity.startime;
                     string nightEnd = nightEntity.endtime;
                     string rq = "";
                     string[] b = qkEntity.rq.Split(' ');
                     if (b.Length > 0)
                     {
                         rq = b[0];
                     }
                     string nextDay = Time.GetNextDayTime(rq);
                     nightBegan = rq + " " + nightBegan;
                     nightEnd = nextDay + " " + nightEnd;

                     //早餐，午餐，晚餐
                     breakfastBegan = rq + " " + breakfastBegan;
                     breakfastEnd = rq + " " + breakfastEnd;
                     LunchBegan = rq + " " + LunchBegan;
                     LunchEnd = rq + " " + LunchEnd;
                     dinnerBegan = rq + " " + dinnerBegan;
                     dinnerEnd = rq + " " + dinnerEnd;
                     if (qkEntity.countTime - qkEntity.timelimit>=0)
                     {
                         if (qkEntity.timelimit > 8)
                         {
                             //长白长夜补贴一样
                             var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                    if (monthPersonListBreak != null && monthPersonListBreak > 0)
                                    {
                                        if (monthPersonListBreak >= breakfastEntity.mas_money)
                                        {
                                            entity.F_Breakfast += breakfastEntity.mas_money;
                                        }
                                        else
                                        {
                                            entity.F_Breakfast += monthPersonListBreak;
                                        }
                                    }
                                    var lunchListmony = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(LunchBegan) && e.Comsume_Date <= Convert.ToDateTime(LunchEnd)).Sum(t => t.countMoney);
                                    if (lunchListmony != null && lunchListmony > 0)
                                    {
                                        if (lunchListmony >= lunchEntity.mas_money)
                                        {
                                            entity.F_Lunch += lunchEntity.mas_money;
                                        }
                                        else
                                        {
                                            entity.F_Lunch += lunchListmony;
                                        }
                                    }
                                    var dinnerListmony = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                    if (dinnerListmony != null && dinnerListmony > 0)
                                    {
                                        if (dinnerListmony >= dinnerEntity.mas_money)
                                        {
                                            entity.F_Dinner += dinnerEntity.mas_money;
                                        }
                                        else
                                        {
                                            entity.F_Dinner += dinnerListmony;
                                        }
                                    }
                                    var nightListMonty = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(nightBegan) && e.Comsume_Date <= Convert.ToDateTime(nightEnd)).Sum(t => t.countMoney);
                                    if (nightListMonty != null && nightListMonty > 0)
                                    {
                                        if (nightListMonty >= nightEntity.mas_money)
                                        {
                                            entity.F_Night += nightEntity.mas_money;
                                        }
                                        else
                                        {
                                            entity.F_Night += nightListMonty;
                                        }
                                    }
                                }
                                else
                                {
                                    if ("夜班".Equals(qkEntity.shift_type))
                                    {
                                        var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                        if (monthPersonListBreak != null && monthPersonListBreak > 0)
                                        {
                                            if (monthPersonListBreak >= breakfastEntity.mas_money)
                                            {
                                                entity.F_Breakfast += breakfastEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Breakfast += monthPersonListBreak;
                                            }
                                        }
                                        var dinnerListmony = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                        if (dinnerListmony != null && dinnerListmony > 0)
                                        {
                                            if (dinnerListmony >= dinnerEntity.mas_money)
                                            {
                                                entity.F_Dinner += dinnerEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Dinner += dinnerListmony;
                                            }
                                        }
                                        var nightListMonty = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(nightBegan) && e.Comsume_Date <= Convert.ToDateTime(nightEnd)).Sum(t => t.countMoney);
                                        if (nightListMonty != null && nightListMonty > 0)
                                        {
                                            if (nightListMonty >= nightEntity.mas_money)
                                            {
                                                entity.F_Night += nightEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Night += nightListMonty;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        //长白长夜补贴一样
                                        var monthPersonListBreak = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(breakfastBegan) && e.Comsume_Date <= Convert.ToDateTime(breakfastEnd)).Sum(t => t.countMoney);
                                        if (monthPersonListBreak != null && monthPersonListBreak > 0)
                                        {
                                            if (monthPersonListBreak >= breakfastEntity.mas_money)
                                            {
                                                entity.F_Breakfast += breakfastEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Breakfast += monthPersonListBreak;
                                            }
                                        }
                                        var lunchListmony = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(LunchBegan) && e.Comsume_Date <= Convert.ToDateTime(LunchEnd)).Sum(t => t.countMoney);
                                        if (lunchListmony != null && lunchListmony > 0)
                                        {
                                            if (lunchListmony >= lunchEntity.mas_money)
                                            {
                                                entity.F_Lunch += lunchEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Lunch += lunchListmony;
                                            }
                                        }
                                        var dinnerListmony = monthPersonList.ToList().Where(e => e.Person_No == qkEntity.user_code && e.Comsume_Date >= Convert.ToDateTime(dinnerBegan) && e.Comsume_Date <= Convert.ToDateTime(dinnerEnd)).Sum(t => t.countMoney);
                                        if (dinnerListmony != null && dinnerListmony > 0)
                                        {
                                            if (dinnerListmony >= dinnerEntity.mas_money)
                                            {
                                                entity.F_Dinner += dinnerEntity.mas_money;
                                            }
                                            else
                                            {
                                                entity.F_Dinner += dinnerListmony;
                                            }
                                        }
                                    }
                                }
                     }
                     else
                     {
                         entity.F_Description = "休假,或者上班时长不够";
                     }
                     entity.F_StandardCombined = entity.F_Breakfast + entity.F_Lunch + entity.F_Dinner + entity.F_Night;
                     list.Add(entity);
                 }
                 int count = this.BaseRepository().Insert(list);
                 if (count > 0)
                 {
                     rc.Status = true;
                     rc.Message = "菜价补贴计算成功!!!";
                 }
                 else
                {
                     rc.Status = false;
                     rc.Message = "菜价补贴计算失败!!!";
                 }

 
                return rc;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        private FS_VegetablePricesEntity NumberOfCalculationsVersion(FS_VegetablePricesEntity entity, QkAndShiftDTO qkAndShiftEntity, Hr_SHIFTTIMETAB_fileEntity shiftEntity)
        {
            try
            {
                string breakfastBegan = breakfastEntity.startime;
                string breakfastEnd = breakfastEntity.endtime;
                string LunchBegan = lunchEntity.startime;
                string LunchEnd = lunchEntity.endtime;
                string dinnerBegan = dinnerEntity.startime;
                string dinnerEnd = dinnerEntity.endtime;
                string nightBegan = nightEntity.startime;
                string nightEnd = nightEntity.endtime;
                //长白班或者长夜班
                //补贴四次
                //早餐
                IEnumerable<FSRecordsConsumptionDTO> subsidiesDTO = fsConsumptionRecordBLL.GetMonthlyconsumptiondataList(qkAndShiftEntity.user_code, qkAndShiftEntity.rq, breakfastBegan, breakfastEnd,
   LunchBegan, LunchEnd, dinnerBegan, dinnerEnd, nightBegan, nightEnd);

                if (subsidiesDTO.Count() == 0)
                {
                    entity.F_MonBreakfastTogether = entity.F_MonBreakfastTogether;
                    entity.F_CountMoney = entity.F_CountMoney;
                }
                else
                {
                    //早餐
                    if (subsidiesDTO.ToList()[0].zc == null)
                    {
                        subsidiesDTO.ToList()[0].zc = 0;
                    }
                    else
                    {
                        entity.F_MonBreakfastTogether += 1;
                        if (subsidiesDTO.ToList()[0].zc >= breakfastEntity.mas_money)
                        {
                            entity.F_CountMoney += breakfastEntity.mas_money;
                        }
                        else
                        {
                            entity.F_CountMoney += subsidiesDTO.ToList()[0].zc;
                        }
                    }
                    //午餐

                    if (subsidiesDTO.ToList()[0].wc == null)
                    {
                        subsidiesDTO.ToList()[0].wc = 0;
                    }
                    else
                    {
                        entity.F_MonLunchTogether += 1;
                        if (subsidiesDTO.ToList()[0].wc >= lunchEntity.mas_money)
                        {
                            entity.F_CountMoney += lunchEntity.mas_money;
                        }
                        else
                        {
                            entity.F_CountMoney += subsidiesDTO.ToList()[0].wc;
                        }
                    }

                    //晚餐
                    if (subsidiesDTO.ToList()[0].wcc == null)
                    {

                    }
                    else
                    {
                        entity.F_MonDinnerTogether += 1;
                        if (subsidiesDTO.ToList()[0].wc >= dinnerEntity.mas_money)
                        {
                            entity.F_CountMoney += dinnerEntity.mas_money;
                        }
                        else
                        {
                            entity.F_CountMoney += subsidiesDTO.ToList()[0].wcc;
                        }
                    }
                    //夜宵

                    if (subsidiesDTO.ToList()[0].yx == null)
                    {

                    }
                    else
                    {
                        entity.F_MonSupperTogether += 1;
                        if (subsidiesDTO.ToList()[0].wc >= nightEntity.mas_money)
                        {
                            entity.F_CountMoney += nightEntity.mas_money;
                        }
                        else
                        {
                            entity.F_CountMoney += subsidiesDTO.ToList()[0].yx;
                        }
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
    }
}
