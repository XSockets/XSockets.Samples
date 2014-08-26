namespace XSockets.IoT.Controllers.Model
{
    /// <summary>
    /// For setting state from the client so we can target messages easily
    /// </summary>
    public enum ClientType
    {        
        Browser,
        Netduino,
        Arduino,
        Native
    }
}
