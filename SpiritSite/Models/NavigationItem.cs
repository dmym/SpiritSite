using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Links;
using System.Collections.Generic;
using System.Linq;

namespace SpiritSite.Models
{
    public class NavigationItem : CustomItem
    {
        public NavigationItem(Item item)
            : base (item)
        {}

        public string Title
            => InnerItem.DisplayName;

        public bool IsActive
            => InnerItem.ID == Context.Item.ID;

        public string Url
            => LinkManager.GetItemUrl(InnerItem);

        public List<NavigationItem> Children { get; set; }

        public bool HasChildren => Children != null && Children.Any();
    }
}