﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
	[Table("Applicant_Skills")]
	public class ApplicantSkillPoco: IPoco
	{
		public ApplicantSkillPoco()
		{
		}
		[Key]
        public Guid Id { get; set; }
		[Key]
		public Guid Applicant { get; set; }
		[Column("Skill")]
		public String Skill { get; set; }
		[Column("Skill_Level")]
		public String SkillLevel { get; set; }
		[Column("Start_Month")]
		public Byte StartMonth { get; set; }
		[Column("Start_Year")]
		public Int32 StartYear { get; set; }
		[Column("End_Month")]
		public Byte EndMonth { get; set; }
		[Column("End_Year")]
		public Int32 EndYear { get; set; }
		[Column("Time_Stamp")]
		public Byte[] TimeStamp { get; set; }

    }
}

