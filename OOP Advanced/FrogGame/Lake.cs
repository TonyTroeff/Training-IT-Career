using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogGame
{
    public class Lake : IEnumerable<int>
    {
        private int[] _stones;

        public Lake(int[] stones)
        {
            this._stones = stones ?? throw new ArgumentNullException(nameof(stones));
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this._stones.Length; i+= 2)
                yield return this._stones[i];

            int parity = this._stones.Length % 2;
            for (int i = this._stones.Length - parity - 1; i >= 0; i -= 2)
                yield return this._stones[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
