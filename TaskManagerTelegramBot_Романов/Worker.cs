using TaskManagerTelegramBot_Романов.Classes;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TaskManagerTelegramBot_Романов;

public class Worker : BackgroundService
{
    readonly string Token = "полученный телеграмм токен";
    TelegramBotClient TelegramBotClient;
    List<Users> Users = new List<Users>();
    Timer Timer;
    List<string> Messages = new List<string>()
    {
        "📢 Здравствуйте! 📢" +
            "\nРады приветствовать вас в Telegram-боте «Напоминатор»! ⏰" +
            "\nНаш бот создан для того, чтобы напоминать вам о важных событиях и мероприятиях. С ним вы точно не пропустите ничего важного! 🔔" +
            "\nНе забудьте добавить бота в список своих контактов и настроить уведомления. Тогда вы всегда будете в курсе событий! 🎯",

        "Укажите дату и время напоминания в следующем формате:" +
            "\n<i><b>12:51 26.04.2025</b>" +
            "\nНапомни о том что я хотел сходить в магазин.</i>",

        "Кажется, что-то не получилось." +
            "Укажите дату и время напоминания в следующем формате:" +
            "\n<i><b>12:51 26.04.2025</b>" +
            "\nНапомни о том что я хотел сходить в магазин.</i>",
        "",
        "Задачи пользователя не найдены.",
        "Событие удалено.",
        "Все события удалены."
    };

    public bool CheckFormatDateTime(string value, out DateTime time)
    {
        return DateTime.TryParse(value, out time);
    }

    private static ReplyKeyboardMarkup GetButtons()
    {
        List<KeyboardButton> keyboardButtons = new List<KeyboardButton>();
        keyboardButtons.Add(new KeyboardButton("Удалить все задачи"));

        return new ReplyKeyboardMarkup
        {
            Keyboard = new List<List<KeyboardButton>> {
                keyboardButtons
            }
        };
    }

    public static InlineKeyboardMarkup DeleteEvent(string Message)
    {
        List<InlineKeyboardButton> inlineKeyboards = new List<InlineKeyboardButton>();
        inlineKeyboards.Add(new InlineKeyboardButton("Удалить", Message));
        return new InlineKeyboardMarkup(inlineKeyboards);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}
