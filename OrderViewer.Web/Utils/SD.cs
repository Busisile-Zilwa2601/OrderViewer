namespace OrderViewer.Web.Utils
{
    public class SD
    {
        public static string OrderAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            PATCH,
            DELETE
        }
    }
}
