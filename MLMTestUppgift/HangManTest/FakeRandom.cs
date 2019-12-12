using System;
using System.Collections.Generic;
using System.Text;
using HangMan;

namespace HangManTest
{
    public class FakeRandom
    {
        public int Next(int a, int b)
        {
            return 5; // returns index number 5 results in word #6
        }
    }
}
