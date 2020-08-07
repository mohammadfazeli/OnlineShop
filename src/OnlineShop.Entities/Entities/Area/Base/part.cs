namespace OnlineShop.Entities.Entities.Area.Base
{
    public class Part : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ForeignName { get; set; }
        public string PartNumber { get; set; }
        public string OperationCode { get; set; }

    }
}