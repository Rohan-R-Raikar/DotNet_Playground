using System;

class Program
{
    static void Main()
    {
        /*
         * Sample employee data with different joining scenarios:
         * - Recent joiners
         * - Employees with months/years of experience
         * - Past, present, and future joining dates
         */
        var examples = new (string Name, DateTime JoiningDate)[]
        {
            // Tentative timeline examples
            ("Joined Today", DateTime.Today),
            ("Joined Yesterday", DateTime.Today.AddDays(-1)),
            ("Joined 1 Month Ago", DateTime.Today.AddMonths(-1)),
            ("Joined 11 Months Ago", DateTime.Today.AddMonths(-11)),
            ("Joined 12 Months Ago", DateTime.Today.AddMonths(-12)),
            ("Joined 13 Months Ago", DateTime.Today.AddMonths(-13)),
            ("Joined 23 Months Ago", DateTime.Today.AddMonths(-23)),
            ("Joined 24 Months Ago", DateTime.Today.AddMonths(-24)),
            ("Joined 25 Months Ago", DateTime.Today.AddMonths(-25)),

            // Fixed date examples
            ("Start of 2025", new DateTime(2025, 1, 1)),
            ("End of 2025", new DateTime(2025, 12, 31)),
            ("Mid of 2015", new DateTime(2015, 6, 15)),

            // Future joining date scenario
            ("Future Joiner", DateTime.Today.AddMonths(6)),

            // Realistic employee examples
            ("EMP 1", new DateTime(2020, 1, 6)),
            ("EMP 2", new DateTime(2023, 1, 5)),
            ("EMP 3", new DateTime(2024, 12, 30))
        };

        // Current system date (can be hardcoded for testing)
        DateTime today = DateTime.Today;
        // DateTime today = new DateTime(2025, 12, 31);

        Console.WriteLine($"Today: {today:dd/MM/yyyy}\n");

        // Loop through each employee and calculate experience
        foreach (var person in examples)
        {
            Console.WriteLine($"Employee: {person.Name}");
            Console.WriteLine($"Joining Date: {person.JoiningDate:dd/MM/yyyy}");

            // Calculate total completed months since joining
            int completedMonths = CalculateCompletedMonths(person.JoiningDate, today);

            // Calculate which year of experience is being completed
            int yearCompleting = CalculateYearCompleting(
                person.JoiningDate,
                today,
                completedMonths
            );

            Console.WriteLine($"Completed Months: {completedMonths}");
            Console.WriteLine($"Year Completing YOE: {yearCompleting}");
            Console.WriteLine(new string('-', 45));
        }
    }

    /// <summary>
    /// Calculates the number of fully completed months between
    /// the joining date and today's date.
    /// </summary>
    /// <param name="joiningDate">Employee joining date</param>
    /// <param name="today">Current date</param>
    /// <returns>Completed months of experience</returns>
    static int CalculateCompletedMonths(DateTime joiningDate, DateTime today)
    {
        // If joining date is in the future, no experience
        if (joiningDate.Date > today.Date)
            return 0;

        // If joined today, no completed months
        if (joiningDate.Date == today.Date)
            return 0;

        // Calculate raw month difference using year and month values
        int months = (today.Year - joiningDate.Year) * 12
                   + (today.Month - joiningDate.Month);

        // If current day is before joining day, last month is not completed
        if (today.Day < joiningDate.Day)
            months--;

        // Ensure result is never negative
        return Math.Max(0, months);
    }

    /// <summary>
    /// Determines which year of experience (YOE) the employee is completing.
    /// Example:
    /// - 0–11 months  → Completing Year 1
    /// - 12–23 months → Completing Year 2
    /// </summary>
    /// <param name="joiningDate">Employee joining date</param>
    /// <param name="today">Current date</param>
    /// <param name="completedMonths">Already completed months</param>
    /// <returns>Year of experience being completed</returns>
    static int CalculateYearCompleting(
        DateTime joiningDate,
        DateTime today,
        int completedMonths)
    {
        // Future joiners have no experience
        if (joiningDate.Date > today.Date)
            return 0;

        // Joined today → no experience year yet
        if (joiningDate.Date == today.Date)
            return 0;

        /*
         * If today is the exact anniversary date,
         * subtract 1 because the next year just starts today.
         */
        if (joiningDate.Month == today.Month &&
            joiningDate.Day == today.Day)
        {
            int yearComplete =
                (int)Math.Ceiling((completedMonths + 1) / 12.0);

            return yearComplete - 1;
        }

        // General calculation for year being completed
        int yearCompleting =
            (int)Math.Ceiling((completedMonths + 1) / 12.0);

        return yearCompleting;
    }
}
