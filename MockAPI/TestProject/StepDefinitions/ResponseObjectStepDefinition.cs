using System.Text;
using Newtonsoft.Json.Linq;
using Infrastructure.Entities;
using Assert = Xunit.Assert;

namespace TestProject.StepDefinitions
{
    [Binding]
    public class DictionaryFeatureSteps
    {
        private ResponseObject _responseObject = new ResponseObject();
        private CustomObject _customObject;
        private ResponseObjectDto _responseObjectDto;
        
        public DictionaryFeatureSteps()
        {
            _responseObject.Data = Encoding.UTF8.GetBytes("{}");
            _responseObjectDto = new ResponseObjectDto(_responseObject);
        }
        
        // ------------------------- Add Elements To Dictionary -------------------------
        
        private Dictionary<string, CustomObject> _dictionary;
        private string _parent;
        private JToken? _jToken;
        
        [Given(@"The current dictionary has (\d+) elements in it")]
        public void GivenTheCurrentDictionaryHasElementsInIt(int elementCount)
        {
            _dictionary = new Dictionary<string, CustomObject>();
            for (int i = 0; i < elementCount; i++)
            {
                _dictionary.Add($"Key{i}", new CustomObject(i));
            }
        }

        [Given(@"The String parent is empty")]
        public void GivenTheStringParentIsEmpty()
        {
            _parent = string.Empty;
        }

        [Given(@"The String parent is filled")]
        public void GivenTheStringParentIsFilled()
        {
            _parent = "ParentValue";
        }

        [When(@"I give an Valid JToken")]
        public void WhenIGiveAnValidJToken()
        {
            _jToken = JToken.FromObject(new CustomObject(1));
        }

        [When(@"I give an Invalid JToken")]
        public void WhenIGiveAnInvalidJToken()
        {
            _jToken = null;
        }
        
        [When(@"I give an Empty JToken")]
        public void WhenIGiveAnEmptyJToken()
        {
            _jToken = JToken.Parse("null");
        }

        [Then(@"The JToken should be added to the dictionary")]
        public void ThenTheJTokenShouldBeAddedToTheDictionary()
        {
            _responseObject.AddElementsToDictionary(_jToken, _dictionary, _parent);
            var prop = _jToken.ToObject<JObject>()!.Properties().First().Name;
            Assert.Contains(prop, _dictionary);
        }
        
        [Then(@"The empty JToken should be added to the dictionary")]
        public void ThenTheEmptyJTokenShouldBeAddedToTheDictionary()
        {
            _responseObject.AddElementsToDictionary(_jToken, _dictionary, _parent);
            Assert.Contains(_parent, _dictionary);
        }

        [Then(@"It should throw an error")]
        public void ThenItShouldThrowAnError()
        {
            Assert.Throws<NullReferenceException>(() => _responseObject.AddElementsToDictionary(_jToken, _dictionary, _parent));
        }

        // ------------------------- Get Typed Value -------------------------
        
        private object _value;

        [Given(@"The value is of a string")]
        public void GivenTheValueIsOfAString()
        {
            _value = "TestString";
        }

        [Given(@"The value is of a User")]
        public void GivenTheValueIsOfAUser()
        {
            _value = new { Name = "John", Age = 30 };
        }

        [Given(@"The value is of a Int")]
        public void GivenTheValueIsOfAInt()
        {
            _value = 42;
        }

        [Then(@"It should return String as a type")]
        public void ThenItShouldReturnStringAsAType()
        {
            _customObject = new CustomObject(_value);
            Object TypedValue = _customObject.GetTypedValue();
            Assert.Equal(_value, TypedValue);
        }

        [Then(@"It should return User as a type")]
        public void ThenItShouldReturnUserAsAType()
        {
            _customObject = new CustomObject(_value);
            Object TypedValue = _customObject.GetTypedValue();
            Assert.Equal(_value, TypedValue);
        }

        [Then(@"It should return Int as a type")]
        public void ThenItShouldReturnIntAsAType()
        {
            _customObject = new CustomObject(_value);
            Object TypedValue = _customObject.GetTypedValue();
            Assert.Equal(_value, TypedValue);
        }

        // ------------------------- Add Element to JObject -------------------------

