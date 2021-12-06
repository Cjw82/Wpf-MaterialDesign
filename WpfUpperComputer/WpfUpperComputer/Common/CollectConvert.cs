using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUpperComputer.Common
{
    public class CollectConvert<T>
    {
        private static List<T> ConvertToList(ObservableCollection<T> collection)
        {
            List<T> ts;
            if (collection != null)
            {
                ts = new List<T>(collection.Count);
                for (int i = 0; i < collection.Count; i++)
                {
                    ts.Add(collection[i]);
                }
            }
            else {
                ts = null;
            }
            return ts;
        }
        private static ObservableCollection<T> ConvertToObserableCollect(List<T> list)
        {
            ObservableCollection<T> ts = new ObservableCollection<T>();
            if (list!=null)
            {
                list.ForEach(p => ts.Add(p));
            }
            return ts;
        }
    }
}
