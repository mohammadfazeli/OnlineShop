using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Common.Enums
{
    public enum CreateStatus
    {
        Successfully,
        Fail,
        Exists,
    }

    public enum UpdateStatus
    {
        Successfully,
        Fail,
        NotExists,
    }

    public enum DeleteStatus
    {
        Successfully,
        Fail,
        NotExists,
        Dependent
    }

    public enum Message
    {
        Successfully,
        Fail,
        NotExists,
        Exists,
        Dependent
    }

    public enum MenuGroupEnum
    {
        BasicInfo,
        Warehouse,
        Managment
    }

    public enum IconType
    {
        UiKit,
        BootStrap,
        FontAwesome5,
        FontAwesome4,
        SVG
    }

    public enum AttachmentType
    {
        Image,
        File,
    }

    public enum CardHeaderTye
    {
        Index,
        Create,
        Edit,
        Search,
        All
    }

    public enum AddCardItemType
    {
        link,
        Form
    }

    public enum SpecificationType
    {
        TextBox,
        CheckBox,
        TextArea,
    }

    public enum ItemSectionType
    {
        [Display(Name = "تصادفی")]
        Random,

        [Display(Name = "پیشنهادی")]
        Suggested,
    }
}