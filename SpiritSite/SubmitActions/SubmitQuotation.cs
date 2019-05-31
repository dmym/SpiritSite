using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using SpiritSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpiritSite.SubmitActions
{
    public class SubmitQuotation : SubmitActionBase<Quotation>
    {
        public SubmitQuotation(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }

        protected override bool Execute(Quotation data, FormSubmitContext formSubmitContext)
        {
            
            return true;
        }

        protected override bool TryParse(string value, out Quotation target)
        {
            target = new Quotation();
            return true;
        }
    }
}