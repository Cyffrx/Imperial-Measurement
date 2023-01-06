using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasurementConverter;
using Xunit;

namespace MeasurementConverter.Tests
{
	/*
		there is definetly a better way to test all these inputs
		throwing the variations into an array and having it tell me which indicies fail and why would be much simpler 
			than writing the same boilerplate eleven times
		but this does work!
	 */
	public class ImperialTests
	{
		[Fact]
		public void Inches_AutoConvertInchesFeet()
		{
			// Arrange
			double expected = 1.0f;
			double test = 1.0f;

			// Act
			ImperialMeasurement im = new ImperialMeasurement();
			im.Inches = test;
			double actual = im.Inches;

			// Assert
			Assert.Equal(expected, actual);

		}

		[Fact]
		public void Constructor_ReadAndWriteDimensionalString()
		{
			//	Arrange
			string expected = "12'1\"";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("12'1''");
			string actual = im.Dimensional;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Written_ReadFormOfMeasurement_Inch()
		{
			//	Arrange
			string expected = "12 Feet 1 Inch";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("12'1''");
			string actual = im.Written;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TotalInches_CalculateTotalInchesOfMeasurement()
		{
			//	Arrange
			double expected = 145.0f;

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("12'1''");
			double actual = im.TotalInches;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Feet_ReplyFeet()
		{
			//	Arrange
			string expected = "Feet";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("12'2''");
			string actual = im.Foot;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Feet_ReplyFoot()
		{
			//	Arrange
			string expected = "Foot";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("1'2''");
			string actual = im.Foot;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Feet_ReplyInch()
		{
			//	Arrange
			string expected = "Inch";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("12'1''");
			string actual = im.Inch;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Feet_ReplyInches()
		{
			//	Arrange
			string expected = "Inches";

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("1'22''");
			string actual = im.Inch;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Constructor_NoQuotes()
		{
			//	Arrange
			double expected = 10.0f;

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("10");
			double actual = im.Inches;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Constructor_SingleQuotes()
		{
			//	Arrange
			double expected = 10.0f;

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("10'");
			double actual = im.Feet;

			//	Assert
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void Constructor_DoubleQuotes()
		{
			//	Arrange
			double expected = 10.0f;

			//	Act
			ImperialMeasurement im = new ImperialMeasurement("10\"");
			double actual = im.Inches;

			//	Assert
			Assert.Equal(expected, actual);
		}
	}
}
