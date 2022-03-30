using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate
{
    public class FormulaLogicJudgment
    {
		public  int bracketsMatchedSearchByLeft(char[] checkedCharArray, int leftIndex)
		{

			// 校验传进来的数组和索引是否为合法
			if (checkedCharArray.Length < leftIndex || leftIndex < 0)
			{
				return -1;
			}

			char left = checkedCharArray[leftIndex];
			left = '{';
			// 非左括号或空格
			if (!('(' == left || '[' == left || '{' == left))
			{
				return -1;
			}

			/*
			 *  获取传进来的是第几个左括号
			 */
			int index = 0;

			Match matcher = Regex.Match(new String(checkedCharArray), "\\(|\\[|\\{", RegexOptions.IgnoreCase);
			while (matcher.Success)
			{
				index++;
				if (matcher.Index == leftIndex)
				{
					break;
				}
			}
			/*
			 *  获取另一配对括号位置
			 */
			Stack<char> bracketsStack = new Stack<char>();
			int count = 0;
			for (int i = 0; i < checkedCharArray.Length; i++)
			{
				char c = checkedCharArray[i];

				// 左括号都压入栈顶，右括号进行比对
				if (c == '(' || c == '[' || c == '{')
				{
					count++;
					// 如果是目标，就插入*作为标记
					if (index == count)
					{
						bracketsStack.Push('*');
					}
					else
					{
						bracketsStack.Push(c);
					}
				}
				else if (c == ')' || c == ']' || c == '}')
				{
					// 栈非空校验，防止首先出现的是右括号
					if (bracketsStack.Count == 0)
					{
						return -2;
					}
					char popChar = bracketsStack.Pop();
					if ('*' == popChar)
					{
						return i;
					}
				}
			}

			return -2;
		}

		/**
		 * 校验字符串中的括号是否匹配
		 * @param s
		 * @return
		 */
		public static Boolean isMatch(string s)
		{
			//定义左右括号的对应关系
			Dictionary<char, char> bracket = new Dictionary<char, char>();
			bracket.Add(')', '(');
			bracket.Add(']', '[');
			bracket.Add('}', '{');

			Stack<Char> stack = new Stack<Char>();

			for (int i = 0; i < s.Length; i++)
			{
				//string values = "";
				char temp = s[i];//先转换成字符
								 //是否为左括号
				if (bracket.ContainsValue(temp))
				{
					stack.Push(temp);
					//是否为右括号
				}
				else if (bracket.ContainsKey(temp))
				{
					if (stack.Count == 0)
					{
						return false;
					}
					//若左右括号匹配
					if (stack.Peek().Equals(bracket.TryGetValue(temp, out char values)))
					{
						stack.Pop();
					}
					else
					{
						return false;
					}
				}
			}
			return stack.Count == 0 ? true : false;

		}

		/**
		 * 通过右括号的位置得到匹配的左括号的位置
		 * 
		 * 返回对应坐标为正常，
		 * -1表示传进来的坐标不是右括号
		 * -2表示不存在对应右括号（不应该出现，应该提前校验过括号配对）
		 * 
		 * @param checkedCharArray
		 * @param leftIndex
		 * @return
		 */
		public static int bracketsMatchedSearchByRight(char[] checkedCharArray, int rightIndex)
		{

			// 校验传进来的数组和索引是否为合法
			if (checkedCharArray.Length < rightIndex || rightIndex < 0)
			{
				return -1;
			}

			char right = checkedCharArray[rightIndex];
			// 非左括号或空格
			if (!(')'.Equals(right) || ']'.Equals(right) || '}'.Equals(right)))
			{
				return -1;
			}

			/*
			 *  获取另一配对括号位置
			 */
			Stack<char> bracketsStack = new Stack<char>();
			for (int i = rightIndex; i > 0; i--)
			{
				char c = checkedCharArray[i];

				// 左括号都压入栈顶，右括号进行比对
				if (c == ')' || c == ']' || c == '}')
				{
					// 如果是目标，就插入*作为标记
					if (i == rightIndex)
					{
						bracketsStack.Push('*');
					}
					else
					{
						bracketsStack.Push(c);
					}
				}
				else if (c == '(' || c == '[' || c == '{')
				{
					// 栈非空校验，防止首先出现的是右括号
					if (bracketsStack.Count == 0)
					{
						return -2;
					}
					char popChar = bracketsStack.Pop();
					if ('*' == popChar)
					{
						return i;
					}
				}
			}

			return -2;
		}
	}
}
