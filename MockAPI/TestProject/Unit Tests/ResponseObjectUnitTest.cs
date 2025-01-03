using Infrastructure.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assert = Xunit.Assert;

namespace TestProject.Unit_Tests
{
    public class ResponseObjectUnitTest
    {
        
        [Fact]
        public void AddResponseObjectAsync_Adds_OneElement_To_Dictionary()
        {
            // Arrange
            var responseObject = new ResponseObject();
            var data = new Dictionary<string, CustomObject>();
            var json = JsonConvert.SerializeObject(new { test = "test" });
            
            // Act
            responseObject.AddElementsToDictionary(json, data, "test");
            
            // Assert
            Assert.Contains("test", data.Keys);
            Assert.Equal("{\"test\":\"test\"}", data["test"].Value);
        }
        
        [Fact]
        public void AddResponseObjectAsync_WhenJsonHasArray_AddsElementsToDictionary()
        {
            // Arrange
            var responseObject = new ResponseObject();
            var data = new Dictionary<string, CustomObject>();
            var json = JsonConvert.SerializeObject(new
            {
                items = new[] { "item1", "item2", "item3" }
            });

            // Act
            responseObject.AddElementsToDictionary(json, data, "items");

            // Assert
            Assert.Contains("items", data.Keys);
            Assert.Equal("{\"items\":[\"item1\",\"item2\",\"item3\"]}", data["items"].Value);
        }
        
        [Fact]
        public void ToJson_WhenDictionaryIsEmpty_ReturnsEmptyJsonObject()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;
            
            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>();
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{}", json);
        }
        
        [Fact]
        public void ToJson_WhenPathHasSingleLevel_AddsPropertyToJson()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;
            
            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>
            {
                { "key", new CustomObject { Value = "value" } }
            };
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{\r\n  \"key\": \"value\"\r\n}", json);
        }
        
        [Fact]
        public void ToJson_WhenPathHasNestedLevels_CreatesNestedJsonObject()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;

            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>
            {
                { "level1.level2", new CustomObject { Value = "value" } }
            };
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{\"level1\":{\"level2\":\"value\"}}", json);
        }
        
        [Fact]
        public void ToJson_WhenPathContainsArray_AddsArrayToJson()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;

            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>
            {
                { "items[0]", new CustomObject { Value = "value1" } },
                { "items[1]", new CustomObject { Value = "value2" } }
            };
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{\"items\":[\"value1\",\"value2\"]}", json);
        }
        
        [Fact]
        public void ToJson_WhenPathCombinesArraysAndObjects_CreatesComplexStructure()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;

            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>
            {
                { "items[0].name", new CustomObject { Value = "item1" } },
                { "items[1].name", new CustomObject { Value = "item2" } }
            };
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{\"items\":[{\"name\":\"item1\"},{\"name\":\"item2\"}]}", json);
        }
        
        [Fact]
        public void ToJson_WhenArrayIndexIsSkipped_FillsMissingIndexes()
        {
            // Arrange
            Dictionary<string, CustomObject> data = new Dictionary<string, CustomObject>();
            for (int i = 0; i < 100; i++) 
            {
                data.Add(i.ToString(), new CustomObject(i));
            }
            var jsonData = JsonConvert.SerializeObject(data);
            var _byteArray = System.Text.Encoding.UTF8.GetBytes(jsonData);
            var responseObject = new ResponseObject();
            responseObject.Data = _byteArray;

            var responseObjectDto = new ResponseObjectDto(responseObject);
            responseObjectDto.Data = new Dictionary<string, CustomObject>
            {
                { "items[1]", new CustomObject { Value = "value2" } }
            };
        
            // Act
            var json = responseObjectDto.ToJson();
        
            // Assert
            Assert.Equal("{\"items\":[{},\"value2\"]}", json);
        }
    }
}
