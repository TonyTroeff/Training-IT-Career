using System;
using System.Text;

namespace AnonymousVox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] values = Console.ReadLine().Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();
            int textIndex = 0, valueIndex = 0;
            while (textIndex < text.Length && valueIndex < values.Length)
            {
                sb.Length = 0;
                sb.Append(text[textIndex]);

                int correspondingEndIndex = text.LastIndexOf(sb.ToString()), lastEndIndex = -1;
                while (char.IsAsciiLetter(sb[sb.Length - 1]) && textIndex + sb.Length < correspondingEndIndex)
                {
                    sb.Append(text[textIndex + sb.Length]);

                    lastEndIndex = correspondingEndIndex;
                    correspondingEndIndex = text.LastIndexOf(sb.ToString());
                }

                sb.Length--;
                if (sb.Length == 0) textIndex++;
                else
                {
                    int placeholderBeginIndex = textIndex + sb.Length;
                    text = text.Remove(placeholderBeginIndex, lastEndIndex - placeholderBeginIndex);
                    text = text.Insert(placeholderBeginIndex, values[valueIndex]);

                    textIndex = textIndex + sb.Length * 2 + values[valueIndex].Length;
                    valueIndex++;
                }
            }

            Console.WriteLine(text);
        }
    }
}