using System;
using System.Collections.Generic;
using System.Threading;

namespace pizzeria
{
    class Program
    {
        internal interface InterfacePeople
        {
            public string Name { get; set; }
            public int CountOrder { get; set; }
            public int Productivity { get; set; }
            public bool TakenTask { get; set; }
            public bool HavePizza { get; set; }
        }

        internal class Сourier : InterfacePeople
        {
            string _name = "Сourier";
            public string Name
            {
                set { _name = value; }
                get { return _name; }
            }
            int countOrder = 0;
            public int CountOrder
            {
                set { countOrder = value; }
                get { return countOrder; }
            }

            int speed;
            public int Productivity
            {
                set { speed = value; }
                get { return speed; }
            }

            int volumeBackPack;
            public int VolumeBackPack
            {
                set { volumeBackPack = value; }
                get { return volumeBackPack; }
            }
            int backRack = 0;
            public int BackPack
            {
                set { backRack = value; }
                get { return backRack; }
            }

            bool task = false;
            public bool TakenTask
            {
                set { task = value; }
                get { return task; }
            }
            bool havePizza = false;
            public bool HavePizza
            {
                set { havePizza = value; }
                get { return havePizza; }
            }

            int taskDistanse = 0;
            public void TaskDistans(int[] pred, int[] now)
            {
                taskDistanse += ((now[0] - pred[0]) ^ 2 + (now[1] - pred[1]) ^ 2) ^ (1 / 2);
            }

            List<int> numOrders = new List<int>();
            public List<int> NumOrders
            {
                set { numOrders = value; }
                get { return numOrders; }
            }
            public void Delivery()
            {
                while (true)
                {
                    if (task == true)
                    {
                        Thread.Sleep(1000 * speed * taskDistanse);
                        task = false;
                        taskDistanse = 0;
                    }
                }
            }
        }

        internal class Baker : InterfacePeople
        {
            string _name = "baker";
            public string Name
            {
                set { _name = value; }
                get { return _name; }
            }
            int workExpaines = 0;
            public int WorkExpaines
            {
                set { workExpaines = value; }
                get { return workExpaines; }
            }
            int countOrder = 0;
            public int CountOrder
            {
                set { countOrder = value; }
                get { return countOrder; }
            }
            int cookingTime;
            public int Productivity
            {
                set { cookingTime = value; }
                get { return cookingTime; }
            }

            bool task = false;
            public bool TakenTask
            {
                set { task = value; }
                get { return task; }
            }

            bool wait = false;
            public bool Wait
            {
                set { wait = value; }
                get { return wait; }
            }

            bool havePizza = false;
            public bool HavePizza
            {
                set { havePizza = value; }
                get { return havePizza; }
            }
            public void Cook()
            {
                while (true)
                {
                    if (task == true && wait == false)
                    {
                        Thread.Sleep(1000 * cookingTime);
                        task = false;
                    }
                }
            }
        }

        internal class Order
        {
            int numerOrder;
            public int NumerOrder
            {
                set { numerOrder = value; }
                get { return numerOrder; }
            }
            int[] distanse;
            public int[] Distanse
            {
                set { distanse = value; }
                get { return distanse; }
            }
            int countPizze;
            public int CountPizze
            {
                set { countPizze = value; }
                get { return countPizze; }
            }
            int countBaker = 0;
            public int CountBaker
            {
                set { countBaker = value; }
                get { return countBaker; }
            }
            bool doneBaker = false;
            public bool DoneBakker
            {
                set { doneBaker = value; }
                get { return doneBaker; }
            }
            int takeBaker = 0;
            public int TakeBaker
            {
                set { takeBaker = value; }
                get { return takeBaker; }
            }

            bool takeСourier = false;
            public bool TakeСourier
            {
                set { takeСourier = value; }
                get { return takeСourier; }
            }
        }

        internal class WaitOrder
        {
            bool wait = false;
            public bool Wait
            {
                set { wait = value; }
                get { return wait; }
            }

