
using System;

/// <summary>
/// Đại diện cho sự kiện do câu lạc bộ tổ chức.
/// </summary>
public class Event
{
    /// <summary>
    /// Mã định danh của sự kiện.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã câu lạc bộ tổ chức sự kiện.
    /// </summary>
    public Guid ClubId { get; private set; }

    /// <summary>
    /// Tên sự kiện.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Ngày giờ tổ chức sự kiện.
    /// </summary>
    public DateTime Date { get; private set; }

    /// <summary>
    /// Sức chứa tối đa của sự kiện.
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// Cho biết sự kiện có tổ chức trực tuyến hay không.
    /// </summary>
    public bool IsOnline { get; private set; }

    private Event(
        Guid id,
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        Id = id;
        ClubId = clubId;
        Title = title;
        Date = date;
        Capacity = capacity;
        IsOnline = isOnline;
    }

    /// <summary>
    /// Tạo sự kiện mới sau khi kiểm tra dữ liệu.
    /// </summary>
    public static Event Create(
        Guid clubId,
        string title,
        DateTime date,
        int capacity,
        bool isOnline)
    {
        if (clubId == Guid.Empty)
            throw new ArgumentException("Mã câu lạc bộ không hợp lệ.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Tên sự kiện không được để trống.");

        if (date == default)
            throw new ArgumentException("Ngày tổ chức không hợp lệ.");

        if (capacity <= 0)
            throw new ArgumentException("Sức chứa phải lớn hơn 0.");

        return new Event(
            Guid.NewGuid(),
            clubId,
            title.Trim(),
            date,
            capacity,
            isOnline);
    }

    /// <summary>
    /// Kiểm tra sự kiện còn đủ chỗ cho số người đăng ký mới hay không.
    /// </summary>
    public bool HasCapacity(int registeredCount)
    {
        if (registeredCount < 0)
            throw new ArgumentOutOfRangeException(
                nameof(registeredCount),
                "Số người đăng ký không được âm.");

        return registeredCount < Capacity;
    }
}

