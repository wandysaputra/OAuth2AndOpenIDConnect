namespace WestSouth.IDP.Entities;

public interface IConcurrencyAware
{
    string ConcurrencyStamp { get; set; }
}