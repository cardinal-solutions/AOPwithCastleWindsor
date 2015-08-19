using System;
using Castle.DynamicProxy;

namespace Project.Aop.Aspects
{
    public class ExceptionAspect : Aspect
    {
        public override void ProcessInvocation(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Intercepted: {0}", exception.Message);
                throw;//re-throw
            }
        }
    }
}
