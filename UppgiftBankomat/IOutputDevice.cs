namespace UppgiftBankomat
{
    interface IOutputDevice
    {
        void ResetSettings();
        void PrintTitle(string title);
        void PrintNeutral(string info);
        void PrintSuccess(string success);
        void PrintWarning(string warning);
        void PrintPrompt(string prompt);
        void PrintContinueConfirmation();
    }
}