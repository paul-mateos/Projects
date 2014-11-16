using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookGame
{
    public static class JaggedArrayExtensions
    {
        public static void ForEach(this Object[][] array, Action action)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[i].GetLength(0); j++)
                {
                    action.Invoke();
                }
            }
        }
    }
}
