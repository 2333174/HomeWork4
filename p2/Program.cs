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
        Order(string num,string name,string client)
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
        OrderDetails(string name,string price,string number)
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
        //根据订单号删除订单
        public void deleteOrder(string num)
        {
            int m = count;
            for (int i = 0; i < m ; i++) {
                if (orderList[i].orderNum == num)
                {
                    orderList.Remove(orderList[i]);
                    count--;
                }
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
            if (num >= count) { Console.WriteLine("越界");return; }
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
