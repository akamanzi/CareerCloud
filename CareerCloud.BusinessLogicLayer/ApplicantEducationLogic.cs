﻿using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class ApplicantEducationLogic: BaseLogic<ApplicantEducationPoco>
	{
		public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository): base(repository)
		{
		}

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, "Cannot be empty"));
                }
                else if(poco.Major.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, "Cannot be less than 3 characters"));
                }

                if (poco?.StartDate > DateTime.Now)
                {
                    exceptions.Add(new ValidationException(108, "Cannot be greater than today"));
                }
                if (poco?.CompletionDate < poco?.StartDate)
                {
                    exceptions.Add(new ValidationException(109, "CompletionDate cannot be earlier than StartDate"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }
}

