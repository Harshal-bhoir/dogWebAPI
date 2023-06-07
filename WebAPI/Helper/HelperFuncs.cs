using System;
using System.Text.Json;

namespace WebAPI.Helper
{
	public class HelperFuncs
	{
        private string jsonPath = "/Users/harshalb/Projects/JsonFiles/csvjson.json";

        public void serializeWrite(List<Dog> data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }

        public List<Dog> deserealizeRead()
        {
            string existString = System.IO.File.ReadAllText(@jsonPath);
            var existText = JsonSerializer.Deserialize<List<Dog>>(existString);

            return existText;
        }
    }
}

