using System;

namespace BullsAndCows
{
    public class PlayerInfo : IComparable<PlayerInfo>
    {
        public string Name { get; private set; }
        public int Guesses { get; private set; }

        public PlayerInfo(string name, int guesses)
        {
            this.Name = name;
            this.Guesses = guesses;
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} {2}", this.Name, this.Guesses,
                                 this.Guesses == 1 ? "guess" : "guesses");
        }

        public int CompareTo(PlayerInfo otherPlayer)
        {
            if (otherPlayer == null)
            {
                return 1;
            }
            if (this.Guesses.CompareTo(otherPlayer.Guesses) == 0)
            {
                return this.Name.CompareTo(otherPlayer.Name);
            }
            else
            {
                return this.Guesses.CompareTo(otherPlayer.Guesses);
            }
        }
    }
}