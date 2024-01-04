namespace TimeApp.Classes;


    public class GreetingsService(TimeProvider timeProvider)
    {
        public string TimeOfDay() =>
            timeProvider.GetLocalNow().Hour switch
            {
                <= 6 => "Night",
                > 6 and <= 12 => "Morning",
                > 12 and <= 18 => "Afternoon",
                > 18 and <= 24 => "Evening",
                _ => "Invalid hour"
            };
    }



