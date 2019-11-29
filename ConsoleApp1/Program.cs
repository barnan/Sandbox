using System;

namespace ConsoleApp1
{

    // todo isassignable from partial interface?


    class Program
    {
        static void Main(string[] args)
        {
            // IRepository<IRepositoryContent1>
            Console.WriteLine($"reference: {typeof(IRepository<IReferenceSample>).IsAssignableFrom(typeof(ReferenceRepository))}");
            Console.WriteLine($"specification: {typeof(IRepository<IToolSpecification>).IsAssignableFrom(typeof(SpecificationRepository))}");

            ReferenceRepository repoRef = new ReferenceRepository();
            Console.WriteLine($"reference: {repoRef is IRepository<IReferenceSample>}");


            SpecificationRepository specRef = new SpecificationRepository();
            Console.WriteLine($"spec: {specRef is IRepository<IToolSpecification>}");
            IRepository<IToolSpecification> iSpecRef = specRef;


            string valami = null;


            valami += "contnt";

            Console.WriteLine(valami);

            Console.ReadKey();
        }
    }



    interface INamed
    {
        string Name { get; }
    }

    //interface INamed2
    //{
    //    string Name2 { get; }
    //}

    interface IToolSpecification : INamed, IComparable<IToolSpecification>
    { }

    class ToolSpecification : IToolSpecification
    {
        public string Name { get; }

        public int CompareTo(IToolSpecification other)
        {
            throw new NotImplementedException();
        }
    }

    interface IReferenceSample : INamed, IComparable<IReferenceSample>
    { }

    class ReferenceSample : IReferenceSample
    {
        public string Name { get; }

        public int CompareTo(IReferenceSample other)
        {
            throw new NotImplementedException();
        }
    }

    interface IRepository<T>
        where T : INamed
    {
        bool Read();
    }

    class Repository<T> : IRepository<T>
        where T : INamed
    {
        public virtual bool Read()
        {
            return true;
        }
    }


    class SpecificationRepository : Repository<IToolSpecification>
    {
        public override bool Read()
        {
            return true;
        }
    }


    class ReferenceRepository : Repository<IReferenceSample>
    {
        public override bool Read()
        {
            return true;
        }
    }



}
