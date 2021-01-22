namespace OnlineShop.ViewModels.Base
{
    public class ValidationResultvm
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public string AppendMessage(string message)
        {
            return this.Message += string.IsNullOrEmpty(this.Message) ? message : "</br>" + message;
        }
    }
}