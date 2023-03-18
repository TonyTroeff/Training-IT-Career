using System;

namespace SendMeAnEmail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            int sumBefore = 0, sumAfter = 0;

            /*int indexOfSeparator = email.IndexOf('@');
            for (int i = 0; i < indexOfSeparator; i++) sumBefore += email[i];
            for (int i = indexOfSeparator + 1; i < email.Length; i++)
                sumAfter += email[i];*/

            bool hasSeenSeparator = false;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '@') hasSeenSeparator = true;
                else
                {
                    if (hasSeenSeparator) sumAfter += email[i];
                    else sumBefore += email[i];
                }
            }

            if (sumBefore >= sumAfter) Console.WriteLine("Call her!");
            else Console.WriteLine("She is not the one.");
        }
    }
}