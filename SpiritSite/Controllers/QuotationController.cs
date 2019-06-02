using SpiritSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;

namespace SpiritSite.Controllers
{
    public class QuotationController : Controller
    {
        // GET: Quotation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddQuotation(Quotation model)
        {
            if (ModelState.IsValid)
            {
                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    Database master = Database.GetDatabase("master");
                    TemplateItem template = master.GetItem(new ID("{A3E2FEA0-002A-4F5D-87CE-F9490A8471D0}"));
                    Item parentItem = master.GetItem(Sitecore.Context.Item.ID);
                    Item newItem = parentItem.Add("quotation", template);
                    newItem.Editing.BeginEdit();

                    try
                    {
                        newItem.Fields["UserName"].Value = model.UserName;
                        newItem.Fields["Text"].Value = model.Text;
                        newItem.Editing.EndEdit();
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error("Could not update item " + newItem.Paths.FullPath + ": " + ex.Message, this);
                        newItem.Editing.CancelEdit();
                    }

                    PublishItem(newItem);
                }
            }

            IView pageView = Sitecore.Mvc.Presentation.PageContext.Current.PageView;
            if (pageView == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(pageView);
            }
        }

        private void PublishItem(Item item)
        {
            PublishOptions publishOptions = new PublishOptions(item.Database,
                                                     Database.GetDatabase("web"),
                                                     PublishMode.SingleItem,
                                                     item.Language,
                                                     DateTime.Now);

            Publisher publisher = new Publisher(publishOptions);
            publisher.Options.RootItem = item;
            publisher.Publish();
        }
    }
}