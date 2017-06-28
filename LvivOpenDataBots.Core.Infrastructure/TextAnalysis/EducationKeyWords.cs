using System.Collections.Generic;

namespace LvivOpenDataBots.Core.Infrastructure.TextAnalysis
{
    public static class EducationKeyWords
    {
        public static (string intent, List<string> synonims) Gymnasium = ("gymnasium", new List<string>
        {
            "гімназія", "гімназії",
            "львівська", "комплекс",
            "Навчально-виховний",
            "навчально", "виховний",
            "школа-гімназія", "школа"
        });
        public static (string intent, List<string> synonims) KinderGarten = ("kindergarten", new List<string>
        {
            "садок-школа", "нвк",
            "школа-садок",
            "пнвк", "садок"
        });
        public static (string intent, List<string> synonims) TechLyceum = ("techlyceum", new List<string>
        {
            "коледж", "Львівський", "медичний", "ну",
            "ліцей", "училище", "львівське",
            "вище", "професійне", "професійний",
            "дптнз", "державне", "державний", "національного", "університету"
        });
        public static (string intent, List<string> synonims) PreSchool = ("preschool", new List<string>
        {
            "днз", "дошкільний", "навчальний", "заклад", "приватний", "району", "франківського", "шевченківського", "залізничного", "сихівського"
        });
        public static (string intent, List<string> synonims) School = ("school", new List<string>
        {
            "школа", "львівська", "середня",
            "загальноосвітня", "спеціалізована",
            "інтернат", "спеціальна",
            "I", "III", "ступенів", "ступеня",
            "початкова", "приватна", "поглибленим", "вивченням", "англійської", "сзш"
        });

        public static (string intent, List<string> synonims) University = ("university", new List<string>
        {
            "львівська", "львівський",
            "національний", "національна",
            "університет", "університету",
            "академія", "українська",
            "інститут", "державний", "філія",

        });

    }
}
