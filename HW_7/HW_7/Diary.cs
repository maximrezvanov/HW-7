using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HW_7
{
    public class Diary
    {
        private List<Note> notes;
        string path;

        string[] titles;
        int index;


        public Diary(params Note[] arg)
        {
            notes = arg.ToList();
            this.index = 0;
            this.titles = new string[]
            {
                "Date", "Text1", "Text2", "Text3", "Text4"
            };
            this.notes = new List<Note>();
        }

        public void SaveNotes(string file)
        {
            using (StreamWriter writer = new StreamWriter(file))
            {
                //titles = stream.ReadLine().Split(',');
                writer.WriteLine(titles);
               
                foreach (var note in notes)
                {
                    writer.Write(note);
                    //writer.Write($"{i}-я группа: [{String.Join(" ", NextGroup(i, GroupsNum(n), n))}] \n");
                }
                

            }
        }

        public void Load()
        {
            notes.Clear();

            using (StreamReader stream = new StreamReader(this.path))
            {
                titles = stream.ReadLine().Split(',');
                while (!stream.EndOfStream)
                {
                    string[] args = stream.ReadLine().Split(',');
                    AddNote(new Note());
                }
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

        public void DeleteNote(int indexNote)
        {
            if(notes.Count != 0)
            notes.RemoveAt(indexNote);
        }

        public void RemoveFieldNote(string field)
        {
            if (notes.Count != 0)
            {
                foreach (var note in notes.ToList())
                {
                    if(note.text1 == field || note.text2 == field || note.text3 == field || note.text4 == field)
                        notes.Remove(note);
                }      
            }
        }

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
            Console.WriteLine($"# {titles[0], -10} \t\t {titles[1], -10}\t {titles[2], -10}\t {titles[3], -10}\t {titles[4], -10} \n");
            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine(i + " " + notes[i].PrintNotes());
            }
        }
    }
}
