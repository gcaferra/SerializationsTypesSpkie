namespace SerializationScenarios
{
    public interface IFooService
    {
        public int UseTestClass(TestClass testClass);
        
        public int UseGeneric<T>(T testClass);
    }

    class FooService : IFooService
    {
        public int UseTestClass(TestClass testClass)
        {
            return 0;
        }

        public int UseGeneric<T>(T testClass)
        {
            return 0;
        }
    }
}