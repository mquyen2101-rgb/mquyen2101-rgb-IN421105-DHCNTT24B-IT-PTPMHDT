
using System;

/// <summary>
/// Hình thức điểm danh của thành viên.
/// </summary>
public enum CheckInMethod
{
    QRCode,
    Manual
}

/// <summary>
/// Lưu thông tin điểm danh của một phiếu đăng ký.
/// </summary>
public class CheckIn
{
    /// <summary>
    /// Mã định danh bản ghi điểm danh.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Mã phiếu đăng ký được điểm danh.
    /// </summary>
    public Guid RegistrationId { get; private set; }

    /// <summary>
    /// Thời điểm thực hiện điểm danh.
    /// </summary>
    public DateTime CheckedInAt { get; private set; }

    /// <summary>
    /// Hình thức thực hiện điểm danh.
    /// </summary>
    public CheckInMethod Method { get; private set; }

    private CheckIn(
        Guid id,
        Guid registrationId,
        DateTime checkedInAt,
        CheckInMethod method)
    {
        Id = id;
        RegistrationId = registrationId;
        CheckedInAt = checkedInAt;
        Method = method;
    }

    /// <summary>
    /// Tạo bản ghi điểm danh mới.
    /// </summary>
    public static CheckIn Create(
        Guid registrationId,
        CheckInMethod method)
    {
        if (registrationId == Guid.Empty)
            throw new ArgumentException(
                "Mã phiếu đăng ký không hợp lệ.");

        if (!Enum.IsDefined(typeof(CheckInMethod), method))
            throw new ArgumentException(
                "Hình thức điểm danh không hợp lệ.");

        return new CheckIn(
            Guid.NewGuid(),
            registrationId,
            DateTime.Now,
            method);
    }

    /// <summary>
    /// Trả về chuỗi mô tả thông tin điểm danh.
    /// </summary>
    public string Summary()
    {
        return $"Check-in ID: {Id} | " +
               $"Registration ID: {RegistrationId} | " +
               $"Time: {CheckedInAt:dd/MM/yyyy HH:mm:ss} | " +
               $"Method: {Method}";
    }
}
