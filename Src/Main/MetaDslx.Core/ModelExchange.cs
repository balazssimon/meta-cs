using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaDslx.Core
{
    public enum ModelExchangeFormat
    {
        Xmi,
        Json
    }

    public class ModelExchange
    {
        public static void SaveToFile(string fileName, Model model, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(ModelExchange.SaveToString(model, format));
            }
        }

        public static Model LoadFromFile(string fileName, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string text = reader.ReadToEnd();
                return ModelExchange.LoadFromString(text, format);
            }
        }

        public static string SaveToString(Model model, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            switch (format)
            {
                case ModelExchangeFormat.Xmi:
                    return ModelExchange.ToXmi(model);
                case ModelExchangeFormat.Json:
                    return ModelExchange.ToJson(model);
                default:
                    return string.Empty;
            }
        }

        public static Model LoadFromString(string text, ModelExchangeFormat format = ModelExchangeFormat.Xmi)
        {
            switch (format)
            {
                case ModelExchangeFormat.Xmi:
                    return ModelExchange.FromXmi(text);
                case ModelExchangeFormat.Json:
                    return ModelExchange.FromJson(text);
                default:
                    return null;
            }
        }

        public static string ToXmi(Model model)
        {
            return string.Empty;
        }

        public static string ToJson(Model model)
        {
            return string.Empty;
        }

        public static Model FromXmi(string text)
        {
            return null;
        }

        public static Model FromJson(string text)
        {
            return null;
        }

    }
}