            bool stop = false;
            public bool Stop
            {
                set { stop = value; }
                get { return stop; }
            }
        }

        static void Main(string[] args)
        {
            List<Baker> bakers = new List<Baker>();
            List<Сourier> couriers = new List<Сourier>();
            List<Thread> threads = new List<Thread>();

            Console.WriteLine("Введите количество пекарей:");
            int N = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                Baker baker = new Baker();
                Console.Write("Введите время приготовление одной пиццы: ");
                baker.Productivity = Int32.Parse(Console.ReadLine());
                bakers.Add(baker);
                Thread t = new Thread(baker.Cook);

                threads.Add(t);

            }

            Console.WriteLine("Введите количество курьеров:");
            int M = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < M; i++)
            {
                Сourier courier = new Сourier();
                Console.Write("Введите объем рюкзака: ");
                courier.VolumeBackPack = Int32.Parse(Console.ReadLine());
                Console.Write("Введите время доставки на один адрес: ");
                courier.Productivity = Int32.Parse(Console.ReadLine());
                couriers.Add(courier);
                Thread t = new Thread(courier.Delivery);

                threads.Add(t);
            }

            Console.WriteLine("Введите размер склада:");
            int T = Int32.Parse(Console.ReadLine());
            int countPizzeInStoke = 0;

            for (int i = 0; i < N + M; i++)
            {
                threads[i].Start();
            }

            Console.WriteLine("Если вы хотите сделать заказ, напишите - 1\nИначе - stop");

            int countOrder = 0;
            int sumPizze = 0; //сумма пицц ожидающих готовку
            int timeStoke = 0;

            List<Order> orders = new List<Order>();
            WaitOrder wait = new WaitOrder();
            void WaitOrder()
            {
                while (true)
                {
                    if (wait.Wait == false)
                    {
                        string msg = Console.ReadLine();
                        if (msg == "stop")
                            wait.Stop = true;

                        wait.Wait = true;
                    }
                }
            }
            Thread tr = new Thread(WaitOrder);

