using System;

public class PriceIncreasedEventArgs : EventArgs
{
	public decimal OldValue { get; set; }
	public decimal NewValue { get; set; }

	public PriceIncreasedEventArgs(decimal oldValue, decimal newValue)
	{
		this.OldValue = oldValue;
		this.NewValue = newValue;
	}
}


