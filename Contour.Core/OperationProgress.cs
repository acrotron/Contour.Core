namespace Contour.Core;

public class OperationProgress
{
    public OperationProgress(string statusMessage)
    {
        StatusMessage = statusMessage;
    }

    public string StatusMessage { get; set; }
}