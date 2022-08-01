namespace Stable.Business.Concrete.Constants
{
    public static class ExceptionMessage
    {
        public const string UserAlreadyRegistered = "Bu email adresine sahip kullanıcı sistemde zaten kayıtlıdır.";
        public const string UserNotRegistered = "Bu email adresine sahip kullanıcı sistemde kayıtlı değildir.";
        public const string AccountTypeNotFound = "Tipinde bir hesabınız bulunmamaktadır.";
        public const string AccountInformationNotVisible = "Hesap bilgileriniz görüntülenememektedir.";
        public const string InsufficientBalance = "Bakiyeniz yetersizdir.";
        public const string AccountCreatedSuccessfully = "hesabınız başarıyla oluşturulmuştur.";


        public static string AccountNotFound = "Seçilen hesap türünde hesabınız bulunmadığından ötürü hesap işlemleriniz görüntülenememektedir." +
                                               "İşleminize devam etmek istiyorsanız, lütfen mevcut hesabınızı seçiniz.";
        public static string AccountTypeAlreadyExists =
            "Oluşturmak istediğiniz hesap türünde hesabınız sistemimizde bulunmaktadır. İşleminize devam etmek istiyorsanız, lütfen başka bir hesap türü seçiniz.";

    }
}
