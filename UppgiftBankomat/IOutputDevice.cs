﻿namespace UppgiftBankomat
{
    interface IOutputDevice
    {
        void ResetSettings();
        void PrintTitle(string title);
        void PrintInfo(string info);
        void PrintSuccess(string success);
        void PrintWarning(string warning);
        void PrintPrompt(string prompt);
        void PrintContinueConfirmation();
    }
}
