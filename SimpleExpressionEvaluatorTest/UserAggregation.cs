using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleExpressionEvaluatorTest
{
    public class UserAggregation : RuleEngineExtensions
    {
        public bool HasPurchased { get; set; }

        public int Visits { get; set; }

        public IList<string> VisitsBySubfolder { get; set; }

        public bool HasPromocodeAvailable { get; set; }

        public int PageViewsCount { get; set; }

        public IDictionary<string, int> PageViewsByDesigner { get; set; }

        public IList<string> PageViewsByType { get; set; }

        public bool Returning { get; set; }

        public IList<string> Channel { get; set; }

        public DateTime LastKnownVisit { get; set; }

        public List<string> VisitsByDesigner { get; set; }

        public bool HasWishListProducts { get; set; }

        public bool HasMultipleAddresses { get; set; }

        public string SpendLevel { get; set; }

        public string AccessTier { get; set; }

        //other - test

        public string NullProp { get; set; }

        public bool ReceiveBenefits { get; set; }

        public void SetCanReceiveBenefits(bool receiveBenefits)
        {
            ReceiveBenefits = receiveBenefits;
        }

        public int GetPageViewsCount()
        {
            return PageViewsCount;
        }

        //public bool FilterBySubFolder(string subfolder)
        //{
        //    return VisitsBySubfolder.Where(x=> x == subfolder).Any();
        //}

        //public bool FilterPageViewsByDesigner(string key, int min)
        //{
        //    PageViewsByDesigner.TryGetValue(key , out int value);

        //    return value > 0 ? value >= min : false;
        //}

        //public int GetPageViewsByDesigner(string key)
        //{
        //    PageViewsByDesigner.TryGetValue(key, out int value);

        //    return value;
        //}
    }
}
