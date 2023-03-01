using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opp_man1
{
    class Program
    {
        static void Main(string[] args)
        {
            // переменная, которая будет хранить команду пользователя
            string user_writing = "";

            // бесконечный цикл
            bool Consts = true;

            // пустой (раный null) экземпляр класса Man
            Man SomeMan = null;

            while (Consts) // пока Consts равно true
            {
                // приглашение ввести команду
                System.Console.WriteLine("Пожалуйста, введите команду\n");

                // получение строки (команды) от пользователя
                user_writing = System.Console.ReadLine();

                // обработка команды с Помощью оператора ветвления
                switch (user_writing)
                {
                    // если user_writing содержит строку Выход
                    case "Выход":
                        {
                            Consts = false;
                            // теперь цикл завершиться, и программа завершит свое выполнение
                            break;
                        }

                    // если user_writing содержит строку Помощь
                    case "Помощь":
                        {
                            System.Console.WriteLine("\nСписок команд:");

                            System.Console.WriteLine("creating_people : команда создает человека, (экземпляр класса Man)");

                            System.Console.WriteLine("people_dead : команда убивает человека");

                            System.Console.WriteLine("talking_people : команда заставляет человека говорить (если создан экземпляр класса)");
                            System.Console.WriteLine("start_walk : команда заставляет человека идти (если создан экземпляр класса)");
                            break;
                        }

                    case "creating_people":
                        {
                            // проверяем, создан ли уже какой либо человек
                            if (SomeMan != null)
                            {
                                SomeMan.dead();
                            }
                            // тут у пользователя просим ввести имя 
                            System.Console.WriteLine("Пожалуйста, введите имя создаваемого человека \n");
                            user_writing = System.Console.ReadLine();
                            // создаем новый объект в памяти, в качестве параметра
                            // передаем имя человека
                            SomeMan = new Man(user_writing);
                            System.Console.WriteLine("Человек успешно создан \n");
                            break;
                        }

                    case "people_dead":
                        {
                            // проверяем, что объект существует в памяти
                            if (SomeMan != null)
                            {
                                // вызываем смерть
                                SomeMan.dead();
                            }
                            else // иначе
                            {
                                System.Console.WriteLine("Человек не создан. Вы не можете его убить");
                            }

                            break;
                        }

                    case "talking_people":
                        {
                            // проверяем, что объект существует в памяти
                            if (SomeMan != null)
                            {
                                // вызываем функцию разговора
                                SomeMan.Talking_people();
                            }
                            else // иначе
                            {
                                System.Console.WriteLine("Человек не создан. Команда не может быть выполнена");
                            }

                            break;
                        }

                    case "start_walk":
                        {
                            // проверяем, что объект существует в памяти
                            if (SomeMan != null)
                            {
                                // вызываем функцию передвижения
                                SomeMan.start_walk();
                            }
                            else
                            {
                                System.Console.WriteLine("Человек не создан. Команда не может быть выполнена");
                            }

                            break;
                        }

                    // если команду определить не удалось
                    default:
                        {
                            System.Console.WriteLine("Ваша команда не определена, пожалуйста повторите снова\n");
                            System.Console.WriteLine("Для вывода списка команд введите команду Помощь");
                            System.Console.WriteLine("Для завершения программы введите команду Выход\n\n");
                            break;
                        }
                }
            }
        }
    }

    public class Man
    {
        // конструктор класса (данная функция вызывается при создании нового экземпляра класса)

        public Man(string _name)
        {
            // получаем имя человека из входного параметра
            // конструктора класса
            Name = _name;
            // человек жив 
            life = true;

            // генерируем возраст от 15 до 50
            Age = (uint)rnd.Next(15, 50);
            // и здоровье, от 10 до 100%
            Hp = (uint)rnd.Next(10, 100);
        }

        // экземпляр класса Random
        // для генерации случайных чисел
        private Random rnd = new Random();

        // строка содержащая имя
        private string Name;
        // число содержащая возраст
        private uint Age;
        // число отражающее уровень здоровья
        private uint Hp;
        // жив ли данный человек
        private bool life;
        // заготовка функции "говорить"
        public void Talking_people()
        {
            // генерируем случайное число от 1 до 3
            int random_talking_people = rnd.Next(1, 3);

            // объявляем переменную, в которой мы будем хранить
            // строку

            string tmp_str = "";

            // в зависимости от случайного значения random_talking_people
            switch (random_talking_people)
            {
                case 1: // если 1 - называем свое имя
                    {
                        // генерируем сообщения 
                        tmp_str = "Привет, меня зовут " + Name + ", я рад с вами познакомиться";

                        // завершаем оператор выбора
                        break;
                    }
                case 2: // возраст
                    {
                        // генерируем сообщения 
                        tmp_str = "Мне " + Age + ". А тебе сколько?";

                        break;
                    }
                case 3: // говорим о своем здоровье
                    {
                        // в зависимости от параметра здоровья
                        if (Hp > 50)
                            tmp_str = "Да я здоров как бык!";
                        else
                            tmp_str = "Со здоровьем у меня хреново, дожить бы до " + (Age + 10).ToString();

                        // завершаем выбор
                        break;
                    }
            }

            // выводим в консоль сгенерированное сообщение
            System.Console.WriteLine(tmp_str);

        }

        // функция "идти"
        public void start_walk()
        {
            // если объект жив
            if (life == true)
            {
                // если показатель более 40
                // считаем объект здоровым
                if (Hp > 40)
                {
                    // генерируем строку текста
                    string outString = Name + " мирно прогуливается по городу";
                    // выводим в консоль
                    System.Console.WriteLine(outString);
                }
                else
                {
                    // генерируем строку текста
                    string outString = Name + " болен и не может гулять по городу";
                    System.Console.WriteLine(outString);
                }
            }
            else
            {
                // генерируем строку текста
                string outString = Name + " не может идти, он умер";
                System.Console.WriteLine(outString);
            }

        }

        public void dead()
        {
            // устанавливаем значение life (жив)
            life = false;
            System.Console.WriteLine(Name + " умер");
        }

        // функция, возвращающая показатель - жив ли данный человек.
        public bool IsAlive()
        {
            // возвращаем значение, к которому мы не можем
            // обратиться на прямую из вне класса,
            // так как оно имеет статус private
            return life;
        }

    }

}
