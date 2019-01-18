using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleExpressionEvaluatorTest
{


    public class RuleEngineExtensions
    {
        //public bool IntAn1y(T obj, string filter)
        //{
        //    return true;
        //    List<string> list = (List<string>)obj.GetType().GetProperty("UserAggregation").GetValue(obj, null);

        //    return list.Where(x => x.Equals(filter)).Any();
        //}

        //public bool FilterBySubFolder(string subfolder)
        //{
        //    return VisitsBySubfolder.Where(x => x == subfolder).Any();
        //}

        //public bool FilterPageViewsByDesigner(string key, int min)
        //{
        //    PageViewsByDesigner.TryGetValue(key, out int value);

        //    return value > 0 ? value >= min : false;
        //}

        //public int GetPageViewsByDesigner(string key)
        //{
        //    PageViewsByDesigner.TryGetValue(key, out int value);

        //    return value;
        //}

        //---------------------------------------

        public bool IntAny<T>(IList<T> list, T filter)
        {
            return list.Where(x => x.Equals(filter)).Any();
        }

        public V GetPageViewsByDesigner<K, V>(IDictionary<K, V> dic, K key)
        {
            dic.TryGetValue(key, out V value);

            return value;
        }

        public bool FilterPageViewsByDesigner1<K>(IDictionary<K, int> dic, K key, int value)
        {
            dic.TryGetValue(key, out int outValue);

            return outValue > 0 ? outValue >= value : false;
        }
    }
}
