namespace Hotel_Astitou_Backend.Notify
{
    public class Notification
    {
        // le type de la notification
        public NotificationType Type { get; set; }
        // en millisecondes, durée pendant laquelle la notification est affichée
        public int Duration { get; set; }
        // le texte de la notification
        public string Text { get; set; }
    }

    public enum NotificationType
    {
        Alert = 0,
        Notice = 1,
        Greeting = 2,
        HotNews = 3
    }
}