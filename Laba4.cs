using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaLab
{
    // =====================================================
    // ЗАВДАННЯ 1
    // =====================================================

    class ITriangle
    {
        protected int a;
        protected int b;
        protected int c;

        public ITriangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return a;
                    case 1: return b;
                    case 2: return c;
                    default:
                        Console.WriteLine("Помилка індексу!");
                        return -1;
                }
            }

            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    default:
                        Console.WriteLine("Помилка індексу!");
                        break;
                }
            }
        }

        public double Area()
        {
            double h = Math.Sqrt(b * b - (a * a / 4.0));
            return a * h / 2;
        }

        public int Perimeter()
        {
            return a + b + b;
        }

        public bool IsRegular()
        {
            return a == b;
        }

        public void Show()
        {
            Console.WriteLine($"Основа = {a}");
            Console.WriteLine($"Бічна = {b}");
            Console.WriteLine($"Колір = {c}");
            Console.WriteLine($"Площа = {Area():F2}");
            Console.WriteLine($"Периметр = {Perimeter()}");
            Console.WriteLine($"Правильний = {IsRegular()}");
            Console.WriteLine();
        }

        public static ITriangle operator ++(ITriangle t)
        {
            t.a++;
            t.b++;
            return t;
        }

        public static ITriangle operator --(ITriangle t)
        {
            t.a--;
            t.b--;
            return t;
        }

        public static bool operator true(ITriangle t)
        {
            return (t.a + t.b > t.b) &&
                   (t.b + t.b > t.a);
        }

        public static bool operator false(ITriangle t)
        {
            return !((t.a + t.b > t.b) &&
                     (t.b + t.b > t.a));
        }

        public static ITriangle operator *(ITriangle t, int k)
        {
            return new ITriangle(t.a * k, t.b * k, t.c);
        }

        public static implicit operator string(ITriangle t)
        {
            return $"{t.a},{t.b},{t.c}";
        }

        public static implicit operator ITriangle(string s)
        {
            string[] arr = s.Split(',');
            return new ITriangle(
                int.Parse(arr[0]),
                int.Parse(arr[1]),
                int.Parse(arr[2]));
        }
    }

    // =====================================================
    // ЗАВДАННЯ 2
    // =====================================================

    class VectorDecimal
    {
        protected decimal[] ArrayDecimal;
        protected uint num;
        protected int codeError;
        protected static uint num_vec;

        public VectorDecimal()
        {
            num = 1;
            ArrayDecimal = new decimal[1];
            ArrayDecimal[0] = 0;
            num_vec++;
        }

        public VectorDecimal(uint size)
        {
            num = size;
            ArrayDecimal = new decimal[size];
            num_vec++;
        }

        public VectorDecimal(uint size, decimal value)
        {
            num = size;
            ArrayDecimal = new decimal[size];

            for (int i = 0; i < size; i++)
                ArrayDecimal[i] = value;

            num_vec++;
        }

        ~VectorDecimal()
        {
            Console.WriteLine("Vector destroyed");
        }

        public void Input()
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write($"[{i}] = ");
                ArrayDecimal[i] = decimal.Parse(Console.ReadLine());
            }
        }

        public void Show()
        {
            Console.WriteLine("Вектор:");

            foreach (decimal x in ArrayDecimal)
                Console.Write(x + " ");

            Console.WriteLine();
        }

        public void SetValue(decimal value)
        {
            for (int i = 0; i < num; i++)
                ArrayDecimal[i] = value;
        }

        public static uint CountVectors()
        {
            return num_vec;
        }

        public uint Size
        {
            get { return num; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public decimal this[int index]
        {
            get
            {
                if (index >= 0 && index < num)
                    return ArrayDecimal[index];

                codeError = -1;
                return 0;
            }

            set
            {
                if (index >= 0 && index < num)
                    ArrayDecimal[index] = value;
                else
                    codeError = -1;
            }
        }

        public static VectorDecimal operator ++(VectorDecimal v)
        {
            for (int i = 0; i < v.num; i++)
                v.ArrayDecimal[i]++;

            return v;
        }

        public static VectorDecimal operator --(VectorDecimal v)
        {
            for (int i = 0; i < v.num; i++)
                v.ArrayDecimal[i]--;

            return v;
        }

        public static bool operator true(VectorDecimal v)
        {
            if (v.num == 0) return false;

            foreach (decimal x in v.ArrayDecimal)
                if (x == 0)
                    return false;

            return true;
        }

        public static bool operator false(VectorDecimal v)
        {
            return !(v);
        }

        public static bool operator !(VectorDecimal v)
        {
            return v.num != 0;
        }

        public static VectorDecimal operator +(VectorDecimal a, VectorDecimal b)
        {
            uint size = Math.Max(a.num, b.num);

            VectorDecimal r = new VectorDecimal(size);

            for (int i = 0; i < Math.Min(a.num, b.num); i++)
                r.ArrayDecimal[i] = a.ArrayDecimal[i] + b.ArrayDecimal[i];

            return r;
        }

        public static VectorDecimal operator +(VectorDecimal a, decimal k)
        {
            VectorDecimal r = new VectorDecimal(a.num);

            for (int i = 0; i < a.num; i++)
                r.ArrayDecimal[i] = a.ArrayDecimal[i] + k;

            return r;
        }
    }

    // =====================================================
    // ЗАВДАННЯ 3
    // =====================================================

    struct Buyer
    {
        public string FullName;
        public string Address;
        public string Phone;
        public string Card;

        public void Show()
        {
            Console.WriteLine($"{FullName} | {Address} | {Phone} | {Card}");
        }
    }

    // =====================================================
    // ЗАВДАННЯ 4
    // =====================================================

    class DecimalMatrix
    {
        protected decimal[,] DCArray;
        protected uint n, m;
        protected int codeError;
        protected static int num_mf;

        public DecimalMatrix()
        {
            n = 1;
            m = 1;
            DCArray = new decimal[1, 1];
            num_mf++;
        }

        public DecimalMatrix(uint n, uint m)
        {
            this.n = n;
            this.m = m;

            DCArray = new decimal[n, m];
            num_mf++;
        }

        public DecimalMatrix(uint n, uint m, decimal value)
        {
            this.n = n;
            this.m = m;

            DCArray = new decimal[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    DCArray[i, j] = value;

            num_mf++;
        }

        ~DecimalMatrix()
        {
            Console.WriteLine("Matrix destroyed");
        }

        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(DCArray[i, j] + " ");

                Console.WriteLine();
            }
        }

        public decimal this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < n &&
                    j >= 0 && j < m)
                    return DCArray[i, j];

                codeError = -1;
                return 0;
            }

            set
            {
                if (i >= 0 && i < n &&
                    j >= 0 && j < m)
                    DCArray[i, j] = value;
                else
                    codeError = -1;
            }
        }

        public static DecimalMatrix operator +(DecimalMatrix a, DecimalMatrix b)
        {
            DecimalMatrix r = new DecimalMatrix(a.n, a.m);

            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    r.DCArray[i, j] = a.DCArray[i, j] + b.DCArray[i, j];

            return r;
        }

        public static DecimalMatrix operator ++(DecimalMatrix a)
        {
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    a.DCArray[i, j]++;

            return a;
        }
    }

    // =====================================================
    // MAIN MENU
    // =====================================================

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice;

            do
            {
                Console.WriteLine("\n========= МЕНЮ =========");
                Console.WriteLine("1 - Завдання 1");
                Console.WriteLine("2 - Завдання 2");
                Console.WriteLine("3 - Завдання 3");
                Console.WriteLine("4 - Завдання 4");
                Console.WriteLine("0 - Вихід");
                Console.Write("Ваш вибір: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    // ====================================
                    // TASK 1
                    // ====================================

                    case 1:

                        ITriangle t = new ITriangle(4, 4, 2);

                        t.Show();

                        Console.WriteLine("Індексатор:");
                        Console.WriteLine(t[0]);
                        Console.WriteLine(t[1]);
                        Console.WriteLine(t[2]);

                        ++t;

                        Console.WriteLine("Після ++");
                        t.Show();

                        t = t * 2;

                        Console.WriteLine("Після множення:");
                        t.Show();

                        string s = t;

                        Console.WriteLine("String:");
                        Console.WriteLine(s);

                        ITriangle t2 = s;

                        Console.WriteLine("Зі string:");
                        t2.Show();

                        break;

                    // ====================================
                    // TASK 2
                    // ====================================

                    case 2:

                        VectorDecimal v1 = new VectorDecimal(3, 2);
                        VectorDecimal v2 = new VectorDecimal(3, 5);

                        v1.Show();
                        v2.Show();

                        VectorDecimal v3 = v1 + v2;

                        Console.WriteLine("Сума:");
                        v3.Show();

                        ++v3;

                        Console.WriteLine("Після ++");
                        v3.Show();

                        Console.WriteLine("Кількість векторів:");
                        Console.WriteLine(VectorDecimal.CountVectors());

                        break;

                    // ====================================
                    // TASK 3
                    // ====================================

                    case 3:

                        List<Buyer> buyers = new List<Buyer>()
                        {
                            new Buyer{FullName="Іван Петренко",Address="Львів",Phone="111",Card="123"},
                            new Buyer{FullName="Марія Іванова",Address="Київ",Phone="222",Card="456"},
                            new Buyer{FullName="Олег Сидор",Address="Одеса",Phone="333",Card="789"},
                            new Buyer{FullName="Анна Коваль",Address="Харків",Phone="444",Card="999"},
                            new Buyer{FullName="Юлія Бондар",Address="Дніпро",Phone="555",Card="777"},
                        };

                        buyers.RemoveRange(0, 3);

                        buyers.Add(new Buyer
                        {
                            FullName = "Новий 1",
                            Address = "Полтава",
                            Phone = "111",
                            Card = "111"
                        });

                        buyers.Add(new Buyer
                        {
                            FullName = "Новий 2",
                            Address = "Полтава",
                            Phone = "222",
                            Card = "222"
                        });

                        buyers.Add(new Buyer
                        {
                            FullName = "Новий 3",
                            Address = "Полтава",
                            Phone = "333",
                            Card = "333"
                        });

                        foreach (var b in buyers)
                            b.Show();

                        break;

                    // ====================================
                    // TASK 4
                    // ====================================

                    case 4:

                        DecimalMatrix m1 = new DecimalMatrix(2, 2, 1);
                        DecimalMatrix m2 = new DecimalMatrix(2, 2, 5);

                        Console.WriteLine("Матриця 1");
                        m1.Show();

                        Console.WriteLine("Матриця 2");
                        m2.Show();

                        DecimalMatrix m3 = m1 + m2;

                        Console.WriteLine("Сума:");
                        m3.Show();

                        ++m3;

                        Console.WriteLine("Після ++");
                        m3.Show();

                        break;

                    case 0:
                        Console.WriteLine("Програма завершена");
                        break;

                    default:
                        Console.WriteLine("Неправильний вибір!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
