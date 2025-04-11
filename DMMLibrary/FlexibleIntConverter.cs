using System.Text.Json;
using System.Text.Json.Serialization;

namespace DMMLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class FlexibleIntConverter : JsonConverter<int>
    {
        public override int Read ( ref Utf8JsonReader reader , Type typeToConvert , JsonSerializerOptions options )
        {
            return reader.TokenType switch
            {
                JsonTokenType.String => int.Parse ( reader.GetString ()! ),
                JsonTokenType.Number => reader.GetInt32 (),
                _ => throw new JsonException ( $"Unexpected token parsing int. Token: {reader.TokenType}" )
            };
        }

        public override void Write ( Utf8JsonWriter writer , int value , JsonSerializerOptions options )
        {
            writer.WriteNumberValue ( value ); // 普通に数値で書き出す
        }
    }
}
