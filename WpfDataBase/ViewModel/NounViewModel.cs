using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public sealed class NounViewModel
    {
        public int ID { get; set; }
        public Articles Article { get; set; }
        public string Word { get; set; }
        public string Plural { get; set; }
        public string Expression { get; set; }
    }
}