            tr.Start();
            while (wait.Stop == false)
            {
                //добабвляем заказ    
                if (wait.Wait == true)
                {
                    Order order = new Order();
                    Console.WriteLine("Введите заказ в формате 'X-Y-количество пицц'"); //X,Y={0,20}
                    string[] msg = Console.ReadLine().Split("-");
                    while (msg.Length < 3) msg = Console.ReadLine().Split("-");
                    int X, Y, countPizze = 0;
                    while (!((int.TryParse(msg[0], out X)) && (int.TryParse(msg[1], out Y)) && (int.TryParse(msg[2], out countPizze))))
                        msg = Console.ReadLine().Split("-");
                    int[] distanse = new int[2] { X, Y };

                    countOrder++;
                    order.NumerOrder = countOrder;
                    order.Distanse = distanse;
                    order.CountPizze = countPizze;
                    orders.Add(order);
                    Console.WriteLine("\t\t\t\t\t\t\t\t" + order.NumerOrder + "- заказ получен.");
                    wait.Wait = false;
                    sumPizze += countPizze;
                    Console.WriteLine("Если вы хотите сделать заказ, напишите - 1\nИначе - stop");
                }
                foreach (Order elem in orders)
                {
                    if (elem.DoneBakker == false) //выбираем невзятый заказ
                    {
                        //elem.DoneBakker = true;
                        foreach (Baker people in bakers) //выбираем свободного пекаря
                        {
                            if (people.TakenTask == false && sumPizze > 0 && people.HavePizza == false) //и если есть пицца которую не начали готовить
                            {
                                people.TakenTask = true; //пекарь берет пиццу и его поток остановливается, после возобновляется
                                people.CountOrder += 1; //увеличили количество взятых пицц
                                sumPizze--;
                                people.HavePizza = true;

                            }

                        }

                        foreach (Baker people in bakers)
                        {
                            if (people.TakenTask == false && elem.CountBaker < elem.CountPizze && people.HavePizza == true) //пицца приготовлена
                            {
                                people.HavePizza = false;
                                elem.CountBaker++; //увеличиваем количество готовых пицц
                                countPizzeInStoke++;
                                Console.WriteLine("\t\t\t\t\t\t\t\t" + elem.NumerOrder + " - пицца " + elem.CountBaker + " (из " + elem.CountPizze + ") готово.");
                                //здесь мы должны отнести пиццу на склад, если склад полный, people.wait = true;
                                if (countPizzeInStoke > T)
                                {
                                    timeStoke++;
                                    people.Wait = true; //в таком случае задача на пекаре висит и он не может принять следующий заказ
                                    people.TakenTask = true;
                                }
                                if (countPizzeInStoke <= T)
                                {
                                    people.Wait = false;
                                    people.TakenTask = false;
                                }

                                if (elem.CountBaker == elem.CountPizze) //пекари готовят непрерывно, если есть заказы
                                {
                                    elem.DoneBakker = true;
                                    Console.WriteLine("\t\t\t\t\t\t\t\t" + elem.NumerOrder + ", все готово.");
                                }
                            }
                        }
                    }
                }
                foreach (Сourier people in couriers)
                {
                    int[] pred = new int[] { 0, 0 };
                    //дальше заказ берет курьер
                    if (people.TakenTask == false && countPizzeInStoke > 0) //
                    {
                        foreach (Order elem in orders)
                        {
                            if (elem.TakeСourier == false && elem.DoneBakker == true && people.BackPack + elem.CountPizze <= people.VolumeBackPack) //выбираем невзятый заказ курьером, но выполненый пекарем b влезают в рюкзак
                            {
                                elem.TakeСourier = true;
                                countPizzeInStoke -= elem.CountPizze;
                                people.TaskDistans(pred, elem.Distanse);
                                pred = elem.Distanse;
                                people.TakenTask = true; // берет пиццу и его поток остановливается, после возобновляется
                                people.CountOrder += 1;
                                people.BackPack += elem.CountPizze;
                                people.NumOrders.Add(elem.NumerOrder);
                                people.HavePizza = true;
                                Console.WriteLine("\t\t\t\t\t\t\t\t" + elem.NumerOrder + ", заказ доставлен.");
                            }
                        }

                    }
                }
                foreach (Сourier people in couriers)
                {
                    if (people.TakenTask == false && people.HavePizza == true) //пицца 
                    {
                        people.HavePizza = false;
                        foreach (Order elem in orders)
                        {
                            if (people.NumOrders.Contains(elem.NumerOrder))
                            {
                                people.BackPack -= elem.CountPizze;
                                Console.WriteLine("\t\t\t\t\t\t\t\t" + elem.NumerOrder + ", заказ был выполнен.");
                            }
                        }
                        people.NumOrders.Clear();

                    }
                }
                //курьеры ожидают появления нового заказа(if order.take==false) , берет у кого в рюкзак влезают пиццы, остановили поток курьера на время S/V, пока спит его не выбирают
                // закончил доставлять курьер.готов = правда
            }


            if (timeStoke > 0)
                Console.WriteLine("Расширить склад");
            else
                Console.WriteLine("Увеличить количество заказов");

            int max = 0, min = 10000, indexMax = 0, indexMin = 0, j = 0;
            foreach (Baker people in bakers)
            {
                j++;
                if (people.CountOrder > max)
                { max = people.CountOrder; indexMax = j; }
                if (people.CountOrder < min)
                { min = people.CountOrder; indexMin = j; }

            }
            Console.WriteLine("Нанять " + indexMax + " пекаря, уволить " + indexMin + " пекаря");

            max = 0; min = 10000; indexMax = 0; indexMin = 0; j = 0;
            foreach (Сourier people in couriers)
            {
                j++;
                if (people.CountOrder > max)
                { max = people.CountOrder; indexMax = j; }
                if (people.CountOrder < min)
                { min = people.CountOrder; indexMin = j; }

            }
            Console.WriteLine("Нанять " + indexMax + " курьера, уволить " + indexMin + " курьера");
        }
    }
}
