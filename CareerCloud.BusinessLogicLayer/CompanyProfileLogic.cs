using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyProfileLogic: BaseLogic<CompanyProfilePoco>
	{
		public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
		}
        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (poco.CompanyWebsite is not null)
                {
                    if (!poco.CompanyWebsite.EndsWith(".ca"))
                    {
                        exceptions.Add(new ValidationException(600, "Valid websites must end with the\nfollowing extensions – \".ca\", \".com\", \".biz\""));
                    }
                    else if (!poco.CompanyWebsite.EndsWith(".biz"))
                    {
                        exceptions.Add(new ValidationException(600, "Valid websites must end with the\nfollowing extensions – \".ca\", \".com\", \".biz\""));
                    }
                    else if (!poco.CompanyWebsite.EndsWith(".com"))
                    {
                        exceptions.Add(new ValidationException(600, "Valid websites must end with the\nfollowing extensions – \".ca\", \".com\", \".biz\""));
                    }
                }

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number (e.g. 416-555-1234)"));
                }

                if (poco.ContactPhone is not null)
                {
                    
                    string[] phoneComponents = poco.ContactPhone.Split('-');

                    if (phoneComponents?[0].Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                    else if (phoneComponents?[1].Length != 3)
                    {
                        exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                    else if (phoneComponents[2]?.Length != 4)
                    {
                        exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number (e.g. 416-555-1234)"));
                    }
                }
                

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
    }

}

