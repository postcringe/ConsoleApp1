using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ConsoleApp1
{
    class Program
    {

        /*  public class User
          {
              public int Id;
              public string ФИО_Покупателя;
              public int Количество_комнат;
              public int Этаж;
              public int Метраж;
          }
        */
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int KolvoComnat { get; set; }
        public int Etas { get; set; }
            public int Metr { get; set; }
    }

        class UserContext : DbContext
        {
            public UserContext()
                : base("DbConnection")
            { }

            public DbSet<User> Users { get; set; }
        }


        static void Main(string[] args)
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Ivan",  KolvoComnat = 1, Etas = 1,Metr=4 };
                User user2 = new User { Name = "Petr", KolvoComnat = 1, Etas = 1, Metr = 4 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    Console.WriteLine("{0}.{1} - {2} {3}", u.Id, u.Name, u.KolvoComnat ,u.Metr);
                }
            }
            Console.Read();
        }
    }

} 


