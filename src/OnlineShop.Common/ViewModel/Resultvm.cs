using OnlineShop.Common.Enums;
using System;

namespace OnlineShop.Common.ViewModel
{
    public class Resultvm
    {
        public Guid RetrunId { get; set; }
        public string Message { get; set; }
        public bool Valid { get; set; }
    }

    public class UpdateStatusvm : Resultvm
    {
        public UpdateStatus UpdateStatus { get; set; }
    }

    public class CreateStatusvm : Resultvm
    {
        public CreateStatus CreateStatus { get; set; }
    }

    public class DeleteStatusvm : Resultvm
    {
        public DeleteStatus DeleteStatus { get; set; }
    }
}