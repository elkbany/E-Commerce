using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Implementations
{
    public abstract class AppService
    {
        protected async Task DoValidationAsync<TValidator, TRequest>(TRequest request, params object[] constructorParameters)
           where TValidator : AbstractValidator<TRequest>
        {
            //TValidator instance;
            //if (unitOfWork != null)
            //{
            //    //object[] constructorParameters = { unitOfWork }; // Pass the parameter values
            //    instance = (TValidator)Activator.CreateInstance(typeof(TValidator), unitOfWork)!;
            //}
            //else instance = Activator.CreateInstance<TValidator>();

            var instance = (TValidator)Activator.CreateInstance(typeof(TValidator), constructorParameters)!;

            var validateResult = await instance.ValidateAsync(request);
            if (!validateResult.IsValid)
            {
                throw new ValidationException(validateResult.Errors);
            }
        }

    }
}
