using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2 
{
    public class Order
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
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
        List<Order> orderList = new List<Order>();
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
            OrderDetails a1 = new OrderDetails("矿泉水","1","2");
            OrderDetails a2 = new OrderDetails("可乐", "3", "2");
            OrderDetails a3 = new OrderDetails("威化饼干", "5", "2");
            OrderDetails a4 = new OrderDetails("薯片", "4", "3");
            Order b1 = new Order("201801", "水", "小赵");
            b1.addOrderDatails(a1);
            b1.addOrderDatails(a2);
            Order b2 = new Order("201802", "饼干", "小张");
            b2.addOrderDatails(a3);
            b2.addOrderDatails(a4);
            OrderService c = new OrderService();
            c.addOrder(b1);
            c.addOrder(b2);
            c.deleteOrder(0);

        }
    }
}
