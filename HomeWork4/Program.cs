using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class MyEventArgs:EventArgs
    {
        public int Hour, Minute;
        public MyEventArgs(int hour,int minute)
        {
            this.Hour = hour;
            this.Minute = minute;
        }
    }
    public delegate void AlarmEvent(object b, MyEventArgs e);
    public class AlarmSet
    {
        public event AlarmEvent Alarm;
        public virtual bool AlarmFire(MyEventArgs e)
        {
            if ((Alarm!=null)&&(e.Hour == DateTime.Now.Hour) && (e.Minute == DateTime.Now.Minute))
            {
                Alarm(this, e);
                return true;
            }
            return false;
        }
    }
    public class AlarmReceive
    {
        public void AlarmHandle(object b,MyEventArgs e)
        {
            Console.WriteLine("时间到了！");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int hour, minute;
            hour = int.Parse(Console.ReadLine());
            minute = int.Parse(Console.ReadLine()); ;
            AlarmSet a = new AlarmSet();
            AlarmReceive b = new AlarmReceive();
            MyEventArgs e = new MyEventArgs(hour, minute);
            a.Alarm += new AlarmEvent(b.AlarmHandle);
            string path = "D:/CloudMusic/Delacey - Dream It Possible.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            for (; ; )
            {
                if (a.AlarmFire(e))
                {
                    //break;
                    //闹铃
                    player.PlayLooping();
                    Console.WriteLine("关闭：Y;一分钟后再响：N");
                    if (Console.ReadLine() == "Y") break;
                    else { e.Minute = DateTime.Now.Minute + 1; player.Stop(); continue; }
                }
            }
        }
    }
}
