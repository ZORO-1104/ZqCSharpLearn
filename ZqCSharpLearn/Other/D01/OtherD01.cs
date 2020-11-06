using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZqCSharpLearn.Other.D01
{
    internal class OtherD01 : ICodeTest
    {
        public void Execute()
        {
            Test01();
            Test02();
        }

        /// <summary>
        /// 特性类的AllowMultiple和Inherited
        /// 1.如不设置，默认为AllowMultiple=false Inherited=true
        /// 2.测试结果如下：
        ///     1.父类中添加特性A（Inherited=true），子类不写特性，==>  子类中可以继承父类的特性A
        ///     2.父类中添加特性A（Inherited=false），子类不写特性，==>  子类中可以没有特性
        ///     3.父类中添加特性A（Inherited=false），子类添加特性B，==>  子类中有特性B
        ///     4.父类中添加特性A（Inherited=true），子类添加特性B，==>  子类中有特性A、B
        ///     5.父类中添加特性A（Inherited=true, AllowMultiple=false），子类添加特性A，==>  子类中有特性A（该特性为子类自己添加的特性）
        ///     5.父类中添加特性A（Inherited=true, AllowMultiple=true），子类添加特性A，==>  子类中有2个特性A（一个为父类的，一个为自己添加的）
        ///
        ///
        /// </summary>
        private void Test02()
        {
            foreach (MethodInfo p in typeof(SubOrder).GetMethods())
            {
                foreach (object attribute in p.GetCustomAttributes(true)) //2.通过映射，找到成员属性上关联的特性类实例，
                {
                    Console.WriteLine(attribute.ToString());
                }
            }
        }

        private void Test01()
        {
            Order order = new Order();

            do
            {
                Console.WriteLine();
                Console.WriteLine("请输入订单号：");
                order.OrderId = Console.ReadLine();
            }
            while (!Checker.isOrderValid(order));

            Console.WriteLine("订单号输入正确，按任意键退出！");
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class StringLengthAttribute : Attribute
    {
        public string DisplayName { get; private set; }
        public int MaxLength { get; private set; }
        public string ErrorMessage { get; set; }//验证失败的提示信息
        public int MinLength { get; set; }//可选的规范标准

        public StringLengthAttribute(string displayName, int maxLength)
        {
            this.DisplayName = displayName;
            this.MaxLength = maxLength;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true)]
    public class CountAttribute : Attribute
    {
    }

    public class Order
    {
        [StringLength("订单号", 6, MinLength = 3, ErrorMessage = "{0}的长度必须在{1}和{2}之间！")]
        public string OrderId { get; set; }

        public string OrderName { get; set; }

        [Count]
        [StringLength("供应商", 10, MinLength = 1, ErrorMessage = "{0}的长度必须在{1}和{2}之间！")]
        public string OrderSupplier { get; set; }

        [Count]
        public int OrderCount { get; set; }

        [StringLength("订单号", 16, MinLength = 13, ErrorMessage = "{0}的长度必须在{1}和{2}之间！")]
        [Count]
        public virtual void Fun()
        {
        }
    }

    public class SubOrder : Order
    {
        [StringLength("订单号", 60, MinLength = 30, ErrorMessage = "{0}的长度必须在{1}和{2}之间！")]
        public override void Fun()
        {
        }
    }

    public class Checker
    {
        //验证过程
        //1.通过映射，找到成员属性关联的特性类实例，
        //2.使用特性类实例对新对象的数据进行验证

        //用特性类验证订单号长度
        //[Obsolete("该方法已过时，请使用XXXX来代替。")]
        public static bool isIDLengthValid(int IDLength, MemberInfo member)
        {
            MethodBase mb = MethodInfo.GetCurrentMethod();
            Console.WriteLine(mb.Name);
            Console.WriteLine(mb.ToString());
            foreach (var item in mb.GetParameters())
            {
                Console.WriteLine($"{item.Position},{item.Name},{item.ParameterType},{item.DefaultValue}");
            }
            Console.WriteLine("--------");

            foreach (object attribute in member.GetCustomAttributes(true)) //2.通过映射，找到成员属性上关联的特性类实例，
            {
                if (attribute is StringLengthAttribute)//3.如果找到了限定长度的特性类对象，就用这个特性类对象验证该成员
                {
                    StringLengthAttribute attr = (StringLengthAttribute)attribute;
                    if (IDLength < attr.MinLength || IDLength > attr.MaxLength)
                    {
                        string displayName = attr.DisplayName;
                        int maxLength = attr.MaxLength;
                        int minLength = attr.MinLength;
                        string error = attr.ErrorMessage;
                        Console.WriteLine(error, displayName, maxLength, minLength);//验证失败，提示错误

                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //验证订单对象是否规范
        public static bool isOrderValid(Order order)
        {
            if (order == null)
            {
                return false;
            }

            foreach (PropertyInfo p in typeof(Order).GetProperties())
            {
                if (p.PropertyType == typeof(string))
                {
                    if (isIDLengthValid(Convert.ToString(p.GetValue(order, null)).Length, p))
                    {
                        //return true;
                    }
                    else
                    {
                        //return false;
                    }
                }
            }

            return false;
        }
    }
}