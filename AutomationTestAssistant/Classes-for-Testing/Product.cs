using System;

public class Product
{
	public string Name { get; set; }
	public event PriceIncreasedEventHandler PriceIncreased;

	private decimal price;

	public Product(string name, decimal price)
	{
		this.Name = name;
		this.Price = price;
	}
	
	public decimal Price
	{
		get
		{
			return this.price;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("Price can not be negative.");
			}
			if (PriceIncreased != null && value > this.price)
			{
				PriceIncreased(this, new PriceIncreasedEventArgs(this.price, value));
			}
			this.price = value;
		}
	}
}


