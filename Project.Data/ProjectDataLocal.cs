using System;
using System.Collections.Generic;
using System.Linq;
using Project.Aop.Aspects;
using Project.Core.Interfaces;
using Project.Core.Models;

namespace Project.Data
{
    public class ProjectDataLocal : IProjectData
    {
        private List<ProjectItem> _masterList;
        public ProjectDataLocal()
        {
            _masterList = new List<ProjectItem>
            {
                new ProjectItem { Id = Guid.Parse("5843b73d-45f7-4284-86cf-c2f07821e01d"), Name ="Item 1", ItemType = "A" },
                new ProjectItem { Id = Guid.Parse("9815b73d-45f7-4284-86cf-c2f07821e01d"), Name ="Item 2", ItemType = "A" },
                new ProjectItem { Id = Guid.Parse("2100b73d-45f7-4284-86cf-c2f07821e01d"), Name ="Item 3", ItemType = "B" },
                new ProjectItem { Id = Guid.Parse("8688b73d-45f7-4284-86cf-c2f07821e01d"), Name ="Item 4", ItemType = "C" }
            };
        }

        //Do not do it this way!
        //public List<ProjectItem> GetAllItems()
        //{
        //    var start = DateTime.UtcNow;
        //    try
        //    {
        //        return _masterList;
        //    }
        //    catch (Exception exception)
        //    {
        //        LogException(exception);
        //        throw;
        //    }
        //    finally
        //    {
        //        LogTiming(start, DateTime.Now);
        //    }
        //}
        //private void LogTiming(DateTime start, DateTime now)
        //{
        //    //log timing metrics
        //}
        //private void LogException(Exception exception)
        //{
        //    //log exception
        //}

        [ExceptionAspect]
        [TimingAspect]
        public List<ProjectItem> GetAllItems()
        {
            //throw new Exception("Test Exception");//uncomment to test ExcpetionAspect
            return _masterList;
        }

        public ProjectItem GetItemById(Guid id)
        {
            return _masterList.Single(x => x.Id == id);
        }

        public ProjectItem GetItemByName(string name)
        {
            return _masterList.Single(x => x.Name == name);
        }
    }
}
