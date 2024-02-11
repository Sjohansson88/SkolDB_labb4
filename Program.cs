
using Microsoft.EntityFrameworkCore;
using SkolDB_Labb3;
using SkolDB_labb4;
using SkolDB_labb4.Models;

namespace SkolDB_Labb3
{
    internal class Program
    {


        static void Main(string[] args)
        {
            using (Labb2DbContext context = new Labb2DbContext())
            {
                bool continueProgram = true;

                while (continueProgram)
                {
                    Console.WriteLine("Välj en handling:");
                    Console.WriteLine("1. Sortera elever");
                    Console.WriteLine("2. Elevinfo");
                    Console.WriteLine("3. Alla kurser");
                    Console.WriteLine("4. Välj klass");
                    Console.WriteLine("5. Lägg till personal");
                    Console.WriteLine("6. Antal personal");
                    Console.WriteLine("7. Avsluta programmet");

                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > 7))
                    {
                        Console.WriteLine("Ogiltig inmatning.");
                    }

                    switch (choice)
                    {
                        case 1:
                            Funktioner.SortStudents(context);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Studentinfo.PrintAllStudentsInfo(context);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Kurser.PrintAllCourses(context);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Funktioner.ChooseClass(context);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            Funktioner.AddStaff(context);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 6:
                            var roleCounts = Befattningar.GetRoleCounts(context);
                            Console.WriteLine($"Antal lärare: {roleCounts.Item1}");
                            Console.WriteLine($"Antal vaktmästare: {roleCounts.Item2}");
                            Console.WriteLine($"Antal rektorer: {roleCounts.Item3}");

                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7:
                            continueProgram = false;
                            break;
                    }
                }
            }
        
    


                    //            static void SortStudents(Labb2DbContext context)
                    //            {
                    //                Console.WriteLine("Välj sorteringskriterium:");
                    //                Console.WriteLine("1. Förnamn");
                    //                Console.WriteLine("2. Efternamn");

                    //                int sortingChoice;
                    //                while (!int.TryParse(Console.ReadLine(), out sortingChoice) || (sortingChoice < 1 || sortingChoice > 2))
                    //                {
                    //                    Console.WriteLine("Ogiltig inmatning. Ange 1 för förnamn eller 2 för efternamn.");
                    //                }


                    //                var sortedStudents = sortingChoice == 1
                    //                    ? context.TblStudents.OrderBy(s => s.StudentFnamn).ToList()
                    //                    : context.TblStudents.OrderBy(s => s.StudentEnamn).ToList();

                    //                foreach (var student in sortedStudents)
                    //                {
                    //                    Console.WriteLine($"{student.StudentFnamn} {student.StudentEnamn}");
                    //                }
                    //            }





                    //            static void ChooseClass(Labb2DbContext context)
                    //            {

                    //                var allClasses = context.TblKlasses.ToList();

                    //                Console.WriteLine("Lista med alla klasser:");
                    //                foreach (var schoolClass in allClasses)
                    //                {
                    //                    Console.WriteLine($"{schoolClass.KlassId}. {schoolClass.KlassNamn}");
                    //                }


                    //                Console.Write("Ange klassnummer för att se elever i klassen: ");
                    //                if (int.TryParse(Console.ReadLine(), out int selectedClassId))
                    //                {

                    //                    var studentsInClass = context.TblStudents
                    //                        .Where(s => s.KlassId == selectedClassId)
                    //                        .OrderBy(s => s.StudentEnamn)
                    //                        .ToList();


                    //                    Console.WriteLine($"Elever i klassen {allClasses.FirstOrDefault(c => c.KlassId == selectedClassId)?.KlassNamn}:");
                    //                    foreach (var student in studentsInClass)
                    //                    {
                    //                        Console.WriteLine($"{student.StudentFnamn} {student.StudentEnamn}");
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    Console.WriteLine("Ogiltig inmatning för klassnummer.");
                    //                }
                    //            }

                    //            static void AddStaff(Labb2DbContext context)
                    //            {
                    //                Console.WriteLine("Lägg till en ny anställd:");

                    //                Console.Write("Förnamn: ");
                    //                string firstName = Console.ReadLine();

                    //                Console.Write("Efternamn: ");
                    //                string lastName = Console.ReadLine();

                    //                Console.WriteLine("Välj befattning:");
                    //                Console.WriteLine("1. Lärare");
                    //                Console.WriteLine("2. Vaktmästare");
                    //                Console.WriteLine("3. Rektor");

                    //                int positionId;
                    //                while (!int.TryParse(Console.ReadLine(), out positionId) || (positionId < 1 || positionId > 3))
                    //                {
                    //                    Console.WriteLine("Ogiltig inmatning. Ange 1 för Lärare, 2 för Vaktmästare eller 3 för Rektor.");
                    //                }

                    //                var newStaffMember = new TblPersonal
                    //                {
                    //                    PersonalFnamn = firstName,
                    //                    PersonalEnamn = lastName,
                    //                    BefattningsId = positionId,

                    //                };

                    //                context.TblPersonals.Add(newStaffMember);
                    //                context.SaveChanges();

                    //                Console.WriteLine("Ny personal har lagts till i databasen.");
                    //            }





                    //        }
                    //        public static class Befattningar
                    //        {
                    //            public static (int, int, int) GetRoleCounts(Labb2DbContext context)
                    //            {
                    //                int lärareCount = context.TblPersonals.Count(p => p.BefattningsId == 1); // Antag att lärarrollen har BefattningsId 1
                    //                int vaktmästareCount = context.TblPersonals.Count(p => p.BefattningsId == 2); // Antag att vaktmästarrollen har BefattningsId 2
                    //                int rektorCount = context.TblPersonals.Count(p => p.BefattningsId == 3); // Antag att rektorrollen har BefattningsId 3

                    //                return (lärareCount, vaktmästareCount, rektorCount);
                    //            }
                    //        }


                    //        public static class Studentinfo
                    //        {
                    //            public static void PrintAllStudentsInfo(Labb2DbContext context)
                    //            {
                    //                var allStudents = context.TblStudents.Include(s => s.Klass).ToList();

                    //                foreach (var student in allStudents)
                    //                {
                    //                    Console.WriteLine($"Student ID: {student.StudentId}");
                    //                    Console.WriteLine($"Förnamn: {student.StudentFnamn}");
                    //                    Console.WriteLine($"Efternamn: {student.StudentEnamn}");
                    //                    Console.WriteLine($"Personnummer: {student.Personnummer}");
                    //                    Console.WriteLine($"Klass: {student.Klass?.KlassNamn}");

                    //                    Console.WriteLine("-----------------------------------------------------------");
                    //                }
                    //            }
                    //        }

                    //        public static class Kurser
                    //        {
                    //            public static void PrintAllCourses(Labb2DbContext context)
                    //            {
                    //                var allCourses = context.TblKurs.ToList();

                    //                foreach (var course in allCourses)
                    //                {
                    //                    Console.WriteLine($"Kurs ID: {course.KursId}");
                    //                    Console.WriteLine($"Kursnamn: {course.KursNamn}");
                    //                    Console.WriteLine();
                    //                }
                    //            }
                    //        }
                }
    }
}