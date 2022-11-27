﻿namespace SS.Shared.Extensions;

public static class DateTimeExtensions
{
    public static string ToFriendlyDateTimeString(this DateTime Date)
    {
        return FriendlyDate(Date) + " @ " + Date.ToString("t").ToLower();
    }

    public static string ToFriendlyShortDateString(this DateTime Date)
    {
        return $"{Date.ToString("MMM dd")}, {Date.Year}";
    }

    public static string ToFriendlyDateString(this DateTime Date)
    {
        return FriendlyDate(Date);
    }

    private static string FriendlyDate(DateTime date)
    {
        var FormattedDate = "";
        if (date.Date == DateTime.Today)
            FormattedDate = "Today";
        else if (date.Date == DateTime.Today.AddDays(-1))
            FormattedDate = "Yesterday";
        else if (date.Date > DateTime.Today.AddDays(-6))
            // *** Show the Day of the week
            FormattedDate = date.ToString("dddd");
        else
            FormattedDate = date.ToString("MMMM dd, yyyy");

        return FormattedDate;
    }
}