namespace Classbook.App.Components.Utitlity
{
    using System.Globalization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Forms;

    public class CustomInputSelect<TValue> : InputSelect<TValue>
    {
        protected override bool TryParseValueFromString(string value,
        out TValue result, out string errorMessage)
        {
            var success = BindConverter.TryConvertTo<TValue>(
                value, CultureInfo.CurrentCulture, out var parsedValue);
            if (success)
            {
                result = parsedValue;
                errorMessage = null;

                return true;
            }
            else
            {
                result = default;
                errorMessage = $"Въведените данни в полето са невалидни.";

                return false;
            }
        }
    }
}

