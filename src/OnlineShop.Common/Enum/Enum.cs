namespace OnlineShop.Common.Enum
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
        FontAwesome4

    }

    public enum AttachmentType
    {
        Image,
        File,
    }

}

