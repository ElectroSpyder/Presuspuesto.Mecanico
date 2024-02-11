namespace Taller.Mecanico.Persistence.Common
{
    public static class ReaderHelper
    {
        public static T ConvertFromReader<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default; // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
    }
}
