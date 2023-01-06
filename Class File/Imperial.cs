public class ImperialMeasurement
{
	private static double bInchesInFoot = 12.0f;
	public static double InchesInFoot { get { return bInchesInFoot; } }

	public string Foot { get { if (Feet == 1.0f) return "Foot"; return "Feet"; } }
	public double Feet = 0.0f;

	public string Inch { get { if (Inches == 1.0f) return "Inch"; return "Inches"; } }
	private double bInchValue = 0.0f;
	public double Inches
	{
		get { return bInchValue; }
		set
		{
			bInchValue += value;
			if (bInchValue > InchesInFoot)
			{
				double remainderInches = bInchValue % InchesInFoot;
				double Feet = (bInchValue - remainderInches) / InchesInFoot;
			}
		}
	}

	public ImperialMeasurement()
	{
		Inches = 0;
		Feet = 0;
	}

	/// <summary>
	/// Create an Imperial Measurement using a string-dimensional.
	/// 12'1" is read as 12 feet 1 inch.
	/// 12' is read as 12 feet
	/// 1" is read as 1 inch
	/// 1 is read as 1 inch
	/// </summary>
	/// <param name="dimensional"></param>
	public ImperialMeasurement(string dimensional)
	{
		string sfeet = "";
		string sinches = "";

		// if this passes then there were no deliminators to check anyways (' or ")
		if (double.TryParse(dimensional, out double inches))
		{
			Inches = inches;
			return;
		}

		// convert double single-quoutes to double-quotes ('' -> ")
		if (dimensional.Contains("''")) dimensional = dimensional.Replace("''", "\"");

		if (dimensional.Contains("'"))
		{
			sfeet = dimensional.Substring(0, dimensional.IndexOf("'"));
			dimensional = dimensional.Replace(sfeet + "'", "");
		}

		// if has double quotes assign substring to sinches sans quotes, else assign dimension to sinches
		sinches = dimensional.Contains("\"") ?
			dimensional.Substring(0, dimensional.IndexOf("\""))
			: dimensional;

		double.TryParse(sfeet, out double feet);
		double.TryParse(sinches, out inches);

		Feet = feet;
		Inches = inches;

		// the set function of Inches will handle if inches > bInchesInFoot
	}

	public double TotalInches { get { return bInchesInFoot * Feet + Inches; } }
	public string Written { get { return $"{Feet} {Foot} {Inches} {Inch}"; } }
	public string Dimensional { get { return $"{Feet}'{Inches}\""; } }
}
