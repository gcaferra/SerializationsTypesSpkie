using System;

namespace SerializationScenarios
{
    public class TestClass
    {
        public TestClass()
        {
            TestString = String.Empty;
        }
        public string TestString { get; set; }
        public int TestNumber { get; set; }
    }
}