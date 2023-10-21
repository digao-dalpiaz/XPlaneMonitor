namespace XPlaneMonitorApp.Communicator
{
    public delegate void RefSubscriptionAction(RefDataSubscription s);

    public class RefDataContract
    {
        public readonly string Name;
        public readonly RefSubscriptionAction Proc;
        public readonly int ArraySize;

        public RefDataContract(string name, RefSubscriptionAction proc, int arraySize)
        {
            this.Name = name;
            this.Proc = proc;
            this.ArraySize = arraySize; 
        }
    }

    public class RefDataContractList : List<RefDataContract>
    {
        public void Subscribe(string name, RefSubscriptionAction proc, int arraySize = 0)
        {
            Add(new RefDataContract(name, proc, arraySize));
        }

        public List<RefDataSubscription> GetSubscriptions()
        {
            List<RefDataSubscription> lst = new();
            foreach (var r in this)
            {
                if (r.ArraySize > 0)
                {
                    for (int i = 0; i < r.ArraySize; i++)
                    {
                        lst.Add(new RefDataSubscription(r, i));
                    }
                }
                else
                {
                    lst.Add(new RefDataSubscription(r, -1));
                }
            }
            return lst;
        }
    }

    //

    public class RefDataSubscription
    {
        public readonly RefDataContract Contract;
        public readonly int ArrayIndex;
        public float Value;

        public RefDataSubscription(RefDataContract contract, int arrayIndex)
        {
            this.Contract = contract;
            this.ArrayIndex = arrayIndex;
        }

        public string GetName()
        {
            string name = Contract.Name;
            if (Contract.ArraySize > 0)
            {
                name += string.Format("[{0}]", ArrayIndex);
            }
            return name;
        }
    }

}
