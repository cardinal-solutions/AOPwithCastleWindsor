using System;
using System.Diagnostics;
using Castle.DynamicProxy;

namespace Project.Aop.Aspects
{
    public class TimingAspect : Aspect
    {
        public override void ProcessInvocation(IInvocation invocation)
        {
            var sw = Stopwatch.StartNew();
            invocation.Proceed();
            sw.Stop();
            Console.WriteLine("({0})Elapsed: {1}", invocation.MethodInvocationTarget.Name, sw.Elapsed);
        }
    }
}