namespace XPlaneMonitorApp.Functions
{
    public class Messages
    {
        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool SurroundMsgException(Action proc)
        {
            try
            {
                proc();
            }
            catch (MsgException exMsg)
            {
                Error(exMsg.Message);
                return true;
            }
            return false;
        }
    }

    public class MsgException : Exception
    {
        public MsgException(string message) : base(message)
        {
        }
    }
}