        /*private JObject _jObject;
        private string _path;
        
        [Given(@"The JObject is empty")]
        public void GivenTheJObjectIsEmpty()
        {
            _jObject = new JObject();
        }

        [Given(@"The JObject is nested")]
        public void GivenTheJObjectIsNested()
        {
            _jObject = new JObject { ["Nested"] = new JObject() };
        }

        [Given(@"The Path is empty")]
        public void GivenThePathIsEmpty()
        {
            _path = string.Empty;
        }

        [Given(@"The Path is not empty")]
        public void GivenThePathIsNotEmpty()
        {
            _path = "Nested.Path";
        }

        [When(@"I give a int ObjectValue")]
        public void WhenIGiveAIntObjectValue()
        {
            if (string.IsNullOrEmpty(_path)) return;
            _jObject[_path] = 42;
        }

        [When(@"I give a Null ObjectValue")]
        public void WhenIGiveANullObjectValue()
        {
            _jObject[_path ?? "nullValue"] = null;
        }

        [When(@"I give a string ObjectValue")]
        public void WhenIGiveAStringObjectValue()
        {
            _jObject[_path] = "TestString";
        }

        [Then(@"It should do nothing")]
        public void ThenItShouldDoNothing()
        {
            _responseObjectDto.Add
        }

        [Then(@"It should add null to JObject")]
        public void ThenItShouldAddNullToJObject()
        {
            Assert.IsTrue(_jObject.ContainsKey("nullValue"));
        }

        [Then(@"It should add string to JObject")]
        public void ThenItShouldAddStringToJObject()
        {
            Assert.AreEqual("TestString", _jObject.SelectToken(_path).ToString());
        }*/

        // ------------------------- Deserialize Data -------------------------

        /*[Given(@"The ByteArray is encoded wrong")]
        public void GivenTheByteArrayIsEncodedWrong()
        {
            _byteArray = new byte[] { 0xFF, 0x00 }; // Invalid UTF-8 encoding
        }

        [Given(@"The ByteArray is encoded correct")]
        public void GivenTheByteArrayIsEncodedCorrect()
        {
            _byteArray = System.Text.Encoding.UTF8.GetBytes("{}");
        }

        [Then(@"Gives an empty dictionary")]
        public void ThenGivesAnEmptyDictionary()
        {
            var result = JObject.Parse(System.Text.Encoding.UTF8.GetString(_byteArray));
            Assert.IsEmpty(result);
        }

        [Then(@"Throw an error")]
        public void ThenThrowAnError()
        {
            Assert.Throws<Exception>(() => JObject.Parse(System.Text.Encoding.UTF8.GetString(_byteArray)));
        }

        [Then(@"Gives an filled dictionary")]
        public void ThenGivesAnFilledDictionary()
        {
            var result = JObject.Parse(System.Text.Encoding.UTF8.GetString(_byteArray));
            Assert.IsNotEmpty(result);
        }

        // ------------------------- From Json -------------------------

        [Given(@"The Json is structered correct")]
        public void GivenTheJsonIsStructuredCorrect()
        {
            _value = "{\"key\":\"value\"}";
        }

        [Given(@"The Json is not structered correct")]
        public void GivenTheJsonIsNotStructuredCorrect()
        {
            _value = "{invalidJson}";
        }

        [Then(@"It gives a dictionary")]
        public void ThenItGivesADictionary()
        {
            var result = JObject.Parse((string)_value);
            Assert.IsNotEmpty(result);
        }

        [Then(@"It gives an empty dictionary")]
        public void ThenItGivesAnEmptyDictionary()
        {
            var result = JObject.Parse((string)_value);
            Assert.IsEmpty(result);
        }*/
        
        // ------------------------- Convert Dictionary To JObject -------------------------
        
        [Given(@"The Dictionary is empty")]
        public void GivenTheDictionaryIsEmpty()
        {
            _dictionary = new Dictionary<string, CustomObject>();
        }
        
        [Given(@"The Dictionary is filled")]
        public void GivenTheDictionaryIsFilled()
        {
            _dictionary = new Dictionary<string, CustomObject>
            {
                { "Key1", new CustomObject(1) },
                { "Key2", new CustomObject(2) }
            };
        }
        
        [Then(@"Gives a empty JObject")]
        public void ThenItShouldReturnAnEmptyJObject()
        {
            _responseObjectDto.Data = _dictionary;
            var result = _responseObjectDto.ToJson();
            Assert.Equal("{}", result);
        }
        
        [Then(@"Gives a filled JObject")]
        public void ThenItShouldReturnAFilledJObject()
        {
            _responseObjectDto.Data = _dictionary;
            var result = _responseObjectDto.ToJson();
            
            var expectedJson = JObject.Parse(@"{""Key1"":1,""Key2"":2}");
            var actualJson = JObject.Parse(result);
            
            Assert.True(JToken.DeepEquals(expectedJson, actualJson), "The Jsons are not equal");
        }
    }
}