using System;
using System.Collections.Generic;

public class Card
{
	public string Face { get; set; }
	public string Value { get; set; }

	public Card()
	{

	}

	public Card(string value, string face)
	{
		this.Value = value;
		this.Face = face;
	}
}