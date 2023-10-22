namespace XPlaneMonitorApp
{
    public class Messages
    {
        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
