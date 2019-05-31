using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace SpiritSite.Models
{
    public class BreadcrumbsList : RenderingModel
    {
        public List<NavigationItem> Breadcrumbs { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            string homePath = Sitecore.Context.Site.StartPath;
            Item homeItem = Sitecore.Context.Database.GetItem(homePath);

            Breadcrumbs = Sitecore.Context.Item.Axes.GetAncestors()
              .SkipWhile(item => item.ID != homeItem.ID)
              .Select( item => new NavigationItem(item))
              .ToList();

            Breadcrumbs.Add(new NavigationItem(Sitecore.Context.Item));

            base.Initialize(rendering);
        }
    }
}