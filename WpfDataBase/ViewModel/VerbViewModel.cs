using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public sealed class VerbViewModel
    {
        public int ID { get; set; }
        public string Present { get; set; }
        public string PresentE3 { get; set; }
        public string SimplePast { get; set; }
        public AuxiliaryVerbs AuxVerb { get; set; }
        public string Perfect { get; set; }
        public string Expression { get; set; }

    }
}
