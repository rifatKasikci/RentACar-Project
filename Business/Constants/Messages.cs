using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarAdded = "Araba eklendi";
        public static string CarNameIsInvalid= "Araba ismi eklenemedi";
        public static string CarListed = "Arabalar listelendi";
        public static string CarNotReturned = "Araba geri teslim edilmedi";
        public static string ImageAdded = "Resim yüklendi";
        public static string CarImageAdded = "Araba resmi yüklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string TokenCreated = "Token oluşturuldu";
        public static string UserAlreadyRegistered = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordIsUncorrect = "Parola yanlış";
        public static string LoginSuccessful = "Giriş başarılı";
        public static string CreditCardAdded = "Kredi kartı eklendi";
        public static string CreditCardDeleted = "Kredi kartı silindi";
        public static string CreditCardUpdated = "Kredi kartı güncellendi";
        public static string PaymentAdded = "Ödeme alındı";
        internal static string CreditCardIsIncorrect;
        public static string InsufficientBalance = "Yetersiz bakiye";
        public static string CarHired = "Araba kiralandı";
    }
}
