using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    // This is how this class would have looked like, if there were no generics.
    public class Pair
    {
        public object First { get; set; }
        public object Second { get; set; }
    }

    // Syntax for defining generic classes:
    // {access_modifier} class {class_name}<{generic_type_param_1}, {generic_type_param_2}, ...>
    // T, U, V, ...
    // T{word_1}
    // T{word_1}, T_{word_2}
    public class Pair<TValue>
    {
        public TValue First { get; }
        public TValue Second { get; }

        public Pair(TValue first, TValue second)
        {
            this.First = first;
            this.Second = second;
        }
    }
}
