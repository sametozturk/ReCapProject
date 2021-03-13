using Castle.DynamicProxy;
using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    //aspect demek MethodInterception ı temel alan ve hangisi çalışsın istiyosan onu içeren operasyon
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//productvalidator ün instance'ını olustur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidator'ün(base typeının) çalışma tipinin ilkimi bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//metodun parametrelerine bak entityType a denk parametreleri bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
 