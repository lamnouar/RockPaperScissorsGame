namespace RockPaperScissorsGame.Helpers
{
    public static class EnumHelper
    {
        public static T GetValue<T>(int value)
        {
            var enumType = typeof(T);
            var enumValues = enumType.GetEnumValues();

            return (T)enumValues.GetValue(value);
        }
    }
}
