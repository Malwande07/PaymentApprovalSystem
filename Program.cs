public class PaymentRequest
{
    public int RequestID { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime RequestDate { get; set; }
    public string Status { get; set; } = "Pending";
    public List<RequestHistory> History { get; set; } = new List<RequestHistory>();
}

public class RequestHistory
{
    public string ActionTaken { get; set; }
    public string Approver { get; set; }
    public DateTime Timestamp { get; set; }
}

public interface IApprover
{
    void ApproveRequest(PaymentRequest request);
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ApprovalLimitAttribute : Attribute
{
    public decimal MaxAmount { get; }
    public ApprovalLimitAttribute(decimal maxAmount) => MaxAmount = maxAmount;
}

[ApprovalLimit(1000)]
public class TeamLead : IApprover
{
    public void ApproveRequest(PaymentRequest request)
    {
        // Approval logic for Team Lead
    }
}

[ApprovalLimit(10000)]
public class Manager : IApprover
{
    public void ApproveRequest(PaymentRequest request)
    {
        // Approval logic for Manager
    }
}

[ApprovalLimit(decimal.MaxValue)]
public class Director : IApprover
{
    public void ApproveRequest(PaymentRequest request)
    {
        // Approval logic for Director
    }
}

public class ApprovalWorkflow
{
    public void ProcessRequest(PaymentRequest request, IApprover approver)
    {
        approver.ApproveRequest(request);
        // Update request status and history
    }
}

public class NotificationSystem
{
    public void NotifyEmployee(string message)
    {
        // Notify employee logic
    }

    public void NotifyApprover(string message)
    {
        // Notify approver logic
    }
}

