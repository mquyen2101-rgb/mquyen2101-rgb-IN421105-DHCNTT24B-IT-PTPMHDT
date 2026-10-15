using System;

/// <summary>
/// Đại diện cho thành viên sinh viên trong hệ thống EduHub.
/// </summary>
public class Member
{
    /// <summary>
    /// Mã định danh của thành viên.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Họ tên thành viên.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Email của thành viên.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Mã số sinh viên.
    /// </summary>
    public string StudentCode { get; private set; }

    /// <summary>
    /// Ngày tham gia hệ thống.
    /// </summary>
    public DateTime JoinedAt { get; private set; }

    private Member(
        Guid id,
        string name,
        string email,
        string studentCode,
        DateTime joinedAt)
    {
        Id = id;
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = joinedAt;
    }

    /// <summary>
    /// Tạo thành viên mới sau khi kiểm tra dữ liệu.
    /// </summary>
    public static Member Create(
        string name,
        string email,
        string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên không được để trống.");

        if (string.IsNullOrWhiteSpace(email) ||
            !email.Contains('@'))
            throw new ArgumentException("Email không hợp lệ.");

        if (string.IsNullOrWhiteSpace(studentCode))
            throw new ArgumentException("Mã sinh viên không được để trống.");

        return new Member(
            Guid.NewGuid(),
            name.Trim(),
            email.Trim(),
            studentCode.Trim(),
            DateTime.Now);
    }

    /// <summary>
    /// Kiểm tra thành viên có thông tin hợp lệ để hoạt động hay không.
    /// </summary>
    public bool IsActive()
    {
        return !string.IsNullOrWhiteSpace(Name)
            && !string.IsNullOrWhiteSpace(Email);
    }
}