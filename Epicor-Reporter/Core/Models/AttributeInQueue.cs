


namespace Core.Models
{
    public class AttributeInQueue
    {
        public string Attribute { get; set; }

        public string Value{ get; set; }

        public AttributeInQueue()
        {
            
        }

        public override string ToString()
        {
            return $"Attibute: {Attribute}, Number: {Value}";
        }

        public class AttributeInQueueBuilder
        {
            AttributeInQueue attributeInQueue;

            public AttributeInQueueBuilder()
            {
                attributeInQueue = new AttributeInQueue();
            }

            public AttributeInQueueBuilder WithAttribute(string attribute)
            {
                attributeInQueue.Attribute = attribute;
                return this;
            }

            public AttributeInQueueBuilder WithValue(string value) 
             { 
                attributeInQueue.Value = value; 
                return this; 
            }

            public AttributeInQueue Build() 
            { 
               return attributeInQueue;
            }
        }


    }
}
