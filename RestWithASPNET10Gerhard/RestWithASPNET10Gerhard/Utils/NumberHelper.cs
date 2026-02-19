namespace RestWithASPNET10Gerhard.Utils;

public class NumberHelper
{
    public static decimal ConvertToDecimal(string strNumber)
    {

        if (decimal.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out decimal decimalValue)
            )
        {
            return decimalValue;
        }

        return 0;
    }

    public static bool IsNumeric(string strNumber)
    {

        bool isNumber = decimal.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out decimal decimalValue
            );

        return isNumber;
    }
}
