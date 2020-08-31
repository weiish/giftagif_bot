using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifBotManager
{
    public class BaseProgressReportModel
    {
        public string MainTask { get; set; }
        public int PercentageComplete { get; set; } = 0;
        public string CurrentTask { get; set; }
        public bool CanCancel { get; set; } = true;
        public string SpecialInfo { get; set; }
    }
}
