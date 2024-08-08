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
	public class ChosenMealVoting
	{
		[XmlElement(ElementName = "MealName")]
		public string MealName { get; set; }

		[XmlElement(ElementName = "MealId")]
		public int MealId { get; set; }

		[XmlElement(ElementName = "MealCategoryId")]
		public int MealCategoryId { get; set; }

		[XmlElement(ElementName = "MealCategoryName")]
		public string MealCategoryName { get; set; }
	}

	[XmlRoot(ElementName = "ChosenMeals")]
	public class ChosenMealsVoting
	{
		[XmlElement(ElementName = "ChosenMeal")]
		public List<ChosenMealVoting> ChosenMeal { get; set; }
	}

	[XmlRoot(ElementName = "MealDate")]
	public class MealDateVoting
	{
		[XmlElement(ElementName = "Date")]
		public DateTime Date { get; set; }
		[XmlElement(ElementName = "Day")]
		public string Day { get; set; }
		[XmlElement(ElementName = "ChosenMeals")]
		public ChosenMealsVoting ChosenMeals { get; set; }
	}

	[XmlRoot(ElementName = "MealDates")]
	public class MealDatesVoting
	{
		[XmlElement(ElementName = "MealDate")]
		public List<MealDateVoting> MealDate { get; set; }
	}

	[XmlRoot(ElementName = "WeeklyMeals")]
	public class WeeklyMealsVoting
	{
		[XmlElement(ElementName = "FirstDayOfWeek")]
		public DateTime FirstDayOfWeek { get; set; }
		[XmlElement(ElementName = "LastDayOfWeek")]
		public DateTime LastDayOfWeek { get; set; }
		[XmlElement(ElementName = "DeadLine")]
		public DateTime DeadLine { get; set; }
		[XmlElement(ElementName = "MealDates")]
		public MealDatesVoting MealDates { get; set; }
	}

}
