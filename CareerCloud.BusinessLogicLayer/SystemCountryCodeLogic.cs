using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemCountryCodeLogic
    {
        protected IDataRepository<SystemCountryCodePoco>? _repository;
        public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco>? repository)
        {
            this._repository = repository;
        }
        protected virtual void Verify(SystemCountryCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Code))
                {
                    exceptions.Add(new ValidationException(900, "Code Cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(901, "Code Cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public virtual SystemCountryCodePoco? Get(string name)
        {
            return _repository?.GetSingle(c => c.Name == name);
        }

        public virtual List<SystemCountryCodePoco>? GetAll()
        {
            return _repository?.GetAll().ToList();
        }

        public void Delete(SystemCountryCodePoco[] pocos)
        {
            _repository?.Remove(pocos);
        }

        

        public virtual void Add(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);

            _repository?.Add(pocos);
        }

        public virtual void Update(SystemCountryCodePoco[] pocos)
        {
            Verify(pocos);
            _repository?.Update(pocos);
        }
    }
}

