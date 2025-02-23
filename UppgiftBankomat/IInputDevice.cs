namespace UppgiftBankomat
{
    interface IInputDevice
    {
        string GetStringInput();
        int GetIntInput();
        decimal GetDecimalInput();
    }
}
