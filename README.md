# DailyJournal
This program is a digital journal that allows users to record daily journal entries. It is written in C# with .NET using WinUI.

On the home page, there is a text box that allows for the input of the daily journal entry. To finish the entry, click save.
To view previous entries, click Read Journal. Only one entry per day is allowed, so if an entry already exists for the day,
the user will be given a prompt asking if they want to append their new entry to the end of the previous one or to replace the previous one. 

The journal page can be accessed by the Read Journal button on the homepage. This page shows all of the journal entries that have been entered by the user.
To access an entry from a specific day, use the date selector on the top right. To see all entries again, click Clear Filter. To go back to the homepage, click Back.

The journal will be stored in a file called data.xml in the user's AppData folder.
