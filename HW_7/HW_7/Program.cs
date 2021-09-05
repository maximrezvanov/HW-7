using System;

namespace HW_7
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = "notes.txt";
            string date, text1, text2, text3, text4;
          
            Diary diary = new Diary(new Note());

            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Make a choice: ");
                Console.WriteLine("New Note - press key 1");
                Console.WriteLine("Remove Note by index - press key 2");
                Console.WriteLine("Remove Note by field - press key 3");
                Console.WriteLine("Edit Note - press key 4");
                Console.WriteLine("Save Note - press key 5");
                Console.WriteLine("Load Note - press key 6");
                Console.WriteLine("Print Note - press key 7");

                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        date = DateTime.Now.ToString();
                        Console.WriteLine("Enter text-1");
                        text1 = Console.ReadLine();
                        Console.WriteLine("Enter text-2");
                        text2 = Console.ReadLine();
                        Console.WriteLine("Enter text-3");
                        text3 = Console.ReadLine();
                        Console.WriteLine("Enter text-4");
                        text4 = Console.ReadLine();
                        Console.WriteLine();

                        diary.AddItem(date, text1, text2, text3, text4);
                        diary.PrintNote();
                        break;
                    case 2:
                        Console.WriteLine("Removes item by index:");
                        diary.RemoveNoteByIndex(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Removes item by field:");
                        diary.RemoveNoteByField(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Enter item index:");
                        diary.EditNote(int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        diary.SaveNotes(path);
                        break;
                    case 6:
                        diary.LoadNotes(path);
                        diary.PrintNote();
                        break;
                    case 7:
                        diary.PrintNote();
                        break;

                    default: break;
                }
            }
            

            Console.ReadKey();



        }
    }
}
