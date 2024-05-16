﻿namespace FirstDotNetWebApp.Data;

public class LeaveAllocation
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}