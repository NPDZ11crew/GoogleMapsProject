namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class SearchTextModel
    {
        public string textQuery { get; set; } = string.Empty;
        public SearchTextModel(string text)
        {
            textQuery = text;
        }
        public SearchTextModel()
        {

        }


        public static SearchTextModel GetRequestBody(string text)
        {
            var requestBody = new SearchTextModel()
            {
                textQuery = text
            };
            return requestBody;
        }
    }
}
