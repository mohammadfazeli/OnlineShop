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
<<<<<<< HEAD
    }

    public enum AddCardItemType
    {
        link,
        Form
=======
>>>>>>> 61412acc67ab38b6674945c0f58f2656ed110af2
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