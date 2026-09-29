namespace Contour.Core;

/// <summary>
/// Progress report for a long-running operation.
/// </summary>
public class OperationProgress
{
    /// <summary>
    /// Creates a progress report with the given status message.
    /// </summary>
    public OperationProgress(string statusMessage)
    {
        StatusMessage = statusMessage;
    }

    /// <summary>
    /// Human-readable status message.
    /// </summary>
    public string StatusMessage { get; set; }
}