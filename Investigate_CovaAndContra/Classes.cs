namespace Investigate_CovaAndContra
{
    class ClassBase : IInterfaceBase
    {
        public string Prop01 { get; set; }
    }

    class ClasseDerived1 : ClassBase, IInterfaceDerived1
    {
        public string Prop02 { get; set; }
    }

    class ClasseDerived2 : ClasseDerived1, IInterfaceDerived2
    {
        public string Prop03 { get; set; }
    }


    class ClassGeneric1 : IGenericInterface1<IInterfaceDerived1, IInterfaceDerived1>
    {
    }


    class ClassGeneric2 : IGenericInterface2<IInterfaceDerived1, IInterfaceDerived1>
    {
    }


}
