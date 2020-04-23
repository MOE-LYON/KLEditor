using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KLEditor.Interface
{
    public interface IReplaceable
    {
        bool ReplaceOne(String pattern, string replacemet,RegexOptions optons);

        int ReplaceAll(String pattern, string replacemet, RegexOptions optons);
    }
}
