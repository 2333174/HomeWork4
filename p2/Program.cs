using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2 
{
    public class Order
    {
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public string orderNum;
        public string orderName;
        public string orderClient;
        public Order(string num,string name,string client)
        {
            this.orderNum = num;
            this.orderName = name;
            this.orderClient = client;
        }
        public void addOrderDatails(OrderDetails b)
        {
            orderDetails.Add(b);
        }
    }
    public class OrderDetails
    {
        public string goodName;
        public string goodPrice;
        public string goodNum;
        public OrderDetails(string name,string price,string number)
        {
            this.goodName = name;
            this.goodNum = number;
            this.goodPrice = price;
        }
    }
    public class OrderService
    {
        int count=0;
        public List<Order> orderList = new List<Order>();
        public void addOrder(Order b)
        {
            orderList.Add(b);
            count++;
        }
        
        public void deleteOrder(int i)
        {
            try
            {
                orderList.Remove(orderList[i]);
                count--;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("该订单不存在");
            }

        }
        //查找订单 flag为0按订单号查找，flag为1按订单客人名称 
        public Order searchOrder(string s,int flag)
        {
            switch (flag)
            {
                case 0:
                    foreach (Order b in orderList)
                    {
                        if (b.orderNum == s) return b;
                    }
                    Console.WriteLine("无此订单");
                    return null;
                default:
                    foreach(Order b in orderList)
                    {
                        if (b.orderClient == s) return b;
                    }
                    Console.WriteLine("无此订单");
                    return null;
            }
        }
        //更改List第num个成员；flag为0，更改订单号，flag为1，更改订单商品名称，flag为2，更改订单客户名称
        public void changeOrder(int num,string s,int flag)
        {
            try
            {
                switch (flag)
                {
                    case 0:
                        orderList[num].orderNum = s;
                        break;
                    case 1:
                        orderList[num].orderName = s;
                        break;
                    default:
                        orderList[num].orderClient = s;
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("需要修改的订单不存在");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入： 1.添加  2.查找  3.删除  4.修改  #.结束操作");
            string s = Console.ReadLine();
            string s1, s2, s3, s4, s5, s6;
            OrderService c = new OrderService();
            while (s != "#")
            {
                int n = int.Parse(s);
                switch (n)
                {
                    case 1:
                        Console.Write("订单号：");
                        s1 = Console.ReadLine();
                        Console.Write("商品种类：");
                        s2 = Console.ReadLine();
                        Console.Write("客户名称：");
                        s3 = Console.ReadLine();
                        Order b1 = new Order(s1, s2, s3);
                        Console.Write("商品条目数量：");
                        int m = int.Parse(Console.ReadLine());
                        for (int i = 0; i < m; i++)
                        {
                            Console.Write("商品名称：");
                            s4 = Console.ReadLine();
                            Console.Write("商品单价：");
                            s5 = Console.ReadLine();
                            Console.Write("商品数量：");
                            s6 = Console.ReadLine();
                            OrderDetails a1 = new OrderDetails(s4, s5, s6);
                            b1.addOrderDatails(a1);
                        }
                        c.addOrder(b1);
                        break;
                    case 2:
                        Console.WriteLine("查找订单 flag为0按订单号查找，flag为1按订单客人名称 ");
                        Console.Write("flag:");
                        int flag = int.Parse(Console.ReadLine());
                        Console.Write("查找内容：");
                        Order result=c.searchOrder(Console.ReadLine(), flag);
                        Console.Write("找到的订单为：");
                        Console.WriteLine(result.orderNum + "  " + result.orderName + "  " + result.orderClient);
                        Console.WriteLine("明细: ");
                        foreach (OrderDetails d in result.orderDetails)
                        {
                            Console.WriteLine(d.goodName + " " + d.goodPrice + " " + d.goodNum);
                        }
                        break;
                    case 3:
                        Console.Write("删除第n个元素：");
                        int n1=int.Parse(Console.ReadLine());
                        c.deleteOrder(n1);
                        break;
                    case 4:
                        Console.WriteLine("更改List第num个成员；flag为0，更改订单号，flag为1，更改订单商品名称，flag为2，更改订单客户名称");
                        Console.Write("num:");
                        int num=int.Parse(Console.ReadLine());
                        Console.Write("flag:");
                        int flag1 = int.Parse(Console.ReadLine());
                        Console.Write("修改为：");
                        c.changeOrder(num, Console.ReadLine(), flag1);
                        break;


                }
                if (n != 2)
                {
                    Console.Write("当前订单为：");
                    foreach (Order b in c.orderList)
                    {
                        Console.WriteLine(b.orderNum + "  " + b.orderName + "  " + b.orderClient);
                        Console.WriteLine("明细: ");
                        foreach (OrderDetails d in b.orderDetails)
                        {
                            Console.WriteLine(d.goodName + " " + d.goodPrice + " " + d.goodNum);
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("输入： 1.添加  2.查找  3.删除  4.修改  #.结束操作");
                s = Console.ReadLine();
            }
            

        }
    }
}
