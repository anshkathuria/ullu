namespace ullu.ActivityIndicator
{
    public interface IHUDProvider
    {
        void DisplayProgress(string message);

        void DisplaySuccess(string message);

        void DisplayError(string message);

        void Dismiss();
    }
}
