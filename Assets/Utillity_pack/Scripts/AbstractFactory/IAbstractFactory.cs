namespace AbstractFactory
{
    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    public interface IAbstractProductA
    {
        public string FooA();
    }

    class ConcreteProductA1 : IAbstractProductA
    {
        public string FooA()
        {
            return "Result from the product A1";
        }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string FooA()
        {
            return "Result from the product A2";
        }
    }


    public interface IAbstractProductB
    {
        public string FooB();
        public string AnotherFooB(IAbstractProductA collaborator);
    }

    class ConcreteProductB1 : IAbstractProductB
    {
        public string FooB()
        {
            return "Result from the product B1";
        }

        public string AnotherFooB(IAbstractProductA collaborator)
        {
            var result = collaborator.FooA();
            return $"The result of B1 in collaboration with ({result})";
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string FooB()
        {
            return "Result from the product B2";
        }

        public string AnotherFooB(IAbstractProductA collaborator)
        {
            var result = collaborator.FooA();
            return $"The result of B2 in collaboration with ({result})";
        }
    }
}