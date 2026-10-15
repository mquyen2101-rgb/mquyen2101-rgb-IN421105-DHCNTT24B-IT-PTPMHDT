
using System;
using System.Collections.Generic;

/// <summary>
/// Đại diện cho câu lạc bộ sinh viên trong hệ thống EduHub.
/// </summary>
public class Club
{
    /// <summary>
    /// Mã định danh của câu lạc bộ.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Tên câu lạc bộ.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Mô tả câu lạc bộ.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Ngày tạo câu lạc bộ.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Danh sách thành viên của câu lạc bộ.
    /// </summary>
    public List<Member> Members { get; private set; }

    private Club(
        Guid id,
        string name,
        string description,
        DateTime createdAt)
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Members = new List<Member>();
    }

    /// <summary>
    /// Tạo câu lạc bộ mới sau khi kiểm tra dữ liệu.
    /// </summary>
    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên câu lạc bộ không được để trống.");

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Mô tả câu lạc bộ không được để trống.");

        return new Club(
            Guid.NewGuid(),
            name.Trim(),
            description.Trim(),
            DateTime.Now);
    }

    /// <summary>
    /// Thêm thành viên vào câu lạc bộ.
    /// </summary>
    public void AddMember(Member member)
    {
        if (member == null)
            throw new ArgumentNullException(nameof(member));

        if (Members.Exists(m => m.Id == member.Id))
            throw new InvalidOperationException(
                "Thành viên đã có trong câu lạc bộ.");

        Members.Add(member);
    }

    /// <summary>
    /// Đếm số thành viên trong câu lạc bộ.
    /// </summary>
    public int MemberCount()
    {
        return Members.Count;
    }
}
