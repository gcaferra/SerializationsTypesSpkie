using System;
using System.Text.Json;
using Shouldly;
using Xunit;

namespace SerializationScenarios
{
    public class SerializationScenario
    {
        [Fact]
        void Can_serialize_specified_string_Type()
        {
            string stringType = typeof(TestClass).FullName ?? throw new InvalidOperationException();
            var type = Type.GetType(stringType);

            var jsonString = GetTestObjectString();

            var actual = JsonSerializer.Deserialize(jsonString, type);

            actual.ShouldBeOfType(typeof(TestClass));
        }        
        
        [Fact]
        void serialized_Type_can_be_used_as_parameter_to_a_function()
        {
            string stringType = typeof(TestClass).FullName ?? throw new InvalidOperationException();
            var type = Type.GetType(stringType);
            var jsonString = GetTestObjectString();

            IFooService component = new FooService();

            dynamic actual = JsonSerializer.Deserialize(jsonString, type);
            
            var result = component.UseTestClass(actual);
            
            Assert.True(result == 0);
            
        }
        
        [Fact]
        void serialized_Type_can_be_used_as_parameter_to_a_generic_function()
        {
            string stringType = typeof(TestClass).FullName ?? throw new InvalidOperationException();
            var type = Type.GetType(stringType);
            var jsonString = GetTestObjectString();

            IFooService component = new FooService();

            dynamic actual = JsonSerializer.Deserialize(jsonString, type);
            
            var result = component.UseGeneric(actual);
            
            Assert.True(result == 0);
            
        }

        string GetTestObjectString()
        {
            var entity = new TestClass() {TestNumber = 1, TestString = "Test String"};
            return JsonSerializer.Serialize(entity);
        }
        
    }
}