using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHelperLIB.Services
{
    public static class ExtensionService
    {
        #region "String"
        public static string ToMessage(this Exception ex, bool stackTrace = false)
        {
            string message = ex.Message;
            try
            {
                if (ex.InnerException != null)
                {
                    message += ", [Internal : " + ex.InnerException.Message + "]";
                }
                if (ex.StackTrace != null && stackTrace)
                {
                    message += ", [StackTrace : " + ex.StackTrace + "]";
                }
            }
            catch { Console.WriteLine("Extension ToMessage is failed"); }
            return message;
        }

        public static string ToText(this object? text)
        {
            string message = "";
            try
            {
                if (text == null)
                {
                    message = "";
                }
                else
                {
                    message = (string)text;
                    message = message.Trim();
                }
            }
            catch { Console.WriteLine("Extension ToText is failed"); }
            return message;
        }

        public static string ToDateString(this DateTime dateTime, string culture = "th", string format = "dd/MM/yyyy")
        {
            DateTime currentDate = dateTime;

            if (culture == "th")
            {
                // B.E. (Buddhist calendar)
                CultureInfo beCulture = new CultureInfo("th-TH");
                beCulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();
                string beDateString = currentDate.ToString(format, beCulture);

                return beDateString;
            }
            else
            {
                // A.D. (Gregorian calendar)
                CultureInfo adCulture = new CultureInfo("en-US");
                string adDateString = currentDate.ToString(format, adCulture);

                return adDateString;
            }
        }

        public static string ConvertStringToFormattedDouble(string input, int decimalPlaces)
        {
            double value;
            if (double.TryParse(input, out value))
            {
                string formattedValue = value.ToString("N" + decimalPlaces);
                return formattedValue;
            }
            else
            {
                Console.WriteLine("Invalid input");
                return "0.00";
            }
        }

        public static int ToNumberic(this string text)
        {
            try
            {
                return int.Parse(text);
            }
            catch (Exception)
            {
                throw new ValidationException($"Extension ToNumberic is failed. [{text}]");
            }
        }

        private static double ToDouble(this string text, int digit = 2, string mode = "down")
        {
            double value;
            if (double.TryParse(text, out value))
            {
                if (mode == "up")
                {
                    double roundedValue = Math.Round(value, digit, MidpointRounding.AwayFromZero);
                    return roundedValue;
                }
                else
                {
                    double roundedValue = Math.Round(value, digit);
                    return roundedValue;
                }
            }
            else
            {
                throw new ValidationException($"Extension ToDouble is failed. [{text}]");
            }
        }

        public static void TrimProperties(this object model)
        {
            try
            {
                var stringProperties = model.GetType().GetProperties()
                    .Where(p => p.PropertyType == typeof(string));

                foreach (var prop in stringProperties)
                {
                    try
                    {
                        var value = prop.GetValue(model) as string;
                        if (value != null)
                        {
                            prop.SetValue(model, value.Trim());
                        }
                    }
                    catch { Console.WriteLine($"Extension TrimProperties is failed. [{prop}]"); }
                }
            }
            catch { Console.WriteLine("Extension TrimProperties is failed."); }
        }
        #endregion

        #region "Object"
        public static T ToMyModel<T>(this string value)
        {
            try
            {
                var result = JsonSerializer.Deserialize<T>(value);
                if (result == null)
                {
                    throw new ValidationException("Result is null");
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ToServiceModel : {value}");
                throw new ValidationException($"Failed convert string to service result model because {ex.Message}");
            }
        }
        #endregion
    }
}
