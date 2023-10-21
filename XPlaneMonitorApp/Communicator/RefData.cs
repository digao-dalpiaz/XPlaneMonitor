namespace XPlaneMonitorApp.Communicator
{
    public class RefData
    {
        public readonly string Name;
        public readonly RefDataAction Proc;

        public float? Value;

        public RefData(string name, RefDataAction proc)
        {
            Name = name;
            Proc = proc;
        }
    }

    public class RefDataList : List<RefData>
    {
        public void Subscribe(string name, RefDataAction proc)
        {
            Add(new RefData(name, proc));
        }
    }

    public delegate void RefDataAction(float value);

}
