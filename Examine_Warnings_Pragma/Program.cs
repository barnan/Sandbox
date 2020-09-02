#define MANCIKA


namespace Examine_Warnings_Pragma
{
    class Program
    {
        static void Main(string[] args)
        {



#if (MANCIKA && NET40)


#pragma warning disable 1030

#warning 6000 MANCIKA is defined

#pragma warning restore

#warning 6000 MANCIKA is defined

#endif


            //#error this code sucks


        }
    }
}
