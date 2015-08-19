using System;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Project.Core.Interfaces;

namespace Project.Console
{
    class Program
    {
        private static WindsorContainer _kernel;
        static void Main(string[] args)
        {
            _kernel = new WindsorContainer();
            _kernel.Install(FromAssembly.This());

            var pData = _kernel.Resolve<IProjectData>();

            try
            {
                Run(pData);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine("Program threw an exception: {0}", exception.Message);
            }
            System.Console.Read();
        }

        static void Run(IProjectData data)
        {
            var d = data.GetAllItems();
            System.Console.WriteLine("Get some Project Data: {0} items", d.Count);
            foreach (var item in d)
            {
                System.Console.WriteLine("\t({0}) Name:{1}, Type:{2}", item.Id, item.Name, item.ItemType);
            }
        }
    }
}




//System.Console.WriteLine("Get by id: {0}", d.First().Id);
//            var getOne = data.GetItemById(d.First().Id);
//System.Console.WriteLine("\t({0}){1}, {2}, {3}", getOne.Id, getOne.Name, getOne.ItemType, getOne.Date);

//            //System.Console.WriteLine("Get by id: {0}", "NO");
//            //getOne = data.GetItemById(Guid.Empty);
//            //System.Console.WriteLine("\t({0}){1}, {2}, {3}", getOne.Id, getOne.Name, getOne.ItemType, getOne.Date);
