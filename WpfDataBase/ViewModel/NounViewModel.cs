using System;
using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public sealed class NounViewModel
    {
        public int ID { get; set; }
        public Articles Article { get; set; }
        public Articles[] AvailableArticles { get; set; } = (Articles[])Enum.GetValues(typeof(Articles));
        public string Word { get; set; }
        public string Plural { get; set; }
        public string Expression { get; set; }
    }
}
