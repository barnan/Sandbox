namespace Investigate_CovaAndContra
{
    interface IInterfaceBase
    {
        string Prop01 { get; set; }
    }

    interface IInterfaceDerived1 : IInterfaceBase
    {
        string Prop02 { get; set; }
    }

    interface IInterfaceDerived2 : IInterfaceDerived1
    {
        string Prop03 { get; set; }
    }



    interface IGenericInterface1<T, G>
    {
    }

    interface IGenericInterface2<in T, out G>
    {
    }

}
