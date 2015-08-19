using System;

namespace Project.Core.Models
{
    public class ProjectItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
    }
}