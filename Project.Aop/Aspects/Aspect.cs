using System;
using System.Linq;
using Castle.DynamicProxy;

namespace Project.Aop.Aspects
{
    /// <summary>
    /// Abstract class to wrap Castle Windsor's IInterceptor to only fire if the method or class is decorated with this attribute.
    /// </summary>
    public abstract class Aspect : Attribute, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!CanIntercept(invocation, GetType()))
            {//method is NOT decorated with the proper aspect, continue as normal
                invocation.Proceed();
                return;
            }
            ProcessInvocation(invocation);
        }

        /// <summary>
        /// Determine if the intercepted class or method is decorated with the current attribute
        /// Classes decorated will process if decorated on ALL methods
        /// Methods decorated will process if decorate
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool CanIntercept(IInvocation invocation, Type type)
        {
            return invocation.TargetType.CustomAttributes.Any(x => x.AttributeType == type) ||
                invocation.MethodInvocationTarget.CustomAttributes.Any(x => x.AttributeType == type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void ProcessInvocation(IInvocation invocation);
    }
}