
using System;

/// <summary>
/// Trạng thái của phiếu đăng ký tham gia sự kiện.
/// </summary>
public enum RegistrationStatus
{
    Pending,
    Confirmed,
    Cancelled
}

/// <summary>
/// Đại diện cho phiếu đăng ký của thành viên tham dự sự kiện.
/// </summary>
public class Registration
{
    /// <summary>
    /// Mã định danh phiếu đăng ký.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã thành viên đăng ký.
    /// </summary>
    public Guid MemberId { get; private set; }

    /// <summary>
    /// Mã sự kiện được đăng ký.
    /// </summary>
    public Guid EventId { get; private set; }

    /// <summary>
    /// Thời điểm đăng ký.
    /// </summary>
    public DateTime RegisteredAt { get; private set; }

    /// <summary>
    /// Trạng thái hiện tại của phiếu đăng ký.
    /// </summary>
    public RegistrationStatus Status { get; private set; }

    private Registration(
        Guid id,
        Guid memberId,
        Guid eventId,
        DateTime registeredAt,
        RegistrationStatus status)
    {
        Id = id;
        MemberId = memberId;
        EventId = eventId;
        RegisteredAt = registeredAt;
        Status = status;
    }

    /// <summary>
    /// Tạo phiếu đăng ký mới ở trạng thái chờ xác nhận.
    /// </summary>
    public static Registration Create(Guid memberId, Guid eventId)
    {
        if (memberId == Guid.Empty)
            throw new ArgumentException("Mã thành viên không hợp lệ.");

        if (eventId == Guid.Empty)
            throw new ArgumentException("Mã sự kiện không hợp lệ.");

        return new Registration(
            Guid.NewGuid(),
            memberId,
            eventId,
            DateTime.Now,
            RegistrationStatus.Pending);
    }

    /// <summary>
    /// Xác nhận phiếu đăng ký.
    /// </summary>
    public void Confirm()
    {
        if (Status != RegistrationStatus.Pending)
            throw new InvalidOperationException(
                "Chỉ có thể xác nhận phiếu đang chờ.");

        Status = RegistrationStatus.Confirmed;
    }

    /// <summary>
    /// Hủy phiếu đăng ký.
    /// </summary>
    public void Cancel()
    {
        if (Status == RegistrationStatus.Cancelled)
            throw new InvalidOperationException(
                "Phiếu đăng ký đã bị hủy.");

        Status = RegistrationStatus.Cancelled;
    }
}
