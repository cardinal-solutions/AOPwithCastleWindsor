using System;
using System.Collections.Generic;
using Project.Core.Models;

namespace Project.Core.Interfaces
{
    public interface IProjectData
    {
        List<ProjectItem> GetAllItems();
        ProjectItem GetItemById(Guid id);
        ProjectItem GetItemByName(string name);
    }
}
