﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name) : base(name)
		{
			Type = Enums.GradeBookType.Ranked;
		}
		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5)
			{
				throw new InvalidOperationException();
			}

			int topTwentyPercent = (int)Math.Ceiling(Students.Count * 0.2);

			List<double> grades = Students.OrderByDescending(s => s.AverageGrade)
										  .Select(s => s.AverageGrade)
										  .ToList();

			if (averageGrade >= grades[topTwentyPercent - 1])
			{
				return 'A';
			}
			else if (averageGrade >= grades[(topTwentyPercent * 2) - 1])
			{
				return 'B';
			}
			else if (averageGrade >= grades[(topTwentyPercent * 3) - 1])
			{
				return 'C';
			}
			else if (averageGrade >= grades[(topTwentyPercent * 4) - 1])
			{
				return 'D';
			}
			else
			{
				return 'F';
			}
		}
		public override void CalculateStatistics()
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students");
			}
			else if (Students.Count >= 5)
			{
				base.CalculateStatistics();
			}
		}
	}
}
