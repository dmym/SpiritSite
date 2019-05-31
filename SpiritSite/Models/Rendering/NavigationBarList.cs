using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace SpiritSite.Models
{
    public class NavigationBarList : RenderingModel
    {
        public List<NavigationItem> NavigationItems { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            string homePath = Sitecore.Context.Site.StartPath;
            Item homeItem = Sitecore.Context.Database.GetItem(homePath);

            NavigationItems = new List<NavigationItem> { new NavigationItem(homeItem) };

            homeItem.GetChildren()
                .Where(item => item["ExcludeFromNavigation"] != "1")
                .ToList()
                .ForEach(item => NavigationItems.Add(new NavigationItem(item)));

            base.Initialize(rendering);
        }
    }
}