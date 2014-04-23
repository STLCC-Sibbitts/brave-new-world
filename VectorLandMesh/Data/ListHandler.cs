using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace VectorLandMesh.Data
{
    class ListHandler<Type>
    {

        static public Type getFromTrimedIndex(List<Type> list,int index)
        {
            return ((index >= list.Count-1) ? list[list.Count - 1] : list[index]);
        }

        internal static Type getNullIfOutOfRange(List<Type> list, int index)
        {
            Type indent = default(Type);
            if (list != null & list.Count > 0)
            {
                indent = list[index];
            }
            return indent;
        }
    }
}
