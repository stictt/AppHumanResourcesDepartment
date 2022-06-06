using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppHumanResourcesDepartment.Model;

namespace AppHumanResourcesDepartment.Service
{
    public static class TestDataGenerator
    {
        public static void Run()
        {
            CreateFirst();
            CreateSecond();
        }

        private static void CreateFirst()
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                Department departmentMain = new Department();
                departmentMain.Name = "Головной отдел";
                context.Departments.Add(departmentMain);

                Work work = new Work()
                {
                    Name = "Генеральный деректор",
                    Department = departmentMain,
                    RefineFields = new List< RefineField > (){new RefineField()
                    {
                        Name = "Звезды",
                        Value = "5"
                    } }
                };
                Work work2 = new Work()
                {
                    Name = "Директор",
                    Department = departmentMain,
                    RefineFields = new List<RefineField>(){ new RefineField()
                    {
                        Name = "Регион",
                        Value = "76"
                    } },
                    Perent = work
                };
                context.Works.Add(work);
                context.Works.Add(work2);

                Person person = new Person()
                {
                    FullName = "Иванов Иван Сергеевич",
                    Gender = "Муж",
                    BirthDay = DateTime.Now,
                    Work = work
                };
                Person person2 = new Person()
                {
                    FullName = "Иванов Иван Сергеевич",
                    Gender = "Муж",
                    BirthDay = DateTime.Now,
                    Work = work2
                };
                context.Persons.Add(person);
                context.Persons.Add(person2);
                context.SaveChanges();
            }
        }

        private static void CreateSecond()
        {
            using (HumanResourcesContext context = new HumanResourcesContext())
            {
                Department departmentMain = new Department();
                departmentMain.Name = "Разработка";
                context.Departments.Add(departmentMain);

                Work work = new Work()
                {
                    Name = "Ведущий программист",
                    Department = departmentMain,
                    RefineFields = new List<RefineField>(){new RefineField()
                    {
                        Name = "Проектов",
                        Value = "5"
                    } }
                };
                Work work2 = new Work()
                {
                    Name = "Midle",
                    Department = departmentMain,
                    RefineFields = new List<RefineField>(){ new RefineField()
                    {
                        Name = "Продуктивность",
                        Value = "76"
                    } },
                    Perent = work
                };
                Work work3 = new Work()
                {
                    Name = "Junior",
                    Department = departmentMain,
                    RefineFields = new List<RefineField>(){ new RefineField()
                    {
                        Name = "Курсы",
                        Value = "ООО Рога и копыта"
                    } },
                    Perent = work2
                };
                context.Works.Add(work);
                context.Works.Add(work2);
                context.Works.Add(work3);

                Person person = new Person()
                {
                    FullName = "Клим Имануил Павлович",
                    Gender = "Муж",
                    BirthDay = DateTime.Now,
                    Work = work
                };
                Person person2 = new Person()
                {
                    FullName = "Арзул Степан Багданович",
                    Gender = "Муж",
                    BirthDay = DateTime.Now,
                    Work = work3
                };
                Person person3 = new Person()
                {
                    FullName = "Просто степа",
                    Gender = "Муж",
                    BirthDay = DateTime.Now,
                    Work = work2
                };
                context.Persons.Add(person);
                context.Persons.Add(person2);
                context.Persons.Add(person3);
                context.SaveChanges();
            }
        }
    }
}
