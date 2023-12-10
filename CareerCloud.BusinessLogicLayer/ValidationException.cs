using System;
namespace CareerCloud.BusinessLogicLayer
{
	public class ValidationException: Exception
	
	{
        public int Code;
		public ValidationException(int code, string message): base(message)
		{
			this.Code = code; 
		}
	}
}

