using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioTest
{
    public static class CalculateValues
    {
       public static int KeyValue { get; set; }
        public static int RowIndex { get; set; }
        public static int ColumnIndex { get; set; }

        public static string Chord { get; set; }

        public static string Root { get; set; }
        public static string Third { get; set; }
        public static string Fift { get; set; }

        public static string PracticeRoot { get; set; }
        public static string PracticeThird { get; set; }
        public static string PracticeFift { get; set; }



        public static int ArrayIndex { get; set; }

        public static List<int> chordNotesList = new List<int>();

        


        public static bool isInRange = false;

        public static bool isDataValid = false;
        public static void RangeCheck(double frequency)
        {
            isInRange = false;
            int freq = Convert.ToInt16(frequency);

            bool keyE = Enumerable.Range(75, 10).Contains(freq);
            bool keyA = Enumerable.Range(105, 11).Contains(freq); 
            bool keyD = Enumerable.Range(140, 15).Contains(freq); 
            bool keyG = Enumerable.Range(186, 21).Contains(freq); 
            bool keyH = Enumerable.Range(234, 27).Contains(freq); 
            bool keyE6 = Enumerable.Range(312, 37).Contains(freq); 

            if (keyE || keyA || keyD || keyG || keyH || keyE6)
            {                 
                    CalculateValues.isInRange = true;
            }
            else
            {
                isInRange = false;
            }

           
            
        }


       

        public static void CalculateFretBoardKey(double frequency)
        { 
              
            int[] fretboardKeyArray = new int[] { 329, 349, 370, 392, 415, 440,
                                                  247, 262, 277, 294, 311, 329,
                                                  196, 208, 220, 233, 247, 262,
                                                  147, 156, 165, 175, 185, 196,
                                                  110, 117, 123, 131, 139, 147,
                                                  82,  87,  92,  98,  104, 110};

            List<int> fretboardKeyList = new List<int>();
            int freq = Convert.ToInt16(frequency);

            for (int i = 0; i < fretboardKeyArray.Length; i++)
            {
               fretboardKeyList.Add(Math.Abs(freq - fretboardKeyArray[i]));
            }

            for (int i = 0; i < fretboardKeyArray.Length; i++)
            {
                if (fretboardKeyList.Min() == Math.Abs(freq - fretboardKeyArray[i]))
                {
                  ArrayIndex = fretboardKeyList.IndexOf(Math.Abs(freq - fretboardKeyArray[i]));

                    RowIndex = ArrayIndex / 6;
                    ColumnIndex = ArrayIndex - RowIndex * 6;

                  break;
                  
                  
                }
               
            }
        }

        public static string CalculateClosestKeyToTune(double frequency)
        {

            int[] standardTuneArray = new int[] {330, 247, 195, 147, 110, 82};
            string[] stringNotes = new string[] {"E6","H","G","D","A","E"};

            List<int> noteDistanceList = new List<int>();
            int freq = Convert.ToInt16(frequency);

            for (int i = 0; i < standardTuneArray.Length; i++)
            {
                noteDistanceList.Add(Math.Abs(freq - standardTuneArray[i]));
            }

            for (int i = 0; i < standardTuneArray.Length; i++)
            {
                if (noteDistanceList.Min() == Math.Abs(freq - standardTuneArray[i]))
                {
                    ArrayIndex = noteDistanceList.IndexOf(Math.Abs(freq - standardTuneArray[i]));
                    KeyValue = standardTuneArray[ArrayIndex];
                    RangeCheck(frequency);
                    break;
                }
                
            }
            return stringNotes[ArrayIndex];
        }

        public static string PracticeChordGenerator(int index1, int index2)
        {
            string[] rootnoteArray = new string[] { "E", "F", "G", "A", "H", "C", "D"};
            
            string[] chordModeArray = new string[] { "Dúr","Mol", "Szűkített", "Bővített"};

            string[] modesArray = new string[] { "E", "F", "F#", "G", "G#", "A", "A#", "H", "C", "C#", "D", "D#",
                                                 "E", "F", "F#", "G", "G#", "A", "A#"};

            PracticeRoot = rootnoteArray[index1];
               index1 = modesArray.ToList().IndexOf(PracticeRoot);

            switch (index2)
            {
                case 0:
                    PracticeThird = modesArray[index1 + 4];
                    PracticeFift = modesArray[index1 + 7];
                    
                    break;

                case 1:
                    PracticeThird = modesArray[index1 + 3];
                    PracticeFift = modesArray[index1 + 7];
                    break;

                case 2:
                    PracticeThird = modesArray[index1 + 3];
                    PracticeFift = modesArray[index1 + 6];
                    break;

                case 3:
                    PracticeThird = modesArray[index1 + 4];
                    PracticeFift = modesArray[index1 + 8];
                    break;

            }

            return $"{PracticeRoot} {chordModeArray[index2]}";

        }

        public static void CalculateChord(double freq1)
        {
            
            int arrayindex;
            int[] fretboardKeyArray = new int[] { 82, 87, 92, 98, 104,  110, 117, 123, 131, 139, 147, 156,
                                                  165, 175, 185,  195, 208, 220, 233, 247, 262, 277, 294,
                                                  311, 330, 349, 370, 392, 415, 440,};

            string[] rootnoteArray = new string[] { "E", "F", "F#", "G", "G#", "A", "A#", "H", "C", "C#", "D", "D#",
                                                    "E", "F", "F#", "G", "G#", "A", "A#", "H", "C", "C#", "D", "D#",
                                                    "E", "F", "F#", "G", "G#", "A"};



            List<int> fretboardKeyList = new List<int>();
            int freq = Convert.ToInt16(freq1);

            for (int i = 0; i < fretboardKeyArray.Length; i++)
            {
                fretboardKeyList.Add(Math.Abs(freq - fretboardKeyArray[i]));
            }

            for (int i = 0; i < fretboardKeyArray.Length; i++)
            {
                if (fretboardKeyList.Min() == Math.Abs(freq - fretboardKeyArray[i]))
                {
                    arrayindex = fretboardKeyList.IndexOf(Math.Abs(freq - fretboardKeyArray[i]));
                    chordNotesList.Add(arrayindex);

                    break;


                }
            }

            for (int i = 1; i < chordNotesList.Count-1; i++)
            {
                int distance = chordNotesList.ElementAt(i) - chordNotesList.ElementAt(i - 1);
                int distance2 = chordNotesList.ElementAt(i + 1) - chordNotesList.ElementAt(i);

                if (distance == 5 && (distance2 == 3 || distance2 == 4))
                {
                    Root = rootnoteArray[chordNotesList.ElementAt(i)];
                    Third = rootnoteArray[chordNotesList.ElementAt(i + 1)];
                    Fift = rootnoteArray[chordNotesList.ElementAt(i-1)];

                    switch (distance2)
                    {
                        case 3:
                            Chord = $"{rootnoteArray[chordNotesList.ElementAt(i)]} Mol";
                            break;

                        case 4:
                            Chord = $"{rootnoteArray[chordNotesList.ElementAt(i)]} Dúr";
                            break;      
                    }

                }
               else if (distance == 4 && distance2 == 4)
                {
                    Root = rootnoteArray[chordNotesList.ElementAt(i)];
                    Third = rootnoteArray[chordNotesList.ElementAt(i + 1)];
                    Fift = rootnoteArray[chordNotesList.ElementAt(i - 1)];

                            Chord = $"{rootnoteArray[chordNotesList.ElementAt(i)]} Bővített";
                }

                else if (distance == 6 && distance2 == 3)
                {
                    Root = rootnoteArray[chordNotesList.ElementAt(i)];
                    Third = rootnoteArray[chordNotesList.ElementAt(i + 1)];
                    Fift = rootnoteArray[chordNotesList.ElementAt(i - 1)];

                    Chord = $"{rootnoteArray[chordNotesList.ElementAt(i)]} Szűkített";
                }



            }

        }

      
        public static void CheckPeakData(double frequency,double lastfrequency) 
        {
          int currentfreq = Convert.ToInt32(frequency);
          int lastfreq = Convert.ToInt32(lastfrequency);

            if (Enumerable.Range(lastfreq-10, 20).Contains(currentfreq))
            {
                isDataValid = true;
            }
            else
            {
                isDataValid = false;
            }
               

           

            
        }
    }
}
