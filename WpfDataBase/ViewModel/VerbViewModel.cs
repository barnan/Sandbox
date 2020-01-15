using System;
using WpfDataBase.BaseClasses;

namespace WpfDataBase.ViewMod
{
    public sealed class VerbViewModel
    {
        public int ID { get; set; }
        public string Present { get; set; }
        public string PresentE3 { get; set; }
        public string SimplePast { get; set; }
        public AuxiliaryVerbs[] AvailableAuxiliaryVerbs => (AuxiliaryVerbs[])Enum.GetValues(typeof(AuxiliaryVerbs));
        public AuxiliaryVerbs AuxVerb { get; set; } = AuxiliaryVerbs.hat;
        public string Perfect { get; set; }
        public string Expression { get; set; }

    }
}
