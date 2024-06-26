

using System;

namespace Core.Models
{
    public class CallInQueues
    {
        public string SupporCallID { get; set; }
        public int Number { get; set; }

        public string Types { get; set; }

        public string Summary { get; set; }

        public string Queue { get; set; }

        public string Status { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DateAssignTo { get; set; }

        public string Priority { get; set; }    


        public CallInQueues()
        {
        }

        public override string ToString()
        {
            return $"SupportCallID: {SupporCallID}, Number: {Number}, Types: {Types}, Summary: {Summary}, Queue: {Queue}, " +
                   $"Status: {Status}, OpenDate: {OpenDate}, DueDate: {DueDate}, StartDate: {StartDate}, DateAssignTo: {DateAssignTo}" +
                   $", Priority : {Priority}  ";
        }


        public class CallInQueuesBuilder
        {
            private CallInQueues supportCall;

            public CallInQueuesBuilder()
            {
                supportCall = new CallInQueues();
            }

            public CallInQueuesBuilder WithSupportCallID(string supportCallID)
            {
                supportCall.SupporCallID = supportCallID;
                return this;
            }

            public CallInQueuesBuilder WithNumber(int number)
            {
                supportCall.Number = number;
                return this;
            }

            public CallInQueuesBuilder WithTypes(string types)
            {
                supportCall.Types = types;
                return this;
            }

            public CallInQueuesBuilder WithSummary(string summary)
            {
                supportCall.Summary = summary;
                return this;
            }

            public CallInQueuesBuilder WithQueue(string queue)
            {
                supportCall.Queue = queue;
                return this;
            }

            public CallInQueuesBuilder WithStatus(string status)
            {
                supportCall.Status = status;
                return this;
            }

            public CallInQueuesBuilder WithOpenDate(DateTime openDate)
            {
                supportCall.OpenDate = openDate;
                return this;
            }

            public CallInQueuesBuilder WithDueDate(DateTime dueDate)
            {
                supportCall.DueDate = dueDate;
                return this;
            }

            public CallInQueuesBuilder WithStartDate(DateTime startDate)
            {
                supportCall.StartDate = startDate;
                return this;
            }

            public CallInQueuesBuilder WithDateAssignTo(DateTime dateAssignTo)
            {
                supportCall.DateAssignTo = dateAssignTo;
                return this;
            }
            public CallInQueuesBuilder WithPriority(string priority)
            {
                supportCall.Priority = priority;
                return this;
            }



            public CallInQueues Build()
            {
                return supportCall;
            }

        }
    }
}
