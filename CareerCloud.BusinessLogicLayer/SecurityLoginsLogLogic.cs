using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SecurityLoginsLogLogic: BaseLogic<SecurityLoginsLogPoco>
	{
		public SecurityLoginsLogLogic(IDataRepository<SecurityLoginsLogPoco> repository) : base(repository)
		{
		}
        protected override void Verify(SecurityLoginsLogPoco[] pocos)
        {
            base.Verify(pocos);
        }
        public override void Add(SecurityLoginsLogPoco[] pocos)
        {
            base.Add(pocos);
        }
        public override void Update(SecurityLoginsLogPoco[] pocos)
        {
            base.Update(pocos);
        }
    }
}

