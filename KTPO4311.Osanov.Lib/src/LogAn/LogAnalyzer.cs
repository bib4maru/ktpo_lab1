using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Osanov.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }
        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("имя файла должно быть задано");
            }
            if (!fileName.EndsWith(".OKG",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            WasLastFileNameValid=true;
            return true;
        }
    }
}
