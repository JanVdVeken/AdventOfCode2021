using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Day10
{
    public class SyntaxLine
    {
        public string Line { get; set; }
        
        public char WrongCharacter;
        public List<char> OpenChuncks;
        
        public bool IsIncomplete => OpenChuncks.Any();
        public bool IsCorrupted => WrongCharacter != char.MinValue;


        public SyntaxLine(string line)
        {
            OpenChuncks = new List<char>();
            Line = line;
        }

        public void CalculateSyntax()
        {
            foreach (var character in Line)
            {
                switch(character)
                {
                    case '(': 
                    case '[': 
                    case '<': 
                    case '{':
                        OpenChuncks.Add(character);
                        break;
                    
                    case '}':
                        if (OpenChuncks.Last() == '{')
                        {
                            OpenChuncks.RemoveAt(OpenChuncks.Count-1);
                        }
                        else
                        {
                            WrongCharacter = character;
                        }
                        break;
                    case ')':
                        if (OpenChuncks.Last() == '(')
                        {
                            OpenChuncks.RemoveAt(OpenChuncks.Count-1);
                        }
                        else
                        {
                            WrongCharacter = character;
                        }
                        break;
                    case '>':
                        if (OpenChuncks.Last() == '<')
                        {
                            OpenChuncks.RemoveAt(OpenChuncks.Count-1);
                        }
                        else
                        {
                            WrongCharacter = character;
                        }
                        break;
                    case ']':
                        if (OpenChuncks.Last() == '[')
                        {
                            OpenChuncks.RemoveAt(OpenChuncks.Count-1);
                        }
                        else
                        {
                            WrongCharacter = character;
                        }
                        break;
                }
                if (WrongCharacter != char.MinValue) break;
            }
        }

        public int ValueOfWrongCharacter()
        {
            switch (WrongCharacter)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    return 0;
            }
        }
    }
}