using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate;
using Learun.Application.TwoDevelopment.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlements
{
    public class MonthlySettlementsIBLLImpl : MonthlySettlementsIBLL
    {
        ReturnCommon rc = new ReturnCommon();

        private MonthlyAttendanceReportIBLL monthlyAttendanceReportIBLL = new MonthlyAttendanceReportBLL();

        private UserIBLL userIBLL = new UserBLL();

        private SalaryGenerationIBLL sgIBLL = new SalaryGenerationBLL();
        private IndividualStandardItemIBLL IsService = new IndividualStandardItemBLL();

        //工龄工资
        private SeniorityPayClassIBLL spInfoBLL = new SeniorityPayClassBLL();
        //财务扣款
        private FinancialDeductionsClassIBLL fdInfoBLL = new FinancialDeductionsClassBLL();
        #region 获取数据

        /// <summary>
        /// 
        /// </summary>
        /// <param name="computTime"></param>
        /// <returns></returns>
        public ReturnCommon monthlyCalculation(string computTime)
        {
            try
            {
                 FormulaToCalculateIBLL ftcIBLL = new FormulaToCalculateBLL();
                //拿到要结算的月考勤数据
                IEnumerable<Hy_hr_AttendanceSheetEntity> data = monthlyAttendanceReportIBLL.GetMonthList().Where(e => e.F_AttendanceMonth.Equals(computTime)).ToList();
                //IEnumerable<Hy_hr_AttendanceSheetEntity> data = monthlyAttendanceReportIBLL.GetMonthList().Where(e => e.F_AttendanceMonth.Equals(computTime) && e.F_UserId.Equals("afb890d5-bc53-4278-83a8-2d1ea281d893")).ToList();
                EverybodyStandardWageIBLL esw = new EverybodyStandardWageBLL();
                //存储月结算数据
                List<Hy_hr_SalaryGenerationEntity> hrSalaryGenerationList = new List<Hy_hr_SalaryGenerationEntity>();
                if (data.Count() > 0)
                {
                    //计算逻辑有所修改
                    //返回应发工资计算公式,算出应发工资，缺勤扣款等于标准工资减去应发工资
                    

                    //长白班
                    LinkedList<string> genTotalFormulaLinkList = new LinkedList<string>();
                    genTotalFormulaLinkList =  ftcIBLL.getTheTotalFormula("TotalNormalShifts");

                    //夜班
                    LinkedList<string> genTotalFormulaNightLinkList = new LinkedList<string>();
                    genTotalFormulaNightLinkList = ftcIBLL.getTheTotalFormula("TotalNormalShifts");

                    //应发工资计算公式
                    LinkedList<string> genApplyPayLinkList = new LinkedList<string>();
                    genApplyPayLinkList = ftcIBLL.getTheTotalFormula("应发工资");

                    //缺勤扣款
                    LinkedList<string> genAbsenceLinkList = new LinkedList<string>();
                    genAbsenceLinkList = ftcIBLL.getTheTotalFormula("缺勤扣款");

                    //延时工资
                    LinkedList<string> delaySalaryLinkList = new LinkedList<string>();
                    delaySalaryLinkList = ftcIBLL.getTheTotalFormula("延时工资（倒班）");

                    //夜班补贴
                    LinkedList<string> nightShiftAllowanceLinkList = new LinkedList<string>();
                    nightShiftAllowanceLinkList = ftcIBLL.getTheTotalFormula("夜班补贴（倒班）");

                    //法定节假日工资
                    LinkedList<string> statutoryHolidaysLinkList = new LinkedList<string>();
                    statutoryHolidaysLinkList = ftcIBLL.getTheTotalFormula("法定节假日加班工资");

                    ///测试环节设置变量 i
                   // int j = 0;
                    foreach (var itemData in data)
                    {
                        //根据工号获取用户信息的排班制度
                        string shifType = userIBLL.GetEntityByUserId(itemData.F_UserId).F_WorkingSystem;
                        //获取月结算数据
                        Hy_hr_SalaryGenerationEntity sg = sgIBLL.GetHy_hr_SalaryGenerationEntity(itemData.F_UserId , itemData.F_AttendanceMonth).FirstOrDefault();

                        //获取个人标准工资
                        //查询标准工资
                        IEnumerable<Hr_personalStandards_fileEntity> hyEsList = IsService.GetList(itemData.F_UserId);

                        //工龄工资
                        IEnumerable<HR_SeniorityPayTableEntity> spList = spInfoBLL.GetList(itemData.F_UserId, itemData.F_AttendanceMonth);
                        if (spList.Count() > 0)
                        {
                            sg.F_SeniorityPay = spList.FirstOrDefault().F_CostMoney;
                        }
                        //财务扣款
                        IEnumerable<Hr_FinancialDeductionsEntity> fdList = fdInfoBLL.GetList(itemData.F_UserId, itemData.F_AttendanceMonth);
                        if (fdList.Count() > 0)
                        {
                            sg.F_FinancialDeduction = fdList.FirstOrDefault().F_DeductionsMoney;
                        }
                        //sgIBLL.
                        if (!string.IsNullOrEmpty(shifType))
                        {
                            //根据考勤计算的工资
                            double absenceDeductions = 0;
                            //应发工资
                            double shouldPay = 0;
                            //实发工资
                            double realPay = 0;

                            //延时工资
                            double delaySalaryMoney = 0;

                            //夜班补贴
                            double nightShiftAllowanceMoney = 0;

                            //法定节假日工资
                            double statutoryHolidaysMoney = 0;

                            //1.返回缺勤扣款
                            if ("正常班".Equals(shifType) || "特殊工时".Equals(shifType))
                            {
                                //应发工资
                                shouldPay = ftcIBLL.getCalculateResulet(genApplyPayLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //延时工资
                                delaySalaryMoney = ftcIBLL.getCalculateResulet(delaySalaryLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);

                                //夜班补贴
                                nightShiftAllowanceMoney = ftcIBLL.getCalculateResulet(nightShiftAllowanceLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);

                                //法定节假日工资
                                statutoryHolidaysMoney = ftcIBLL.getCalculateResulet(statutoryHolidaysLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //缺勤扣款 =  标准工资 - 应发工资
                                absenceDeductions = ftcIBLL.getCalculateResulet(genAbsenceLinkList, itemData.F_UserId, itemData.F_AttendanceMonth) + (double)hyEsList.ToList()[0].f_ps12; ;
                                //实发工资
                                realPay = ftcIBLL.getCalculateResulet(genTotalFormulaLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);


                            }
                            else 
                            {
                               // continue;
                                //应发工资
                                shouldPay = ftcIBLL.getCalculateResulet(genApplyPayLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //延时工资
                                delaySalaryMoney = ftcIBLL.getCalculateResulet(delaySalaryLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //夜班补贴
                                nightShiftAllowanceMoney = ftcIBLL.getCalculateResulet(nightShiftAllowanceLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //法定节假日工资
                                statutoryHolidaysMoney = ftcIBLL.getCalculateResulet(statutoryHolidaysLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);
                                //缺勤扣款 =  标准工资 - 应发工资
                                absenceDeductions = ftcIBLL.getCalculateResulet(genAbsenceLinkList, itemData.F_UserId, itemData.F_AttendanceMonth) +(double)hyEsList.ToList()[0].f_ps12;
                                //实发工资
                                realPay = ftcIBLL.getCalculateResulet(genTotalFormulaNightLinkList, itemData.F_UserId, itemData.F_AttendanceMonth);

                            }
                            
                            //


                            //2.获取缺勤考款数据减去餐补
                            sg.F_AbsenceFromDuty = (decimal)absenceDeductions  ;
                            //先给0 等会计算用
                            //夜班补贴
                            sg.F_NightShiftAllowance = (decimal)nightShiftAllowanceMoney;

                            //延时工资
                            sg.F_DelaySalary = (decimal)delaySalaryMoney;
                            //法定节假日工资
                            sg.F_StatutoryHolidaysMoney = (decimal) statutoryHolidaysMoney;

                            sg.F_WagesPayable = (decimal)shouldPay;

                            //3.计算最终工资 应发工资 +（奖惩）- 剩余项
                            sg.F_NetSalary = (decimal)realPay;
                            //sg.F_NetSalary = sg.F_WagesPayable+sg.F_RewardPunishmentSubsidy -(sg.F_RoomRate + sg.F_OvertimePay + sg.F_TotalManagementSystem  + sg.F_PersonalIncomeTax + sg.F_ElectricityFees + sg.F_PartyMembershipDues + sg.F_FinancialDeduction + sg.F_AbsenceFromDuty + sg.F_FiveInsurancesOneFund);

                            //4.修改单个添加list
                            hrSalaryGenerationList.Add(sg);

                            //j++;
                        }
                        else
                        {
                            rc.Status = false;
                            rc.Message = "对应人员没有查到对应排班制度请联系管理员";
                        }
                        /*
                        if (j == 5)
                        {
                            break;
                        }
                        */
                        //~1~~~

                    }
                    int count = sgIBLL.SaveEntity(hrSalaryGenerationList);
                    if (count == 0)
                    {
                        rc.Status = false;
                        rc.Message = "月结算批量计算失败,请联系管理员";
                    }
                    else
                    {
                        rc.Status = true;
                        rc.Message = "月结算计算完成";
                    }
                }
                else
                {
                    rc.Status = false;
                    rc.Message = "未查询到该月的月考勤数据,请联系管理员";
                }
                return rc;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ReturnCommon monthlyCalculation()
        {
            throw new NotImplementedException();
        }

        public ReturnCommon monthlyCalculation(DateTime date)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
