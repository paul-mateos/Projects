using System;

public class Time
{
    private int hours;
    private int minutes;
    private const int MAX_HOURS = 23;
    private const int MAX_MINUTES = 60;

    public int Hours
    {
        get
        {
            return hours;
        }
    }

    public int Minutes
    {
        get
        {
            return minutes;
        }
    }

    public Time(int hours, int minutes)
    {
        if (hours > MAX_HOURS)
        {
            throw new ArgumentException("Hours cannot be greater than " + MAX_HOURS);
        }
        if (hours < 0)
        {
            throw new ArgumentException("Hours cannot be less than 0");
        }

        this.hours = hours;

        if (minutes > MAX_MINUTES)
        {
            throw new ArgumentException("Minutes cannot be greater than " + MAX_MINUTES);
        }
        if (minutes < 0)
        {
            throw new ArgumentException("Minutes cannot be less than 0");
        }
        this.minutes = minutes;
    }

    public bool Equals(Time value)
    {
        if(value == null)
        {
            return false;
        }
        return this.hours == value.hours &&
               this.minutes == value.minutes;
    }

    public override bool Equals(object obj)
    {
        Time time = obj as Time;
        if (time == null) 
            return false;
        return this.Equals(time);
    }

    public override int GetHashCode()
    {
        int result = 0;
        result = result * 6661313 + this.hours.GetHashCode();
        result = result * 6661313 + this.minutes.GetHashCode();
        return result;
    }    

    public override string ToString()
    {
        return string.Format("{0:00}:{1:00}", hours, minutes);
    }

    public static Time operator +(Time givenTime, int givenMinutes)
    {
        int hoursToAdd = givenMinutes / MAX_MINUTES;
        int newHours = givenTime.Hours + hoursToAdd;

        int minutesToAdd = givenMinutes % MAX_MINUTES;
        int newMinutes = givenTime.Minutes + minutesToAdd;

        if (newHours >= MAX_HOURS)
        {
            newHours %= MAX_HOURS;
        }

        if (newMinutes >= MAX_MINUTES)
        {
            if (newHours != 0)
            {
                newHours += 1;
            }			
            newMinutes = newMinutes - MAX_MINUTES;
        }

        return new Time(newHours, newMinutes);
    }

    public static Time operator -(Time givenTime, int givenMinutes)
    {
        int hoursToRemove = givenMinutes / MAX_MINUTES;
        int newHours = givenTime.Hours - hoursToRemove;

        int minutesToRemove = givenMinutes % MAX_MINUTES;
        int newMinutes = givenTime.Minutes - minutesToRemove;

        if (newHours < 0)
        {
            int hoursToBalance = newHours % MAX_HOURS;
            newHours = MAX_HOURS + hoursToBalance;
        }

        if (newMinutes < 0)
        {
            newHours -= 1;
            if (newHours < 0)
            {
                newHours += (MAX_HOURS + 1);
            }
            newMinutes = newMinutes + MAX_MINUTES;
        }

        return new Time(newHours, newMinutes);
    }

    public static Time operator ++(Time givenTime)
    {
        return givenTime + 1;
    }

    public static Time operator --(Time givenTime)
    {
        return givenTime - 1;
    }
}

