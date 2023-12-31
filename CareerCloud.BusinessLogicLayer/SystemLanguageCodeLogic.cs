﻿using System;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemLanguageCodeLogic
	{
        protected IDataRepository<SystemLanguageCodePoco>? _repository;
        public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
		{
			this._repository = repository;
		}
        protected virtual void Verify(SystemLanguageCodePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.LanguageID))
                {
                    exceptions.Add(new ValidationException(1000, "LanguageID Cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.Name))
                {
                    exceptions.Add(new ValidationException(1001, "Name Cannot be empty"));
                }
                if (string.IsNullOrEmpty(poco.NativeName))
                {
                    exceptions.Add(new ValidationException(1002, "NativeName Cannot be empty"));
                }
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
        public virtual void Add(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository?.Add(pocos);
        }

        public virtual void Update(SystemLanguageCodePoco[] pocos)
        {
            Verify(pocos);
            _repository?.Update(pocos);
        }
        public virtual SystemLanguageCodePoco? Get(string name)
        {
            return _repository?.GetSingle(c => c.Name == name);
        }

        public virtual List<SystemLanguageCodePoco>? GetAll()
        {
            return _repository?.GetAll().ToList();
        }

        public void Delete(SystemLanguageCodePoco[] pocos)
        {
            _repository?.Remove(pocos);
        }

    }
}

