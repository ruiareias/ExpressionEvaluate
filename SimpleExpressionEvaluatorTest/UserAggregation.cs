using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleExpressionEvaluatorTest
{
    public class UserAggregation
    {
        public bool HasPurchased { get; set; }

        public int Visits { get; set; }

        public List<KeyValue> VisitsBySubfolder { get; set; }

        public bool HasPromocodeAvailable { get; set; }

        public int PageViewsCount { get; set; }

        public List<KeyValue> PageViewsByDesigner { get; set; }

        public List<KeyValue> PageViewsByType { get; set; }

        public bool Returning { get; set; }

        public List<KeyValue> Channel { get; set; }

        public DateTime LastKnownVisit { get; set; }

        public List<KeyValue> VisitsByDesigner { get; set; }

        public bool HasWishListProducts { get; set; }

        public bool HasMultipleAddresses { get; set; }

        public string SpendLevel { get; set; }

        public string AccessTier { get; set; }

        //other - test
        public bool ReceiveBenefits { get; set; }

        public void SetCanReceiveBenefits(bool receiveBenefits)
        {
            ReceiveBenefits = receiveBenefits;
        }
    }

    public class KeyValue
    {
        public string key { get; set; }

        public int value { get; set; }
    }
}
