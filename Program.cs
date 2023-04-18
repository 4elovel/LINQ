using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
namespace Запити
{
    class Студенти
    {
        public string імйа { get; set; }
        public string прізвище { get; set; }
        public int номер_групи { get; set; }
    }
    class Групи
    {
        public int ідентифікатор { get; set; }
        public string назва { get; set; }
    }
    class Програма
    {
        static void Main(string[] арґументи)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Групи> групи = new List<Групи> {
      new Групи { ідентифікатор = 1, назва = "індивідуальні" },
      new Групи { ідентифікатор = 2, назва = "групові" }
    };
            List<Студенти> студенти = new List<Студенти> {
      new Студенти { імйа = "Вадим",
      прізвище = "Тесліцький", номер_групи = 2 },
      new Студенти { імйа = "Олександра",
      прізвище = "Мандиринка", номер_групи = 2 },
      new Студенти { імйа = "Анна",
      прізвище = "Ґант", номер_групи = 1 },
      new Студенти { імйа = "Мирослав",
      прізвище = "Садовський", номер_групи = 1 },
      new Студенти { імйа = "Ніколь",
      прізвище = "Князева", номер_групи = 3 }
    };
            var запит = from група in групи //from st in students
                        join студент in студенти
                        on група.ідентифікатор equals студент.номер_групи
                        //інший варіант where g.ідентифікатор==st.номер_групи
                        select new { студент.імйа, студент.прізвище, група.назва };

            var linq1 = from st in студенти
                        where st.номер_групи == 1
                            select new { st.імйа, st.прізвище, групи[0].назва };
            var linq2 = from st in студенти
                        where st.номер_групи == 2
                        select new { st.імйа, st.прізвище, групи[1].назва };
            WriteLine("\tСписок студентів по групах:");
            foreach (var el in linq1)
            {
                WriteLine(el);
            }
            foreach (var el in linq2)
            {
                WriteLine(el);
            }
            Console.ReadKey();
        }
    }
}