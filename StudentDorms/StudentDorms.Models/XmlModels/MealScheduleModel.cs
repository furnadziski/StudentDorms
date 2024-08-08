/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
	[XmlRoot(ElementName = "ChosenMeal")]
	public class ChosenMeal
	{
		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "MealCategoryName")]
		public string MealCategoryName { get; set; }

		[XmlElement(ElementName = "MealCategoryId")]
		public int MealCategoryId { get; set; }

		[XmlElement(ElementName = "Percents")]
		public string Percents { get; set; }
	}

	[XmlRoot(ElementName = "ChosenMeals")]
	public class ChosenMeals
	{
		[XmlElement(ElementName = "ChosenMeal")]
		public List<ChosenMeal> ChosenMeal { get; set; }
	}

	[XmlRoot(ElementName = "MealDate")]
	public class MealDateXmlModel
	{
		[XmlElement(ElementName = "Date")]
		public DateTime Date { get; set; }
		[XmlElement(ElementName = "Day")]
		public string Day { get; set; }
		[XmlElement(ElementName = "ChosenMeals")]
		public ChosenMeals ChosenMeals { get; set; }
	}

	[XmlRoot(ElementName = "MealDates")]
	public class MealDates
	{
		[XmlElement(ElementName = "MealDate")]
		public List<MealDateXmlModel> MealDate { get; set; }
	}

	[XmlRoot(ElementName = "WeeklyMeals")]
	public class WeeklyMealsXmlModel
	{
		[XmlElement(ElementName = "FirstDayOfWeek")]
		public DateTime FirstDayOfWeek { get; set; }
		[XmlElement(ElementName = "LastDayOfWeek")]
		public DateTime LastDayOfWeek { get; set; }
		[XmlElement(ElementName = "MealDates")]
		public MealDates MealDates { get; set; }
	}

}
