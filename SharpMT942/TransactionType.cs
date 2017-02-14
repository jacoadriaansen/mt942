namespace SharpMT942
{
    public class TransactionType 
    {    
        public string Code { get; }
        public string Name { get; }

        public TransactionType(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}