using Learun.Application.TwoDevelopment.HR_Code.EverybodyStandardWage;
using Learun.Util;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate
{
    public class FormulaToCalculateBLL : FormulaToCalculateIBLL
    {
        private OperationItemsIBLL oitem = new OperationItemsBLL();
        private AttendanceSalaryFormulaIBLL attendanceSalary = new AttendanceSalaryFormulaBLL();

        private FormulaToCalculateService stc = new FormulaToCalculateService();
        private EverybodyStandardWageIBLL esw = new EverybodyStandardWageBLL();
        private IndividualStandardItemIBLL IsService = new IndividualStandardItemBLL();

        #region 计算逻辑

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalFormulainfo">计算公式的每一项</param>
        /// <param name="f_userid">用户id</param>
        /// <param name="dateMonth">薪酬结算月</param>
        /// <returns></returns>
        public double getCalculateResulet(LinkedList<string> totalFormulainfo, string f_userid, string dateMonth)
        {
            try
            {
                ReturnCommonMeg rc = new ReturnCommonMeg();
                int i = 0;
                Dictionary<string, double> totalFormula = new Dictionary<string, double>();
                string generalCFormula = null;
                //根据考勤班次查出总公式
                foreach (string items in totalFormulainfo)
                {
                    if (i == 0)
                    {
                        //获取计算总公式
                        generalCFormula = items;
                    }
                    else
                    {   //判断总公式里面是否有逻辑判断语句
                        if(generalCFormula.IndexOf("IF(") >=0 || generalCFormula.IndexOf("ROUND") >0)
                        {
                     //       flag = false;
                            //  break;
                            string item = items.Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("*", "").Replace("/", "");

                            //到考勤项里面去查是否存在
                            if (totalFormula.ContainsKey(item))
                            {
                                //已存在key
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    rc = getAttendanceSalary(item, f_userid, dateMonth);
                                    if (rc.Meg == "未找到值")
                                    {
                                      //  throw new Exception(item+ rc.Meg);
                                    }
                                    else
                                    {
                                        if ("电费".Equals(item))
                                        {
                                            totalFormula.Add(item, getAttendanceSalary(item, f_userid, dateMonth).Data.Num);
                                        }
                                        else
                                        {
                                            totalFormula.Add(item, getAttendanceSalary(item, f_userid, dateMonth).Data.Num);
                                        }
                                    }
               
                                }
                            }
                        }
                        else
                        {
                            string item = items.Replace("(", "").Replace(")", "").Replace("+", "").Replace("-", "").Replace("*", "").Replace("/", "");

                            //到考勤项里面去查是否存在
                            if (totalFormula.ContainsKey(item))
                            {
                                //已存在key
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    if ("电费".Equals(item))
                                    {
                                        totalFormula.Add(item, getAttendanceSalary(item, f_userid, dateMonth).Data.Num);
                                    }
                                    else
                                    {
                                        totalFormula.Add(item, getAttendanceSalary(item, f_userid, dateMonth).Data.Num);
                                    }
                             
                                }
                            }
                        }
                    }
                    i++;
                }

                //处理逻辑if表达式或者round表达式
              //  if (!flag)
               // {
                //    Dictionary<string, string> ifKeyResult = new Dictionary<string, string>();
               //     FormulaLogicJudgment flj = new FormulaLogicJudgment();

                //    getLogicReruslt(generalCFormula, f_userid, dateMonth, flj, ifKeyResult);
             //   }
                var resulet = Convert.ToDouble(Calculate(getGeneralCalculationResulet(generalCFormula, totalFormula)));
                //var  = Convert.ToDouble(temp);
                //替换中文项
                return resulet;
            }
            catch(Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        ///写程序一定要有大局观否则要写很多代码 首位呼应


        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attendanceItem"></param>
        /// <param name="userid"></param>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        private ReturnCommonMeg getAttendanceSalaryResult(string exetion)
        {
            try
            {

                DataStorageDTO dsdto = new DataStorageDTO();
                ReturnCommonMeg rc = new ReturnCommonMeg();

                if (true)
                {
                    string tabName = "funtion";

                    if (!string.IsNullOrEmpty(tabName))
                    {
                        //调方法生成sql
                        /**
                         * 实体表字段对应时间字段不一样所以这块写死
                         * function：根据表名生成对应的表名
                         * author：cz
                         * time：2021-09-13
                         */
                        //岗位工资
                        if ("funtion".Equals(tabName))
                        {
                            //查询标准工资
                            IEnumerable<Hy_hr_EverybodyStandardWageEntity> hyEsList = esw.GetHyPageList(exetion);
                            decimal tempCost = (decimal)hyEsList.ToList()[0].F_StandardWage;

                            //根据标准工资查询通用分项
                            IEnumerable<EverybodyStandardWageSubDTO> ebsw = esw.GetSubList(hyEsList.ToList()[0].F_UserId, tempCost);
                            foreach (var data in ebsw)
                            {
                                //if (attendanceItem.Contains(data.SubItem))
                                //{
                                //    dsdto.Num = data.SubCost;
                                //}
                            }
                        }
                        else
                        {
                            dsdto.Num = 0;
                        }
                    }
                    else
                    {
                        dsdto.Num = 0;
                    }
                }
                rc.Data = dsdto;
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        /// <summary>
        /// function:根据计算公式的到其值
        /// author:cz
        /// time:2021-09-15
        /// </summary>
        /// <param name="expression">传入公式（比如 0+1*12-3）</param>
        /// <returns></returns>
        public static object Calculate(string expression)
        {
            try
            {
                string className = "Calc";
                string methodName = "Run";
                expression = expression.Replace("/", "*1.0/");

                //设置编译参数
                CompilerParameters paras = new CompilerParameters();
                paras.GenerateExecutable = false;
                paras.GenerateInMemory = true;

                //创建动态代码
                StringBuilder classSource = new StringBuilder();
                classSource.Append("public class " + className + "\n");
                classSource.Append("{\n");
                classSource.Append(" public object " + methodName + "()\n");
                classSource.Append(" {\n");
                classSource.Append(" return " + expression + ";\n");
                classSource.Append(" }\n");
                classSource.Append("}");

                //编译代码
                CompilerResults result = new CSharpCodeProvider().CompileAssemblyFromSource(paras, classSource.ToString());

                //获取编译后的程序集。 
                Assembly assembly = result.CompiledAssembly;

                //动态调用方法。 
                object eval = assembly.CreateInstance(className);
                MethodInfo method = eval.GetType().GetMethod(methodName);
                object reobj = method.Invoke(eval, null);

                GC.Collect();
                return reobj;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        #region 判断字符串是否为数字
        //判断字符串是否为数字
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        public static bool IsUnsign(string value)
        {
            return Regex.IsMatch(value, @"^\d*[.]?\d*$");
        }
        public static bool isTel(string strInput)
        {
            return Regex.IsMatch(strInput, @"\d{3}-\d{8}|\d{4}-\d{7}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber) &&
                   !objTwoDotPattern.IsMatch(strNumber) &&
                   !objTwoMinusPattern.IsMatch(strNumber) &&
                   objNumberPattern.IsMatch(strNumber);
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="generalCFormula"></param>
        /// <param name="totalFormula"></param>
        /// <returns></returns>
        public string getGeneralCalculationResulet(string generalCFormula, Dictionary<string, double> totalFormula)
        {
            try
            {
                Dictionary<string, double> totalFormulas = new Dictionary<string, double>();
                //var totalFormulaOrder  = from pair in totalFormula orderby pair.Key descending select pair; ; //以字典Key值顺序排序[升序]
                Regex hPattern = new Regex("H");
           
                foreach (KeyValuePair<string, double> item in totalFormula)
                {
             
                    //Match mat = Regex.Match(TaobaoLink, RegexStr);
          
                    //判断是否为数字
                    if (IsNumber(item.Key))
                    {

                    }
                    else
                    {

                        if (hPattern.IsMatch(item.Key))
                        {
                            generalCFormula = generalCFormula.Replace(item.Key, "" + item.Value / 8);
                        }
                        else
                        {
                            int total = DictionaryCheck(totalFormula, item.Key);
                            if (total >= 2)
                            {
                                totalFormulas.Add(item.Key, item.Value);
                            }
                            else
                            {
                                generalCFormula = generalCFormula.Replace(item.Key, "" + item.Value);
                            }
                            //有一个bug如果长夜班数和夜班数用 replace替换时就会剩下长，所以这块要加一个判断是否是子项是否其他字符串包换关系，如果是,先替换长的字串
                        }
                       
                    }

                }
                if (totalFormulas.Count() > 0)
                {
                    foreach (var data in totalFormulas)
                    {
                        generalCFormula = generalCFormula.Replace(data.Key, "" + data.Value);
                    }
                }

                //去除if语句计算
                //传入公式计算
                //return Double.Parse(Calculate(generalCFormula.Replace("长","")).ToString());
                FormulaLogicJudgment fj = new FormulaLogicJudgment();
                string endFul = generalCFormula.Replace("长", "").ToString().Replace("IF", "if").Replace("AND", " && ").Replace("OR", " || ");

                //判断公式是否有if如果有去掉if判断逻辑计算，没有直接返回计算逻辑
                if (endFul.IndexOf("if") >= 0)
                {
                    return getLogicReruslt(endFul, endFul, fj);
                }
                else
                {
                    return endFul;
                }
              
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        private int  DictionaryCheck(Dictionary<string, double> dic,string keys)
        {
            int count = 0;
            foreach (var item in dic)
            {
                if (item.Key.IndexOf(keys) > -1)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formulLogic"></param>
        /// <param name="stringCast"></param>
        /// <param name="flj"></param>
        /// <returns></returns>
        public  string getLogicReruslt(string formulLogic, string stringCast, FormulaLogicJudgment flj)
        {
            string currentFol = stringCast;
            int starPot = currentFol.IndexOf("if(");



            if (starPot >= 0)
            {
                currentFol = currentFol.Substring(starPot, currentFol.Length - starPot);
                //替换if语句
                int starPots = currentFol.IndexOf("if(");
                int endPot = flj.bracketsMatchedSearchByLeft(currentFol.ToCharArray(), starPots + 2) + 1;
                string tempValue = currentFol.Substring(starPots, endPot);

                starPots = tempValue.IndexOf("if(");
                if (starPots >= 0)
                {
                    //递归去查找最底层的if语句
                    tempValue = tempValue.Substring(3, tempValue.Length - 3);
                    return getLogicReruslt(formulLogic, tempValue, flj);
                }
                else
                {
                    return formulLogic;
                }
            }
            else
            {
                currentFol = currentFol.Substring(0, currentFol.Length - 1);
                //没有if语句直接计算对应的值
                string[] ifItem = currentFol.Split(',');
                if (ifItem.Length != 3)
                {
                    throw new Exception("计算错误");
                }
                else
                {
                    string ifstring = "if(" + ifItem[0] + ")" + "{ " + ifItem[1] + " }" + "else{ " + ifItem[2] + " }";
                    //(ifItems[0]).
                    var engine = new V8ScriptEngine();

                    object result = engine.Evaluate(ifstring);
                    formulLogic = formulLogic.Replace("if(" + currentFol + ")", result + "");
                    int starPotend = formulLogic.IndexOf("if(");

                    if (starPotend >= 0)
                    {
                        return getLogicReruslt(formulLogic, formulLogic, flj);
                    }
                    else
                    {
                        return formulLogic;
                    }
                }
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f_Expression"></param>
        /// <param name="initCalcu"></param>
        /// <param name="endCalcul"></param>
        /// <returns></returns>
        private LinkedList<string> getGeneralCalculation(string f_Expression,string initCalcu,LinkedList<string> endCalcul)
        {
            try
             {
                if (!string.IsNullOrEmpty(f_Expression))
                {
                    string[] exeArray = f_Expression.Split('@');
                    if (exeArray.Length > 1)
                    {
                        for (int i = 0;i < exeArray.Length;i++)
                        {
                            // exeArray[i]
                            //检查是否存在存在就递归,不存在就相加
                            IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asend =  attendanceSalary.GetPageList().Where(e => exeArray[i].Equals(e.F_FormulaCode));
                            if (asend.Count() > 0)
                            {
                                initCalcu = getGeneralCalculation("("+asend.ToList()[0].F_Expression +")", initCalcu, endCalcul).First() ;

                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(exeArray[i]))
                                {
                                    endCalcul.AddLast(exeArray[i]);
                                }
                                //调用薪资项目替换每人的考勤工资
                                initCalcu += exeArray[i];
                            }
                        }
                    }
                    else
                    {
                        endCalcul.AddLast(initCalcu + f_Expression);
                        return endCalcul;
                    }
                }
                else
                {
                    return null;
                }
                if (endCalcul.Count() == 0)
                {
                    endCalcul.AddFirst(initCalcu);
                }
                else
                {
               //     endCalcul.RemoveFirst();
                    endCalcul.AddFirst(initCalcu);
                }
                return endCalcul;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 获取子项的相关值
        /// </summary>
        /// <param name="attendanceItem"></param>
        /// <param name="userid"></param>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        private ReturnCommonMeg getAttendanceSalary(string attendanceItem,string userid,string monthTime)
        {
            try
            {
                DataStorageDTO dsdto = new DataStorageDTO();
                ReturnCommonMeg rc = new ReturnCommonMeg();
                IEnumerable<Hy_hr_OperationItemsEntity> opItem = oitem.GetList().Where(e => e.F_Item == attendanceItem);
                if (opItem.Count()>0)
                {
                    string tabName = opItem.ToList()[0].F_TableName;
                    string filedName = opItem.ToList()[0].F_FiledName;
                    if (!string.IsNullOrEmpty(tabName) && !string.IsNullOrEmpty(filedName))
                    {
                        //调方法生成sql
                        /**
                         * 实体表字段对应时间字段不一样所以这块写死
                         * function：根据表名生成对应的表名
                         * author：cz
                         * time：2021-09-13
                         */
                        //岗位工资
                        if ("Hy_hr_PostLevel".Equals(tabName))
                        {
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if ("Hy_hr_FiveInsurancesOneFund".Equals(tabName))
                        {
                            //string tabName,string filedName,string f_userid,string monthTime,string timeFiled
                            //五险一金表，时间字段
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_SettlementYearMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if("Hy_hr_SalaryGeneration".Equals(tabName))
                        {
                            //月结算数据
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_WagesYearMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }

                        }
                        //"Hy_hr_AttendanceSheet"
                        else if ("Hy_hr_AttendanceSheet".Equals(tabName))
                        {
                            //月考勤数据
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_AttendanceMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }

                        }
                        else if ("Hy_hr_RoomRate".Equals(tabName))
                        {
                            //房费
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_RoomRateYreaMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if ("Hy_hr_WaterElectricity".Equals(tabName))
                        {
                            //水电费
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_SettlementYearMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }

                        }
                        else if ("Hy_hr_EverybodyStandardWage".Equals(tabName))
                        {
                            //标准工资
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid).ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if ("Hy_hr_FiveInsurancesOneFund".Equals(tabName))
                        {
                            //通用项
                            IEnumerable<DataStorageDTO> dsList = stc.GetGenMonthList(tabName, filedName, userid , "F_SettlementYearMonth").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if ("Hr_personalStandards_file".Equals(tabName))
                        {
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid).ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else if ("Hy_hr_RewardPunishment".Equals(tabName))
                        {
                            //奖惩
                            IEnumerable<DataStorageDTO> dsList = stc.GetGenRewardsMonthList(tabName, filedName, userid, monthTime, attendanceItem).ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }else if ("HR_SeniorityPayTable".Equals(tabName))
                        {
                            //工龄工资
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_MonthLength").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }

                        }
                        else if ("Hr_FinancialDeductions".Equals(tabName))
                        {
                            //财务扣款
                            IEnumerable<DataStorageDTO> dsList = stc.GetMonthList(tabName, filedName, userid, monthTime, "F_MonthFinancial").ToList();
                            if (dsList.Count() > 0)
                            {
                                dsdto.Num = dsList.ToList()[0].Num;
                            }
                            else
                            {
                                dsdto.Num = 0;
                            }
                        }
                        else 
                        {
                            dsdto.Num = 0;
                        }
                    }
                    else
                    {
                        dsdto.Num = 0;
                    }
                }
                else
                {
                    rc.Meg = "未找到值";
                }

                rc.Data = dsdto;
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
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shiftType"></param>
        /// <returns></returns>
        public LinkedList<string> getTheTotalFormula(string shiftType)
        {
            LinkedList<string> totalFormula = new LinkedList<string>();
            try
            {
                if ("应发工资".Equals(shiftType))
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList().Where(e => e.F_FormulaName.Contains(shiftType));
                    return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                }
                else if ("缺勤扣款".Equals(shiftType))
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList().Where(e => e.F_FormulaName.Contains(shiftType));
                    return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                }
                else if("延时工资（倒班）".Equals(shiftType))
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList().Where(e => e.F_FormulaName.Contains(shiftType));
                    return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                }
                else if ("夜班补贴（倒班）".Equals(shiftType))
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList().Where(e => e.F_FormulaName.Contains(shiftType));
                    return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                }
                else if ("法定节假日加班工资".Equals(shiftType))
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList().Where(e => e.F_FormulaName.Contains(shiftType));
                    return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                }
                else
                {
                    IEnumerable<Hy_hr_AttendanceSalaryFormulaEntity> asf = attendanceSalary.GetPageList(shiftType).ToList();
                    if (asf.Count() > 0 && asf.Count() == 1)
                    {
                        return getGeneralCalculation(asf.ToList()[0].F_Expression, "", totalFormula);
                    }
                    else
                    {
                        return null;
                    }
                }
               
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="filedName"></param>
        /// <param name="flowLength"></param>
        /// <param name="head"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        #region 获取流水编号
        public string getTableFileNum(string dbinfo, string tableName, string filedName, int flowLength, string head, string db)
        {
            try
            { 

                 string a1 = "";
                IEnumerable < DataStoreNumDTO > dt  = stc.getTableFileNum(dbinfo,tableName, filedName, flowLength, head, db);
                if (dt.Count() > 0)
                {
                     a1 = dt.ToList()[0].Num;
                }

                return a1;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion
    }


}
