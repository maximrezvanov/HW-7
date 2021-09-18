using System;
namespace HW_7
{
    public struct Note
    {
        public string date; 
        public string text1, text2, text3, text4;

        public Note(string date, string text1, string text2, string text3, string text4)
        {
            this.date = date;
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
        }

        public string PrintNotes()
        {
            return $"{this.date, -10}\t {this.text1, -10} \t{this.text2, -10} \t {this.text3, -10} \t {this.text4, -10}";
        }
    }
}
