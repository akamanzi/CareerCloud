using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobLogic: BaseLogic<CompanyJobPoco>
	{
		public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {
		}
        protected override void Verify(CompanyJobPoco[] pocos)
        {
            base.Verify(pocos);
        }
        public override void Update(CompanyJobPoco[] pocos)
        {
            base.Update(pocos);
        }
        public override void Add(CompanyJobPoco[] pocos)
        {
            base.Add(pocos);
        }
    }
}

