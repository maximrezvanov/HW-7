using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW_7
{
    public class Diary
    {
        private List<Note> notes;
        string[] titles;

        public Diary(params Note[] arg)
        {
            notes = arg.ToList();
            this.titles = new string[]
            {
                "Date", "Text1", "Text2", "Text3", "Text4"
            };
            this.notes = new List<Note>();
        }

        public void SaveNotes(string path)
        {
            try
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    string line = String.Format($"{notes[i].date},{notes[i].text1},{notes[i].text2},{notes[i].text3},{notes[i].text4}");
                    File.AppendAllText(path, $"{line}\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }     
        }

        public void LoadNotes(string path)
        {
            notes.Clear();
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    while (!stream.EndOfStream)
                    {
                        string[] args = stream.ReadLine().Split(',');
                        AddNote(new Note(args[0], args[1], args[2], args[3], args[4]));
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddItem(params string[] arg)
        {
            AddNote(new Note(arg[0], arg[1], arg[2], arg[3], arg[4]));
        }

        public void AddNote(Note newNote)
        {
            notes.Add(newNote);
        }

        #region removeNotes

        public void RemoveNoteByIndex(int indexNote)
        {
            if (notes.Count != 0)
            {
                notes.RemoveAt(indexNote);
            }

            Console.WriteLine("Notes is empty");
        }

        public void RemoveNoteByField(string field)
        {
            if (notes.Count != 0)
            {
                foreach (var note in notes.ToList())
                {
                    if(note.text1 == field || note.text2 == field || note.text3 == field || note.text4 == field)
                        notes.Remove(note);
                }      
            }
            Console.WriteLine("Notes is empty");
        }
        #endregion

        public void EditNote(int indexNote)
        {
            Note newNote = new Note();
            newNote.date = DateTime.Now.ToString();
            Console.WriteLine("Enter new text1");
            newNote.text1 = Console.ReadLine();
            Console.WriteLine("Enter new text2");
            newNote.text2 = Console.ReadLine();
            Console.WriteLine("Enter new text3");
            newNote.text3 = Console.ReadLine();
            Console.WriteLine("Enter new text4");
            newNote.text4 = Console.ReadLine();
            notes[indexNote] = newNote;
        }

        public void PrintNote()
        {
            Console.WriteLine($"# {titles[0],-10}\t {titles[1],-10}\t {titles[2],-10}\t {titles[3],-10}\t {titles[4],-10} \n");
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine(i + " " + notes[i].PrintNotes());
            }
        }

        public void LoadNoteByDateRange(string startDate, string finishDate, string file)
        {
            DateTime start = Convert.ToDateTime(startDate);
            DateTime finish = Convert.ToDateTime(finishDate);
            notes.Clear();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string[] arg = sr.ReadLine().Split(',');
                    DateTime time = Convert.ToDateTime(arg[0]);

                    if (time >= start && time <= finish)
                    {
                        AddNote(new Note(arg[0], arg[1], arg[2], arg[3], arg[4]));
                    }
                }
                PrintNote();
            }
        }

        public void SortNotes(int field)
        {
            switch(field)
            {
                case 1:
                    notes = notes.OrderBy(f => f.date)
                        .ThenBy(f => f.text1)
                        .ThenBy(f => f.text2)
                        .ThenBy(f => f.text3)
                        .ThenBy(f => f.text4)
                        .ToList();
                    break;
                case 2:
                    notes = notes.OrderBy(f => f.text1)
                        .ThenBy(f => f.date)
                        .ThenBy(f => f.text2)
                        .ThenBy(f => f.text3)
                        .ThenBy(f => f.text4)
                        .ToList();
                    break;
                case 3:
                    notes = notes.OrderBy(f => f.text2)
                        .ThenBy(f => f.text1)
                        .ThenBy(f => f.date)
                        .ThenBy(f => f.text3)
                        .ThenBy(f => f.text4)
                        .ToList();
                    break;
                case 4:
                    notes = notes.OrderBy(f => f.text3)
                        .ThenBy(f => f.text1)
                        .ThenBy(f => f.text2)
                        .ThenBy(f => f.date)
                        .ThenBy(f => f.text4)
                        .ToList();
                    break;  
                case 5:
                    notes = notes.OrderBy(f => f.text4)
                        .ThenBy(f => f.text1)
                        .ThenBy(f => f.text2)
                        .ThenBy(f => f.date)
                        .ThenBy(f => f.text3)
                        .ToList();
                    break;  
                default: 
                    break;
            }
        }
    }
}
