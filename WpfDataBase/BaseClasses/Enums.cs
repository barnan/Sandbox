using System.ComponentModel;

namespace WpfDataBase.BaseClasses
{

    public enum Parts
    {
        Verb = 1,
        Noun = 2,
        Adjective = 4
    }


    public enum AuxiliaryVerbs
    {
        [Description("")]
        None = 0,

        [Description("hat")]
        h = 1,

        [Description("ist")]
        i = 2,
    }


    public enum Articles
    {
        [Description("")]
        None = 0,

        [Description("der")]
        der = 1,

        [Description("die")]
        die = 2,

        [Description("das")]
        das = 4
    }


}
