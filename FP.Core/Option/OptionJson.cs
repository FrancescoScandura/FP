using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using static FP.Core.Option.Prelude;

namespace FP.Core.Option;

public class OptionJson
{
    public class OptionConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert.IsGenericType &&
               typeToConvert.GetGenericTypeDefinition() == typeof(Option<>);

        public override JsonConverter? CreateConverter
            (Type type, JsonSerializerOptions options)
            => Activator.CreateInstance(
                typeof(OptionConverterInner<>)
                    .MakeGenericType([type.GetGenericArguments()[0]]),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options],
                culture: null) as JsonConverter;
    }
    
    private class OptionConverterInner<T>(JsonSerializerOptions options) : JsonConverter<Option<T>>
    {
        private readonly JsonConverter<T> _valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
        private readonly Type _valueType = typeof(T);

        public override bool HandleNull => true;

        public override Option<T> Read
            (ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.TokenType == JsonTokenType.Null
                ? None
                : Some(_valueConverter.Read(ref reader, _valueType, options)
                       ?? throw new InvalidOperationException($"Cannot deserialize '{typeof(T)}'"));

        public override void Write
            (Utf8JsonWriter writer, Option<T> value, JsonSerializerOptions options)
            => value.Match(
                writer.WriteNullValue,
                (v) => _valueConverter.Write(writer, v, options));
    }
}