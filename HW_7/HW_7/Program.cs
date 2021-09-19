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
                int key;
                Console.WriteLine();
                Console.WriteLine("Make a choice: ");
                Console.WriteLine("New Note - press key 1");
                Console.WriteLine("Remove Note by index - press key 2");
                Console.WriteLine("Remove Note by field - press key 3");
                Console.WriteLine("Edit Note - press key 4");
                Console.WriteLine("Save Note - press key 5");
                Console.WriteLine("Load Note - press key 6");
                Console.WriteLine("Load Note by date range - press key 7");
                Console.WriteLine("Sort by selected field - press key 8");
                Console.WriteLine("Print Note - press key 9");

                while (!int.TryParse(Console.ReadLine(), out key))
                {
                    Console.WriteLine("Invalid input. Try again");
                }
                
                switch (key)
                {
                    case 1:
                        DateTime dateTime = new DateTime(2021, 9, 18);
                        date = dateTime.ToShortDateString().ToString();
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
                        int index;
                        while (!int.TryParse(Console.ReadLine(), out index))
                        {
                            Console.WriteLine("Invalid input. Try again");
                        }
                        diary.RemoveNoteByIndex(index);
                        diary.PrintNote();
                        break;
                    case 3:
                        Console.WriteLine("Removes item by field:");
                        diary.RemoveNoteByField(Console.ReadLine());
                        diary.PrintNote();
                        break;
                    case 4:
                        Console.WriteLine("Enter note index:");
                        int noteIndex;
                        while (!int.TryParse(Console.ReadLine(), out noteIndex))
                        {
                            Console.WriteLine("Invalid input. Try again");
                        }
                        diary.EditNote(noteIndex);
                        break;
                    case 5:
                        diary.SaveNotes(path);
                        break;
                    case 6:
                        Console.Clear();
                        diary.LoadNotes(path);
                        diary.PrintNote();
                        break;
                    case 7:
                        Console.WriteLine("Enter start date, dd/mm/yyyy");
                        string startDate = Console.ReadLine();
                        Console.WriteLine("Enter finish date");
                        string finishDate = Console.ReadLine();
                        Console.Clear();
                        diary.LoadNoteByDateRange(startDate, finishDate, path);
                        break;
                     case  8:
                         Console.WriteLine("Enter the field number to sort, #1 - 5");
                         int fieldNumber;
                         while (!int.TryParse(Console.ReadLine(), out fieldNumber))
                         {
                             Console.WriteLine("Invalid input. Try again");
                         }
                         diary.SortNotes(fieldNumber);
                         Console.Clear();
                         diary.PrintNote();
                         break;
                    case 9:
                        diary.PrintNote();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
