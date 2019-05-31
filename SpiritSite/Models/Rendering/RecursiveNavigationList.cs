using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Linq;

namespace SpiritSite.Models
{
    public class RecursiveNavigationList : RenderingModel
    {
        public NavigationItem BaseItem { get; private set; }

        public override void Initialize(Rendering rendering)
        {
            BaseItem = new NavigationItem(Sitecore.Context.Item);

            int? level = null;

            if (int.TryParse(rendering.Parameters["Level"], out int temp))
                level = temp;

            AddDescendands(BaseItem, level);

            base.Initialize(rendering);
        }

        private void AddDescendands(NavigationItem baseItem, int? level)
        {
            if (level == 0)
                return;

            baseItem.Children = new List<NavigationItem>();

            foreach (var child in baseItem.InnerItem.GetChildren()
                .Where(item => item["ExcludeFromNavigation"] != "1"))
            {
                var item = new NavigationItem(child);
                if (child.HasChildren)
                {
                    AddDescendands(item, level - 1);
                }

                baseItem.Children.Add(item);
            }
        }
    }
}