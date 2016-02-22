namespace BullsAndCows
{
    public class Result
    {
        public int Bulls { get; private set; }
        public int Cows { get; private set; }

        public Result(int bulls, int cows)
        {
            this.Bulls = bulls;
            this.Cows = cows;
        }

        public override string ToString()
        {
            return string.Format("Wrong number! Bulls: {0}, Cows: {1}",
                                 this.Bulls, this.Cows);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Result other = obj as Result;
            bool areBullsEqual = this.Bulls.Equals(other.Bulls);
            bool areCowsEqual = this.Cows.Equals(other.Cows);
            bool areResultsEqual = areBullsEqual && areCowsEqual;

            if (areResultsEqual)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}